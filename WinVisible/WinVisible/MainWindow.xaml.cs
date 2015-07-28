using System;
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

namespace WinVisible
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //System.Windows.Forms.NotifyIcon nIcon = new System.Windows.Forms.NotifyIcon();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //var iconHandle = WinVisible.Properties.Resources.winvisible.Handle;
            //this.nIcon.Icon = System.Drawing.Icon.FromHandle(iconHandle);
            ////this.nIcon.ShowBalloonTip(5000, "Hi", "This is a BallonTip from Windows Notification", System.Windows.Forms.ToolTipIcon.Info);
            //this.nIcon.Visible = true;
        }
    }
}
