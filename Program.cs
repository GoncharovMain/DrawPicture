using System;
using System.Drawing;

namespace DrawPicture
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawGraphic graphic = new DrawGraphic(700, 700);

            graphic.Pen = new Pen(Color.FromArgb(255, 0, 192, 255));

            graphic.Draw(x => x * x, new Pen(Color.Yellow));
            graphic.Draw(x => x > 0 ? Math.Sqrt(x) : 0, new Pen(Color.Green));
            graphic.Draw(x => x * x * x, new Pen(Color.Green));
            graphic.Draw(x => -5 + 3 * Math.Sin(1.5 * x), new Pen(Color.Red));
            graphic.Draw(x => -3 + 6 / (1 + Math.Exp(-x)));

            graphic.Save("Graphs.png");
        }
    }
}
