using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using Calculator.Common.Commands;

namespace Calculator.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        #region Public Properties

        private float _number;
        private string _operation;
        private string _result;

        public float Number
        {
            get { return _number; }
            set { _number = value;
                OnPropertyChanged("Number");
            }
        }

        public string Operation
        {
            get { return _operation; }
            set { _operation = value;
                OnPropertyChanged("Operation");
            }
        }

        public string Result
        {
            get { return _result; }
            set { _result = value;
                OnPropertyChanged("Result");
            }
        }
        #endregion

        #region Relay Commands
        //Click button command
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
                    clearButton = new RelayCommand(param => Clear(param), CanClear);
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

        private void Clear(object param)
        {
            Result = string.Empty;
        }

        private bool CanClickButtonCommand(object param)
        {
            return true;
        }

        private void ClickButtonCommand(object buttonValue)
        {
            Result += buttonValue.ToString();
        }

        #endregion
    }
}
