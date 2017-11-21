using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego.Ev3.Desktop;
using Lego.Ev3.Core;
namespace LegoRevamp
{
    class MyBrick
    {
        public Brick pBrick;
        public Arena pArena;
        public Sensing pSensing;
        public Motion pMotion;

        public MyBrick()
        {
            MakeConnection();
            pArena = new Arena(pBrick);
            pSensing = new Sensing(pBrick);
            pMotion = new Motion(pBrick, pSensing);
        }

        public async void MakeConnection()
        {
            pBrick = new Brick(new UsbCommunication());
            await pBrick.ConnectAsync();
        }

        public void LocateHome()
        {
            if (pSensing.CurrentDistance < 3)
            {
                var returnVal =pArena.MovementLogic(pSensing.CurrentColor);
                DecideArenaVal(returnVal);
            }
            else if (pSensing.CurrentDistance > 210)
            {
                pMotion.Drive(4000, true);
                pMotion.AlignToWall();
                var returnVal = pArena.MovementLogic(pSensing.CurrentColor);
                DecideArenaVal(returnVal);
            }
        }

        public void DecideArenaVal(int Val)
        {
            switch (Val)
            {
                case 180:
                    pMotion.SpinToGyro(180);
                    pMotion.Drive(0, false);
                    Val = pArena.MovementLogic(pSensing.CurrentColor);
                    pMotion.DirectionChoice(Val);
                    break;
                default:
                    pMotion.DirectionChoice(Val);
                    break;
            }
        }
    }
}
