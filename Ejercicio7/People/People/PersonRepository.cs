using People.Models;
using SQLite;

namespace People;

public class PersonRepository
{
    string _dbPath;
    private SQLiteConnection conn;


    public string StatusMessage { get; set; }

    // TODO: Add variable for the SQLite connection

    private void Init()
    {
        // TODO: Add code to initialize the repository         
    }

    public PersonRepository(string dbPath)
    {
        conn = new SQLiteConnection(dbPath);
        conn.CreateTable<Person>();
    }

    public void AddNewPerson(string name)
    {
        int result = 0;
        try
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Valid name required");

            result = conn.Insert(new Person { Name = name });

            if (result == 1)
                Console.WriteLine("Persona agregada correctamente.");
            else
                Console.WriteLine("Error al agregar persona.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


    public List<Person> GetAllPeople()
    {
        try
        {
            return conn.Table<Person>().ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        return new List<Person>();
    }

}
