using NetworkService.ViewModel;
using System.Collections.ObjectModel;

namespace NetworkService.Model
{
    public class Entity : ClassINotifyPropertyChanged
    {
        private int id;
        private string name;
        private EntityType type;
        private double value;

        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public double Value
        {
            get { return this.value; }
            set
            {
                if (this.value != value)
                {
                    this.value = value;
                    OnPropertyChanged("Value");
                    UpdateGraph();
                }
            }
        }

        public EntityType Type
        {
            get { return type; }
            set
            {
                if (type != value)
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
        }

        public bool IsValueValid()
        {
            bool isValid = false;

            if (Value >= 250 && Value <= 350)
            {
                isValid = true;
            }

            return isValid;
        }

        private void UpdateGraph()
        {
            // You can include logic here if needed to handle the specific value changes for the graph
            MeasurementGraphViewModel.UpdateGraphForEntity(this);
        }
    }
}
