using System.Data.SqlClient;
using Microsoft.AspNetCore.Http.HttpResults;
using WebApplication1.Model;

namespace WebApplication1.Repositories;

public class AnimalRepository : IAnimalRepository
{
    
    private readonly IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IEnumerable<Animal> GetAnimals()
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = "SELECT * FROM ANIMAL";
        
        var dr = cmd.ExecuteReader();
        
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

    public IEnumerable<Animal> FetchAnimals()
    {
        throw new NotImplementedException();
    }
}