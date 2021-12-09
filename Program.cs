using System;
using System.Drawing;

namespace DrawPicture
{
    class Program
    {
        static void Main(string[] args)
        {
            DrawGraphic graphic = new DrawGraphic(1000, 1000);

            graphic.Pen = new Pen(Color.FromArgb(255, 0, 192, 255));

            graphic.Draw(x => Math.Pow(x, 4) - 2*x*x - 3, new Pen(Color.Yellow));
            graphic.Draw(x => x > 0 ? 1-1/x: 0, new Pen(Color.Red));
            graphic.Draw(x => -1 + 1, new Pen(Color.Red));

            graphic.Draw(x => x > 0 ? -1/x: 0, new Pen(Color.Green));
            graphic.Draw(x => -1, new Pen(Color.Green));
            graphic.DrawVerticalLine(Math.E, new Pen(Color.Green));


            graphic.Save("Graphs.png");
        }
    }
}
