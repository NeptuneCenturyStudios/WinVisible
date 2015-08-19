using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WinVisible.Classes
{
    class DesktopWindowEnumerator
    {


        public delegate bool CallBackPtr(IntPtr hwnd, int lParam);

        private static List<ProcessItem> _currentList = new List<ProcessItem>();
        //private static CallBackPtr callBackPtr;

        #region Imports
        [DllImport("user32.dll")]
        private static extern int EnumWindows(CallBackPtr callPtr, int lPar);

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);
        #endregion

        #region Properties
        /// <summary>
        /// Gets the windows enumerated by EnumWindow
        /// </summary>
        public static ProcessItemCollection Windows { get; private set; } = new ProcessItemCollection();
        #endregion

        #region Methods
        public static void EnumerateWindows()
        {
            //clear the current list
            _currentList.Clear();

            //create callback
            //callBackPtr = new CallBackPtr(EnumWindow);

            //enumerate the windows
            //var ok = EnumWindows(callBackPtr, 0);

            var ok = 1;
            var processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                if (process.MainWindowHandle != IntPtr.Zero)
                {
                    //collect all the windows into a list
                    _currentList.Add(new ProcessItem()
                    {
                        WindowHandle = process.MainWindowHandle.ToInt32(),
                        WindowText = process.MainWindowTitle.ToString(),
                        IsWindowVisible = IsWindowVisible(process.MainWindowHandle)
                    });
                }
            }

            if (ok == 1)
            {
                //compare the current list to the collection

                //find the items in the current list that are not in the collection
                var notInCollection = (from c in _currentList
                                       where !(from w in Windows select w.WindowHandle).Contains(c.WindowHandle)
                                       select c).ToArray();

                //now find the ones in the Window list that are not in the current list
                var notInCurrent = (from w in Windows
                                    where !(from c in _currentList select c.WindowHandle).Contains(w.WindowHandle)
                                    select w).ToArray();

                //now remove the ones not in current
                foreach (var w in notInCurrent)
                {
                    App.Current.Dispatcher.BeginInvoke(new Action(() => { Windows.Remove(w); }));
                }

                //add the ones not in collection
                foreach (var w in notInCollection)
                {
                    App.Current.Dispatcher.BeginInvoke(new Action(() => { Windows.Add(w); }));

                }


            }
        }
        #endregion

        #region Private Methods
        private static bool EnumWindow(IntPtr hwnd, int lParam)
        {
            //Debug.WriteLine("Window handle is " + hwnd);

            int len = GetWindowTextLength(hwnd);
            var sb = new StringBuilder(len);
            if (len > 0)
            {
                //get the window text
                
                GetWindowText(hwnd, sb, len + 1);
            }

            //collect all the windows into a list
            _currentList.Add(new ProcessItem()
            {
                WindowHandle = hwnd.ToInt32(),
                WindowText = sb.ToString()
            });

            return true;
        }
        #endregion
    }
}
