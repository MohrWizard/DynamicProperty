using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProperty.Models
{
    public class DynamicProperty<T> : ObservableObject where T : struct, INumber<T>
    {
        private readonly Func<T> defaultValueGetter;
        private readonly string propertyName;

        public DynamicProperty(Func<T> defaultValueGetter, string propertyName, ObservableValidator defaultsProvider)
        {
            this.defaultValueGetter = defaultValueGetter;
            this.propertyName = propertyName;
            defaultsProvider.PropertyChanged += DefaultsChanged;
        }

        private void DefaultsChanged(object sender, PropertyChangedEventArgs e)
        {
            if (!IsCustom && e.PropertyName == propertyName)
            {
                OnPropertyChanged(nameof(Value));
            }
        }



        private T? _value;

        public T Value
        {
            get { return _value ?? defaultValueGetter(); }
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
                OnPropertyChanged(nameof(IsCustom));
            }
        }

        public bool IsCustom
        {
            get { return _value.HasValue; }
            set
            {
                if (value == true)
                {
                    _value = Value;
                }
                else
                {
                    _value = null;
                    OnPropertyChanged(nameof(Value));
                }
                OnPropertyChanged(nameof(IsCustom));
            }
        }

        public static implicit operator T(DynamicProperty<T> property) { return property.Value; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
