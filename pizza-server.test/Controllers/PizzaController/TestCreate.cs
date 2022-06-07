using PizzaSchool.Controllers;
using PizzaSchool.Models;
using Microsoft.AspNetCore.Mvc;
// using FluentAssertions;
// using Xunit;

namespace PizzaSchool.UnitTests.Systems.Controllers;

public class TestCreate
{
  public TestCreate()
  {
    this.sut = new PizzaController();
  }

  private PizzaController sut;

  [Fact]
  public void SutCheckForDuplicateName()
  {
    Pizza newPizza = new Pizza { Name = "Hawaiian", IsGlutenFree = true };

    var actual = this.sut.Create(newPizza);

    Assert.IsType<BadRequestResult>(actual);
  }

  [Fact]
  public void SutCorrectlyTrimsEmptyValue()
  {
    Pizza newPizza = new Pizza { Name = "", IsGlutenFree = true };

    var actual = this.sut.Create(newPizza);

    Assert.IsType<BadRequestResult>(actual);
  }

  [Fact]
  public void IfAllergiesAreNotEmptyCheckValues()
  {
    Pizza newPizza = new Pizza { Name = "Test", IsGlutenFree = true, Allergies = new string[] { "Milk", "Egg", "Peanut" } };

    var actual = this.sut.Create(newPizza);

    Assert.IsType<BadRequestResult>(actual);
  }
}
