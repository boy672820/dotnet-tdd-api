using PizzaSchool.Models;
using PizzaSchool.Services;
using Microsoft.AspNetCore.Mvc;

namespace PizzaSchool.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
  public PizzaController()
  {
  }

  [HttpGet]
  public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

  [HttpGet("{id}")]
  public ActionResult<Pizza> Get(int id)
  {
    var pizza = PizzaService.Get(id);

    if (pizza == null)
    {
      return NotFound();
    }

    return pizza;
  }

  [HttpPost]
  public IActionResult Create(Pizza newPizza)
  {
    // 검증되지 않은 코드
    var pizza = PizzaService.GetByName(newPizza.Name);

    if (pizza != null)
    {
      return BadRequest();
    }

    // TDD 검증코드
    if (newPizza.Name == "")
    {
      return BadRequest();
    }

    // TDD 검증코드
    if (newPizza.Allergies != null)
    {
      string[] validAllergies = new string[] { "Milk", "Egg", "Tomato" };
      bool isAllergies = newPizza.Allergies.All(a => validAllergies.Contains(a));

      if (!isAllergies)
      {
        return BadRequest();
      }
    }

    return CreatedAtAction(nameof(Create), new { id = newPizza.Id }, newPizza);
  }

  [HttpPut("{id}")]
  public IActionResult Update(int id, Pizza pizza)
  {
    if (id != pizza.Id)
    {
      return BadRequest();
    }

    var existingPizza = PizzaService.Get(id);

    if (existingPizza is null)
    {
      return NotFound();
    }

    PizzaService.Update(pizza);

    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var pizza = PizzaService.Get(id);

    if (pizza is null)
    {
      return NotFound();
    }

    PizzaService.Delete(id);

    return NoContent();
  }
}