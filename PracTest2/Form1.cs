using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PracTest2
{
    public partial class Form1 : Form
    {
        //Name: Cameron Nepe
        //ID: 1262199

        //The minimum size of the board
        int MIN_BOARD_SIZE = 2;
        //The maximum size of the board
        int MAX_BOARD_SIZE = 10;

        //Width of a square
        int WIDTH = 50;
        //Height of a square
        int HEIGHT = 50;

        //the colour of a Dark square (a variable since Color cannot be a const)
        Color DarkBrown = Color.SaddleBrown;

        //the colour of a Light square (a variable since Color cannot be a const)
        Color LightBrown = Color.SandyBrown;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Draw a square at the given x and y position and size and in the given color 
        /// </summary>
        /// <param name="paper">Where to draw the graphics</param>
        /// <param name="x">The x position of the top left corner</param>
        /// <param name="y">The y position of the top left corner</param>
        /// <param name="length">The width and height of the square</param>
        /// <param name="squareColor">The fill color of the square</param>
        private void DrawSquare(Graphics paper, int x, int y, int width, int height, Color squareColor)
        {
            //Graphics paper = pictureBoxDisplay.CreateGraphics();
            SolidBrush br = new SolidBrush(squareColor);
            Pen pen1 = new Pen(Color.Black, 2);

            paper.FillRectangle(br, x, y, width, height);
            paper.DrawRectangle(pen1, x, y, width, height);
        }

        private void drawBoardMenu_Click(object sender, EventArgs e)
        {
            Graphics canvas = pictureBoxDisplay.CreateGraphics();
            int xpos = 0;
            int ypos = 0;
            int rowNum = 0; //int.Parse(toolStripTextBox1.Text);

            //DrawSquare(canvas, xpos, ypos, WIDTH, HEIGHT, DarkBrown);
            //xpos += WIDTH;
            //DrawSquare(canvas, xpos, ypos, WIDTH, HEIGHT, LightBrown);
            DrawRow(canvas, MAX_BOARD_SIZE, rowNum, ypos);
        }

        /// <summary>
        /// Draw a row at the given x and y position and in the given color
        /// </summary>
        /// <param name="paper">Where to draw the graphics</param>
        /// <param name="boardSize">Size of board</param>
        /// <param name="currentRowNum">Current row number</param>
        /// <param name="y">The y position of the top left corner</param>
        private void DrawRow(Graphics canvas, int boardSize, int currentRowNum, int y)
        {
            //Declare variables
            //Graphics canvas1 = pictureBoxDisplay.CreateGraphics();
            int xpos = 0;
            int ypos = 0;
            //GET number of squares 
            int rowNum = int.Parse(toolStripTextBox1.Text);
            int colNum = 0;

            //FOR each column to draw
            for (int i = 0; i <= MAX_BOARD_SIZE; i++)
            {
                //IF(row num + col num) % 2 == 0 THEN
                if ((rowNum + colNum) % 2 == 0) // Working on this statement
                {
                    //Call DrawSquare with LightBrown colour
                    DrawSquare(canvas, xpos, ypos, WIDTH, HEIGHT, LightBrown);
                }
                else
                {
                    //Call DrawSquare with DarkBrown colour
                    DrawSquare(canvas, xpos, ypos, WIDTH, HEIGHT, DarkBrown);
                }
                //ENDIF
                //Shift x to the right by width of square
                xpos += WIDTH;
            }
            //ENDFOR
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripTextBox1.Clear();
            toolStripTextBox1.Focus();
            pictureBoxDisplay.Refresh();
        }
    }
}
