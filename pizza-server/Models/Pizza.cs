namespace PizzaSchool.Models;

public class Pizza
{
  public int Id { get; set; }
  public string Name { get; set; } = "";
  public bool IsGlutenFree { get; set; }
  public string[]? Allergies { get; set; }
}