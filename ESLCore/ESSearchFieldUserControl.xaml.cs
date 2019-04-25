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
using System.Runtime.CompilerServices;
using ESLCore;

[assembly: InternalsVisibleTo("UnitTestESLCore")]
namespace ESLCore
{
    /// <summary>
    /// Interaction logic for ESSearchFieldUserControl.xaml
    /// </summary>
    public partial class ESSearchFieldUserControl : UserControl
    {

        public static readonly RoutedEvent CloseAppEvent = EventManager.RegisterRoutedEvent("CloseApp", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ESSearchFieldUserControl));


        private ESSearchControllerInterface _SearchController;
        public ESSearchControllerInterface SearchController {
            set {
                _SearchController = value;
                ReInitializing();
            }
            get { return _SearchController; }
        }

        
        private ESLAppHandlerInterface _AppController;
        public ESLAppHandlerInterface AppController
        {
            set
            {
                _AppController = value;
                ReInitializing();
            }
            get { return _AppController; }
        }

        public String Text
        {
            set { SearchTextField.Text = value; }
            get { return SearchTextField.Text; }
        }
         
        public String WhaterMarc
        {
            set { SearchTextField_Watermark.Text = value; }
            get { return SearchTextField_Watermark.Text; }
        }

        public ESSearchFieldUserControl()
        {
            InitializeComponent();
        }

        private void ReInitializing()
        {
            SearchTextField.Focus();
            if (SearchController != null)
                SearchTextField_Watermark.Text = SearchController.GetActionTextFor("");
             
            SearchTextField.SelectionStart = 0;
            SearchTextField.SelectionLength = 0;
        }

        internal void StartSearch()
        {  
            AppController.OpenURL(SearchController.GetURLForSearchString(SearchTextField.Text));
        }

        private void SearchTextField_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.WhaterMarc = SearchController.GetActionTextFor(this.Text) ;
        }

        private void SearchTextField_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
                StartSearch(); 

            if (e.Key == Key.Escape) 
                RiseCloseAppEvent();

            if (e.Key == Key.Up)
                Prev();

            if (e.Key == Key.Down)
                Next();
        }

        public void Next()
        {
            UpdateSearchString(SearchController.SelectNext(SearchTextField.Text));
        }

        public void Prev()
        {
            UpdateSearchString(SearchController.SelectPrev(SearchTextField.Text));
        }

        private void UpdateSearchString(string newSearchString)
        {
            SearchTextField.Text = newSearchString;
            SearchTextField.Focus();
            SearchTextField.CaretIndex = SearchTextField.Text.Length;
            SearchTextField_Watermark.Text = SearchController.GetActionTextFor(newSearchString);

            SearchTextField_Watermark.CaretIndex = SearchTextField_Watermark.Text.Length;
        }

        private void ESSearchButton_KeyUp(object sender, KeyEventArgs e)
        {
            StartSearch();
        } 

        private void ESSearchButton_ExecuteSearch(object sender, RoutedEventArgs e)
        {
            StartSearch();
        }

        private void ESSearchButton_ExecuteMenue(object sender, RoutedEventArgs e)
        {

        }

        // Provide CLR accessors for the event
        public event RoutedEventHandler CloseApp
        {
            add { AddHandler(CloseAppEvent, value); }
            remove { RemoveHandler(CloseAppEvent, value); }
        }


        // This method raises the Tap event
        void RiseCloseAppEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ESSearchFieldUserControl.CloseAppEvent);
            RaiseEvent(newEventArgs);
        }

        private void SearchTextField_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            // If the mouse wheel delta is positive, move the box up.
            if (e.Delta > 0)
                Prev();

            // If the mouse wheel delta is negative, move the box down.
            if (e.Delta < 0)
                Next();
        }
    }
}
