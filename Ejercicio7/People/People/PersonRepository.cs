using People.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People;

public class PersonRepository
{
    private SQLiteAsyncConnection conn;
    private readonly string _dbPath;

    public string StatusMessage { get; set; }

    public PersonRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    private async Task Init()
    {
        if (conn != null)
            return;

        conn = new SQLiteAsyncConnection(_dbPath);
        await conn.CreateTableAsync<Person>();
    }

    public async Task AddNewPerson(string name)
    {
        try
        {
            await Init();

            if (string.IsNullOrEmpty(name))
                throw new Exception("Valid name required");

            int result = await conn.InsertAsync(new Person { Name = name });

            StatusMessage = $"{result} record(s) added [Name: {name}]";
            Console.WriteLine(StatusMessage);
        }
        catch (Exception ex)
        {
            StatusMessage = $"Failed to add {name}. Error: {ex.Message}";
            Console.WriteLine(StatusMessage);
        }
    }

    public async Task<List<Person>> GetAllPeople()
    {
        try
        {
            await Init();
            return await conn.Table<Person>().ToListAsync();
        }
        catch (Exception ex)
        {
            StatusMessage = $"Failed to retrieve data. {ex.Message}";
            Console.WriteLine(StatusMessage);
        }

        return new List<Person>();
    }
}
