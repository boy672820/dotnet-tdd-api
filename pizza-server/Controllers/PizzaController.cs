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
    return CreatedAtAction(nameof(Create), new { id = newPizza.Id }, newPizza);
  }
}