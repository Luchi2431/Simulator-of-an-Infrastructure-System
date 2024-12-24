using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace NetworkService.ViewModel
{
    public class NetworkEntitiesViewModel : ClassINotifyPropertyChanged
    {
        #region Initialize
        private int _id = 0;

        private string errorMSg = "";
        public List<string> ComboBoxItems { get; set; } = new List<string>()
        {
            "RTD",
            "TermoSprega",
        };

        public ObservableCollection<Entity> EntitiesToShow { get; set; }
        public ObservableCollection<Entity> Entities { get; set; }
        public ObservableCollection<Entity> EntitiesFiltered { get; set; }

       

        //Cuvanje Filtera
        public Filter SelectedFilter { get; set; }
        public string NewFilterName { get; set; }
        public ClassICommand SaveFilterCommand { get; set; }
        public ClassICommand LoadFilterCommand { get; set; }

        public ObservableCollection<Filter> SavedFilters { get; set; }


        public ClassICommand AddEntityCommand { get; set; }
        public ClassICommand DeleteEntityCommand { get; set; }
        public ClassICommand FilterEntityCommand { get; set; }
        public ClassICommand ResetFilterCommand { get; set; }

        // For add entity 
        private EntityType currentEntityType = new EntityType();

        // Entity selected in table
        private Entity selectedEntity;
      
        //FIlter
        public ObservableCollection<string> TypeList { get; set; }
        public string SelectedType { get; set; }
        public string IdFilterValue { get; set; }


        public NetworkEntitiesViewModel()
        {
            Entities = new ObservableCollection<Entity>();
            EntitiesFiltered = new ObservableCollection<Entity>();
            EntitiesToShow = Entities;
            TypeList = new ObservableCollection<string>(ComboBoxItems);

            AddEntityCommand = new ClassICommand(OnAdd);
            DeleteEntityCommand = new ClassICommand(OnDelete, CanDelete);
            FilterEntityCommand = new ClassICommand(OnFilter);
            ResetFilterCommand = new ClassICommand(OnResetFilter);

            SavedFilters = new ObservableCollection<Filter>();

            SaveFilterCommand = new ClassICommand(OnSaveFilter);
            LoadFilterCommand = new ClassICommand(OnLoadFilter);

        }
        #endregion

        #region SaveFilter

        private void OnSaveFilter()
        {
            if (!string.IsNullOrEmpty(NewFilterName))
            {
                var filter = new Filter
                {
                    Name = NewFilterName,
                    SelectedType = SelectedType,
                    IdFilterValue = IdFilterValue,
                    IsLessThanSelected = IsLessThanSelected,
                    IsGreaterThanSelected = IsGreaterThanSelected,
                    IsEqualSelected = IsEqualSelected
                };
                SavedFilters.Add(filter);
            }
        }

        private void OnLoadFilter()
        {
            if (SelectedFilter != null)
            {
                SelectedType = SelectedFilter.SelectedType;
                IdFilterValue = SelectedFilter.IdFilterValue;
                IsLessThanSelected = SelectedFilter.IsLessThanSelected;
                IsGreaterThanSelected = SelectedFilter.IsGreaterThanSelected;
                IsEqualSelected = SelectedFilter.IsEqualSelected;

                OnFilter();
            }
        }


        #endregion






        #region FilterBTN

        private bool _isLessThanSelected;
        public bool IsLessThanSelected
        {
            get { return _isLessThanSelected; }
            set
            {
                _isLessThanSelected = value;
                OnPropertyChanged(nameof(IsLessThanSelected));
            }
        }

        private bool _isGreaterThanSelected;
        public bool IsGreaterThanSelected
        {
            get { return _isGreaterThanSelected; }
            set
            {
                _isGreaterThanSelected = value;
                OnPropertyChanged(nameof(IsGreaterThanSelected));
            }
        }

        private bool _isEqualSelected;
        public bool IsEqualSelected
        {
            get { return _isEqualSelected; }
            set
            {
                _isEqualSelected = value;
                OnPropertyChanged(nameof(IsEqualSelected));
            }
        }

        private void OnFilter()
        {
            EntitiesFiltered.Clear();
            try
            {
                IEnumerable<Entity> filteredEntities = Entities;

                // Filter by type if selected
                if (!string.IsNullOrEmpty(SelectedType))
                {
                    filteredEntities = filteredEntities.Where(e => e.Type.Type == SelectedType);
                }

                // Filter by ID condition
                if (int.TryParse(IdFilterValue, out int idFilter))
                {
                    if (IsLessThanSelected)
                    {
                        filteredEntities = filteredEntities.Where(e => e.Id < idFilter);
                    }
                    else if (IsGreaterThanSelected)
                    {
                        filteredEntities = filteredEntities.Where(e => e.Id > idFilter);
                    }
                    else if (IsEqualSelected)
                    {
                        filteredEntities = filteredEntities.Where(e => e.Id == idFilter);
                    }
                }

                foreach (var entity in filteredEntities)
                {
                    EntitiesFiltered.Add(entity);
                }

                EntitiesToShow = EntitiesFiltered;
                OnPropertyChanged(nameof(EntitiesToShow));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        #endregion

        #region ResetFilterBTN
        private void OnResetFilter()
        {
            SelectedType = null;
            IdFilterValue = null;
            IsLessThanSelected = false;
            IsGreaterThanSelected = false;
            IsEqualSelected = false;
            OnFilter();
        }
        #endregion

        #region DeletEntityBTN
        public Entity SelectedEntity
        {
            get { return selectedEntity; }
            set
            {
                selectedEntity = value;
                DeleteEntityCommand.RaiseCanExecuteChanged();
            }
        }
        private void OnDelete()
        {
            Entities.Remove(SelectedEntity);
            if (EntitiesFiltered.Contains(SelectedEntity))
            {
                EntitiesFiltered.Remove(SelectedEntity);
            }
        }

        private bool CanDelete()
        {
            return SelectedEntity != null;
        }
        #endregion

        #region AddEntityBTN
        public string ErrorMSg
        {
            get { return errorMSg; }
            set
            {
                errorMSg = value;
                OnPropertyChanged("ErrorMSg");
            }
        }
        public EntityType CurrentEntityType
        {
            get { return currentEntityType; }
            set
            {
                currentEntityType = value;
                OnPropertyChanged("CurrentEntityType");
            }
        }

        public void OnAdd()
        {
            string imgPath = "";
            if (CurrentEntityType.Type == null)
            {
                ErrorMSg = "Need To Choose Type!";
                return;
            }
            else if (CurrentEntityType.Type == "RTD")
            {
                imgPath = "pack://application:,,,/NetworkService;component/Images/rtd1.jpeg";
            }
            else
            {
                imgPath = "pack://application:,,,/NetworkService;component/Images/termosprega1.jpeg";
            }
            ErrorMSg = "";
            try
            {
                Entities.Add(new Entity()
                {
                    Id = _id,
                    Name = $"Entity_{_id++}",
                    Value = 0,
                    Type = new EntityType() { Type = CurrentEntityType.Type, ImgSrc = imgPath }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{DateTime.Now} - {ex.Message}");
            }
        }
        #endregion


    }
}
