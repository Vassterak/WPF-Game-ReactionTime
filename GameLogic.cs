using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace WPF_Game_ReactionTime
{
    public class GameLogic
    {
        MainWindow mainWindow;
        Random rnd;
        Stopwatch timer;

        double currentDelayMin, currentDelayMax;
        int currentNumberOfRuns;

        bool gameIsRunning = false;

        public GameLogic(MainWindow main)
        {
            mainWindow = main;
            rnd = new Random();
            timer = new Stopwatch();
        }

        private void RandomButtonSelect()
        {
            int index = rnd.Next(0, 6+1); //select random button
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
                currentNumberOfRuns = numberOfRuns;
                gameIsRunning = true;
                RandomButtonSelect();
            }
            else
            {
                //mainWindow.ShowError....
            }
        }

        public void ButtonsPressed(int buttonID)
        {
            timer.Stop();
            mainWindow.ShowElepsedTime(timer.Elapsed.TotalMilliseconds.ToString());
            mainWindow.ClearAll();
            gameIsRunning = false;
        }
    }
}
