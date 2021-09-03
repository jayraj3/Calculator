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

        private bool CanClickButtonCommand(object param)
        {
            return true;
        }

        private void ClickButtonCommand(object param)
        {
            Result = "0";
            //MessageBox.Show("Button Clicked"); ;
        }

        #endregion
    }
}
