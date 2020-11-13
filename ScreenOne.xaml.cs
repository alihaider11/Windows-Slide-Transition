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
    /// Interaction logic for ScreenOne.xaml
    /// </summary>
    public partial class ScreenOne : UserControl
    {
        private TransitionControl _transitionControl;
        public ScreenOne(TransitionControl transitionControl)
        {
            InitializeComponent();
            _transitionControl = transitionControl;
        }
        private void btnChangeContent_Click(object sender, RoutedEventArgs e)
        {
            _transitionControl.ParentWindow.ChangeContent(new ScreenTwo(new TransitionControl(_transitionControl.ParentWindow)));
        }
    }
}
