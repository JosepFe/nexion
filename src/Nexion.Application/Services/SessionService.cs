namespace Nexion.Application.Services;

using System.Net;
using Devon4Net.Application.Dtos;
using Devon4Net.Application.Ports.Repositories;
using Devon4Net.Domain.Entities;
using Devon4Net.Infrastructure.Common.Errors;
using Devon4Net.Infrastructure.Common.Models;
using MongoDB.Bson;
using Nexion.Application.Dtos;
using Nexion.Application.Extensions;
using Nexion.Application.Services.Interfaces;
using Nexion.Domain.Entities;

public class SessionService : ISessionService
{
    private readonly ISessionRepository _sessionRepository;
    private readonly ISurveyRepository _surveyRepository;

    public SessionService(ISessionRepository sessionRepository, ISurveyRepository surveyRepository)
    {
        _sessionRepository = sessionRepository;
        _surveyRepository = surveyRepository;
    }

    public async Task<DevonResult<SessionDto>> AddSessionAsync(SessionDto? sessionDto)
    {
        // Validate if sessionDto is null
        if (sessionDto == null)
        {
            return DevonResult<SessionDto>.Error(new DevonError("3004", "Session data is null", HttpStatusCode.BadRequest));
        }

        // Validate TrainerId
        if (!ObjectId.TryParse(sessionDto.TrainerId, out var trainerObjectId))
        {
            return DevonResult<SessionDto>.Error(new DevonError("3001", "Invalid Trainer ID", HttpStatusCode.BadRequest));
        }

        // Create surveys and gather their IDs
        var surveyIds = await CreateSurveysAsync(sessionDto.Surveys!);
        if (surveyIds.Count == 0)
        {
            return DevonResult<SessionDto>.Error(new DevonError("3002", "Failed to create surveys", HttpStatusCode.InternalServerError));
        }

        // Create session entity from DTO
        var session = new Session
        {
            SessionType = sessionDto.SessionType,
            TrainerId = trainerObjectId,
            Athletes = ParseObjectIds(sessionDto.Athletes),
            Exercises = ParseSessionExercises(sessionDto.SessionExercises)!,
            Surveys = surveyIds,
        };

        // Save session entity
        var sessionEntity = await _sessionRepository.Create(session);

        // Return success result
        return DevonResult<SessionDto>.Success(sessionEntity.ToSessionDto(sessionDto.Surveys));
    }

    public async Task<DevonResult<bool>> DeleteSessionAsync(string sessionId)
    {
        // Validate the session ID
        if (!ObjectId.TryParse(sessionId, out var sessionObjectId))
        {
            var error = new DevonError("3001", "Invalid Data", HttpStatusCode.BadRequest);
            return DevonResult<bool>.Error(error);
        }

        // Retrieve the session by ID
        var session = await GetSessionByIdAsync(sessionId);

        // If session retrieval encountered any errors, return them
        if (session.Errors.Any())
        {
            return DevonResult<bool>.Error(session.Errors);
        }

        // Attempt to delete the session
        var deletedSession = await _sessionRepository.DeleteSessionByIdAsync(sessionObjectId);

        // If the deletion fails, return an error
        if (!deletedSession)
        {
            var error = new DevonError("3003", "Session not deleted", HttpStatusCode.NotFound);
            return DevonResult<bool>.Error(error);
        }

        // Return success if the session was deleted
        return DevonResult<bool>.Success(true);
    }

    public async Task<DevonResult<IEnumerable<SessionDto>>> GetAllSessionsAsync()
    {
        // Retrieve all sessions from the repository
        var sessions = await _sessionRepository.Get();

        // Check if any sessions were retrieved
        if (sessions == null || !sessions.Any())
        {
            var error = new DevonError("3003", "No sessions found", HttpStatusCode.NotFound);
            return DevonResult<IEnumerable<SessionDto>>.Error(error);
        }

        // Convert the sessions to DTOs, including retrieving surveys asynchronously
        var sessionDtos = await Task.WhenAll(sessions.Select(async session =>
        {
            var surveyDtos = await GetSurveyDtos(session.Surveys!);
            return session.ToSessionDto(surveyDtos);
        }));

        // Return the result
        return DevonResult<IEnumerable<SessionDto>>.Success(sessionDtos);
    }

