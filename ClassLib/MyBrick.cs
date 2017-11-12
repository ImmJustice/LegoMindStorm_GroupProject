using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;

namespace LegoStormGrp5
{

    public class MyBrick
    {

        public Sensing pSensing;
        public Arena pArena;
        public Brick pBrick;
        public Motion pMotion;

        public string AlignToWall()
        {
            pSensing = new Sensing();
            pMotion  = new Motion();
            //. Order of operations;
            //. 1. If distance <= 2cm move backwards 3 cm
            //. 2. Do a 360* turn
            //. 3. Store the starting Distance + Gyro in seperate variables then update both if current distance is shorter than starting distance
            //. 4. Set the smallest distance and take the correlated gyro value
            //. 5. Spin until vGyro == vGyroStart + 360
            //. 6. Approach wall until distance >= 2cm
            //. 7. call colour sensor and return colour
            double vDist = pSensing.GetDist();
            double vDistShortest = vDist;
            int vGyro    = pSensing.GetGyro();
            int vGyroShortest = vGyro;
            int vGyroStart = vGyro;

            if (vDist >= 2)
            {
                pMotion.Move(-50, -50, 50, false);
            }
            
            pMotion.Rotate(360);
            do
            {
                if (vDist < vDistShortest)
                {
                    vDistShortest = vDist;
                }
            } while (vGyro != (vGyroStart+360));

            pMotion.Rotate(vGyroShortest - vGyro);

            do
            {
                pMotion.Move(20, 20, 100, false);
            } while (vDist > 1);

            pMotion.Move(0, 0, 100, true);

            string vColour = pSensing.GetClr();
            return vColour;
        }

        public async void MakeConnection()
        {
            pBrick = new Brick(new UsbCommunication());
            await pBrick.ConnectAsync();
        }

    }
}