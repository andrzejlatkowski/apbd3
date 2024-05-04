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

    public IEnumerable<Animal> GetAnimals()
    {
        // pobieramy cos z bazy
        // cos robumy z danymi
        return _animalRepository.GetAnimals();
         
    }

    public int CreateAnimal(Animal newAnimal)
    {
        throw new NotImplementedException();
    }
}