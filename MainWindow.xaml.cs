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

namespace WPF_Game_ReactionTime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameLogic gameLogic;
        public MainWindow()
        {
            InitializeComponent();
            gameLogic = new GameLogic();
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            double delayMin, delayMax;
            int numberOfRuns;
            try
            {
                delayMin = double.Parse(TextBoxsetTimeFrom.Text);
                delayMax = double.Parse(TextBoxsetTimeTo.Text);
                numberOfRuns = int.Parse(ComboBoxSelectRuns.Text);

                gameLogic.NewGame(delayMin, delayMax, numberOfRuns);
            }
            catch (Exception)
            {
                MessageBox.Show("Zadal jste neplatné údaje. Použijte pouze čísla s desetinou čárkou.", "Chyba");
            }
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            gameLogic.ButtonsPressed(0);
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            gameLogic.ButtonsPressed(1);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            gameLogic.ButtonsPressed(2);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            gameLogic.ButtonsPressed(3);
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            gameLogic.ButtonsPressed(4);
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            gameLogic.ButtonsPressed(5);
        }

        private void ClearStats_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D:
                    gameLogic.ButtonsPressed(0);
                    break;

                case Key.F:
                    gameLogic.ButtonsPressed(1);
                    break;

                case Key.G:
                    gameLogic.ButtonsPressed(2);
                    break;

                case Key.H:
                    gameLogic.ButtonsPressed(3);
                    break;

                case Key.J:
                    gameLogic.ButtonsPressed(4);
                    break;

                case Key.K:
                    gameLogic.ButtonsPressed(5);
                    break;

                default:
                    break;
            }
        }
    }
}
