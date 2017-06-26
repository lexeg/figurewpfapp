using System;
using FigureWpfApp.Commands;
using FigureWpfApp.Controls;
using FigureWpfApp.Figures;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace FigureWpfApp
{
    public class FiguresViewModel : INotifyPropertyChanged
    {
        private FigureTypeModel m_SelectedFigureType;
        private FigureBase m_SelectedFigure;
        private Control m_CurrentControlTemplate;

        public FiguresViewModel()
        {
            Figures = new ObservableCollection<FigureBase>();
            Figures.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add || e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove || e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Reset)
                {
                    OnPropertyChanged(nameof(HasFigures));
                }
            };
            FigureTypes = new List<FigureTypeModel>
            {
                new FigureTypeModel(FigureType.Square),
                new FigureTypeModel(FigureType.Triangle),
                new FigureTypeModel(FigureType.Circle)
            };
            SelectedFigureType = FigureTypes.First();
            SetControlTemplate(SelectedFigureType.GetFigureType);
            PropertyChanged += (s, e) =>
            {
                if (e.PropertyName.Equals(nameof(SelectedFigureType)))
                {
                    SetControlTemplate(SelectedFigureType.GetFigureType);
                    OnPropertyChanged(nameof(CurrentControlTemplate));
                }
            };

            AddFigure = new BaseAutoEventCommand(o =>
            {
                try
                {
                    var figureName = $"{SelectedFigureType.Name}_{Figures.Count}";
                    switch (SelectedFigureType.GetFigureType)
                    {
                        case FigureType.Circle:
                            Figures.Add(new Circle(figureName, ((CircleControl)m_CurrentControlTemplate).Diameter));
                            break;
                        case FigureType.Square:
                            Figures.Add(new Square(figureName, ((SquareControl)m_CurrentControlTemplate).Size));
                            break;
                        case FigureType.Triangle:
                            var control = ((TriangleControl)m_CurrentControlTemplate);
                            Figures.Add(new Triangle(figureName, control.FirstSide, control.SecondSide, control.ThirdSide));
                            break;
                    }
                }catch(NegativeException)
                {
                    MessageBox.Show("Размер фигуры должен быть положительным числом");
                }
            }, o => Figures != null);

            RemoveFigure = new BaseAutoEventCommand(o =>
            {
                var f = o as FigureBase;
                if (f == null) return;
                Figures.Remove(f);
            }, o => Figures != null && Figures.Count > 0);
        }

        public ObservableCollection<FigureBase> Figures { get; private set; }

        public ICommand AddFigure { get; private set; }
        public ICommand RemoveFigure { get; private set; }

        public FigureTypeModel SelectedFigureType
        {
            get { return m_SelectedFigureType; }
            set
            {
                m_SelectedFigureType = value;
                OnPropertyChanged(nameof(SelectedFigureType));
            }
        }

        public FigureBase SelectedFigure
        {
            get { return m_SelectedFigure; }
            set
            {
                m_SelectedFigure = value;
                OnPropertyChanged(nameof(SelectedFigure));
            }
        }

        public bool HasFigures => Figures != null && Figures.Count > 0;

        public Control CurrentControlTemplate => m_CurrentControlTemplate;

        public List<FigureTypeModel> FigureTypes { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void SetControlTemplate(FigureType figureType)
        {
            switch (figureType)
            {
                case FigureType.Circle:
                    m_CurrentControlTemplate = new CircleControl();
                    break;
                case FigureType.Square:
                    m_CurrentControlTemplate = new SquareControl();
                    break;
                case FigureType.Triangle:
                    m_CurrentControlTemplate = new TriangleControl();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(figureType), figureType, null);
            }
        }
    }
}
