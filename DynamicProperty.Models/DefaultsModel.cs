using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProperty.Models
{
    public class DefaultsModel : ObservableValidator
    {
        private int numberOfFoo;
        public int NumberOfFoo
        {
            get => numberOfFoo;
            set => SetProperty(ref numberOfFoo, value);
        }
    }
}
