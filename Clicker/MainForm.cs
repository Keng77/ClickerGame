using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clicker;
using FiguresClassLibrary;

namespace Clicker
{
    public partial class MainForm : Form
    {
        const int cursorSpeed = 10; // Уменьшил скорость для более плавного движения
        private Point cursor1Position;
        private Point cursor2Position;
        Player player1 = null;
        Player player2 = null;
        FiguresList figures = new FiguresList();
        Graphics g = null;
        // Добавляем поля для хранения текущей скорости движения курсоров
        private int cursor1SpeedX = 0;
        private int cursor1SpeedY = 0;
        private int cursor2SpeedX = 0;
        private int cursor2SpeedY = 0;

        private Timer movementTimer;

        public MainForm()
        {
            InitializeComponent();
            g = CreateGraphics();
            DoubleBuffered = true;

            // Инициализируем и настраиваем таймер для движения курсоров
            movementTimer = new Timer();
            movementTimer.Interval = 1000 / 60; // примерно 60 кадров в секунду
            movementTimer.Tick += MovementTimer_Tick;
            movementTimer.Start();

            KeyDown += MainForm_KeyDown;
            KeyUp += MainForm_KeyUp;
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
            // Установка скорости движения курсоров при нажатии соответствующих клавиш
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

            // Обновление позиций курсоров после установки скоростей
            cursor1Position = pictureBox1.Location;
            cursor2Position = pictureBox2.Location;


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

        private void MovementTimer_Tick(object sender, EventArgs e)
        {
            // Обновление позиций курсоров в соответствии с их текущей скоростью
            cursor1Position.X += cursor1SpeedX;
            cursor1Position.Y += cursor1SpeedY;
            cursor2Position.X += cursor2SpeedX;
            cursor2Position.Y += cursor2SpeedY;

            // Проверка, чтобы курсоры не выходили за границы экрана
            if (cursor1Position.X < 0)
                cursor1Position.X = 0;
            if (cursor1Position.X > ClientSize.Width - pictureBox1.Width)
                cursor1Position.X = ClientSize.Width - pictureBox1.Width;
            if (cursor1Position.Y < 0)
                cursor1Position.Y = 0;
            if (cursor1Position.Y > ClientSize.Height - pictureBox1.Height)
                cursor1Position.Y = ClientSize.Height - pictureBox1.Height;

            if (cursor2Position.X < 0)
                cursor2Position.X = 0;
            if (cursor2Position.X > ClientSize.Width - pictureBox2.Width)
                cursor2Position.X = ClientSize.Width - pictureBox2.Width;
            if (cursor2Position.Y < 0)
                cursor2Position.Y = 0;
            if (cursor2Position.Y > ClientSize.Height - pictureBox2.Height)
                cursor2Position.Y = ClientSize.Height - pictureBox2.Height;

            // Обновляем позиции PictureBox
            pictureBox1.Location = cursor1Position;
            pictureBox2.Location = cursor2Position;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            // Обнуление скорости движения курсоров при отпускании клавиш
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