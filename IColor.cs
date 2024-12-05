namespace Demo.DotnetCore.DI.MultipleImplementationsFactory
{
    public interface IColor
    {
        string Name { get; }
    }
    
    public class Red : IColor
    {
        public string Name => "Red";
    }
    
    public class Yellow : IColor
    {
        public string Name => "Yellow";
    }
    
    public class Blue : IColor
    {
        public string Name => "Blue";
    }
}