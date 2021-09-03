using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Calculator.Common.Commands;
using Calculator.Core.Calculators;

namespace Calculator.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        #region Public Properties

        private string _result;
        private bool hasCalculated = false;


        public string Result
        {
            get { return _result; }
            set { _result = value;
                OnPropertyChanged("Result");
            }
        }
        #endregion

        #region Relay Commands
        //Click button command0
        private RelayCommand clickButton;

        public ICommand ClickButton
        {
            get
            {
                if (clickButton == null)
                {
                    clickButton = new RelayCommand(param => ClickButtonCommand(param), CanClickButtonCommand);
                }
                return clickButton;
            }
        }
        private RelayCommand clearButton;

        public ICommand ClearButton
        {
            get
            {
                if (clearButton == null)
                {
                    clearButton = new RelayCommand((paran) => Clear(), CanClear);
                }
                return clearButton;
            }
        }

        private RelayCommand clearLastValue;

        public ICommand ClearLastValue
        {
            get
            {
                if (clearLastValue == null)
                {
                    clearLastValue = new RelayCommand(param => ClearLastV(param), CanClearLastV);
                }
                return clearLastValue;
            }
        }

        private RelayCommand performCalculation;

        public ICommand PerformCalculation
        {
            get
            {
                if (performCalculation == null)
                {
                    performCalculation = new RelayCommand(param => PCalculation(param), CanPCalculation);
                }
                return performCalculation;
            }
        }


        #endregion

        #region Methods


        private void ClearLastV(object param)
        {
            Result = Result.Remove(Result.Length - 1, 1);
        }

        private bool CanClearLastV(object obj)
        {
            return true;
        }

        private bool CanClear(object obj)
        {
            return true;
        }

        private void Clear()
        {
            Result = string.Empty;
        }

        private bool CanClickButtonCommand(object param)
        {
            return true;
        }

        private void ClickButtonCommand(object buttonValue)
        {
            if (hasCalculated)
            {
                Clear();
                hasCalculated = false;
            }
            Result += buttonValue.ToString();
        }

        private bool CanPCalculation(object obj)
        {
            return true;
        }

        private void PCalculation(object param)
        {
            ExpressionCalculator calc = new ExpressionCalculator();
            Result = calc.Calculate(Result).ToString();
            hasCalculated = true;
        }

        #endregion
    }
}
