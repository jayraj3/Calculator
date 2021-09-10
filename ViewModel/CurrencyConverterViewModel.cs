using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Calculator.Common.Commands;
using Calculator.Core.API;
using Calculator.Core.Calculators;

namespace Calculator.ViewModel
{
    class CurrencyConverterViewModel : BaseViewModel
    {
        #region Public Properties
        public CurrencyConverter conveter;
        private string _toValue ="0";

        private List<string> _currencies = new List<string>();
        public List<string> Currencies
        {
            get { return _currencies; }
            set
            {
                _currencies = value;
                OnPropertyChanged();
            }

        }
        private string _toCurrency = "INR";

        public string ToCurrency
        {
            get { return _toCurrency; }
            set
            {
                _toCurrency = value;
                OnPropertyChanged("ToCurrency");
            }
        }

        private string _fromCurrency = "EUR";

        public string FromCurrency
        {
            get { return _fromCurrency; }
            set
            {
                _fromCurrency = value;
                OnPropertyChanged("FromCurrency");
            }
        }
        public string ToValue
        {
            get { return _toValue; }
            set
            {
                _toValue = value;
                OnPropertyChanged("ToValue");
            }
        }

        private string _fromValue = "0";
        public string FromValue
        {
            get { return _fromValue; }
            set
            {
                _fromValue = value;
                OnPropertyChanged("FromValue");
            }
        }


        private string _date;
        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
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



        private RelayCommand _refreshRates;
        /// <summary>
        /// RefreshRates button command
        /// </summary>
        public ICommand RefreshRates
        {
            get
            {
                if (_refreshRates == null)
                {
                    _refreshRates = new RelayCommand(param => ClickRefresh(param), CanRefresh);
                }
                return _refreshRates;
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
        #endregion

        #region Method

        private bool CanClickButtonCommand(object param)
        {
            return true;
        }

        private void Clear()
        {
            FromValue = "0";
            //ToValue = string.Empty;
        }
        /// <summary>
        /// Number button method to get entered value
        /// </summary>
        private void ClickButtonCommand(object buttonValue)
        {
            if (FromValue=="0" & buttonValue.ToString() == "0")
            {
                Clear();
                ClickConvert();
            }
            else
            {
                if(FromValue == "0")
                {
                    FromValue = "";
                }
                FromValue += buttonValue.ToString();
                ClickConvert();
            }


        }

        /// <summary>
        /// Convert currency button method
        /// </summary>
        private void ClickConvert()
        {
            double value = double.Parse(FromValue, System.Globalization.CultureInfo.InvariantCulture);
            ToValue = conveter.ConvertCurrency(FromCurrency, ToCurrency, value);
        }

        private bool CanRefresh(object param)
        {
            return true;
        }
        /// <summary>
        /// Refresh currency rates button method
        /// </summary>
        private void ClickRefresh(object param)
        {
            Date = conveter.UpdateCurrencyRate();
        }
        #endregion

        private void GetAllCurrency(object c)
        {
            Currencies.Add("EUR");
            foreach (var property in c.GetType().GetProperties())
            {
                string n = property.Name;
                Currencies.Add(n);
            }


        }

        /// <summary>
        /// Delete last entered value method
        /// </summary>
        private void ClearLastV(object param)
        {
            if (FromValue != null)
            {
                if (FromValue.Length > 0)
                {
                    FromValue = FromValue.Remove(FromValue.Length - 1, 1);
                    if (FromValue == "")
                    {
                        FromValue = "0";
                    }
                    ClickConvert();
                }

                
            }
        }

        private bool CanClearLastV(object obj)
        {
            return true;
        }

        public CurrencyConverterViewModel()
        {
            conveter = new CurrencyConverter();
            Date = conveter.UpdateCurrencyRate();
            Rates Currency = new Rates();
            GetAllCurrency(Currency);
        }

    }
}
