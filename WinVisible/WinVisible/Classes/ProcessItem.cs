using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinVisible.Models;

namespace WinVisible.Classes
{
    /// <summary>
    /// Represents a running windowed process
    /// </summary>
    class ProcessItem : BaseModel
    {
        /// <summary>
        /// Gets or sets the window handle hWnd
        /// </summary>
        public int WindowHandle { get; set; }

        private string _windowText;
        /// <summary>
        /// Gets or sets the window text for this process item
        /// </summary>
        public string WindowText
        {
            get { return _windowText; }
            set
            {
                _windowText = value;
                //notify change
                OnPropertyChanged(nameof(WindowText));
            }
        }

        private bool _isWindowVisible;
        /// <summary>
        /// Gets or sets whether this window is visible
        /// </summary>
        public bool IsWindowVisible
        {
            get { return _isWindowVisible; }
            set
            {
                _isWindowVisible = value;
                //notify change
                OnPropertyChanged(nameof(IsWindowVisible));
            }
        }

    }
}