    public async Task<DevonResult<SessionDto>> GetSessionByIdAsync(string sessionId)
    {
        // Validate the session ID
        if (!ObjectId.TryParse(sessionId, out var sessionObjectId))
        {
            var error = new DevonError("3001", "Invalid Data", HttpStatusCode.BadRequest);
            return DevonResult<SessionDto>.Error(error);
        }

        // Retrieve the session by ID
        var session = await _sessionRepository.GetSessionByIdAsync(sessionObjectId);

        // Check if the session exists
        if (session == null)
        {
            var error = new DevonError("3002", "Session not found", HttpStatusCode.NotFound);
            return DevonResult<SessionDto>.Error(error);
        }

        var surveyDtos = await GetSurveyDtos(session.Surveys);

        // Convert the session to DTO and return success result
        return DevonResult<SessionDto>.Success(session.ToSessionDto(surveyDtos));
    }

    public async Task<DevonResult<SessionDto>> UpdateSessionAsync(string sessionId, SessionDto sessionDto)
    {
        // Validate the session ID
        if (!ObjectId.TryParse(sessionId, out var sessionObjectId))
        {
            var error = new DevonError("3001", "Invalid Data", HttpStatusCode.BadRequest);
            return DevonResult<SessionDto>.Error(error);
        }

        // Retrieve the existing session
        var existingSession = await _sessionRepository.GetSessionByIdAsync(sessionObjectId);

        // Check if the session exists
        if (existingSession == null)
        {
            var error = new DevonError("3002", "Session not found", HttpStatusCode.NotFound);
            return DevonResult<SessionDto>.Error(error);
        }

        // Update the fields of the session
        existingSession.SessionType = sessionDto.SessionType;
        existingSession.TrainerId = ObjectId.Parse(sessionDto.TrainerId);
        existingSession.Athletes = sessionDto.Athletes.Select(id => ObjectId.Parse(id)).ToList();
        existingSession.Exercises = sessionDto.SessionExercises.Select(x =>
            new SessionExercise(ObjectId.Parse(x.ExerciseId), x.Repetitions, x.Sets)).ToList();

        // Save the updated session to the repository
        await _sessionRepository.Update(existingSession);

        // Return the updated session as a DTO
        return DevonResult<SessionDto>.Success(existingSession.ToSessionDto(sessionDto.Surveys));
    }

    private async Task<List<SurveyDto>> GetSurveyDtos(List<ObjectId> surveyIds)
    {
        var surveyDtos = new List<SurveyDto>();

        foreach (var surveyId in surveyIds)
        {
            var result = await _surveyRepository.GetSurveyByIdAsync(surveyId);
            surveyDtos.Add(result.ToSurveyDto());
        }

        return surveyDtos;
    }

    // Helper method to create surveys and return their ObjectIds
    private async Task<List<ObjectId>> CreateSurveysAsync(IEnumerable<SurveyDto> surveysDto)
    {
        var surveyIds = new List<ObjectId>();

        foreach (var surveyDto in surveysDto)
        {
            var survey = new Survey(
                name: surveyDto.Name,
                description: surveyDto.Description,
                type: surveyDto.Type)
            {
                Questions = surveyDto.Questions.Select(q => new SurveyQuestion(q.Name, q.Type)).ToList(),
            };

            var result = await _surveyRepository.Create(survey);
            if (result != null)
                surveyIds.Add(result.Id);
            else
                return null; // Return null if survey creation failed
        }

        return surveyIds;
    }

    // Helper method to parse athletes' ObjectIds
    private List<ObjectId> ParseObjectIds(IEnumerable<string> athleteIds)
    {
        return athleteIds
            .Select(id => ObjectId.TryParse(id, out var objectId) ? objectId : ObjectId.Empty)
            .Where(objectId => objectId != ObjectId.Empty) // Filter out invalid ObjectIds
            .ToList();
    }

    // Helper method to parse session exercises
    private List<SessionExercise> ParseSessionExercises(IEnumerable<SessionExerciseDto> sessionExercisesDto)
    {
        return sessionExercisesDto
            .Select(x => ObjectId.TryParse(x.ExerciseId, out var exerciseObjectId)
                ? new SessionExercise(exerciseObjectId, x.Repetitions, x.Sets)
                : null)
            .Where(exercise => exercise != null) // Filter out null exercises
            .ToList()!;
    }
}
