using System.Windows;
using Age_Of_War;

namespace Times_Of_Conflict
{
    /// <summary>
    /// Interaction logic for the MainWindow.xaml. This screen allowws the user to start the game
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameManager _gameManager = new GameManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void OpenLossScreen()
        {
            LostScreen loseWindow = new LostScreen();
            loseWindow.Show();
        }
        public void OpenWinScreen()
        {
            WinScreen winWindow = new WinScreen();
            winWindow.Show();
        }

        public void OpenPauseScreen()
        {
            PauseWindow pauseWindow = new PauseWindow(_gameManager);
            pauseWindow.Show();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
            _gameManager.PauseEvent += OpenPauseScreen; //Pause screen event trigger
            _gameManager.LoseEvent += OpenLossScreen;//Loss screen event trigger
            _gameManager.WinEvent += OpenWinScreen;//Win screen event trigger
            _gameManager.Start();
        }
    }
}