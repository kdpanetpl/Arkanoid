using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Arkanoid.ModelWidoku;

namespace Arkanoid.Model
{
    class Ball : GameObject, INotifyPropertyChanged
    {
        #region properties

        public double size { get; private set; }
        public double speed { get; set; }
        public double angle { get; set; }

        #endregion

        #region ctor

        public Ball()
        {
            size = 5;
            fill = new RadialGradientBrush(Colors.Black, Colors.LightGray);
            geometry = new EllipseGeometry(new Point(xLocation, yLocation), size, size);
        }

        #endregion

        #region methods

        public void Move()
        {
            xLocation += speed * Math.Cos(angle / 180 * Math.PI);
            yLocation += speed * Math.Sin(angle / 180 * Math.PI);

            if (xLocation > GameField.gameFieldWidth || xLocation < 0)
            {
                if (angle > 0)
                {
                    angle += 90;
                    if (angle > 180)
                        angle -= 180;
                }
                else
                {
                    angle -= 90;
                    if (angle < -180)
                        angle += 180;
                }

            }

            if (xLocation > GameField.gameFieldWidth)
                xLocation = GameField.gameFieldWidth;
            if (xLocation < 0)
                xLocation = 0;

            if (yLocation > GameField.gameFieldHeight || yLocation < 0)
            {
                angle = -angle;
            }


            if (yLocation > GameField.gameFieldHeight)
                yLocation = GameField.gameFieldHeight;
            if (yLocation < 0)
                yLocation = 0;

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
