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
            GameAction[,] action = new GameAction[3, 3];

            double sigma0 = Math.Pow(0.2, 2.0);
            double sigma1 = Math.Pow(0.2, 2.0);
            double sigma = Math.Pow(0.2, 2.0);

            action[0, 0] = new GameActionRandom(new RandomValueNormal(11.0, sigma0));
            action[0, 1] = new GameActionRandom(new RandomValueNormal(-30.0, sigma));
            action[0, 2] = new GameActionRandom(new RandomValueNormal(0.0, sigma));
            action[1, 0] = new GameActionRandom(new RandomValueNormal(-30.0, sigma));
            action[1, 1] = new GameActionRandom(new RandomValueNormal(7.0, sigma1));
            action[1, 2] = new GameActionRandom(new RandomValueNormal(6.0, sigma));
            action[2, 0] = new GameActionRandom(new RandomValueNormal(0.0, sigma));
            action[2, 1] = new GameActionRandom(new RandomValueNormal(0.0, sigma));
            action[2, 2] = new GameActionRandom(new RandomValueNormal(5.0, sigma));

            /*
            Game game = new Game(action, 
                new SelectorBoltzmannIndependent(action.GetLength(0), 5.0), 
                new SelectorBoltzmannIndependent(action.GetLength(1), 5.0));
                */

            Game game = new Game(action,
                new SelectorBoltzmannMulti(action.GetLength(0), action.GetLength(1), 5.0),
                new SelectorBoltzmannMulti(action.GetLength(1), action.GetLength(0), 5.0));

            int round = 100;

            for (int i = 0; i < round; i++)
                game.NextStep();
        }
    }
}
