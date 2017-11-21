using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego.Ev3.Desktop;
using Lego.Ev3.Core;
namespace LegoRevamp
{
    class Motion
    {
        private Brick pBrick;
        private Sensing pSensing;
        public Motion(Brick _Brick,Sensing _Sensing)
        {
            pBrick = _Brick;
            pSensing = _Sensing;
        }

        public async void SpinToGyro(int TargetGyro)
        {
            int LocalGyro = pSensing.CurrentGyro;

            if (TargetGyro >= 0)
            {
                TargetGyro = TargetGyro + LocalGyro;
                while (LocalGyro < TargetGyro)
                {
                    pBrick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.A, 25, 1500, false);
                    pBrick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.D, -25, 1500, false);
                    await pBrick.BatchCommand.SendCommandAsync();
                    LocalGyro = pSensing.CurrentGyro;
                }
            }
            else
            {
                TargetGyro = LocalGyro - TargetGyro;
                while (LocalGyro > TargetGyro)
                {
                    pBrick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.A, -25, 1500, false);
                    pBrick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.D, 25, 1500, false);
                    await pBrick.BatchCommand.SendCommandAsync();
                    LocalGyro = pSensing.CurrentGyro;
                }
            }   
            
        }

        public async void SetSpin(bool Direction)
        {
            switch (Direction)
            {
                case true:
                    pBrick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.A, 25, 3000, false);
                    pBrick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.D, -25, 3000, false);
                    await pBrick.BatchCommand.SendCommandAsync();
                    break;
                case false:
                    pBrick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.A, -25, 3000, false);
                    pBrick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.D, 25, 3000, false);
                    await pBrick.BatchCommand.SendCommandAsync();
                    break;
                default:
                    break;
            }
        }

        public async void Drive(uint Time, bool RunTime)
        {
            switch (RunTime)
            {
                case true:
                    pBrick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.A, 25, Time, false);
                    pBrick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.D, 25, Time, false);
                    await pBrick.BatchCommand.SendCommandAsync();
                    break;

                case false:
                    int localDist = pSensing.CurrentDistance;
                    while (localDist > 5)
                    {
                        pBrick.BatchCommand.TurnMotorAtPower(OutputPort.A, 30);
                        pBrick.BatchCommand.TurnMotorAtPower(OutputPort.D, 30);
                        await pBrick.BatchCommand.SendCommandAsync();
                        localDist = pSensing.CurrentDistance;
                    }
                    break;
                default:
                    break;
            }
        }

        public async void Reverse()
        {
            pBrick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.A, -25, 2000, false);
            pBrick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.D, -25, 2000, false);
            await pBrick.BatchCommand.SendCommandAsync();
        }

        public void DirectionChoice(int Var)
        {
            switch (Var)
            {
                case 90:
                    SetSpin(true);
                    Drive(0, true);
                    break;
                default:
                    SetSpin(false);
                    Drive(0, true);
                    break;
            }
        }

        public void AlignToWall()
        {
            int localGyro = pSensing.CurrentGyro;
            int targetGyro = localGyro + 360;
            int[] returnTo = new int[] { pSensing.CurrentDistance , localGyro  }; // {Dist, Gyro}
            while (localGyro <= targetGyro)
            {
                //SpinToGyro(5);
                if (pSensing.CurrentDistance < returnTo[0] )
                {
                    returnTo[0] = pSensing.CurrentDistance;
                    returnTo[1] = pSensing.CurrentGyro;
                }
                
            }

            SpinToGyro((returnTo[1] - localGyro));
            Drive(0, false);
            
            
        }
    }
}
