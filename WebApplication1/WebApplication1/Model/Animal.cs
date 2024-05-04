using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Model;
//Parametr jako dostępne wartości przyjmuje: name, description, category, area. 
public class Animal
{
    
    public int IdAnimal { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Area { get; set; }
    
    
}