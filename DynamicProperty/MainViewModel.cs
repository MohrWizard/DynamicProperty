using DynamicProperty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProperty
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Defaults = new DefaultsModel
            {
                NumberOfFoo = 23
            };
            Model = new DynamicModel(Defaults);
            Model.NumberOfFoo.Value = 30;
        }

        public DynamicModel Model { get; set; }
        public DefaultsModel Defaults { get; set; }
    }
}
