using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    /// <summary>
    /// Класс, представляющий игрока.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Имя игрока.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Счет игрока.
        /// </summary>
        public int Score;

        /// <summary>
        /// Создает новый экземпляр класса Player с заданным именем и начальным счетом 0.
        /// </summary>
        /// <param name="name">Имя игрока.</param>
        public Player(string name)
        {
            Name = name;
            Score = 0;
        }

        /// <summary>
        /// Увеличивает счет игрока на заданное значение.
        /// </summary>
        /// <param name="score">Значение, на которое увеличивается счет игрока.</param>
        public void AddScore(int score)
        {
            this.Score += score;
        }

        /// <summary>
        /// Возвращает строковое представление игрока, включающее имя и счет.
        /// </summary>
        /// <returns>Строковое представление игрока.</returns>
        public override string ToString()
        {
            return Name + ": " + Score;
        }
    }
}