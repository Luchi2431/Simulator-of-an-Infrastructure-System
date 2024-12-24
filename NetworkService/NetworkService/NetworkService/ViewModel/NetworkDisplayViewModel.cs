using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NetworkService.ViewModel
{
    public class NetworkDisplayViewModel : ClassINotifyPropertyChanged
    {

        #region Initialize
        public BindingList<Entity> EntitiesInList { get; set; }
        public ObservableCollection<Brush> BorderBrushCollection { get; set; }
        public ObservableCollection<Canvas> CanvasCollection { get; set; }
        public ObservableCollection<MyLine> LineCollection { get; set; }
        public ObservableCollection<string> DescriptionCollection { get; set; }

        private Entity selectedEntity;

        private Entity draggedItem = null;
        private bool dragging = false;
        public int draggingSourceIndex = -1;

        public ClassICommand<object> DropEntityOnCanvas { get; set; }
        public ClassICommand<object> LeftMouseButtonDownOnCanvas { get; set; }
        public ClassICommand MouseLeftButtonUp { get; set; }
        public ClassICommand<object> SelectionChanged { get; set; }
        public ClassICommand<object> FreeCanvas { get; set; }
        public ClassICommand<object> RightMouseButtonDownOnCanvas { get; set; }
        public ClassICommand OrganizeAllCommand { get; set; }

        private bool isLineSourceSelected = false;
        private int sourceCanvasIndex = -1;
        private int destinationCanvasIndex = -1;
        private MyLine currentLine = new MyLine();
        private Point point1 = new Point();
        private Point point2 = new Point();

        public NetworkDisplayViewModel()
        {
            EntitiesInList = new BindingList<Entity>();
            LineCollection = new ObservableCollection<MyLine>();
            CanvasCollection = new ObservableCollection<Canvas>();
            BorderBrushCollection = new ObservableCollection<Brush>();
            DescriptionCollection = new ObservableCollection<string>();

            for (int i = 0; i < 12; i++)
            {
                BorderBrushCollection.Add(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1E1F22")));

                CanvasCollection.Add(new Canvas()
                {
                    Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#949BA4")),
                    AllowDrop = true
                });

                DescriptionCollection.Add(" ");
            }

            DropEntityOnCanvas = new ClassICommand<object>(OnDrop);
            LeftMouseButtonDownOnCanvas = new ClassICommand<object>(OnLeftMouseButtonDown);
            MouseLeftButtonUp = new ClassICommand(OnMouseLeftButtonUp);
            SelectionChanged = new ClassICommand<object>(OnSelectionChanged);
            FreeCanvas = new ClassICommand<object>(OnFreeCanvas);
            RightMouseButtonDownOnCanvas = new ClassICommand<object>(OnRightMouseButtonDown);
            OrganizeAllCommand = new ClassICommand(onOrganize);

        }
        #endregion

        #region OrganizeBTN
        private void onOrganize()
        {
            List<Entity> addedEntities = new List<Entity>();
            try
            {
                int index = 0;
                foreach (var item in EntitiesInList)
                {
                    while (index < CanvasCollection.Count)
                    {
                        if (CanvasCollection[index].Resources != null && CanvasCollection[index].Resources["taken"] == null)
                        {
                            BitmapImage logo = new BitmapImage();
                            logo.BeginInit();
                            logo.UriSource = new Uri(item.Type.ImgSrc, UriKind.RelativeOrAbsolute);
                            logo.EndInit();

                            CanvasCollection[index].Background = new ImageBrush(logo);
                            CanvasCollection[index].Resources.Add("taken", true);
                            CanvasCollection[index].Resources.Add("data", item);
                            BorderBrushCollection[index] = (item.IsValueValid()) ? Brushes.Green : Brushes.Red;
                            DescriptionCollection[index] = ($"ID: {item.Id} Value: {item.Value}");

                            addedEntities.Add(item);

                            break;
                        }
                        index++;
                    }
                    index = 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            foreach (var entity in addedEntities)
            {
                EntitiesInList.Remove(entity);
            }
        }
        #endregion

        #region GetCanvasIndexForEntityId
        public int GetCanvasIndexForEntityId(int entityId)
        {
            for (int i = 0; i < CanvasCollection.Count; i++)
            {
                Entity entity = (CanvasCollection[i].Resources["data"]) as Entity;

                if ((entity != null) && (entity.Id == entityId))
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion

        #region OnDrop
        private void OnDrop(object parameter)
        {
            if (draggedItem != null)
            {
                int index = Convert.ToInt32(parameter);

                if (CanvasCollection[index].Resources["taken"] == null)
                {
                    BitmapImage logo = new BitmapImage();
                    logo.BeginInit();
                    logo.UriSource = new Uri(draggedItem.Type.ImgSrc, UriKind.RelativeOrAbsolute);
                    logo.EndInit();

                    CanvasCollection[index].Background = new ImageBrush(logo);
                    CanvasCollection[index].Resources.Add("taken", true);
                    CanvasCollection[index].Resources.Add("data", draggedItem);
                    BorderBrushCollection[index] = (draggedItem.IsValueValid()) ? Brushes.Green : Brushes.Red;
                    DescriptionCollection[index] = ($"ID: {draggedItem.Id} Value: {draggedItem.Value}");

                    // prevlacenje iz drugog canvasa
                    if (draggingSourceIndex != -1)
                    {
                        CanvasCollection[draggingSourceIndex].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#949BA4"));

                        CanvasCollection[draggingSourceIndex].Resources.Remove("taken");
                        CanvasCollection[draggingSourceIndex].Resources.Remove("data");
                        BorderBrushCollection[draggingSourceIndex] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1E1F22"));
                        DescriptionCollection[draggingSourceIndex] = (" ");


                        UpdateLinesForCanvas(draggingSourceIndex, index);

                        if (sourceCanvasIndex != -1)
                        {
                            isLineSourceSelected = false;
                            sourceCanvasIndex = -1;
                            point1 = new Point();
                            point2 = new Point();
                            currentLine = new MyLine();
                        }

                        draggingSourceIndex = -1;
                    }

                    // brisanje iz treeViewa
                    if (EntitiesInList.Contains(draggedItem))
                    {
                        EntitiesInList.Remove(draggedItem);
                    }
                }
            }
        }

        #endregion

        #region UpdateEntityOnCanvas
        public void UpdateEntityOnCanvas(Entity entity)
        {
            int canvasIndex = GetCanvasIndexForEntityId(entity.Id);

            if (canvasIndex != -1)
            {
                DescriptionCollection[canvasIndex] = ($"ID: {entity.Id} Value: {entity.Value}");
                if (entity.IsValueValid())
                {
                    BorderBrushCollection[canvasIndex] = Brushes.Green;
                }
                else
                {
                    BorderBrushCollection[canvasIndex] = Brushes.Red;
                }
            }
        }
        #endregion

        #region Delete
        
        public void DeleteEntityFromCanvas(Entity entity)
        {
            int canvasIndex = GetCanvasIndexForEntityId(entity.Id);

            if (canvasIndex != -1)
            {
                CanvasCollection[canvasIndex].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#949BA4"));
                CanvasCollection[canvasIndex].Resources.Remove("taken");
                CanvasCollection[canvasIndex].Resources.Remove("data");
                BorderBrushCollection[canvasIndex] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1E1F22"));
                DescriptionCollection[canvasIndex] = ($" ");

                DeleteLinesForCanvas(canvasIndex);
            }
        }
        private void DeleteLinesForCanvas(int canvasIndex)
        {
            List<MyLine> linesToDelete = new List<MyLine>();

            for (int i = 0; i < LineCollection.Count; i++)
            {
                if ((LineCollection[i].Source == canvasIndex) || (LineCollection[i].Destination == canvasIndex))
                {
                    linesToDelete.Add(LineCollection[i]);
                }
            }

            foreach (MyLine line in linesToDelete)
            {
                LineCollection.Remove(line);
            }
        }
        private void OnFreeCanvas(object parameter)
        {
            int index = Convert.ToInt32(parameter);

            if (CanvasCollection[index].Resources["taken"] != null)
            {
                // Crtanje linije se prekida kad se ukloni element prilikom stavljanja tacaka
                if (sourceCanvasIndex != -1)
                {
                    isLineSourceSelected = false;
                    sourceCanvasIndex = -1;
                    point1 = new Point();
                    point2 = new Point();
                    currentLine = new MyLine();
                }

                DeleteLinesForCanvas(index);

                EntitiesInList.Add((Entity)CanvasCollection[index].Resources["data"]);
                CanvasCollection[index].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#949BA4"));
                CanvasCollection[index].Resources.Remove("taken");
                CanvasCollection[index].Resources.Remove("data");
                BorderBrushCollection[index] = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1E1F22"));
                DescriptionCollection[index] = ($" ");
            }
        }
        public Entity SelectedEntity
        {
            get { return selectedEntity; }
            set
            {
                selectedEntity = value;
                OnPropertyChanged("SelectedEntity");
            }
        }
        #endregion

        #region LeftMouseBTN
        private void OnLeftMouseButtonDown(object parameter)
        {
            if (!dragging)
            {
                int index = Convert.ToInt32(parameter);

                if (CanvasCollection[index].Resources["taken"] != null)
                {
                    dragging = true;
                    draggedItem = (Entity)(CanvasCollection[index].Resources["data"]);
                    draggingSourceIndex = index;
                    DragDrop.DoDragDrop(CanvasCollection[index], draggedItem, DragDropEffects.Move);
                }
            }
        }
        private void OnMouseLeftButtonUp()
        {
            draggedItem = null;
            SelectedEntity = null;
            dragging = false;
            draggingSourceIndex = -1;
        }
        #endregion

        #region SelectionChanged
        private void OnSelectionChanged(object parameter)
        {
            if (!dragging)
            {
                dragging = true;
                draggedItem = SelectedEntity;
                DragDrop.DoDragDrop((ListView)parameter, draggedItem, DragDropEffects.Move);
            }
        }
        #endregion

        #region RightMouseButton
        private void OnRightMouseButtonDown(object parameter)
        {
            int index = Convert.ToInt32(parameter);

            if (CanvasCollection[index].Resources["taken"] != null)
            {
                
                if (!isLineSourceSelected) //da li je izabrana pocetna tacka
                {
                    sourceCanvasIndex = index;

                    point1 = GetPointForCanvasIndex(sourceCanvasIndex);

                    currentLine.X1 = point1.X;
                    currentLine.Y1 = point1.Y;
                    currentLine.Source = sourceCanvasIndex;

                    isLineSourceSelected = true;
                }
                else 
                {
                    destinationCanvasIndex = index;

                    if ((sourceCanvasIndex != destinationCanvasIndex) && !DoesLineAlreadyExist(sourceCanvasIndex, destinationCanvasIndex))
                    {
                        point2 = GetPointForCanvasIndex(destinationCanvasIndex);

                        currentLine.X2 = point2.X;
                        currentLine.Y2 = point2.Y;
                        currentLine.Destination = destinationCanvasIndex;

                        LineCollection.Add(new MyLine
                        {
                            X1 = currentLine.X1,
                            Y1 = currentLine.Y1,
                            X2 = currentLine.X2,
                            Y2 = currentLine.Y2,
                            Source = currentLine.Source,
                            Destination = currentLine.Destination
                        });

                        isLineSourceSelected = false;

                        point1 = new Point();
                        point2 = new Point();
                        currentLine = new MyLine();
                    }
                    else
                    {
                        // Pocetak i kraj linije su u istom canvasu

                        isLineSourceSelected = false;

                        point1 = new Point();
                        point2 = new Point();
                        currentLine = new MyLine();
                    }
                }
            }
            else
            {
                // Canvas na koji se postavlja tacka nije zauzet

                isLineSourceSelected = false;

                point1 = new Point();
                point2 = new Point();
                currentLine = new MyLine();
            }
        }
        #endregion

        #region Line
        private void UpdateLinesForCanvas(int sourceCanvas, int destinationCanvas)
        {
            for (int i = 0; i < LineCollection.Count; i++)
            {
                if (LineCollection[i].Source == sourceCanvas)
                {
                    Point newSourcePoint = GetPointForCanvasIndex(destinationCanvas);
                    LineCollection[i].X1 = newSourcePoint.X;
                    LineCollection[i].Y1 = newSourcePoint.Y;
                    LineCollection[i].Source = destinationCanvas;
                }
                else if (LineCollection[i].Destination == sourceCanvas)
                {
                    Point newDestinationPoint = GetPointForCanvasIndex(destinationCanvas);
                    LineCollection[i].X2 = newDestinationPoint.X;
                    LineCollection[i].Y2 = newDestinationPoint.Y;
                    LineCollection[i].Destination = destinationCanvas;
                }
            }
        }

        private bool DoesLineAlreadyExist(int source, int destination)
        {
            foreach (MyLine line in LineCollection)
            {
                if ((line.Source == source) && (line.Destination == destination))
                {
                    return true;
                }
                if ((line.Source == destination) && (line.Destination == source))
                {
                    return true;
                }
            }
            return false;
        }
        // Centralna tacka 
        private Point GetPointForCanvasIndex(int canvasIndex)
        {
            double x = 0, y = 0;

            for (int row = 0; row <= 3; row++)
            {
                for (int col = 0; col <= 2; col++)
                {
                    int currentIndex = row * 3 + col;

                    if (canvasIndex == currentIndex)
                    {
                        x = 50 + (col * 135);
                        y = 50 + (row * 135);

                        break;
                    }
                }
            }
            return new Point(x, y);
        }
        #endregion






    }
}
