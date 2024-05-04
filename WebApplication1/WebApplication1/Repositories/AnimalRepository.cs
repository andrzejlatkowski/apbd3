using System.Data.SqlClient;
using WebApplication1.Model;

namespace WebApplication1.Repositories;

public class AnimalRepository : IAnimalRepository
{
    
    private readonly IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animal> GetAnimals(string? orderBy)
    {
        
        if (orderBy == null)
        {
            orderBy = "name";
        }
        
        HashSet<string?> orderByOptions = new HashSet<string?>(){ "name", "description", "category", "area"};
        if (!orderByOptions.Contains(orderBy))
        {
            throw new Exception();
        }

        string query = $"SELECT * FROM ANIMAL ORDER BY {orderBy}";
        
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        using var cmd = new SqlCommand(query, con);
        
        var dr = cmd.ExecuteReader(); ///////////////// to jest kursor - w trybie dynamicznym wczytuje rekord po rekordzie
        
        var animals = new List<Animal>();
        while (dr.Read())
        {
            var animal = new Animal
            {
                IdAnimal = (int)dr["IdAnimal"],
                Name = dr["Name"].ToString()!,
                Description = dr["Description"].ToString()!,
                Category = dr["Category"].ToString()!,
                Area = dr["Area"].ToString()!
            };
            animals.Add(animal);
        }
        return animals;
    }

    public int CreateAnimal(Animal newAnimal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "INSERT INTO Animal(Name, Description, Category, Area) VALUES(@Name, @Description, @Category, @Area)";
        cmd.Parameters.AddWithValue("@IdAnimal", newAnimal.IdAnimal);
        cmd.Parameters.AddWithValue("@Name", newAnimal.Name);
        cmd.Parameters.AddWithValue("@Description", newAnimal.Description);
        cmd.Parameters.AddWithValue("@Category", newAnimal.Category);
        cmd.Parameters.AddWithValue("@Area", newAnimal.Area);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int UpdateAnimal(Animal animal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "UPDATE Animal SET Name=@Name, Description=@Description, Category=@Category, Area=@Area WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", animal.IdAnimal);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int DeleteAnimal(int idAnimal)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "DELETE FROM Animal WHERE IdAnimal = @IdAnimal";  ////////////////////// chroni przed SQL injection
        cmd.Parameters.AddWithValue("@idAnimal", idAnimal);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}