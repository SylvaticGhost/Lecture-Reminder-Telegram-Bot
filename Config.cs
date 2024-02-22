using System;

namespace LectureReminder;

public class Config
{
    public string BotToken { get; } = "6876162322:AAGYMpQ8_mazCnwJHgIMnIpAoPbHVWeAGew";
    public string ChatId { get;  } = "-1002142606811";
    public string ConnectionString { get; } = "DefaultEndpointsProtocol=https;AccountName=clonesptstorage;AccountKey=9gF3xUCthAPZU/85EarH5y+d9bxtAPkAh0/Mi8VFq2JGyuAKsBPwZuzaFY+IUvhukZ+2R4HFbKfl+ASt8teHDw==;EndpointSuffix=core.windows.net";
    public string TableName { get; } = "LectureSchedule";
    public DateTime StartingDate { get; } = new (2024, 1, 22);
}