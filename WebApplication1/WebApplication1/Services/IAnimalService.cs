using WebApplication1.Model;

namespace WebApplication1.Services;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimals(string? orderBy);
    int CreateAnimal(Animal newAnimal);
    int UpdateAnimal(Animal animal);
    int DeleteAnimal(int id);
}