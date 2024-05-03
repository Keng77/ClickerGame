using System;
using System.Drawing;
using System.Windows.Forms;
using Clicker;
using FiguresClassLibrary;

namespace Clicker
{
    public class CursorManager
    {
        private const int cursorSpeed = 12;
        private Point cursor1Position;
        private Point cursor2Position;
        private int cursor1SpeedX = 0;
        private int cursor1SpeedY = 0;
        private int cursor2SpeedX = 0;
        private int cursor2SpeedY = 0;
        private readonly PictureBox pictureBox1;
        private readonly PictureBox pictureBox2;
        private readonly Panel topPanel;

        public CursorManager(PictureBox pictureBox1, PictureBox pictureBox2, Panel topPanel)
        {
            this.pictureBox1 = pictureBox1;
            this.pictureBox2 = pictureBox2;
            this.topPanel = topPanel;

            cursor1Position = pictureBox1.Location;
            cursor2Position = pictureBox2.Location;

            KeyPreview = true;
        }

        public bool KeyPreview { get; set; }
        public int Cursor1SpeedY { get; set; }
        public int Cursor1SpeedX { get; set; }
        public Point Cursor1Position { get; set; }
        public int Cursor2SpeedX { get; set; }
        public int Cursor2SpeedY { get; set; }
        public Point Cursor2Position { get; set; }

        public void HandleKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                cursor1SpeedY = -cursorSpeed;
            }
            else if (e.KeyCode == Keys.S)
            {
                cursor1SpeedY = cursorSpeed;
            }
            else if (e.KeyCode == Keys.A)
            {
                cursor1SpeedX = -cursorSpeed;
            }
            else if (e.KeyCode == Keys.D)
            {
                cursor1SpeedX = cursorSpeed;
            }

            if (e.KeyCode == Keys.Up)
            {
                cursor2SpeedY = -cursorSpeed;
            }
            else if (e.KeyCode == Keys.Down)
            {
                cursor2SpeedY = cursorSpeed;
            }
            else if (e.KeyCode == Keys.Left)
            {
                cursor2SpeedX = -cursorSpeed;
            }
            else if (e.KeyCode == Keys.Right)
            {
                cursor2SpeedX = cursorSpeed;
            }

            cursor1Position = pictureBox1.Location;
            cursor2Position = pictureBox2.Location;
        }

        public void HandleKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.S)
            {
                cursor1SpeedY = 0;
            }
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.D)
            {
                cursor1SpeedX = 0;
            }

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                cursor2SpeedY = 0;
            }
            else if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                cursor2SpeedX = 0;
            }
        }

        public void UpdateCursorsPositions()
        {
            cursor1Position.X += cursor1SpeedX;
            cursor1Position.Y += cursor1SpeedY;
            cursor2Position.X += cursor2SpeedX;
            cursor2Position.Y += cursor2SpeedY;

            // Ограничение позиции курсора 1
            if (cursor1Position.X < 0)
                cursor1Position.X = 0;
            if (cursor1Position.X > pictureBox1.Parent.ClientSize.Width - pictureBox1.Width)
                cursor1Position.X = pictureBox1.Parent.ClientSize.Width - pictureBox1.Width;
            if (cursor1Position.Y < topPanel.Bottom)
                cursor1Position.Y = topPanel.Bottom;
            if (cursor1Position.Y > pictureBox1.Parent.ClientSize.Height - pictureBox1.Height)
                cursor1Position.Y = pictureBox1.Parent.ClientSize.Height - pictureBox1.Height;

            // Ограничение позиции курсора 2
            if (cursor2Position.X < 0)
                cursor2Position.X = 0;
            if (cursor2Position.X > pictureBox2.Parent.ClientSize.Width - pictureBox2.Width)
                cursor2Position.X = pictureBox2.Parent.ClientSize.Width - pictureBox2.Width;
            if (cursor2Position.Y < topPanel.Bottom)
                cursor2Position.Y = topPanel.Bottom;
            if (cursor2Position.Y > pictureBox2.Parent.ClientSize.Height - pictureBox2.Height)
                cursor2Position.Y = pictureBox2.Parent.ClientSize.Height - pictureBox2.Height;

            pictureBox1.Location = cursor1Position;
            pictureBox2.Location = cursor2Position;
        }
    }
}