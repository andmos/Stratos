namespace TestStratosTestable.Stratos.Plugin.Service
{
    public class MyService : IMyService
    {
        public string GetValue()
        {
            return "Hello from TestPlugin!";
        }
    }

    public interface IMyService
    {
        string GetValue();
    }
}