using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WinVisible.Classes;

namespace WinVisible
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Tray icon object
        /// </summary>
        private System.Windows.Forms.NotifyIcon _trayIcon = new System.Windows.Forms.NotifyIcon();

        public App()
        {
            //initialize the tray icon
            InitializeTrayIcon();

            //start a background task to monitor windowed processes present on the desktop(s)
            Task.Factory.StartNew(() => {

                while (true)
                {
                    DesktopWindowEnumerator.EnumerateWindows();
                    Thread.Sleep(2000);
                }

            });
        }

        /// <summary>
        /// Sets properties for the tray icon
        /// </summary>
        private void InitializeTrayIcon()
        {
            //get handle to resource icon
            var iconHandle = WinVisible.Properties.Resources.winvisible.Handle;

            //set icon for tray icon
            _trayIcon.Icon = System.Drawing.Icon.FromHandle(iconHandle);
            //set text
            _trayIcon.Text = "WinVisible";
            //ensure it's visible
            _trayIcon.Visible = true;
        }

    }
}
