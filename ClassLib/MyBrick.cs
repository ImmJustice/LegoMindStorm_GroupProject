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
        public Brick pBrick;
        
        public async void MakeConnection()
        {
            pBrick = new Brick(new UsbCommunication());
            await pBrick.ConnectAsync();
        }
    }
}