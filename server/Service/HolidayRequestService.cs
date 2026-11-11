
namespace Service;

using Infrastructure.Data;
using Infrastructure.Entities;
using LinqToDB;
using Service.DTOs;

public class HolidayRequestService(AppDbConnection db)
{
    public HolidayRequestDto CreateRequest(
        string userId,
        CreateHolidayRequestDto dto)
    {
        var startDate = dto.StartDate.Date;
        var endDate = dto.EndDate.Date;

        if (startDate > endDate)
            throw new ArgumentException(
                "Start date cannot be after end date.");

        if (dto.HolidayAccount != "Weeks1To5" &&
            dto.HolidayAccount != "Week6")
            throw new ArgumentException("Invalid holiday account.");

        int requestedDays = 0;
        decimal requestedHours = 0;

        for (var date = startDate; date <= endDate; date = date.AddDays(1))
        {
            if (date.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
                continue;

            requestedDays++;

            requestedHours += date.DayOfWeek == DayOfWeek.Friday
                ? 7.0m
                : 7.5m;
        }

        if (requestedDays == 0)
            throw new ArgumentException(
                "Request must contain at least one working day.");

        bool overlapping = db.GetTable<HolidayRequest>().Any(r =>
            r.UserId == userId &&
            (r.Status == "Pending" || r.Status == "Approved") &&
            r.StartDate <= endDate &&
            r.EndDate >= startDate);

        if (overlapping)
            throw new InvalidOperationException(
                "You already have a holiday request during these dates.");

        var entity = new HolidayRequest
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            StartDate = startDate,
            EndDate = endDate,
            HolidayAccount = dto.HolidayAccount,
            RequestedDays = requestedDays,
            RequestedHours = requestedHours,
            Status = "Pending",
            CreatedAtUtc = DateTime.UtcNow
        };

        db.Insert(entity);

        return new HolidayRequestDto
        {
            Id = entity.Id,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            HolidayAccount = entity.HolidayAccount,
            RequestedDays = entity.RequestedDays,
            RequestedHours = entity.RequestedHours,
            Status = entity.Status,
            CreatedAtUtc = entity.CreatedAtUtc
        };
    }

    public List<HolidayRequestDto> GetMyRequests(string userId)
    {
        return db.GetTable<HolidayRequest>()
            .Where(r => r.UserId == userId)
            .OrderByDescending(r => r.CreatedAtUtc)
            .Select(r => new HolidayRequestDto
            {
                Id = r.Id,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                HolidayAccount = r.HolidayAccount,
                RequestedDays = r.RequestedDays,
                RequestedHours = r.RequestedHours,
                Status = r.Status,
                CreatedAtUtc = r.CreatedAtUtc
            })
            .ToList();
    }
}
