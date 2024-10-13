namespace Nexion.Application.Services;

using Devon4Net.Application.Dtos;
using Devon4Net.Application.Ports.Repositories;
using Devon4Net.Domain.Entities;
using Devon4Net.Infrastructure.Common.Errors;
using Devon4Net.Infrastructure.Common.Models;
using MongoDB.Bson;
using Nexion.Application.Extensions;
using Nexion.Application.Services.Interfaces;
using Nexion.Domain.Entities;

public class CenterService : ICenterService
{
    private readonly ICenterRepository _centerRepository;

    public CenterService(ICenterRepository centerRepository)
    {
        _centerRepository = centerRepository;
    }

    public async Task<DevonResult<CenterDto>> AddCenterAsync(CenterDto centerDto)
    {
        if (centerDto == null)
        {
            var error = new DevonError("1004", "Center data is null", System.Net.HttpStatusCode.BadRequest);
            return DevonResult<CenterDto>.Error(error);
        }

        var location = new Location(centerDto.Location.Address, centerDto.Location.City, centerDto.Location.State, centerDto.Location.ZipCode, centerDto.Location.Country);

        var center = new Center(centerDto.Name);
        center.Location = location;

        var centerEntity = await _centerRepository.Create(center);

        return DevonResult<CenterDto>.Success(centerEntity.ToCenterDto());
    }

    public async Task<DevonResult<bool>> DeleteCenterAsync(string centerId)
    {
        var tryParseObjectIdResult = ObjectId.TryParse(centerId, out var centerObjectId);

        if (!tryParseObjectIdResult)
        {
            var error = new DevonError("1001", "Invalid Data", System.Net.HttpStatusCode.BadRequest);
            return DevonResult<bool>.Error(error);
        }

        var center = await GetCenterByIdAsync(centerId);

        if (center.Errors.Count() > 0)
        {
            return DevonResult<bool>.Error(center.Errors);
        }

        var deletedCenter = await _centerRepository.DeleteCenterByIdAsync(centerObjectId);

        if (!deletedCenter)
        {
            var error = new DevonError("1003", "Center not deleted", System.Net.HttpStatusCode.NotFound);
            return DevonResult<bool>.Error(error);
        }

        return deletedCenter;
    }

    public async Task<DevonResult<IEnumerable<CenterDto>>> GetAllCentersAsync()
    {
        var centers = await _centerRepository.Get();

        if (centers == null || !centers.Any())
        {
            var error = new DevonError("1003", "No centers found", System.Net.HttpStatusCode.NotFound);
            return DevonResult<IEnumerable<CenterDto>>.Error(error);
        }

        return centers.Select(center => center.ToCenterDto()).ToList();
    }

    public async Task<DevonResult<CenterDto>> GetCenterByIdAsync(string centerId)
    {
        var tryParseObjectIdResult = ObjectId.TryParse(centerId, out var centerObjectId);

        if (!tryParseObjectIdResult)
        {
            var error = new DevonError("1001", "Invalid Data", System.Net.HttpStatusCode.BadRequest);
            return DevonResult<CenterDto>.Error(error);
        }

        var center = await _centerRepository.GetCenterByIdAsync(centerObjectId);

        if (center == null) 
        {
            var error = new DevonError("1002", "center not found", System.Net.HttpStatusCode.NotFound);
            return DevonResult<CenterDto>.Error(error);
        }

        return center.ToCenterDto();
    }

    public Task UpdateCenterAsync(string id, CenterDto centerDto)
    {
        throw new NotImplementedException();
    }
}
