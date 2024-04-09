using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FiguresClassLibrary
{
    public abstract class Figure
    {
        public Pnt[] pnts = null;
        public Color color { get; private set; } //свойство - цвет фигуры

        public int TTL; //time to live
        public Figure(Pnt[] pnts)
        {
            this.pnts = pnts;
        }

        public Figure(Pnt[] pnts, Color color, int ttl)
        {
            this.pnts = pnts;
            this.color = color;
            TTL = ttl;
        }


        public abstract double GetP();
        public abstract double GetS();
        public abstract bool isContain(Pnt pnt);
        public abstract int GetCost();

        // Метод уменьшения времени жизни
        public void DecTTL()
        {
            TTL--;
        }

        // Проверка на существование
        public bool isAlive()
        {
            if (TTL > 0)
            {
                return true;
            }
            return false;
        }


    }
}
