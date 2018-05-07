namespace BlackFireFramework.Unity
{
    public interface IProcessModule:IModule
    {
        void AddProcess(ProcessBase process);

        void StartProcess();
    }
}