using Microsoft.AspNetCore.Mvc;

namespace Demo.DotnetCore.DI.MultipleImplementationsFactory.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly IFruitFactory _fruitFactory;

        public DemoController(
            IFruitFactory fruitFactory)
        {
            _fruitFactory = fruitFactory;
        }

        [HttpGet("Fruit")]
        public string Get()
        {
            var fruit = _fruitFactory.GetFruit<Red>();
            
            return fruit != null 
                ? $"Name: {fruit.Name}, Color: {fruit.Color}" 
                : "Fruit not found";
        }
    }
}
