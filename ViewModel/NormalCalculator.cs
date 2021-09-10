using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Calculator.Common.Commands;
using Calculator.Core.Calculators;

namespace Calculator.ViewModel
{
    class NormalCalculator : BaseViewModel
    {
        #region Public Properties

        private string _result = "0";
        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged("Result");
            }
        }
        #endregion

        #region Relay Commands
        
        private RelayCommand clickButton;
        /// <summary>
        /// Number button command
        /// </summary>
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

        /// <summary>
        /// Clear textbox command
        /// </summary>
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
        /// <summary>
        /// Delete last entered value command
        /// </summary>
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
        /// <summary>
        /// Perform calculation based on provided expression command
        /// </summary>
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

        /// <summary>
        /// Delete last entered value method
        /// </summary>
        private void ClearLastV(object param)
        {
            if (Result != null)
            {
                if (Result.Length > 0)
                {
                    Result = Result.Remove(Result.Length - 1, 1);
                }
            }
        }

        private bool CanClearLastV(object obj)
        {
            return true;
        }

        private bool CanClear(object obj)
        {
            return true;
        }
        /// <summary>
        /// Clear textbox method
        /// </summary>
        private void Clear()
        {
            Result = "0";
        }

        private bool CanClickButtonCommand(object param)
        {
            return true;
        }
        /// <summary>
        /// Number button method to get entered value
        /// </summary>
        private void ClickButtonCommand(object buttonValue)
        {
            if (Result == "0" & buttonValue.ToString() == "0")
            {
                Clear();
            }
            else
            {
                if (Result == "0")
                {
                    Result = "";
                }
                Result += buttonValue.ToString();
            }

            
        }

        private bool CanPCalculation(object obj)
        {
            return true;
        }
        /// <summary>
        /// Perform calculation based on provided expression method
        /// </summary>
        private void PCalculation(object param)
        {
            ExpressionCalculator calc = new ExpressionCalculator();
            Result = calc.Calculate(Result).ToString();
        }

        #endregion
    }
}
