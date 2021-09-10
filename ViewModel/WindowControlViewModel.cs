
using System;
using System.Windows;
using System.Windows.Input;
using Calculator.Common.Commands;

namespace Calculator.ViewModel
{

    class WindowControlViewModel : BaseViewModel
    {


        #region Property
        private NormalCalculator windowVM = new NormalCalculator();

        public NormalCalculator MainControlVM 
        {
           get { return windowVM; }
        }

        public NormalCalculator normalCalculator { get; set; }
        public CurrencyConverterViewModel CurrencyConverterVM { get; set; }
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Relay Command
        private RelayCommand _closeButton;
        /// <summary>
        /// Close window button command
        /// </summary>
        public ICommand CloseButton
        {
            get
            {
                if (_closeButton == null)
                {
                    _closeButton = new RelayCommand(param => CloseButtonCommand(param), CanClickCloseButtonCommand);
                }

                return _closeButton;

            }
        }
        private RelayCommand _minimizeButton;
        /// <summary>
        /// Minimize window button command
        /// </summary>
        public ICommand MinimizeButton
        {
            get
            {
                if (_minimizeButton == null)
                {
                    _minimizeButton = new RelayCommand(param => MinimizeButtonCommand(param), CanClickMinimizeButtonCommand);
                }

                return _minimizeButton;

            }
        }



        private RelayCommand _maximizeButton;
        /// <summary>
        /// Maximize window button command
        /// </summary>
        public ICommand MaximizeButton
        {
            get
            {
                if (_maximizeButton == null)
                {
                    _maximizeButton = new RelayCommand(param => MaximizeButtonCommand(param), CanClickMaximizeButtonCommand);
                }

                return _maximizeButton;

            }
        }


        private RelayCommand _currencyConverView;
        /// <summary>
        /// Change to other window command
        /// </summary>
        public ICommand CurrencyConvertView
        {
            get
            {
                if (_currencyConverView == null)
                {
                    _currencyConverView = new RelayCommand(param => OpenCurrencyConvertView(param), CanClickCurrencyConvertView);
                }

                return _currencyConverView;

            }
        }
        private RelayCommand _mainView;

        /// <summary>
        /// Main window control command
        /// </summary>
        public ICommand MainView
        {
            get
            {
                if (_mainView == null)
                {
                    _mainView = new RelayCommand(param => OpenMainView(param), CanClickMainView);
                }

                return _mainView;

            }
        }

        #endregion
        #region Methods

        private bool CanClickCloseButtonCommand(object obj)
        {
            return true;
        }
        /// <summary>
        /// Close window button
        /// </summary>
        /// <param name="param"></param>
        private void CloseButtonCommand(object param)
        {
            Application.Current.Shutdown();
        }
        #endregion

        private bool CanClickMinimizeButtonCommand(object obj)
        {
            return true;
        }
        /// <summary>
        /// Minimize window button
        /// </summary>
        /// <param name="param"></param>

        private void MinimizeButtonCommand(object param)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }


        private bool CanClickMaximizeButtonCommand(object obj)
        {
            return true;
        }
        /// <summary>
        /// Maximize window button 
        /// </summary>
        /// <param name="param"></param>
        private void MaximizeButtonCommand(object param)
        {
            if (Application.Current.MainWindow.WindowState != WindowState.Maximized)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }
        }


        private void OpenCurrencyConvertView(object param)
        {
            CurrentView = CurrencyConverterVM;
        }

        private bool CanClickCurrencyConvertView(object obj)
        {
            return true;
        }

        private void OpenMainView(object param)
        {
            CurrentView = normalCalculator;
        }

        private bool CanClickMainView(object obj)
        {
            return true;
        }


        public WindowControlViewModel()
        {
            normalCalculator = new NormalCalculator();
            CurrencyConverterVM = new CurrencyConverterViewModel();
            CurrentView = normalCalculator;

        }

    }

}
