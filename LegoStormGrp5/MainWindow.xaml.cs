using System;
using System.Windows;
using System.Windows.Documents;
using Lego.Ev3.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Lego.Ev3.Desktop;


namespace LegoStormGrp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
/*  0 = No Color    1 = Black   2 = Blue	3 = Green	4 = Yellow	5 = Red	6 = White	7 = Brown*/

    public partial class MainWindow : Window
    {

        MyBrick vRobo = new MyBrick();
        //public Brick Brick { get; set; }
        public class ListRow
        {
            public string cnr { get; set; }
            public string clr1 { get; set; }
            public string clr2 { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
        }
        public async void btnGo_Click(object sender, RoutedEventArgs e)
        {
            //await Brick.DirectCommand.ClearAllDevicesAsync();
            btnDel.IsEnabled = false;
            txtFeedBack.Text = "Changed Text";

            /*for (int i = 0; i < lstSeq.Items.Count; i++)*/
            foreach (ListRow item in lstSeq.Items)

            {

                string txtCorner = item.cnr;
                txtFeedBack.Text += "Finding the " + txtCorner + " Corner";

                //vRobo.Arena.HomeCnr = new int[] {item.clr1 ,item.clr2 };

            }



        }

        public void btnBluRed_Click(object sender, RoutedEventArgs e)
        {
            this.lstSeq.Items.Add(new ListRow { cnr = "Blue-Red", clr1 = "2", clr2 = "5" });
            btnDel.IsEnabled = true;
        }

        public void btnBlkYel_Click(object sender, RoutedEventArgs e)
        {
            this.lstSeq.Items.Add(new ListRow { cnr = "Black-Yellow", clr1 = "1", clr2 = "4" });
            btnDel.IsEnabled = true;
        }

        public void btnYelBlu_Click(object sender, RoutedEventArgs e)
        {
            this.lstSeq.Items.Add(new ListRow { cnr = "Yellow-Blue", clr1 = "4", clr2 = "2" });
            btnDel.IsEnabled = true;
        }

        public void btnRedBlk_Click(object sender, RoutedEventArgs e)
        {
            this.lstSeq.Items.Add(new ListRow { cnr = "Red-Black", clr1 = "5", clr2 = "1" });
            btnDel.IsEnabled = true;
        }

        public void btnDel_Click(object sender, RoutedEventArgs e)
        {
            lstSeq.Items.Remove(lstSeq.SelectedItem);

        }


    }
}