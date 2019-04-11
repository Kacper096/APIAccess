using System.Windows;
using System.Windows.Input;

namespace APIAccess.View
{
    /// <summary>
    /// Interaction logic for League.xaml
    /// </summary>
    public partial class League : Window
    {
        public League()
        {
            InitializeComponent();
            MouseDown += Window_MouseDown;
        }

        /// <summary>
        /// It closes the window when guest clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Minimizes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Minimized;
            }

        }

        /// <summary>
        /// The window can moves
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        /// <summary>
        /// It closes the window when guest press alt and click F4
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if ((e.KeyboardDevice.Modifiers == ModifierKeys.Alt) &&
                (e.Key == Key.F4 || e.SystemKey == Key.F4))
                this.Close();
        }
    }
}
