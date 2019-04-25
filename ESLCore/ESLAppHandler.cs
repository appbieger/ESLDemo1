using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Linq; 
using System.Threading.Tasks;
using System.Diagnostics;


[assembly: InternalsVisibleTo("UnitTestESLCore")]
namespace ESLCore
{
    public interface ESLAppHandlerInterface
    {
        void CloseApp(Object win);
        void OpenURL(string url);
    }
    public class ESLAppHandler : ESLAppHandlerInterface
    {
        public void CloseApp(Object win)
        {
        /*    if (MainWindow._instance != null)
            {
                MainWindow._instance = null;
                //safe call
                win.Dispatcher.Invoke(() =>
                {
                    win.Close();
                });
            } */
        }

        public void OpenURL(string url)
        {
            System.Diagnostics.Process.Start(url);
        }
    }
}
