using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using Calculator.Application.Calculations;

namespace SimpleCalc.ViewModel
{
    public class MainViewModel :INotifyPropertyChanged
    {
        private ICalculationService _calculationService;
        private string _calculationScreen;

        public MainViewModel(ICalculationService calculationService)
        {
            _calculationService = calculationService;
            _calculationScreen = "";

            NumberCommand = new Command<string>((s) =>
            {
                var output = _calculationService.AppendToExpression(s);
                if (output.IsSuccessed) CalculationScreen = output.OutputValue;
                Debug.WriteLine($"ErrorMassage:{output.ErrorMessage}");
            });
            PointCommand = new Command(() =>
            {
                var output = _calculationService.AppendToExpression(".");
                if (output.IsSuccessed) CalculationScreen = output.OutputValue;
                Debug.WriteLine($"ErrorMassage:{output.ErrorMessage}");
            });
            OperatorCommand = new Command<string>((s) =>
            {
                var output = _calculationService.AppendToExpression(s);
                if (output.IsSuccessed) CalculationScreen = output.OutputValue;
                Debug.WriteLine($"ErrorMassage:{output.ErrorMessage}");
            });
            EqualCommand = new Command(() =>
            {
                var output = _calculationService.Calculate();
                if (output.IsSuccessed) CalculationScreen = output.OutputValue;
                Debug.WriteLine($"ErrorMassage:{output.ErrorMessage}");
            });
            DeleteCommand = new Command(() =>
            {
                var output = _calculationService.DeleteFromExpression();
                if (output.IsSuccessed) CalculationScreen = output.OutputValue;
                Debug.WriteLine($"ErrorMassage:{output.ErrorMessage}");
            });
            ClearCommand = new Command(() =>
            {
                var output = _calculationService.Clear();
                if (output.IsSuccessed) CalculationScreen = output.OutputValue;
                Debug.WriteLine($"ErrorMassage:{output.ErrorMessage}");
            });
            LeftParenthesisCommand = new Command(() =>
            {
                var output = _calculationService.AppendToExpression("(");
                if (output.IsSuccessed) CalculationScreen = output.OutputValue;
                Debug.WriteLine($"ErrorMassage:{output.ErrorMessage}");
            });
            RightParenthesisCommand = new Command(() =>
            {
                var output = _calculationService.AppendToExpression(")");
                if (output.IsSuccessed) CalculationScreen = output.OutputValue;
                Debug.WriteLine($"ErrorMassage:{output.ErrorMessage}");
            });
        }

        public string CalculationScreen
        {
            get => _calculationScreen;
            private set
            {
                _calculationScreen = value;
                OnPropertyChanged();
            }
        }

        public ICommand NumberCommand { get; private set; }
        public ICommand PointCommand { get; private set; }
        public ICommand OperatorCommand { get; private set; }
        public ICommand EqualCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }
        public ICommand LeftParenthesisCommand { get; private set; }
        public ICommand RightParenthesisCommand { get; private set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
