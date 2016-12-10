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
            GameAction[,] action = new GameAction[3, 3];

            double sigma0 = 0.0;
            double sigma1 = 0.0;
            double sigma = 0.0;

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

            int round = 5000;

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

            Game game = new Game(action,
                new SelectorBoltzmannIndependent(action.GetLength(0), 5.0),
                new SelectorBoltzmannIndependent(action.GetLength(1), 5.0));

            for (int i = 0; i < round; i++)
            {
                game.NextStep();
                chart.Series[nameSeries1].Points.AddXY(i + 1, game.TotalReward);
            }

            string nameSeries2 = "Learner type two";
            chart.Series.Add(nameSeries2);
            chart.Series[nameSeries2].ChartType = SeriesChartType.Line;
            chart.Series[nameSeries2].Color = Color.Blue;
            chart.Series[nameSeries2].BorderWidth = 2;

            game = new Game(action,
                new SelectorBoltzmannMulti(action.GetLength(0), action.GetLength(1), 5.0),
                new SelectorBoltzmannMulti(action.GetLength(1), action.GetLength(0), 5.0));

            for (int i = 0; i < round; i++)
            {
                game.NextStep();
                chart.Series[nameSeries2].Points.AddXY(i + 1, game.TotalReward);
            }
        }
    }
}
