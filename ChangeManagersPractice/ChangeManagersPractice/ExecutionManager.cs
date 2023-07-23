using System;
using System.Collections.Generic;

namespace ChangeManagersPractice
{
    public class ExecutionManager
    {
        public Dictionary<Operation, Func<int>> FuncExecute { get; set; }

        private Func<int> Sum;
        private Func<int> Subtract;
        private Func<int> Multiply;
        public ExecutionManager()
        {
        }

        public void PopulateFunctions(int x, int y)
        {
            Sum += () => x + y;
            Subtract += () => x - y;
            Multiply += () => x * y;
        }
        public void PrepareExecution()
        {
            FuncExecute = new Dictionary<Operation, Func<int>>()
            {
                { Operation.Sum, Sum },
                { Operation.Subtract, Subtract },
                { Operation.Multiply, Multiply }
            };
        }
    }
}