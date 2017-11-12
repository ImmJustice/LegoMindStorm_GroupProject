///////////////////////////////////////////////////////////
//  Sensing.cs
//  Implementation of the Class Arena
//  Generated by Enterprise Architect
//  Created on:      10-Nov-2017 1:09:15 PM
//  Original author: 0849480
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;

namespace LegoStormGrp5
{

    public class Sensing
    {

        public double vDist;
        public int vGyro;

        public Sensing()
        {

        }

        ~Sensing()
        {

        }

        public int GetClr(object sender, BrickChangedEventArgs e)
        {
            int color = 0;
            color = e.Ports[InputPort.One].SIValue.ToString;
            return color;
        }

        public double GetDist(object sender, BrickChangedEventArgs e)
        {
            vDist = (double)e.Ports[InputPort.One].SIValue;
            return vDist;
        }

        public int GetGyro(object sender, BrickChangedEventArgs e)
        {
            vGyro = (int)e.Ports[InputPort.One].SIValue;
            return vGyro;
        }

    }

    //end Sensing
}