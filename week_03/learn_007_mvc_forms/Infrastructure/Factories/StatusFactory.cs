using Infrastructure.DTOs;
using Infrastructure.Models;
using Infrastructure.Entities;

namespace Infrastructure.Factories;

public static class StatusFactory
{
    public static StatusForm CreateRegistrationForm() => new();
    public static StatusUpdate CreateUpdateForm() => new();

    public static StatusEntity CreateEntityFrom(StatusForm registrationForm) => new()
    {
        StatusName = registrationForm.StatusName
    };

    public static Status CreateOutputModel(StatusEntity entity) => new()
    {
        Id = entity.Id,
        StatusName = entity.StatusName
    };
    public static Status CreateOutputModelFrom(StatusEntity entity) => new()
    {
        Id = entity.Id,
        StatusName = entity.StatusName
    };

    public static StatusUpdate CreateUpdateForm(Status status) => new()
    {
        Id = status.Id,
        StatusName = status.StatusName
    };

    public static StatusEntity Update(StatusEntity statusTypeEntity, StatusUpdate updateForm)
    {
        statusTypeEntity.Id = statusTypeEntity.Id;
        statusTypeEntity.StatusName = updateForm.StatusName;
        
        return statusTypeEntity;
    }
}