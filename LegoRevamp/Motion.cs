using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego.Ev3.Desktop;
using Lego.Ev3.Core;
namespace LegoRevamp
{
    public class Motion
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

            if (TargetGyro <= 0)
            {
                TargetGyro = LocalGyro+TargetGyro;
                // while (LocalGyro < TargetGyro)
                //    {
                await pBrick.DirectCommand.TurnMotorAtPowerAsync(OutputPort.A, 25);
                await pBrick.DirectCommand.TurnMotorAtPowerAsync(OutputPort.D, -25);
                while (LocalGyro > TargetGyro)
                {
                    LocalGyro = (int)pBrick.Ports[InputPort.One].SIValue;
                }
                await pBrick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.A, 0,1,true);
                await pBrick.DirectCommand.TurnMotorAtPowerForTimeAsync(OutputPort.D, 0, 1, true);


                //  }
                //}
                //else
                //{
                //    TargetGyro = LocalGyro - TargetGyro;
                //    while (LocalGyro > TargetGyro)
                //    {
                //        pBrick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.A, -25, 1500, false);
                //        pBrick.BatchCommand.TurnMotorAtSpeedForTime(OutputPort.D, 25, 1500, false);
                //        await pBrick.BatchCommand.SendCommandAsync();
                //        LocalGyro = pSensing.CurrentGyro;
                //    }
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
                SpinToGyro(-360);
                if (pSensing.CurrentDistance < returnTo[0] )
                {
                    returnTo[0] = (int)pBrick.Ports[InputPort.Three].SIValue;
                    returnTo[1] = (int)pBrick.Ports[InputPort.One].SIValue;
                }

                localGyro = (int)pBrick.Ports[InputPort.Two].SIValue;
            }

            //SpinToGyro((returnTo[1] - localGyro));
            //Drive(0, false);
            
            
        }
    }
}
