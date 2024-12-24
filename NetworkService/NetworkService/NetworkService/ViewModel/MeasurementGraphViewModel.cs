using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace NetworkService.ViewModel
{
    public class MeasurementGraphViewModel : ClassINotifyPropertyChanged
    {
        #region Initialize
        private int keyCount = -1;
        private List<string> comboBoxItems;
        private string selectedEntity;
        private string selectedEntityToShow;
        public Dictionary<int, Entity> ComboBoxDataEntity { get; set; } = new Dictionary<int, Entity>();
        public static Graph ElementHeights { get; set; } = new Graph();
        public BindingList<Entity> EntitiesInList { get; set; }

        //
        public Dictionary<string, List<Graph>> MeasurementDict { get; set; }

        public ObservableCollection<Graph> Grafikoni { get; set; }

        public ClassICommand ShowCommand { get; set; }

        public List<string> ComboBoxItems
        {
            get { return comboBoxItems; }
            set
            {
                comboBoxItems = value;
                OnPropertyChanged("ComboBoxItems");
            }
        }

        public string SelectedEntity
        {
            get { return selectedEntity; }
            set
            {
                selectedEntity = value;

                if (SelectedEntity != null && !ComboBoxItems.Contains(SelectedEntity))
                {
                    SelectedEntity = null;
                }
                else if (SelectedEntity != null)
                {
                    UpdateGraphForSelectedEntity();
                }
                ShowCommand?.RaiseCanExecuteChanged();
                OnPropertyChanged("SelectedEntity");
            }
        }

        public string SelectedEntityToShow
        {
            get { return selectedEntityToShow; }
            set
            {
                selectedEntityToShow = value;
                OnPropertyChanged("SelectedEntityToShow");
            }
        }

        public MeasurementGraphViewModel()
        {
            EntitiesInList = new BindingList<Entity>();

            EntitiesInList.ListChanged += OnEntitiesInListChanged;

            Grafikoni = new ObservableCollection<Graph>();
            for(int i = 0;i<5;i++)
            {
                Graph graph = new Graph();
                Grafikoni.Add(graph);
            }



            UpdateComboBoxItems();

            ShowCommand = new ClassICommand(OnShow, CanShow);

        }


        #endregion

        #region ShowButton
        public void OnShow()
        {
            SelectedEntityToShow = SelectedEntity;
            keyCount = 0;
            foreach (var entity in EntitiesInList)
            {
                if (entity.Name == SelectedEntityToShow)
                {
                    break;
                }
                keyCount++;
            }
            
            UpdateGraphForEntityId(keyCount);
        }

        private bool CanShow()
        {
            return SelectedEntity != null;
        }
        #endregion

        #region ComboBox
        private void OnEntitiesInListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateComboBoxItems();

            if (SelectedEntity != null && !ComboBoxItems.Contains(SelectedEntity))
            {
                SelectedEntity = null;
            }

            UpdateGraphForSelectedEntity();
        }

        private void UpdateComboBoxItems()
        {
            ComboBoxItems = EntitiesInList.Select(entity => entity.Name).ToList();
            OnPropertyChanged(nameof(ComboBoxItems));
        }

        #endregion


        private void UpdateGraphForSelectedEntity()
        {
            if (string.IsNullOrEmpty(SelectedEntity))
                return;

            var selectedEntityId = ComboBoxDataEntity.Values
                .FirstOrDefault(e => e.Name == SelectedEntity)?.Id ?? -1;

            if (selectedEntityId == -1)
                return;

            UpdateGraphForEntityId(selectedEntityId);
        }

        public static void UpdateGraphForEntity(Entity entity)
        {
            if (entity == null)
                return;

            UpdateGraphForEntityId(entity.Id);
        }

        private static void UpdateGraphForEntityId(int entityId)
        {
            if (entityId == -1)
                return;

            List<int> values = new List<int>();
            List<DateTime> dates = new List<DateTime>();

            string[] lines = File.ReadAllLines("Log.txt");
            List<string> l = lines.ToList();
            l.Reverse();

            foreach (string s in l)
            {
                try
                {
                    // Splitovanje linije po delimitatorima "; " i ", "
                    var parts = s.Split(new[] { "; " }, StringSplitOptions.None);

                    if (parts.Length == 2)
                    {
                        // Parsiranje datuma i vremena
                        DateTime dt = DateTime.Parse(parts[0]);

                        // Splitovanje entiteta i vrednosti
                        var entityParts = parts[1].Split(new[] { ", " }, StringSplitOptions.None);
                        if (entityParts.Length == 2)
                        {
                            // Parsiranje ID entiteta
                            string entityString = entityParts[0];
                            if (entityString.StartsWith("Entitet_"))
                            {
                                int id = int.Parse(entityString.Substring("Entitet_".Length));

                                // Provera da li je ID entiteta odgovarajući
                                if (id == entityId)
                                {
                                    // Parsiranje vrednosti
                                    int value = int.Parse(entityParts[1]);

                                    // Dodavanje vrednosti u liste
                                    values.Add(value);
                                    dates.Add(dt);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Obrada greške (po potrebi)
                    Console.WriteLine($"Error parsing line: {s}. Error: {ex.Message}");
                }

                // Prekidanje petlje nakon prikupljanja 5 podataka
                if (dates.Count == 5)
                    break;
            }

            // Ažuriranje elemenata grafa
            UpdateGraphElements(values);
        }
    


        private static void UpdateGraphElements(List<int> values)
        {

            int duzina = values.Count();
            ElementHeights.Height1 = duzina >= 1 ? CalcHg(values[0]) : -1;
            ElementHeights.Fill1 = duzina >= 1 && values[0] >= 250 && values[0] <= 350 ? "Blue" : "Red";

            ElementHeights.Height2 = duzina >= 2 ? CalcHg(values[1]) : -1;
            ElementHeights.Fill2 = duzina >= 2 && values[1] >= 250 && values[1] <= 350 ? "Blue" : "Red";

            ElementHeights.Height3 = duzina >= 3 ? CalcHg(values[2]) : -1;
            ElementHeights.Fill3 = duzina >= 3 && values[2] >= 250 && values[2] <= 350 ? "Blue" : "Red";

            ElementHeights.Height4 = duzina >= 4 ? CalcHg(values[3]) : -1;
            ElementHeights.Fill4 = duzina >= 4 && values[3] >= 250 && values[3] <= 350 ? "Blue" : "Red";

            ElementHeights.Height5 = duzina >= 5 ? CalcHg(values[4]) : -1;
            ElementHeights.Fill5 = duzina >= 5 && values[4] >= 250 && values[4] <= 350 ? "Blue" : "Red";
        }


        public static double CalcHg(double value)
        {
            double vrednost = value;
            return vrednost;
        }
    }
}
