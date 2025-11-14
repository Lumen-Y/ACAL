using System.Drawing;
using CalendarView.Core.Models;
using Common.UI.Extensions;
using Microsoft.Extensions.Logging;

namespace CalendarView.Shared.Utils;

public static class CommonFunctions
{
    public static void LoadPictures(ILogger logger, string? directory, List<string> imageBase64s)
    {
        logger.LogInformation("Started loading pictures");
        imageBase64s.Clear();
        if (!Directory.Exists(directory))
        {
            logger.LogWarning("Picture directory does not exist: {path}", directory);
            return;
        }
        var random = new Random();
        imageBase64s.AddRange(
            Directory.EnumerateFiles(directory)
                .Where(f => MimeMapping.MimeUtility.GetMimeMapping(f).StartsWith("image/"))
                .OrderBy(_ => random.Next())
                .Select(f => Convert.ToBase64String(File.ReadAllBytes(f)))
        );
        logger.LogInformation("Finished loading pictures");
    }

    public static bool IsEventAtDay(CalendarEvent ev, DateTime day)
    {
        return ev.TotalStartTime.Date <= day && ev.TotalEndTime.Date >= day;
    }

    public static IEnumerable<(Calendar calendar, Color backColor, Color dimBackColor, Color foreColor)> GetCalendarsOrderedByColor(IEnumerable<Calendar> calendars, double eventCardDimmingRatio)
    {
        return calendars
            .OrderBy(c => c.Color.GetHue())
            .ThenBy(c => c.Color.R * 3 + c.Color.G * 2 + c.Color.B * 1)
            .Select((Calendar calendar, Color dimBackColor) (calendar) => (calendar, calendar.Color.GetDimColor(eventCardDimmingRatio)))
            .Select(calendar => (calendar.calendar, calendar.calendar.Color, calendar.dimBackColor, calendar.dimBackColor.GetForeColor()));
    }
}