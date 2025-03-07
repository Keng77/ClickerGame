﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clicker;
using FiguresClassLibrary;

namespace Clicker
{
    public partial class GameForm : Form
    {
        private Point cursor1Position;
        private Point cursor2Position;
        Player player1;
        Player player2;
        readonly FiguresList figures = new FiguresList();
        private readonly Graphics g;
        private readonly CursorManager cursorManager;
        private Timer movementTimer;
        private Timer spawnTimer;

        public GameForm()
        {
            InitializeComponent();
            InitializeTimers();
            g = CreateGraphics();
            DoubleBuffered = true;           

            KeyDown += MainForm_KeyDown;
            KeyUp += MainForm_KeyUp;

            // Создаем экземпляр CursorManager и передаем PictureBox'ы
            cursorManager = new CursorManager(pictureBox1, pictureBox2, topPanel);
            // Вызываем метод OnPaint для отрисовки фигур
            this.Paint += MainForm_Paint;
        }

        private void ShowElements()
        {
            Cursor.Hide();
            GameNameLabel.Visible = !GameNameLabel.Visible;
            ScoreLabel1.Visible = !ScoreLabel1.Visible;
            ScoreLabel2.Visible = !ScoreLabel2.Visible;
            PenaltyLabel.Visible = !PenaltyLabel.Visible;
            PenaltyColorBox.Visible = !PenaltyColorBox.Visible;
            topPanel.Visible = !topPanel.Visible;
            pictureBox1.Visible = !pictureBox1.Visible;
            pictureBox2.Visible = !pictureBox2.Visible;
            StartButton.Visible = !StartButton.Visible;
            ExitButton.Visible = !ExitButton.Visible;
            BackgroundImage = Image.FromFile("gamefon.jpg");
            BackgroundImageLayout = ImageLayout.Stretch;
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
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.Close();
            }
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
                    if(figure is FigureDecorator && PenaltyColorBox.BackColor == figure.Color)
                    {
                        player1.AddScore(figure.GetCost());
                    }
                    else if (figure is FigureDecorator DecoratedFigure)
                    {
                        player1.AddScore(DecoratedFigure.GetBaseCost());
                    }
                    else
                    {
                        player1.AddScore(figure.GetCost());
                    }
                    ScoreLabel1.Text = player1.ToString();
                    if(player1.Score >= 150) Playerwin(player1);
                    FigureDraw.Draw(g, figure, TransparencyKey);
                    BackgroundImage = Image.FromFile("gamefon.jpg");
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
                    if (figure is FigureDecorator && PenaltyColorBox.BackColor == figure.Color)
                    {
                        player2.AddScore(figure.GetCost());
                    }
                    else if (figure is FigureDecorator DecoratedFigure)
                    {
                        player2.AddScore(DecoratedFigure.GetBaseCost());
                    }
                    else
                    {
                        player2.AddScore(figure.GetCost());
                    }
                    ScoreLabel2.Text = player2.ToString();
                    if (player2.Score >= 150) Playerwin(player2);
                    FigureDraw.Draw(g, figure, TransparencyKey);
                    BackgroundImage = Image.FromFile("gamefon.jpg");
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

        private void Playerwin(Player player)
        {
            Cursor.Show();
            spawnTimer.Stop();
            MessageBox.Show($@"Игрок ""{player.Name}"" набрал {player.Score} очков. Вы победили!", "Победа!");
            Close();
        }

        private void SpawnTimer_Tick(object sender, EventArgs e)
        {
            Figure figure = figures.GetRndFigure(Width, Height);

            figures.DecTTL();

            Queue<Figure> notAliveFigures = figures.GetNotAliveFigures();

            while (notAliveFigures.Count > 0)
            {
                Figure f = notAliveFigures.Dequeue();
                FigureDraw.Draw(g, f, TransparencyKey);
                figures.RemoveFigure(f);
            }

            figures.AddFigure(figure);

                if (figure is FigureDecorator)
                {
                    PenaltyColorBox.BackColor = figure.Color;
                  
                }
            Invalidate();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            // Отрисовываем фигуры
            foreach (Figure f in figures.Figures)
            {
                FigureDraw.Draw(e.Graphics, f, f.Color);
            }
        }

        private void InitializeTimers()
        {
            // Инициализируем и настраиваем таймер для движения курсоров
            movementTimer = new Timer
            {
                Interval = 1000 / 120 // примерно 120 кадров в секунду
            };
            movementTimer.Tick += MovementTimer_Tick;
            

            // Инициализируем и настраиваем таймер для спавна фигур
            spawnTimer = new Timer
            {
                Interval = 1000 // каждую секунду
            };
            spawnTimer.Tick += SpawnTimer_Tick;
        }

 
    }
}