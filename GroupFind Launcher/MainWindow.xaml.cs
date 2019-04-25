using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Forms.ComponentModel;
 
using ESLCore;
 

namespace GroupFind_Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ESSearchControllerInterface SearchController { set; get; }
        private ESLAppHandlerInterface AppController { set; get; }

        private int DefaultWindowHeight = 56;

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
            CustomHeight = DefaultWindowHeight;

            SearchController = new ESSearchController();
            AppController = new ESLAppHandler();

            SearchFieldControl.AppController = AppController;
            SearchFieldControl.SearchController = SearchController;

            SearchFieldControl.Focus();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EnableBlur();
            SetWindowPositionToUpCenter();
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            CloseApp();
        }

        private int _height;
        public int CustomHeight
        {
            get { return _height; }
            set
            {
                if (value != _height)
                {
                    _height = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("CustomHeight"));
                }
            }
        }

        private void SearchFieldControl_CloseApp(object sender, RoutedEventArgs e)
        {
            CloseApp();
        }

        private void CloseApp()
        {
#if DEBUG
            Console.WriteLine("Debug: Skipped AppController.CloseApp(this)");
#else
             AppController.CloseApp(this);
#endif
        }
 
         
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
