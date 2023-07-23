using System.Collections.Generic;

namespace ChangeManagersPractice
{
    public class OperationManager
    {
        private readonly ExecutionManager ExecutionManager;
        public OperationManager(int first, int second)
        {
            ExecutionManager = new ExecutionManager();
            ExecutionManager.PopulateFunctions(first, second);
            ExecutionManager.PrepareExecution();
        }
        public int Execute(Operation operation)
        {
            return ExecutionManager.FuncExecute.GetValueOrDefault(operation)();
        }
    }
}