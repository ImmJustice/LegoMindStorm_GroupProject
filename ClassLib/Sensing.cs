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
using System.Threading.Tasks;

namespace LegoStormGrp5
{

    public class Sensing
    {
        public string Colour;
        public string Dist;
        public string Gyro;
        public Brick Brick;

        public Sensing(Brick _Brick)
        {
            Brick = _Brick;

            Brick.BrickChanged += BrickChanged;
        }

        ~Sensing()
        {

        }

        public void BrickChanged(object sender, BrickChangedEventArgs e)
        {
            Colour = e.Ports[InputPort.Three].SIValue.ToString();
            Dist = e.Ports[InputPort.Two].SIValue.ToString();
            Gyro = e.Ports[InputPort.Four].SIValue.ToString();
        }

        public int GetClr()
        {
            int vColour = Int32.Parse(Colour);

            return vColour;
        }

        public double GetDist()
        {              
            vDist = Double.Parse(Dist);          
   
            return vDist;
        }

        public int GetGyro()
        {
            int vGyro = Int32.Parse(Gyro);            
            
            return vGyro;
        }

    }

    //end Sensing
}
