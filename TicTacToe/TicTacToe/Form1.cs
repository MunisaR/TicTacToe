using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private enum Players
        {
            None,
            Player1,
            Player2
        }

        private void pnl_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.DrawLine(Pens.Black, 70, 1, 70, 210);
            g.DrawLine(Pens.Black, 140, 1, 140, 210);
            g.DrawLine(Pens.Black, 1, 70, 210, 70);
            g.DrawLine(Pens.Black, 1, 140, 210, 140);


            for (var i = 0; i < 3; i++)

            {

                for (var j = 0; j < 3; j++)

                {

                    var cellCoordinates = new Rectangle(i * 70 + 1, j * 70 + 1, 69, 69);

                    if (cells[i, j] == Players.Player1)

                        g.FillRegion(Brushes.Blue, new Region(cellCoordinates));

                    else if (cells[i, j] == Players.Player2)

                        g.FillRegion(Brushes.Red, new Region(cellCoordinates));

                }

            }
        }

        private Players[,] cells = new Players[3, 3];
        Players currentMove = Players.Player1;

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            var isMove = false;
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var cellCoordinates = new Rectangle(i * 70 + 1, j * 70 + 1, 69, 69);
                    if (cellCoordinates.Contains(e.Location.X, e.Location.Y))
                    {
                        //check that it's not already occupied
                        if (cells[i, j] == Players.None)
                        {
                            isMove = true;
                            cells[i, j] = currentMove;
                        }
                    }
                }
            }
            if (isMove)
            {
                //change the turn
                currentMove = currentMove ==
                    Players.Player1
                        ? Players.Player2
                        : Players.Player1;
                //redraw
                pnl.Invalidate();
            }
        }
    }
}
