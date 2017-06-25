using FigureWpfApp.Commands;
using FigureWpfApp.Controls;
using FigureWpfApp.Figures;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using System;

namespace FigureWpfApp
{
    public class FiguresViewModel : INotifyPropertyChanged
    {
        private FigureType m_SelectedFigureType;
        private FigureBase m_SelectedFigure;
        private Control m_CurrentControlTemplate;
        private Func<string, ControlTemplate> m_Func;

        public FiguresViewModel(Func<string, ControlTemplate> action)
        {
            m_Func = action;
            Figures = new ObservableCollection<FigureBase>();
            Figures.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add || e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove || e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Reset)
                {
                    OnPropertyChanged(nameof(HasFigures));
                }
            };
            FigureTypes = new List<FigureType>
            {
                FigureType.Square,
                FigureType.Triangle,
                FigureType.Circle
            };
            SetControlTemplate(SelectedFigureType);
            PropertyChanged += (s, e) =>
            {
                if (e.PropertyName.Equals(nameof(SelectedFigureType)))
                {
                    SetControlTemplate(SelectedFigureType);
                    OnPropertyChanged(nameof(CurrentControlTemplate));
                }
            };

            AddFigure = new BaseAutoEventCommand(o =>
            {
                var figureName = $"{SelectedFigureType.GetDescription()}_{Figures.Count}";
                switch (SelectedFigureType)
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

        public FigureType SelectedFigureType
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

        public bool HasFigures
        {
            get
            {
                return Figures != null && Figures.Count > 0;
            }
        }

        public Control CurrentControlTemplate { get { return m_CurrentControlTemplate; } }

        public List<FigureType> FigureTypes { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
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
            }
        }
    }
}
