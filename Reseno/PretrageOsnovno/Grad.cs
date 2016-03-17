using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Text;

namespace PretrageOsnovno
{
    class Grad : Node
    {
        
        public Grad(string name, Point position):base(name,0) //cena je u pocetku 0 zato sto nzm koji je ciljni grad
        {
            this.Position = position;
        }

        public Point Position { get; set; }
        /// <summary>
        /// Na osnovu pozicije grada do kog trebamo stici, racuna heuristiku
        /// </summary>
        /// <param name="p">Pozicija ciljnog grada</param>
        public void izracunajHeuristic(Point p)
        {
            var x1 = Position.X;
            var y1 = Position.Y;
            var x2 = p.X;
            var y2 = p.Y;
            Console.WriteLine("     " + Math.Pow(5, 2));
            base.Heuristic = (Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
           
        }
    }
}
