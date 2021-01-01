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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Arkanoid.ModelWidoku
{
    class GraModelWidoku : INotifyPropertyChanged
    {
        #region properties
        public ObservableCollection<Ball> Balls { get; set; }
        public ObservableCollection<Palette> Palette { get; set; }
        private DispatcherTimer time { get; set; }
        private DispatcherTimer timer { get; set; }
        public double gameFieldWidth { get; set; }
        public double gameFieldHeight { get; set; }

        public ICommand KeyUpCommandCommand { get; set; }

        //todo do wywalenie
        private double GameRefreshingSpeed = 0.01;

        Random random = new Random();

        #endregion

        #region ctor

        public GraModelWidoku()
        {
            gameFieldHeight = GameField.gameFieldHeight = 100;
            gameFieldWidth = GameField.gameFieldWidth = 300;

            Palette = new ObservableCollection<Palette>();
            Palette.Add(new Palette { xLocation = 200, yLocation = 10, paletteMovingSpeed = 5 });
            Balls = new ObservableCollection<Ball>();
            Balls.Add(new Ball { xLocation = 50, yLocation = 50, speed = 3, angle = 30 });

            timer = new DispatcherTimer(TimeSpan.FromSeconds(GameRefreshingSpeed),
                DispatcherPriority.Render,
                (sender, args) => Moves(),
                Application.Current.Dispatcher);
            timer.Stop();

            GameStart();
        }

        #endregion

        #region methods

        private void Moves()
        {
            (Balls[0] as Ball).Move();
            Palette[0].Move();
            Balls[0].PaletteBounce(Palette[0]);
            OnPropertyChanged("GameObjects");
        }

        private void GameStart()
        {
            timer.Interval = TimeSpan.FromSeconds(GameRefreshingSpeed);
            timer.Start();

            time = new DispatcherTimer(TimeSpan.FromSeconds(0.05),
                DispatcherPriority.Render,
                (sender, args) => TimeClick(),
                Application.Current.Dispatcher);
        }

        private void TimeClick()
        {
            OnPropertyChanged("CzasGry");
        }

        private void ShootBall()
        {

        }

        #endregion

        #region commands

        #endregion

        #region events

        internal void KeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                Palette[0].movingDirection = Directions.Left;
            }
            else if(e.Key == Key.Right)
            {
                Palette[0].movingDirection = Directions.Right;
            }
        }

        internal void KeyUp(KeyEventArgs e)
        {
            if (e.Key == Key.Left || e.Key == Key.Right)
                Palette[0].movingDirection = Directions.Stopped;

        }

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
