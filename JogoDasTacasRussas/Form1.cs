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

        private void button1_Click(object sender, EventArgs e)
        {
            this.board = new Board(this);
        }

        private void PictureBoxX1Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxX1);
        }

        private void PictureBoxX2Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxX2);
        }

        private void PictureBoxX3Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxX3);
        }

        private void PictureBoxX4Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxX4);
        }

        private void PictureBoxX5Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxX5);
        }

        private void PictureBoxX6Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxX6);
        }

        private void PictureBoxX7Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxX7);
        }

        private void PictureBoxX8Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxX8);
        }

        private void PictureBoxX9Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxX9);
        }

        private void PictureBoxX10Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxX10);
        }

        private void PictureBoxX11Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxX11);
        }

        private void PictureBoxX12Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxX12);
        }

        private void PictureBoxY1Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxY1);
        }

        private void PictureBoxY2Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxY2);
        }

        private void PictureBoxY3Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxY3);
        }

        private void PictureBoxY4Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxY4);
        }

        private void PictureBoxY5Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxY5);
        }

        private void PictureBoxY6Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxY6);
        }

        private void PictureBoxY7Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxY7);
        }

        private void PictureBoxY8Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxY8);
        }

        private void PictureBoxY9Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxY9);
        }

        private void PictureBoxY10Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxY10);
        }

        private void PictureBoxY11Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxY11);
        }

        private void PictureBoxY12Click(object sender, EventArgs e)
        {
            board.Click(pictureBoxY12);
        }
    }
}
