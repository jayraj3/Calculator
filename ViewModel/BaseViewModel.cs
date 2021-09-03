using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Calculator.ViewModel
{
    class BaseViewModel : INotifyPropertyChanged
    {
        private Dictionary<string, object> properties;

        public event PropertyChangedEventHandler PropertyChanged;

        protected BaseViewModel()
        {
            this.properties = new Dictionary<string, object>();
        }

        protected T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            if (!properties.ContainsKey(propertyName))
            {
                return default(T);
            }
            else
            {
                return (T)properties[propertyName];
            }
        }

        protected void SetValue<T>(T newValue, [CallerMemberName] string propertyName = null)
        {
            if (!properties.ContainsKey(propertyName))
            {
                properties.Add(propertyName, default(T));
            }

            var oldValue = GetValue<T>(propertyName);
            if (!EqualityComparer<T>.Default.Equals(oldValue, newValue))
            {
                properties[propertyName] = newValue;
                OnPropertyChanged(propertyName);
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
