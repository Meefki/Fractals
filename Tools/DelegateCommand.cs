using System;
using System.Windows.Input;

namespace SerpShapes.Tools;

internal class DelegateCommand : ICommand
{
    public DelegateCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        executeAction = execute;
        canExecuteFunc = canExecute;
    }

    private readonly Action<object?> executeAction;
    private readonly Func<object?, bool>? canExecuteFunc;

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return canExecuteFunc?.Invoke(parameter) ?? true;
    }

    public void Execute(object? parameter)
    {
        executeAction?.Invoke(parameter);
    }
}
