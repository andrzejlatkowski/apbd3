using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AnimalController : ControllerBase
{
    private readonly IAnimalService _animalService;
    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAnimals(string? orderBy) //////////////////////////////tu ma być query string
                                                    ///     jeśli nie pasuje domyślnie do segmentu w HTTPGET to jest query stirng
    {
        var animals = _animalService.GetAnimals(orderBy);
        return Ok(animals);
    }
    
    [HttpPost]
    public IActionResult CreateAnimal(Animal animal) /////////////////////// obiekt złożony domyślnie w ciele żądania
    {
        _animalService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{idAnimal:int}")]
    public IActionResult UpdateAnimal(int idAnimal, Animal animal)
    {
        var affectedCount = _animalService.UpdateAnimal(animal);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var affectedCount = _animalService.DeleteAnimal(id);
        return NoContent();
    }
}