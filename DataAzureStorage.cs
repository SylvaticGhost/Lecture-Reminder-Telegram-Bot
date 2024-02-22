using System.Threading.Tasks;
using Azure.Data.Tables;

namespace LectureReminder;

public class DataAzureStorage
{
    private readonly TableClient _table;

    public DataAzureStorage(string connectionString, string tableName)
    {
        var tableServiceClient = new TableServiceClient(connectionString);
        _table = tableServiceClient.GetTableClient(tableName);
    }

    public async Task<Lecture> GetLecture(string partitionKey, string rowKey)
    {
        var response = await _table.GetEntityAsync<TableEntity>(partitionKey, rowKey);

        return new Lecture
        {
            RowKey = response.Value.RowKey,
            PartitionKey = response.Value.PartitionKey,
            ETag = response.Value.ETag,
            Timestamp = response.Value.Timestamp,
            Lector = response.Value.GetString("Lector"),
            Link = response.Value.GetString("Link"),
            Subject = response.Value.GetString("Subject"),
            Type = response.Value.GetString("Type")
        };
    }
}