namespace Demo.DotnetCore.DI.MultipleImplementationsFactory
{
    public interface IFruit
    {
        string Name { get; }
        string Color { get; }
    }
    
    public class Apple : IFruit
    {
        public string Name => "Apple";
        public string Color => "Red";
    }
    
    public class Orange : IFruit
    {
        public string Name => "Orange";
        public string Color => "Orange";
    }
    
    public class Banana : IFruit
    {
        public string Name => "Banana";
        public string Color => "Yellow";
    }
}