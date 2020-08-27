using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Player player = new Player();
        readonly Player player1 = player;

        public class Player
        {
            public string PlayerCharacter { get; set; }

            public Player() => PlayerCharacter = "X";
        }

        public MainWindow()
        {
            InitializeComponent();
            ClearGrid();

        }

        private void ToDoWhenButton_Click(object sender, RoutedEventArgs e)
        {
            Button senderAsButton = (Button)sender;
            var actualBackgroundColor = senderAsButton.Background;
            senderAsButton.Background = senderAsButton.Foreground;
            senderAsButton.Foreground = actualBackgroundColor;

            try
            {
                if (StartNewGame())
                {
                    ClearGrid();
                    player1.PlayerCharacter = "X";
                }

                if (senderAsButton.Content == null || senderAsButton.Content.ToString() == "")
                {
                    if (player1.PlayerCharacter == "O")
                    {
                        senderAsButton.Content = "O";
                        player1.PlayerCharacter = "X";
                    }
                    else if(player1.PlayerCharacter == "X")
                    {
                        senderAsButton.Content = "X";
                        player1.PlayerCharacter = "O";
                    }
                }
                else
                {
                    MessageBox.Show("Feld bereits belegt.");
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        private void ClearGrid()
        {
            kaestchen_0_0.Content = "";
            kaestchen_1_0.Content = "";
            kaestchen_2_0.Content = "";
            kaestchen_0_1.Content = "";
            kaestchen_1_1.Content = "";
            kaestchen_2_1.Content = "";
            kaestchen_0_2.Content = "";
            kaestchen_1_2.Content = "";
            kaestchen_2_2.Content = "";
        }

        private bool StartNewGame()
        {
            foreach (var item in Spielfeld.Children)
            {
                if (item is Button kaestchen && kaestchen.Content.ToString() == string.Empty)
                {
                    return false;
                }
            }
            return true;
        }
    }
}