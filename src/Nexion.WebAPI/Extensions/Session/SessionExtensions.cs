namespace Nexion.WebAPI.Extensions.Session;

using Nexion.Application.Dtos;
using Nexion.WebAPI.ApiContracts.Session;

public static class SessionExtensions
{
    public static SessionDto ToSessionDto(this CreateSessionRequest request)
    {
        return new SessionDto
        {
            TrainerId = request.TrainerId,
            SessionType = request.SessionType,
            Athletes = request.Athletes,
            SessionExercises = request.SessionExercises,
            Surveys = request.Surveys,
        };
    }

    public static SessionDto ToSessionDto(this UpdateSessionRequest request)
    {
        return new SessionDto
        {
            TrainerId = request.TrainerId,
            SessionType = request.SessionType,
            Athletes = request.Athletes,
            SessionExercises = request.SessionExercises,
            Surveys = request.Surveys,
        };
    }
}
