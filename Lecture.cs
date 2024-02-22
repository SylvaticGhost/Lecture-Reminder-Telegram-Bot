using System;
using Azure;
using ITableEntity = Azure.Data.Tables.ITableEntity;

namespace LectureReminder;

public class Lecture : ITableEntity
{
    public Lecture()
    {
        Subject ??= string.Empty;
        Lector ??= string.Empty;
        Type ??= string.Empty;
        Link ??= string.Empty;
    }

    public string Subject { get; set; }
    public string Lector { get; set; }
    public string Type { get; set; }
    public string Link { get; set; }
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }

    public override string ToString()
    {
        return $@"Day: {(DayOfWeek)(int.Parse(PartitionKey)%7)},
Number: {RowKey},
Subject: {Subject},
Lector: {Lector},
Type: {Type},
Link: {Link}";
    }

}