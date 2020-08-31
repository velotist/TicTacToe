using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Player player = new Player();
        private readonly List<Button> winningButtons = new List<Button>();
        private int clicks;

        public class Player
        {
            public string PlayerCharacter { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void ToDoWhenButton_Click(object sender, RoutedEventArgs e)
        {
            Button senderAsButton = (Button)sender;

            try
            {
                clicks++;

                if (senderAsButton.Content == null || senderAsButton.Content.ToString() == "")
                {
                    bool isGameWon = false;
                    if (player.PlayerCharacter == "O")
                    {
                        senderAsButton.Content = "O";
                        isGameWon = IsGameWon(player);
                        if (isGameWon)
                        {
                            ShowWinner(player);
                            StartNewGame();
                        }

                        player.PlayerCharacter = "X";
                    }
                    else
                    {
                        senderAsButton.Content = "X";
                        isGameWon = IsGameWon(player);
                        if (isGameWon)
                        {
                            ShowWinner(player);
                            StartNewGame();
                        }

                        if (!isGameWon)
                            player.PlayerCharacter = "O";
                        else
                            player.PlayerCharacter = "X";
                    }
                }
                else
                {
                    clicks--;
                    MessageBox.Show("Feld bereits belegt.");
                }

                if (clicks == 9)
                {
                    MessageBox.Show("The game ended in a tie.");
                    StartNewGame();
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        private void ShowWinner(Player player)
        {
            foreach (var item in winningButtons)
            {
                item.Background = new SolidColorBrush(Color.FromRgb(111, 112, 0));
            }

            MessageBox.Show("Player " + player.PlayerCharacter + " has won.");
        }

        private void StartNewGame()
        {
            winningButtons.Clear();
            clicks = 0;
            player.PlayerCharacter = "X";

            kaestchen_0_0.Content = "";
            kaestchen_1_0.Content = "";
            kaestchen_2_0.Content = "";
            kaestchen_0_1.Content = "";
            kaestchen_1_1.Content = "";
            kaestchen_2_1.Content = "";
            kaestchen_0_2.Content = "";
            kaestchen_1_2.Content = "";
            kaestchen_2_2.Content = "";

            SolidColorBrush background = new SolidColorBrush(Color.FromRgb(0, 168, 198));
            SolidColorBrush foreground = new SolidColorBrush(Color.FromRgb(250, 235, 215));

            kaestchen_0_0.Background = background;
            kaestchen_1_0.Background = background;
            kaestchen_2_0.Background = background;
            kaestchen_0_1.Background = background;
            kaestchen_1_1.Background = background;
            kaestchen_2_1.Background = background;
            kaestchen_0_2.Background = background;
            kaestchen_1_2.Background = background;
            kaestchen_2_2.Background = background;

            kaestchen_0_0.Foreground = foreground;
            kaestchen_1_0.Foreground = foreground;
            kaestchen_2_0.Foreground = foreground;
            kaestchen_0_1.Foreground = foreground;
            kaestchen_1_1.Foreground = foreground;
            kaestchen_2_1.Foreground = foreground;
            kaestchen_0_2.Foreground = foreground;
            kaestchen_1_2.Foreground = foreground;
            kaestchen_2_2.Foreground = foreground;
        }

        private bool IsGameWon(Player player)
        {
            if (kaestchen_0_0.Content.ToString() == player.PlayerCharacter && kaestchen_1_0.Content.ToString() == player.PlayerCharacter && kaestchen_2_0.Content.ToString() == player.PlayerCharacter)
            {
                CreateListOfWinningButtons(kaestchen_0_0, kaestchen_1_0, kaestchen_2_0);
                return true;
            }
            if (kaestchen_0_1.Content.ToString() == player.PlayerCharacter && kaestchen_1_1.Content.ToString() == player.PlayerCharacter && kaestchen_2_1.Content.ToString() == player.PlayerCharacter)
            {
                CreateListOfWinningButtons(kaestchen_0_1, kaestchen_1_1, kaestchen_2_1);
                return true;
            }
            if (kaestchen_0_2.Content.ToString() == player.PlayerCharacter && kaestchen_1_2.Content.ToString() == player.PlayerCharacter && kaestchen_2_2.Content.ToString() == player.PlayerCharacter)
            {
                CreateListOfWinningButtons(kaestchen_0_2, kaestchen_1_2, kaestchen_2_2);
                return true;
            }
            if (kaestchen_0_0.Content.ToString() == player.PlayerCharacter && kaestchen_1_1.Content.ToString() == player.PlayerCharacter && kaestchen_2_2.Content.ToString() == player.PlayerCharacter)
            {
                CreateListOfWinningButtons(kaestchen_0_0, kaestchen_1_1, kaestchen_2_2);
                return true;
            }
            if (kaestchen_0_0.Content.ToString() == player.PlayerCharacter && kaestchen_0_1.Content.ToString() == player.PlayerCharacter && kaestchen_0_2.Content.ToString() == player.PlayerCharacter)
            {
                CreateListOfWinningButtons(kaestchen_0_0, kaestchen_0_1, kaestchen_0_2);
                return true;
            }
            if (kaestchen_1_0.Content.ToString() == player.PlayerCharacter && kaestchen_1_1.Content.ToString() == player.PlayerCharacter && kaestchen_1_2.Content.ToString() == player.PlayerCharacter)
            {
                CreateListOfWinningButtons(kaestchen_1_0, kaestchen_1_1, kaestchen_1_2);
                return true;
            }
            if (kaestchen_2_0.Content.ToString() == player.PlayerCharacter && kaestchen_2_1.Content.ToString() == player.PlayerCharacter && kaestchen_2_2.Content.ToString() == player.PlayerCharacter)
            {
                CreateListOfWinningButtons(kaestchen_2_0, kaestchen_2_1, kaestchen_2_2);
                return true;
            }
            if (kaestchen_0_2.Content.ToString() == player.PlayerCharacter && kaestchen_1_1.Content.ToString() == player.PlayerCharacter && kaestchen_2_0.Content.ToString() == player.PlayerCharacter)
            {
                CreateListOfWinningButtons(kaestchen_0_2, kaestchen_1_1, kaestchen_2_0);
                return true;
            }

            return false;
        }

        private void CreateListOfWinningButtons(Button one, Button two, Button three)
        {
            winningButtons.Add(one);
            winningButtons.Add(two);
            winningButtons.Add(three);
        }
    }
}