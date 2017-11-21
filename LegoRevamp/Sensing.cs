using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego.Ev3.Desktop;
using Lego.Ev3.Core;

namespace LegoRevamp
{
    class Sensing
    {
        private Brick pBrick;

        public int CurrentDistance;
        public int CurrentGyro;
        public int CurrentColor;

        public Sensing(Brick _brick)
        {
            pBrick = _brick;
            pBrick.BrickChanged += ValuesChanged;
        }

        public void ValuesChanged(object sender, BrickChangedEventArgs e)
        {
            CurrentDistance = (int)e.Ports[InputPort.One].SIValue;
            CurrentGyro = (int)e.Ports[InputPort.Two].SIValue;
            CurrentColor = (int)e.Ports[InputPort.Three].SIValue;
        }

    }
}
