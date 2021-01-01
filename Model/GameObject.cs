using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Arkanoid.Model
{
    class GameObject
    {
        public double xLocation { get; set; }
        public double yLocation { get; set; }
        public Brush fill { get; set; }
        public Geometry geometry { get; set; }
    }
}
