using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Arkanoid.Model
{
    class Palette : GameObject, INotifyPropertyChanged
    {
        #region properties
        public int height { get; set; }
        public int width { get; set; }
        public bool isHoldingBall { get; set; }
        public Directions movingDirection { get; set; }
        public double paletteMovingSpeed { get; set; }

        #endregion

        #region ctor

        public Palette()
        {
            movingDirection = Directions.Stopped;
            height = 5;
            width = 30;
            geometry = new RectangleGeometry(new System.Windows.Rect(xLocation, yLocation, width, height));
            fill = new LinearGradientBrush(Colors.Red, Colors.Green, 45);
        }

        #endregion

        #region methods

        public void Move()
        {
            if (movingDirection == Directions.Stopped)
                return;

            xLocation += (int)movingDirection * paletteMovingSpeed;

            if (xLocation < 0)
                xLocation = 0;

            if (xLocation + width > GameField.gameFieldWidth)
                xLocation = GameField.gameFieldWidth - width;

            OnPropertyChanged("xLocation", "yLocation");
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
