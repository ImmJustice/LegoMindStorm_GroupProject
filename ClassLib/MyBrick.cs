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
        public static Brick pBrick;
        public Motion pMotion;

        public int AlignToWall()
        {
            pSensing = new Sensing(pBrick);               //declare local instances of Sensing and Motion classe
            pMotion  = new Motion();
            
                                                            // <=- Order of operations -=>


            double vDist = pSensing.GetDist();              // 1. Retrieve current distance
            int vGyro = pSensing.GetGyro();                 // 1. Retrieve current gyro

            double vDistShortest = vDist;           // Variable for storing shortest distance
            int vGyroShortest = vGyro;              // Variable for storing store shortest gyro

            int vGyroStart = vGyro;                         // 2. Store starting gyro for reallignment

            if (vDist >= 2)                                 // 3. If distance <= 2cm move backwards for manuverability
            {
                pMotion.Move(-50, -50, 50, false);
            }
            
            pMotion.Rotate(360);                            // 4. Do a 360* turn

            do                                              // 5. Update vShortestDist+Gyro if vCurrentDist+Gyro is shorter
            {
                if (vDist < vDistShortest)
                {
                    vDistShortest = vDist;
                }
            } while (vGyro != (vGyroStart+360));            // until 360 turn is complete

            pMotion.Rotate(vGyroShortest - vGyro);

            do                                              // 6. Get within working colour sensor distance
            {
                pMotion.Move(20, 20, 100, false);
            } while (vDist > 1);

            pMotion.Move(0, 0, 100, true);          // Break motors

            int vColour = pSensing.GetClr();             // 7. Store wall colour

            do                                              // 8. Reverse for turning space
            {
                pMotion.Move(-50, -50, 50, false);
            } while (vDist < 2);

            pMotion.Move(0, 0, 100, true);          // Break motors
            

            return vColour;                                 // 9. Return wall colour
        }

        public async void MakeConnection()
        {
            pBrick = new Brick(new UsbCommunication());
            await pBrick.ConnectAsync();
        }

    }
}