using System;
using System.Windows;
using System.Diagnostics;

namespace Times_Of_Conflict
{
    /// <summary>
    /// Interaction logic for WinScreen.xaml. This screen allows for the user to restart or quit the game
    /// </summary>
    public partial class WinScreen : Window
    {
        public WinScreen()
        {
            InitializeComponent();
        }

        private void OnQuitButtonClick(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0); // Closes the game
        }

        private void OnRestartButtonClick(object sender, RoutedEventArgs e)
        {
            Process.Start(Process.GetCurrentProcess().ProcessName, "");
            Close();
            Process.GetCurrentProcess().Kill(); // Closes and restart the process.
        }
    }
}
