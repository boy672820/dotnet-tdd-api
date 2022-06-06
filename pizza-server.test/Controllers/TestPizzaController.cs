using PizzaSchool.Controllers;
using PizzaSchool.Models;
using FluentAssertions;
using Xunit;

namespace PizzaSchool.UnitTests.Systems.Controllers;

public class TestPizzaController
{
  [Fact]
  public void Test1()
  {
    var sut = new PizzaController();

    var result = sut.GetAll();

    result.Should().BeOfType<List<Pizza>>();
  }
}
