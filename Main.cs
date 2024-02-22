using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace LectureReminder;

public static class Main
{
    [FunctionName("Main")]
    public static async Task RunAsync([TimerTrigger("0 0 6,8,10,12,14 * * MON,TUE,WED,THU,FRI")] TimerInfo myTimer, ILogger log)
    {
        log.LogInformation($"C# Timer trigger function executed at: {DateTime.UtcNow}");

        Config config = new Config();
        
        DataAzureStorage storage = new DataAzureStorage(config.ConnectionString, config.TableName);
        TelegramClient telegramClient = new TelegramClient(config.BotToken, config.ChatId);
        Helpers helpers = new Helpers();
        Environment.SetEnvironmentVariable("AZURE_STORAGE_CONNECTION_STRING", config.ConnectionString);
        (string, string) keys = helpers.CalculateNeededLecture(config.StartingDate);
  
        if(int.Parse(keys.Item2) != 0)
        {
            Lecture lecture = storage.GetLecture(keys.Item1, keys.Item2).Result;

            if (lecture is not null)
            {
                telegramClient.Send(lecture);
            }
        }
    }
}