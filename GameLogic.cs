using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace WPF_Game_ReactionTime
{
    public class GameLogic
    {
        MainWindow mainWindow;
        Random rnd;
        Stopwatch timer;

        List<int> reactionTimes; //in ms

        double currentDelayMin, currentDelayMax;
        int targetNumberOfRuns, selectedIndex, currentNumberOfRuns;

        bool gameIsRunning = false;

        public GameLogic(MainWindow main)
        {
            mainWindow = main;
            rnd = new Random();
            timer = new Stopwatch();
            reactionTimes = new List<int>();
        }

        private void RandomButtonSelect()
        {
            int index = selectedIndex = rnd.Next(0, 5+1); //select random button
            int delay = Convert.ToInt32(1000 * (rnd.NextDouble() * (currentDelayMax - currentDelayMin)) + currentDelayMin); //get random delay in range (miliseconds)

            Thread.Sleep(delay);
            timer.Reset();
            timer.Start();

            mainWindow.ChangeColor(index);
        }

        public void NewGame(double delayMin, double delayMax, int numberOfRuns)
        {
            if (!gameIsRunning)
            {
                currentDelayMax = delayMax;
                currentDelayMin = delayMin;
                targetNumberOfRuns = numberOfRuns;
                gameIsRunning = true;
                reactionTimes.Clear();
                mainWindow.ButtonStart.IsEnabled = false;

                RandomButtonSelect();
            }
            else
            {
                mainWindow.ShowMsgError("Zkontroluj zda jsi zadal vstupní hodnoty ve správném formátu!");
                gameIsRunning = false;
                mainWindow.ButtonStart.IsEnabled = true;
            }
        }

        public void ButtonsPressed(int buttonID)
        {
            if (buttonID == selectedIndex && gameIsRunning)
            {
                timer.Stop();
                reactionTimes.Add(Convert.ToInt32(timer.Elapsed.TotalMilliseconds)); //add time to list
                mainWindow.ClearAll(); //clear colors

                currentNumberOfRuns++;
                if (targetNumberOfRuns > currentNumberOfRuns)
                    RandomButtonSelect();

                else
                {
                    gameIsRunning = false;
                    mainWindow.ButtonStart.IsEnabled = true;
                    currentNumberOfRuns = 0;
                    mainWindow.ShowTimes(reactionTimes);
                }
            }
        }
    }
}
