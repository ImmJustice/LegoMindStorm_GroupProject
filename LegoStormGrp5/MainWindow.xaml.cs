﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Lego.Ev3.Core;
using Lego.Ev3.Desktop;

namespace LegoStormGrp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Brick Brick { get; set; }

        public MainWindow()
        {
                        InitializeComponent();
        }


        private async void btnGo_OnClick(object sender, RoutedEventArgs e)
        {
           
            await Brick.DirectCommand.ClearAllDevicesAsync();
        }

        
    }
}
