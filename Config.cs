using System;

namespace LectureReminder;

public class Config
{
    public string BotToken { get; } = "";
    public string ChatId { get;  } = "";
    public string ConnectionString { get; } = "";
    public string TableName { get; } = "LectureSchedule";
    public DateTime StartingDate { get; } = new (2024, 1, 22);
}
