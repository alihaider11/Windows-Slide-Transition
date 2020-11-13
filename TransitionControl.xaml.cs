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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for TransitionControl.xaml
    /// </summary>
    public partial class TransitionControl : UserControl
    {
        public MainWindow ParentWindow { get; set; }
        public TransitionControl CurrentScreen { get; set;}
        public TransitionControl(MainWindow parent)
        {
            this.ParentWindow = parent;
            InitializeComponent();
        }
        public void ChangeScreen(TransitionControl screen)
        {
            if(screen == null)
            {
                throw new ArgumentNullException("unable to navigate to next screen. A null refernce section occurred");
            }
            this.CurrentScreen = screen;
            this.ParentWindow.ChangeContent(screen);
        }
    }
}
