using WebApplication1.Model;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class AnimalService : IAnimalService
{
    private readonly IAnimalRepository _animalRepository;
    
    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public IEnumerable<Animal> GetAnimals(string? orderBy)
    {
        return _animalRepository.GetAnimals(orderBy);
         
    }
    public int CreateAnimal(Animal newAnimal)
    {
        return _animalRepository.CreateAnimal(newAnimal);
    }

    public int UpdateAnimal(Animal animal)
    {
        return _animalRepository.UpdateAnimal(animal);
    }

    public int DeleteAnimal(int idAnimal)
    {
        return _animalRepository.DeleteAnimal(idAnimal);
    }
}