using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Demo.DotnetCore.DI.MultipleImplementationsFactory
{
    public interface IFruitFactory
    {
        IFruit<TColor> GetFruit<TColor>() where TColor : IColor;
    }
    
    public class FruitFactory : IFruitFactory
    {
        private readonly IEnumerable<IFruit> _fruits;

        public FruitFactory(
            IEnumerable<IFruit> fruits)
        {
            _fruits = fruits;
        }
        
        public IFruit<TColor> GetFruit<TColor>() where TColor : IColor
        {
            return _fruits.OfType<IFruit<TColor>>().FirstOrDefault();
        }
    }
}