using CommunityToolkit.Mvvm.ComponentModel;

namespace DynamicProperty.Models
{
    public class DynamicModel : ObservableValidator
    {
        private readonly DefaultsModel defaults;

        public DynamicModel(DefaultsModel defaults)
        {
            this.defaults = defaults;
            NumberOfFoo = new DynamicProperty<int>(() => defaults.NumberOfFoo, nameof(defaults.NumberOfFoo), defaults);
        }
        public DynamicProperty<int> NumberOfFoo { get; }

    }
}
