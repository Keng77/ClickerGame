using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clicker;
using ClickerClassLibrary;
using FiguresClassLibrary;

namespace Clicker
{
    public partial class MainForm : Form
    {
        const int cursorSpeed = 30;
        private Point cursor1Position;
        private Point cursor2Position;
        Player player1 = null; 
        Player player2 = null;
        FiguresList figures = new FiguresList();
        Graphics g = null;

        public MainForm()
        {
            InitializeComponent();
            g = CreateGraphics();
            DoubleBuffered = true;
            KeyDown += MainForm_KeyDown;
        }

        private void ShowElements()
        {
            ScoreLabel1.Visible = !ScoreLabel1.Visible;
            ScoreLabel2.Visible = !ScoreLabel2.Visible;
            pictureBox1.Visible = !pictureBox1.Visible;
            pictureBox2.Visible = !pictureBox2.Visible;
            StartButton.Visible = !StartButton.Visible;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            PlayerForm playerForm = new PlayerForm();
            if (playerForm.ShowDialog() == DialogResult.OK)
            {
                player1 = new Player(playerForm.GetPlayer1Name());
                player2 = new Player(playerForm.GetPlayer2Name());
                ScoreLabel1.Text = player1.ToString();
                ScoreLabel2.Text = player2.ToString();
                ShowElements();
                timer1.Start();
                playerForm.Close();
                playerForm.Dispose();
            }
        }


        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Перемещение первого курсора
            if (e.KeyCode == Keys.W)
            {
                cursor1Position.Y -= cursorSpeed;
            }
            else if (e.KeyCode == Keys.S)
            {
                cursor1Position.Y += cursorSpeed;
            }
            else if (e.KeyCode == Keys.A)
            {
                cursor1Position.X -= cursorSpeed;
            }
            else if (e.KeyCode == Keys.D)
            {
                cursor1Position.X += cursorSpeed;
            }

            // Перемещение второго курсора
            if (e.KeyCode == Keys.Up)
            {
                cursor2Position.Y -= cursorSpeed;
            }
            else if (e.KeyCode == Keys.Down)
            {
                cursor2Position.Y += cursorSpeed;
            }
            else if (e.KeyCode == Keys.Left)
            {
                cursor2Position.X -= cursorSpeed;
            }
            else if (e.KeyCode == Keys.Right)
            {
                cursor2Position.X += cursorSpeed;
            }

            // Обновление позиций курсоров
            pictureBox1.Location = cursor1Position;
            pictureBox2.Location = cursor2Position;

            if (ActiveForm == this) // Проверка, что активна главная форма
            {
                if (e.KeyCode == Keys.E)
                {
                    Pnt pnt = new Pnt(cursor1Position.X, cursor1Position.Y);
                    Figure figure = figures.FindFigure(pnt);
                    if (figure != null)
                    {
                        // Добавление очков
                        player1.AddScore(figure.GetCost());
                        ScoreLabel1.Text = player1.ToString();
                        FigureDraw.Draw(g, figure, BackColor);
                        figures.RemoveFigure(figure);
                    }
                }
                if (e.KeyCode == Keys.NumPad2)
                {
                    Pnt pnt = new Pnt(cursor2Position.X, cursor2Position.Y);
                    Figure figure = figures.FindFigure(pnt);
                    if (figure != null)
                    {
                        // Добавление очков
                        player2.AddScore(figure.GetCost());
                        ScoreLabel2.Text = player2.ToString();
                        FigureDraw.Draw(g, figure, BackColor);
                        figures.RemoveFigure(figure);
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Загрузка изображений для курсоров
            pictureBox1.Image = Image.FromFile("D:\\Laba\\Cours 2\\Курсач ООП\\ClickerGameProject\\ClickerGame\\CursorImages\\cursor1.jpeg");
            pictureBox2.Image = Image.FromFile("D:\\Laba\\Cours 2\\Курсач ООП\\ClickerGameProject\\ClickerGame\\CursorImages\\cursor2.jpeg");

            // Установка начальных позиций курсоров
            cursor1Position = pictureBox1.Location;
            cursor2Position = pictureBox2.Location;
            KeyPreview = true;

            // Установка формы в полноэкранный режим
            WindowState = FormWindowState.Maximized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Figure figure;

            figure = FiguresList.GetRndFigure(Width / 2, Height / 2, 60);

            figures.AddFigure(figure);

            figures.DecTTL();

            Queue<Figure> notAliveFigures = figures.GetNotAliveFigures();

            while (notAliveFigures.Count > 0)
            {
                Figure f = notAliveFigures.Dequeue();
                FigureDraw.Draw(g, f, BackColor);
                figures.RemoveFigure(f);
            }

            foreach (Figure f in figures.figures)
            {
                FigureDraw.Draw(g, f);
            }
        }
    }
}
