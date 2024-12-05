using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.DotnetCore.DI.MultipleImplementationsFactory
{
    public interface IFruitFactory
    {
        IFruit<TColor> GetFruit<TColor>();
    }
    
    public class FruitFactory : IFruitFactory
    {
        private readonly IFruit<Red> _redFruit;
        private readonly IFruit<Yellow> _yellowFruit;
        private readonly IFruit<Blue> _blueFruit;

        public FruitFactory(
            IFruit<Red> redFruit, 
            IFruit<Yellow> yellowFruit, 
            IFruit<Blue> blueFruit)
        {
            _redFruit = redFruit;
            _yellowFruit = yellowFruit;
            _blueFruit = blueFruit;
        }
        
        public IFruit<TColor> GetFruit<TColor>()
        {
            return typeof(TColor) switch
            {
                var type when type == typeof(Red) => (IFruit<TColor>)_redFruit,
                var type when type == typeof(Yellow) => (IFruit<TColor>)_yellowFruit,
                var type when type == typeof(Blue) => (IFruit<TColor>)_blueFruit,
                _ => throw new ArgumentOutOfRangeException(nameof(TColor))
            };
        }
    }
}