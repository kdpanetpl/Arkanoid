using Arkanoid.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace Arkanoid.ModelWidoku
{
    class GraModelWidoku : INotifyPropertyChanged
    {
        #region properties
        public ObservableCollection<GameObject> GameObjects { get; set; }
        private DispatcherTimer Czas { get; set; }
        private DispatcherTimer Stoper { get; set; }

        //todo do wywalenie
        private double Predkosc = 0.01;

        Random random = new Random();

        #endregion

        #region ctor

        public GraModelWidoku()
        {
            GameField.gameFieldHeight = 100;
            GameField.gameFieldWidth = 200;
            GameObjects = new ObservableCollection<GameObject>();
            GameObjects.Add(new Ball { xLocation = 50, yLocation = 50, speed = 3, angle = 30 });

            Stoper = new DispatcherTimer(TimeSpan.FromSeconds(Predkosc),
                DispatcherPriority.Render,
                (sender, args) => Ruch(),
                Application.Current.Dispatcher);
            Stoper.Stop();

            RozpoczecieGry();
        }

        #endregion

        #region methods

        private void Ruch()
        {
            (GameObjects[0] as Ball).Move();
            OnPropertyChanged("GameObjects");
        }

        private void RozpoczecieGry()
        {
            Stoper.Interval = TimeSpan.FromSeconds(Predkosc);
            Stoper.Start();

            Czas = new DispatcherTimer(TimeSpan.FromSeconds(0.05),
                DispatcherPriority.Render,
                (sender, args) => CzasKlik(),
                Application.Current.Dispatcher);
        }

        private void CzasKlik()
        {
            OnPropertyChanged("CzasGry");
        }

        #endregion

        #region events

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(params string[] nazwyWlasnosci)
        {
            if (PropertyChanged != null)
            {
                foreach (string nazwaWlasnosci in nazwyWlasnosci)
                    PropertyChanged(this, new PropertyChangedEventArgs(nazwaWlasnosci));
            }
        }

        #endregion
    }
}
