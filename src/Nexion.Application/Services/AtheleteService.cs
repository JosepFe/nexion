namespace Nexion.Application.Services;

using Devon4Net.Infrastructure.Common.Errors;
using Devon4Net.Infrastructure.Common.Models;
using MongoDB.Bson;
using Nexion.Application.Dtos;
using Nexion.Application.Extensions;
using Nexion.Application.Ports.Repositories;
using Nexion.Application.Services.Interfaces;
using Nexion.Domain.Entities;

public class AthleteService : IAthleteService
{
    private readonly IAthleteRepository _athleteRepository;

    public AthleteService(IAthleteRepository athleteRepository)
    {
        _athleteRepository = athleteRepository;
    }

    public async Task<DevonResult<AthleteDto>> AddAthleteAsync(AthleteDto athleteDto)
    {
        if (athleteDto == null)
        {
            var error = new DevonError("2004", "Athlete data is null", System.Net.HttpStatusCode.BadRequest);
            return DevonResult<AthleteDto>.Error(error);
        }

        var athlete = new Athlete
        {
            Name = athleteDto.Name,
            Age = athleteDto.Age,
            Sports = athleteDto.Sports
        };

        var athleteEntity = await _athleteRepository.Create(athlete);

        return DevonResult<AthleteDto>.Success(athleteEntity.ToAthleteDto());
    }

    public async Task<DevonResult<bool>> DeleteAthleteAsync(string athleteId)
    {
        var tryParseObjectIdResult = ObjectId.TryParse(athleteId, out var athleteObjectId);

        if (!tryParseObjectIdResult)
        {
            var error = new DevonError("2001", "Invalid Data", System.Net.HttpStatusCode.BadRequest);
            return DevonResult<bool>.Error(error);
        }

        var athlete = await GetAthleteByIdAsync(athleteId);

        if (athlete.Errors.Any())
        {
            return DevonResult<bool>.Error(athlete.Errors);
        }

        var deletedAthlete = await _athleteRepository.DeleteAthleteByIdAsync(athleteObjectId);

        if (!deletedAthlete)
        {
            var error = new DevonError("2003", "Athlete not deleted", System.Net.HttpStatusCode.NotFound);
            return DevonResult<bool>.Error(error);
        }

        return DevonResult<bool>.Success(true);
    }

    public async Task<DevonResult<IEnumerable<AthleteDto>>> GetAllAthletesAsync()
    {
        var athletes = await _athleteRepository.Get();

        if (athletes == null || !athletes.Any())
        {
            var error = new DevonError("2003", "No athletes found", System.Net.HttpStatusCode.NotFound);
            return DevonResult<IEnumerable<AthleteDto>>.Error(error);
        }

        return DevonResult<IEnumerable<AthleteDto>>.Success(athletes.Select(athlete => athlete.ToAthleteDto()).ToList());
    }

    public async Task<DevonResult<AthleteDto>> GetAthleteByIdAsync(string athleteId)
    {
        var tryParseObjectIdResult = ObjectId.TryParse(athleteId, out var athleteObjectId);

        if (!tryParseObjectIdResult)
        {
            var error = new DevonError("2001", "Invalid Data", System.Net.HttpStatusCode.BadRequest);
            return DevonResult<AthleteDto>.Error(error);
        }

        var athlete = await _athleteRepository.GetAthleteByIdAsync(athleteObjectId);

        if (athlete == null)
        {
            var error = new DevonError("2002", "Athlete not found", System.Net.HttpStatusCode.NotFound);
            return DevonResult<AthleteDto>.Error(error);
        }

        return DevonResult<AthleteDto>.Success(athlete.ToAthleteDto());
    }

    public async Task<DevonResult<AthleteDto>> UpdateAthleteAsync(string athleteId, AthleteDto athleteDto)
    {
        var tryParseObjectIdResult = ObjectId.TryParse(athleteId, out var athleteObjectId);

        if (!tryParseObjectIdResult)
        {
            var error = new DevonError("2001", "Invalid Data", System.Net.HttpStatusCode.BadRequest);
            return DevonResult<AthleteDto>.Error(error);
        }

        var existingAthlete = await _athleteRepository.GetAthleteByIdAsync(athleteObjectId);

        if (existingAthlete == null)
        {
            var error = new DevonError("2002", "Athlete not found", System.Net.HttpStatusCode.NotFound);
            return DevonResult<AthleteDto>.Error(error);
        }

        // Actualizar los campos
        existingAthlete.Name = athleteDto.Name;
        existingAthlete.Age = athleteDto.Age;
        existingAthlete.Sports = athleteDto.Sports;

        await _athleteRepository.Update(existingAthlete);

        return DevonResult<AthleteDto>.Success(existingAthlete.ToAthleteDto());
    }
}
