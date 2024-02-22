using System;

namespace LectureReminder;

public class Helpers
{
    public (string, string) CalculateNeededLecture(DateTime startingDate)
    {
        var hour = DateTime.UtcNow.Hour;
        
        return (Math.Abs((DateTime.UtcNow.Subtract(startingDate).Days + 1)%14).ToString(),
            hour is >= 6 and <= 14 ? ((hour - 4) / 2).ToString() : "0");
    }
}