///////////////////////////////////////////////////////////
//  Motion.cs
//  Implementation of the Class Motion
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
    public class Motion
    {

        public MyBrick m_MyBrick;

        public Motion()
        {

        }

        ~Motion()
        {

        }

        /// 
        /// <param name="pPower1"></param>
        /// <param name="pPower2"></param>
        /// <param name="pTime"></param>
        /// <param name="pBrake"></param>
        public void Move(int pPower1, int pPower2, uint pTime, bool pBrake)
        {

        }

        /// <summary>
        /// pGyroTurn = how much to turn
        /// </summary>
        /// <param name="pGyroTurn"></param>
        public void Rotate(int pGyroTurn)
        {

        }

    }//end Motion
}