using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lego.Ev3.Desktop;
using Lego.Ev3.Core;
namespace LegoRevamp
{
    public class Arena
    {
        public int[] HomeCnr;
        public int[] Colors = { 2, 5, 1, 4 };

        public Brick pBrick;

        public Arena(Brick _Brick)
        {
            pBrick = _Brick;
        }

        /// <summary>
        /// Rotate 360 to determine the shortest distance.
        /// </summary>
        /// <param name="pGyro"></param>
        /// <param name="pDistance"></param>
        public int GetNearestWallColor(int pGyro, double pDistance)
        {

            return 0;
        }

        /// 
        /// <param name="pColorStart"></param>
        public int MovementLogic(int pColorStart)
        {

            int Left;
            var index = Array.IndexOf(Colors, pColorStart);

            switch (index)
            {
                case 0:
                    Left = 3;
                    break;

                default:
                    Left = index - 1;
                    break;
            }

            if (Colors[index] == HomeCnr[0] || Colors[index] == HomeCnr[1])
            {
                if (Colors[Left] == HomeCnr[0] || Colors[Left] == HomeCnr[1])
                {
                    return -90;
                }
                else
                {
                    return 90;
                }
            }
            else
            {
                return 180;
            }

        }
    }
}
