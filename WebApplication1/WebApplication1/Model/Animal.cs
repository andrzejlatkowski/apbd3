using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Model;
//Parametr jako dostępne wartości przyjmuje: name, description, category, area. 
public class Animal
{
    public int IdAnimal { get; set; }
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    [Required]
    [MaxLength(100)]
    public string Description { get; set; }
    [Required]
    [MaxLength(30)]
    public string Category { get; set; }
    [Required]
    [MaxLength(30)]
    public string Area { get; set; }
}