
using Dapper;
using DbUp.Engine;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Text.Json.Serialization;

namespace Migrations.Scripts;

public class S202306131106_SeedBookTable : IScript
{
    static Random _rand = new Random((int)DateTime.Now.Ticks);

    public string ProvideScript(Func<IDbCommand> commandFactory)
    {

        using var command = (commandFactory() as SqlCommand)!;

        var someImages = new List<string>();
        for (int i = 0; i < 10; i++)
        {
            someImages.Add(ImageGenerator.GenerateRandomBase64Image(80 + GetRandomInt(0, 30), 150 + GetRandomInt(0, 40)));
        }

        for (int i = 0; i < 100000; i++)
        {
            InsertEntry(command, JsonConvert.SerializeObject(new
            {
                BookTitle = GenerateEnglishFullName(1, 4, 2, 12),
                BookDescription = GenerateEnglishFullName(2, 20, 2, 12),
                Author = GenerateEnglishFullName(2, 3, 3, 12),
                PublishDate = DateTime.UtcNow.AddHours(GetRandomInt(-100000, -1)),
                CoverBase64 = someImages[i % 10]
            }));
        }

        return "";
    }

    public static void InsertEntry(SqlCommand command, string bookInfo)
    {
        const string query = @"
INSERT INTO [dbo].[Book]([BookInfo],[LastModified])
VALUES (@BookInfo,@LastModified)
";
        var parameters = new
        {
            BookInfo = bookInfo,
            LastModified = DateTime.UtcNow.AddHours(GetRandomInt(-100000, -1))
        };

        command.Connection.Execute(query, parameters, command.Transaction);
    }

    static string GenerateEnglishName(int minSize, int maxSize)
    {
        int size = GetRandomInt(minSize, maxSize) - 1;
        string result = ((char)GetRandomInt('A', 'Z')).ToString();
        for (int i = 0; i < size; i++)
        {
            result += ((char)GetRandomInt('a', 'z')).ToString();
        }
        return result;
    }

    static string GenerateEnglishFullName(int minWordCount, int maxWordCount, int nameMinSize, int nameMaxSize)
    {
        int size = GetRandomInt(minWordCount, maxWordCount);
        string result = "";
        for (int i = 0; i < size; i++)
        {
            result += GenerateEnglishName(nameMinSize, nameMaxSize) + " ";
        }
        return result.TrimEnd();
    }

    static int GetRandomInt(int minInclusive, int maxInclusive)
    {
        return _rand.Next(minInclusive, maxInclusive + 1);
    }
}
