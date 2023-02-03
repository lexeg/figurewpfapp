using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FigureWpfApp.Commands;
using FigureWpfApp.Controls;
using FigureWpfApp.Enums;
using FigureWpfApp.Exceptions;
using FigureWpfApp.Models;

namespace FigureWpfApp.ViewModels
{
    public class FiguresViewModel : INotifyPropertyChanged
    {
        private FigureTypeModel _selectedFigureType;
        private FigureBase _selectedFigure;
        private Control _currentControlTemplate;

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
                new FigureTypeModel(Enums.FigureTypes.Square),
                new FigureTypeModel(Enums.FigureTypes.Triangle),
                new FigureTypeModel(Enums.FigureTypes.Circle)
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
                        case Enums.FigureTypes.Circle:
                            Figures.Add(new Circle(figureName, ((CircleControl)_currentControlTemplate).Diameter));
                            break;
                        case Enums.FigureTypes.Square:
                            Figures.Add(new Square(figureName, ((SquareControl)_currentControlTemplate).Size));
                            break;
                        case Enums.FigureTypes.Triangle:
                            var control = ((TriangleControl)_currentControlTemplate);
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
            get => _selectedFigureType;
            set
            {
                _selectedFigureType = value;
                OnPropertyChanged(nameof(SelectedFigureType));
            }
        }

        public FigureBase SelectedFigure
        {
            get => _selectedFigure;
            set
            {
                _selectedFigure = value;
                OnPropertyChanged(nameof(SelectedFigure));
            }
        }

        public bool HasFigures => Figures != null && Figures.Count > 0;

        public Control CurrentControlTemplate => _currentControlTemplate;

        public List<FigureTypeModel> FigureTypes { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void SetControlTemplate(FigureTypes figureType)
        {
            switch (figureType)
            {
                case Enums.FigureTypes.Circle:
                    _currentControlTemplate = new CircleControl();
                    break;
                case Enums.FigureTypes.Square:
                    _currentControlTemplate = new SquareControl();
                    break;
                case Enums.FigureTypes.Triangle:
                    _currentControlTemplate = new TriangleControl();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(figureType), figureType, null);
            }
        }
    }
}
