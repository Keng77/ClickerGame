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
        private Point cursor1Position;
        private Point cursor2Position;
        Player player1 = null;
        Player player2 = null;
        readonly FiguresList figures = new FiguresList();
        readonly Graphics g = null;
        private readonly CursorManager cursorManager;
        private Timer movementTimer;
        private Timer spawnTimer;

        public MainForm()
        {
            InitializeComponent();
            InitializeCursors();
            InitializeTimers();
            g = CreateGraphics();
            DoubleBuffered = true;           

            KeyDown += MainForm_KeyDown;
            KeyUp += MainForm_KeyUp;

            // Создаем экземпляр CursorManager и передаем PictureBox'ы
            cursorManager = new CursorManager(pictureBox1, pictureBox2);
        }

        private void ShowElements()
        {
            ScoreLabel1.Visible = !ScoreLabel1.Visible;
            ScoreLabel2.Visible = !ScoreLabel2.Visible;
            PenaltyLabel.Visible = !PenaltyLabel.Visible;
            PenaltyColorBox.Visible = !PenaltyColorBox.Visible;
            pictureBox1.Visible = !pictureBox1.Visible;
            pictureBox2.Visible = !pictureBox2.Visible;
            StartButton.Visible = !StartButton.Visible;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            using (PlayerForm playerForm = new PlayerForm())
            {
                if (playerForm.ShowDialog() == DialogResult.OK)
                {
                    player1 = new Player(playerForm.GetPlayer1Name());
                    player2 = new Player(playerForm.GetPlayer2Name());
                    ScoreLabel1.Text = player1.ToString();
                    ScoreLabel2.Text = player2.ToString();
                    ShowElements();
                    movementTimer.Start();
                    spawnTimer.Start();
                }
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Передаем нажатие клавиш в CursorManager
            KeyEventArgs keyEventArgs = new KeyEventArgs(e.KeyCode);
            cursorManager.HandleKeyDown(keyEventArgs);

            // Обновление позиций курсоров после установки скоростей
            cursorManager.UpdateCursorsPositions();
            cursor1Position = pictureBox1.Location;
            cursor2Position = pictureBox2.Location;

            HandleKeyPress(e.KeyCode);
        }

        private void HandleKeyPress(Keys keyCode)
        {
            if (keyCode == Keys.E)
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
            else if (keyCode == Keys.NumPad2)
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

        private void MovementTimer_Tick(object sender, EventArgs e)
        {
            // Обновление позиций курсоров в соответствии с их текущей скоростью
            cursorManager.UpdateCursorsPositions();

            // Получаем обновленные позиции курсоров
            cursor1Position = pictureBox1.Location;
            cursor2Position = pictureBox2.Location;

            // Обновляем позиции курсоров на форме
            pictureBox1.Location = cursor1Position;
            pictureBox2.Location = cursor2Position;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            // Передаем отпускание клавиш в CursorManager
            KeyEventArgs keyEventArgs = new KeyEventArgs(e.KeyCode);
            cursorManager.HandleKeyUp(keyEventArgs);
        }

        private void SpawnTimer_Tick(object sender, EventArgs e)
        {
            Figure figure = figures.GetRndFigure(Width / 2, Height / 2, 60);
            figures.AddFigure(figure);

            figures.DecTTL();

            Queue<Figure> notAliveFigures = figures.GetNotAliveFigures();

            while (notAliveFigures.Count > 0)
            {
                Figure f = notAliveFigures.Dequeue();
                FigureDraw.Draw(g, f, BackColor);
                figures.RemoveFigure(f);
            }

            foreach (Figure f in figures.Figures)
            {
                FigureDraw.Draw(g, f);

                if (f is FigureDecorator )
                {
                    PenaltyColorBox.BackColor = f.Color;
                    break; // Добавляем break, чтобы установить цвет только для первой живой фигуры-декоратора
                }
            }
        }

        private void InitializeCursors()
        {
            pictureBox1.Image = Image.FromFile("D:\\Laba\\Cours 2\\Курсач ООП\\ClickerGameProject\\ClickerGame\\CursorImages\\cursor1.jpeg");
            pictureBox2.Image = Image.FromFile("D:\\Laba\\Cours 2\\Курсач ООП\\ClickerGameProject\\ClickerGame\\CursorImages\\cursor2.jpeg");
        }
        
        private void InitializeTimers()
        {
            // Инициализируем и настраиваем таймер для движения курсоров
            movementTimer = new Timer
            {
                Interval = 1000 / 60 // примерно 60 кадров в секунду
            };
            movementTimer.Tick += MovementTimer_Tick;
            

            // Инициализируем и настраиваем таймер для спавна фигур
            spawnTimer = new Timer
            {
                Interval = 1000 // каждые 2 секунды
            };
            spawnTimer.Tick += SpawnTimer_Tick;
        }
    }
}