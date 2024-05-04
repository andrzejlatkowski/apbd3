using WebApplication1.Model;

namespace WebApplication1.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals(string? orderBy);
    int CreateAnimal(Animal newAnimal);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int idAnimal);
}