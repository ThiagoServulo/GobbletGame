using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JogoDasTacasRussas.Entities;

namespace JogoDasTacasRussas
{
    public partial class Form1 : Form
    {
        Board board;

        public Form1()
        {
            InitializeComponent();
        }

        private void DrawCircle(PictureBox pictureBox, Color color, int x, int y, int width, int height)
        {
            if (x == y && y == width && width == height && height == 0)
            {
                pictureBox.Dispose();
                return;
            }

            Graphics paper = pictureBox.CreateGraphics();
            SolidBrush solidBrush = new SolidBrush(color);
            paper.FillEllipse(solidBrush, x, y, width, height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.board = new Board(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
