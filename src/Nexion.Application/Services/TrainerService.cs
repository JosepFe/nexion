using Nexion.Application.Dtos;
using Nexion.Application.Ports.Repositories;
using Nexion.Domain.Entities;

namespace Nexion.Application.Services;

using Devon4Net.Application.Dtos;
using Devon4Net.Domain.Entities;
using Devon4Net.Infrastructure.Common.Errors;
using Devon4Net.Infrastructure.Common.Models;
using MongoDB.Bson;
using Nexion.Application.Extensions;
using Nexion.Application.Services.Interfaces;

public class TrainerService : ITrainerService
{
    private readonly ITrainerRepository _trainerRepository;

    public TrainerService(ITrainerRepository trainerRepository)
    {
        _trainerRepository = trainerRepository;
    }

    public async Task<DevonResult<TrainerDto>> AddTrainerAsync(TrainerDto trainerDto)
    {
        if (trainerDto == null)
        {
            var error = new DevonError("2004", "Trainer data is null", System.Net.HttpStatusCode.BadRequest);
            return DevonResult<TrainerDto>.Error(error);
        }

        var trainer = new Trainer
        {
            Name = trainerDto.Name,
            Specialties = trainerDto.Specialties,
            Experience = trainerDto.Experience,
        };

        var trainerEntity = await _trainerRepository.Create(trainer);

        return DevonResult<TrainerDto>.Success(trainerEntity.ToTrainerDto());
    }

    public async Task<DevonResult<bool>> DeleteTrainerAsync(string trainerId)
    {
        var tryParseObjectIdResult = ObjectId.TryParse(trainerId, out var trainerObjectId);

        if (!tryParseObjectIdResult)
        {
            var error = new DevonError("2001", "Invalid Data", System.Net.HttpStatusCode.BadRequest);
            return DevonResult<bool>.Error(error);
        }

        var trainer = await GetTrainerByIdAsync(trainerId);

        if (trainer.Errors.Any())
        {
            return DevonResult<bool>.Error(trainer.Errors);
        }

        var deletedTrainer = await _trainerRepository.DeleteTrainerByIdAsync(trainerObjectId);

        if (!deletedTrainer)
        {
            var error = new DevonError("2003", "Trainer not deleted", System.Net.HttpStatusCode.NotFound);
            return DevonResult<bool>.Error(error);
        }

        return DevonResult<bool>.Success(true);
    }

    public async Task<DevonResult<IEnumerable<TrainerDto>>> GetAllTrainersAsync()
    {
        var trainers = await _trainerRepository.Get();

        if (trainers == null || !trainers.Any())
        {
            var error = new DevonError("2003", "No trainers found", System.Net.HttpStatusCode.NotFound);
            return DevonResult<IEnumerable<TrainerDto>>.Error(error);
        }

        return DevonResult<IEnumerable<TrainerDto>>.Success(trainers.Select(trainer => trainer.ToTrainerDto()).ToList());
    }

    public async Task<DevonResult<TrainerDto>> GetTrainerByIdAsync(string trainerId)
    {
        var tryParseObjectIdResult = ObjectId.TryParse(trainerId, out var trainerObjectId);

        if (!tryParseObjectIdResult)
        {
            var error = new DevonError("2001", "Invalid Data", System.Net.HttpStatusCode.BadRequest);
            return DevonResult<TrainerDto>.Error(error);
        }

        var trainer = await _trainerRepository.GetTrainerByIdAsync(trainerObjectId);

        if (trainer == null)
        {
            var error = new DevonError("2002", "Trainer not found", System.Net.HttpStatusCode.NotFound);
            return DevonResult<TrainerDto>.Error(error);
        }

        return DevonResult<TrainerDto>.Success(trainer.ToTrainerDto());
    }

    public async Task<DevonResult<TrainerDto>> UpdateTrainerAsync(string trainerId, TrainerDto trainerDto)
    {
        var tryParseObjectIdResult = ObjectId.TryParse(trainerId, out var trainerObjectId);

        if (!tryParseObjectIdResult)
        {
            var error = new DevonError("2001", "Invalid Data", System.Net.HttpStatusCode.BadRequest);
            return DevonResult<TrainerDto>.Error(error);
        }

        var existingTrainer = await _trainerRepository.GetTrainerByIdAsync(trainerObjectId);

        if (existingTrainer == null)
        {
            var error = new DevonError("2002", "Trainer not found", System.Net.HttpStatusCode.NotFound);
            return DevonResult<TrainerDto>.Error(error);
        }

        // Update fields
        existingTrainer.Name = trainerDto.Name;
        //existingTrainer.CenterId = trainerDto.CenterId;
        existingTrainer.Specialties = trainerDto.Specialties;
        existingTrainer.Experience = trainerDto.Experience;

        await _trainerRepository.Update(existingTrainer);

        return DevonResult<TrainerDto>.Success(existingTrainer.ToTrainerDto());
    }
}
