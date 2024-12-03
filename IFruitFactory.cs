using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.DotnetCore.DI.MultipleImplementationsFactory
{
    public interface IFruitFactory
    {
        IFruit GetFruit(string name);
    }
    
    public class FruitFactory : IFruitFactory
    {
        private readonly IEnumerable<IFruit> _fruits;

        public FruitFactory(
            IEnumerable<IFruit> fruits)
        {
            _fruits = fruits;
        }
        
        public IFruit GetFruit(string name)
        {
            return _fruits.FirstOrDefault(fruit => fruit.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
}