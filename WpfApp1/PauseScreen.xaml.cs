using System.Windows;
using Age_Of_War;
using System.Diagnostics;
using System;

namespace Times_Of_Conflict
{
    /// <summary>
    /// Interaction logic for PauseScreen.xaml. This screen allows for the user to resume, restart or quit the game
    /// </summary>
    public partial class PauseWindow : Window
    {
        private readonly GameManager _gameManager;

        public PauseWindow(GameManager gameManager)
        {
            InitializeComponent();
            _gameManager = gameManager;
        }

        private void OnResumeButtonClick(object sender, RoutedEventArgs routedEventArgs)
        {
            _gameManager.pause = false;
            Close(); //Resumes the game
        }
        
        private void OnQuitButtonClick(object sender, RoutedEventArgs routedEventArgs)
        {
            Environment.Exit(0); //Closes the process alltogether 
        }
        private void OnRestartButtonClick(object sender, RoutedEventArgs routedEventArgs)
        {
            Process.Start(Process.GetCurrentProcess().ProcessName, "");
            Close();
            Process.GetCurrentProcess().Kill(); // Closes and restart the process.
        }
    }
}
