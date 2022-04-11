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
            gameLogic = new GameLogic(this);
        }

        public void ChangeColor(int index)
        {
            switch (index)
            {
                case 0:
                    Button0.Background = Brushes.LimeGreen;
                    break;

                case 1:
                    Button1.Background = Brushes.LimeGreen;
                    break;

                case 2:
                    Button2.Background = Brushes.LimeGreen;
                    break;
                case 3:
                    Button3.Background = Brushes.LimeGreen;
                    break;

                case 4:
                    Button4.Background = Brushes.LimeGreen;
                    break;

                case 5:
                    Button5.Background = Brushes.LimeGreen;
                    break;

                default:
                    break;
            }
        }

        public void ClearAll()
        {
            SolidColorBrush color = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFDDDDDD");
            Button0.Background = color;
            Button1.Background = color;
            Button2.Background = color;
            Button3.Background = color;
            Button4.Background = color;
            Button5.Background = color;
        }


        public void ShowMsgError(string message)
        {
            MessageBox.Show(message, "Chyba!");
        }

        public void ShowTimes(List<int> values)
        {
            string text = "";
            foreach (int value in values)
                text += value.ToString() + " ms" + "\r\n";

            text += "\r\n";
            text += "Průměrný čas: " + values.Average().ToString("#.##") + " ms" + "\r\n";
            text += "Nejlepší čas: " + values.Min() + " ms" + "\r\n";
            text += "Nejhorší čas: " + values.Max() + " ms" + "\r\n";

            LabelAverage.Content = $"Poslední průměr: {values.Average().ToString("#.##")} ms";
            LabelMin.Content = $"Poslední nejrychlejší: {values.Min()} ms";
            LabelMax.Content = $"Poslední nejpomalejší: {values.Max()} ms";

            MessageBox.Show(text, "Výsledek");
        }

        private void StartClick()
        {
            try
            {
                //read values from input
                double delayMin = double.Parse(TextBoxsetTimeFrom.Text);
                double delayMax = double.Parse(TextBoxsetTimeTo.Text);
                int numberOfRuns = int.Parse(ComboBoxSelectRuns.Text);

                gameLogic.NewGame(delayMin, delayMax, numberOfRuns);
            }
            catch (Exception)
            {
                MessageBox.Show("Zadal jste neplatné údaje. Použijte pouze čísla s desetinou čárkou.", "Chyba");
            }
        }

        //Event based methods
        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            StartClick();
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

                case Key.Space:
                    StartClick();
                    break;

                default:
                    break;
            }
        }
    }
}
