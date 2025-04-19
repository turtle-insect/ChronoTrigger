using System.Windows.Input;

namespace ChronoTrigger
{
	internal class ActionCommand : ICommand
	{
		public event EventHandler? CanExecuteChanged;

		private readonly Action<Object?> mAction;

		public ActionCommand(Action<Object?> action) => mAction = action;

		public bool CanExecute(Object? parameter) => true;

		public void Execute(Object? parameter) => mAction(parameter);
	}
}
