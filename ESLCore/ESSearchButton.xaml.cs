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

namespace ESLCore
{
    /// <summary>
    /// Interaktionslogik für ESSearchButton.xaml
    /// </summary>
    public partial class ESSearchButton : UserControl
    {
        public static readonly RoutedEvent ExecuteSearchEvent = EventManager.RegisterRoutedEvent(  "ExecuteSearch", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ESSearchButton));
        public static readonly RoutedEvent OpenMenueEvent = EventManager.RegisterRoutedEvent("OpenMenue", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ESSearchButton));

        public ESSearchButton()
        {
            InitializeComponent();
        }

        private void MenueButton_Click(object sender, RoutedEventArgs e)
        {
            RaiseSearchMenueEvent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        { 
            RaiseSearchMenueEvent();
        }
         
        public event RoutedEventHandler ExecuteSearch
        {
            add { AddHandler(ExecuteSearchEvent, value); }
            remove { RemoveHandler(ExecuteSearchEvent, value); }
        }

        
        void RaiseOpenMenueEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ESSearchButton.OpenMenueEvent);
            RaiseEvent(newEventArgs);
        }

         
        public event RoutedEventHandler OpenMenue
        {
            add { AddHandler(OpenMenueEvent, value); }
            remove { RemoveHandler(OpenMenueEvent, value); }
        }
        
         
        void RaiseSearchMenueEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ESSearchButton.ExecuteSearchEvent);
            RaiseEvent(newEventArgs);
        }
    }
}
