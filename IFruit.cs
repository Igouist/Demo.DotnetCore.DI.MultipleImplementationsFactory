namespace Demo.DotnetCore.DI.MultipleImplementationsFactory
{
    public interface IFruit
    {
        string Name { get; }
        string Color { get; }
    }
    
    public interface IFruit<TColor> : IFruit where TColor : IColor
    {
    }
    
    public class Apple : IFruit<Red>
    {
        public string Name => "Apple";
        public string Color => "Red";
    }
    
    public class Banana : IFruit<Yellow>
    {
        public string Name => "Banana";
        public string Color => "Yellow";
    }
    
    public class Huckleberry : IFruit<Blue>
    {
        public string Name => "Huckleberry";
        public string Color => "Blue";
    }
}