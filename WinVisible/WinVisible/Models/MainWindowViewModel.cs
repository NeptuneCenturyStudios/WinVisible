using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinVisible.Classes;

namespace WinVisible.Models
{
    class MainWindowViewModel : BaseModel
    {

        #region Properties

        /// <summary>
        /// Gets the enumerated windows
        /// </summary>
        public ProcessItemCollection Items
        {
            get
            {
                return DesktopWindowEnumerator.Windows;
            }
        }
        #endregion

        public MainWindowViewModel()
        {
            
        }
    }
}
