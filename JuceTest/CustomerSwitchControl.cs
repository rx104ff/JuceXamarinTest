using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace JuceTest
{
    public partial class CustomerSwtichControl : Switch
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(CustomerSwtichControl), null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static void Execute(ICommand command)
        {
            if (command == null) return;
            if (command.CanExecute(null))
            {
                command.Execute(null);
            }
        }

        public Command OnTap => new Command(() => Execute(Command));
    }
}
