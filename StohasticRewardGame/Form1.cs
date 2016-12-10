using StohasticRewardGame.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StohasticRewardGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            int round = 5000;
            int repetition = 100;
            double[,] reward1 = new double[round, repetition]; // matrixes of results, rows to be averaged
            double[,] reward2 = new double[round, repetition];
            double[,] reward3 = new double[round, repetition];

            double sigma0 = 0.0;
            double sigma1 = 0.0;
            double sigma = 0.0;
            double temp1 = 1.0;
            double temp2 = 1.0;

            for (int iteration = 0; iteration < repetition; iteration++)
            {
                GameAction[,] action = new GameAction[3, 3];

                if (radioCase1.Checked)
                {
                    sigma0 = Math.Pow(0.2, 2.0);
                    sigma1 = Math.Pow(0.2, 2.0);
                    sigma = Math.Pow(0.2, 2.0);
                }
                else if (radioCase2.Checked)
                {
                    sigma0 = Math.Pow(4.0, 2.0);
                    sigma1 = Math.Pow(0.1, 2.0);
                    sigma = Math.Pow(0.1, 2.0);
                }
                else
                {
                    sigma0 = Math.Pow(0.1, 2.0);
                    sigma1 = Math.Pow(4.0, 2.0);
                    sigma = Math.Pow(0.1, 2.0);
                }

                action[0, 0] = new GameActionRandom(new RandomValueNormal(11.0, sigma0));
                action[0, 1] = new GameActionRandom(new RandomValueNormal(-30.0, sigma));
                action[0, 2] = new GameActionRandom(new RandomValueNormal(0.0, sigma));
                action[1, 0] = new GameActionRandom(new RandomValueNormal(-30.0, sigma));
                action[1, 1] = new GameActionRandom(new RandomValueNormal(7.0, sigma1));
                action[1, 2] = new GameActionRandom(new RandomValueNormal(6.0, sigma));
                action[2, 0] = new GameActionRandom(new RandomValueNormal(0.0, sigma));
                action[2, 1] = new GameActionRandom(new RandomValueNormal(0.0, sigma));
                action[2, 2] = new GameActionRandom(new RandomValueNormal(5.0, sigma));

                Game game = new Game(action,
                    new SelectorBoltzmannIndependent(action.GetLength(0), temp1),
                    new SelectorBoltzmannIndependent(action.GetLength(1), temp1));

                for (int i = 0; i < round; i++)
                {
                    game.NextStep();
                    reward1[i, iteration] = game.TotalReward;
                }

                game = new Game(action,
                    new SelectorBoltzmannMulti(action.GetLength(0), action.GetLength(1), temp2),
                    new SelectorBoltzmannMulti(action.GetLength(1), action.GetLength(0), temp2));

                for (int i = 0; i < round; i++)
                {
                    game.NextStep();
                    reward2[i, iteration] = game.TotalReward;
                }

                game = new Game(action,
                    new SelectorBestMulti(action.GetLength(0), action.GetLength(1)),
                    new SelectorBestMulti(action.GetLength(1), action.GetLength(0)));

                for (int i = 0; i < round; i++)
                {
                    game.NextStep();
                    reward3[i, iteration] = game.TotalReward;
                }
            }

            chart.Series.Clear();
            chart.ChartAreas[0].AxisX.Title = "Episode";
            chart.ChartAreas[0].AxisY.Title = "Reward";
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "{0:0}";
            chart.ChartAreas[0].AxisX.Interval = round / 10;

            string nameSeries1 = "Learner type one";
            chart.Series.Add(nameSeries1);
            chart.Series[nameSeries1].ChartType = SeriesChartType.Line;
            chart.Series[nameSeries1].Color = Color.Red;
            chart.Series[nameSeries1].BorderWidth = 2;

            for (int i = 0; i < round; i++)
            {
                double sum = 0.0;

                for (int j = 0; j < repetition; j++)
                    sum += reward1[i, j];

                sum /= repetition;

                chart.Series[nameSeries1].Points.AddXY(i + 1, sum);
            }

            string nameSeries2 = "Learner type two";
            chart.Series.Add(nameSeries2);
            chart.Series[nameSeries2].ChartType = SeriesChartType.Line;
            chart.Series[nameSeries2].Color = Color.Blue;
            chart.Series[nameSeries2].BorderWidth = 2;

            for (int i = 0; i < round; i++)
            {
                double sum = 0.0;

                for (int j = 0; j < repetition; j++)
                    sum += reward2[i, j];

                sum /= repetition;

                chart.Series[nameSeries2].Points.AddXY(i + 1, sum);
            }

            string nameSeries3 = "Learner best response";
            chart.Series.Add(nameSeries3);
            chart.Series[nameSeries3].ChartType = SeriesChartType.Line;
            chart.Series[nameSeries3].Color = Color.Green;
            chart.Series[nameSeries3].BorderWidth = 2;

            for (int i = 0; i < round; i++)
            {
                double sum = 0.0;

                for (int j = 0; j < repetition; j++)
                    sum += reward3[i, j];

                sum /= repetition;

                chart.Series[nameSeries3].Points.AddXY(i + 1, sum);
            }
        }
    }
}
