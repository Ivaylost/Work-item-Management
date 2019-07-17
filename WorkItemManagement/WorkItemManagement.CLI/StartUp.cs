using WorkItemManagement.Core.Engine;

namespace WorkItemManagement.CLI
{
    class StartUp
    {
        static void Main()
        {
            var engine = new WIMEngine();
            engine.Run();
        }
    }
}
