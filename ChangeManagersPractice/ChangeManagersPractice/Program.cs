using System;
using System.Collections.Generic;

public enum Operation
{
    Sum,
    Subtract,
    Multiply
}
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

class Program
{
    static void Main(string[] args)
    {
        var opManager = new OperationManager(20, 10);
        var result = opManager.Execute(Operation.Sum);
        Console.WriteLine($"The result of the operation is {result}");
        Console.ReadKey();
    }
}