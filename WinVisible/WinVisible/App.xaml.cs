using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


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
            InitializeTrayIcon();
            
        }

        /// <summary>
        /// Sets properties for the tray icon
        /// </summary>
        private void InitializeTrayIcon()
        {
            //get handle to resource icon
            var iconHandle = WinVisible.Properties.Resources.winvisible.Handle;

            //set icon for tray icon
            this._trayIcon.Icon = System.Drawing.Icon.FromHandle(iconHandle);
            //set text
            this._trayIcon.Text = "WinVisible";
            //ensure it's visible
            this._trayIcon.Visible = true;
        }

    }
}
