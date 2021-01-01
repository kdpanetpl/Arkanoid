﻿using Arkanoid.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Arkanoid.ModelWidoku
{
    class GraModelWidoku : INotifyPropertyChanged
    {
        #region properties
        public ObservableCollection<GameObject> GameObjects { get; set; }
        public int gameFieldWidth { get; set; }
        public int gameFieldHeight { get; set; }

        Random random = new Random();

        #endregion

        #region ctor

        public GraModelWidoku()
        {
            gameFieldHeight = 300;
            gameFieldWidth = 500;
            GameObjects = new ObservableCollection<GameObject>();
            GameObjects.Add(new Ball { xLocation = 50, yLocation = 50, speed = 1, vector = 0 });
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
