using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Arkanoid.Model
{
    class Ball : GameObject, INotifyPropertyChanged
    {
        #region properties

        public double size { get; private set; }
        public double speed { get; set; }
        public double vector { get; set; }

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
