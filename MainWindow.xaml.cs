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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Duration _animationDuration = new Duration(TimeSpan.FromSeconds(0.3));
        public MainWindow()
        {
            InitializeComponent();
            ChangeContent(new ScreenOne(new TransitionControl(this)));
        }
        DoubleAnimation CreateDoubleAnimation(double from, double to, EventHandler completedEventHandler)
        {
            DoubleAnimation doubleAnimation = new DoubleAnimation(from, to, _animationDuration);
            if(completedEventHandler != null)
            {
                doubleAnimation.Completed += completedEventHandler;
            }
            return doubleAnimation;
        }
        void SlideAnimation(UIElement newContent,UIElement oldContent,EventHandler completeEventHandler)
        {
            double leftStart = Canvas.GetLeft(oldContent);
            Canvas.SetLeft(newContent, leftStart - Width);
            TransitionContainer.Children.Add(newContent);
            if (double.IsNaN(leftStart))
            {
                leftStart = 0;
            }
            DoubleAnimation outAnimation = CreateDoubleAnimation(leftStart, leftStart + Width, null);
            DoubleAnimation inAnimation = CreateDoubleAnimation(leftStart - Width, leftStart, completeEventHandler);
            oldContent.BeginAnimation(Canvas.LeftProperty, outAnimation);
            newContent.BeginAnimation(Canvas.LeftProperty, inAnimation);
        }
        public void ChangeContent(UIElement newContent)
        {
            if(TransitionContainer.Children.Count == 0)
            {
                TransitionContainer.Children.Add(newContent);
                return;
            }
            if(TransitionContainer.Children.Count == 1)
            {
                TransitionContainer.IsHitTestVisible = false;
                UIElement oldContent = TransitionContainer.Children[0];
                EventHandler onAnimationCompletedHandler = delegate (object sender, EventArgs e)
                {
                    TransitionContainer.IsHitTestVisible = true;
                    TransitionContainer.Children.Remove(oldContent);
                    if(oldContent is IDisposable)
                    {
                        (oldContent as IDisposable).Dispose();
                    }
                    oldContent = null;
                };
                SlideAnimation(newContent, oldContent, onAnimationCompletedHandler);
            }
        }
    }
}
