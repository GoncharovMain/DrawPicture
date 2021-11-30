using System.Drawing;

namespace DrawPicture
{
    public class DrawGraphic
    {
        private int _width;
        private int _height;
        private Bitmap _bitmap;
        private Graphics _graphic;
        private int _stepWidth;
        private int _stepHeight;
        private int _centerX;
        private int _centerY;

        public delegate double Function(double x);
        public Color Background { get; set; }
        public Pen Pen { get; set; }

        public DrawGraphic(int width, int height)
        {
            this._width = width;
            this._height = height;

            this._bitmap = new Bitmap(width, height);
            _graphic = Graphics.FromImage(_bitmap);

            this.Pen = new Pen(Color.White);
            this.Background = Color.Black;

            _graphic.Clear(this.Background);

            this._stepWidth = width / 20;
            this._stepHeight = height / 20;

            _centerX = _width / 2;
            _centerY = _height / 2;

            DrawCells();
        }
        public DrawGraphic() : this(1000, 1000) { }
        public void Draw(Function function)
        {
            Point startPoint = new Point(_width / 2, _height / 2);

            double biasX = _width / 2 / _stepWidth;
            double biasY = _height / 2 / _stepHeight;

            double stepValue = 0.005;
            double value_y;

            int index_x, index_y;

            for (double value_x = -biasX; value_x < biasX; value_x += stepValue)
            {
                value_y = function(value_x);

                if (-biasY > value_y || value_y > biasY) continue;

                index_x = (int) (value_x * _stepWidth + _centerX);
                index_y = (int) (_height - value_y * _stepHeight - 1 - _centerY);

                _bitmap.SetPixel(index_x, index_y, Pen.Color);
            }
        }
        public void Draw(Function function, Pen pen)
        {
            Pen temp = this.Pen;

            this.Pen = pen;

            Draw(function);

            this.Pen = temp;
        }
        public void Save(string filename) => _bitmap.Save(filename);
        private void DrawCells()
        {
            Pen penAxis = new Pen(Color.FromArgb(50, 0, 192, 255));

            for (int stepX = 0; stepX < _width; stepX += _stepWidth)
                _graphic.DrawLine(
                    penAxis,
                    new Point(x: 0, y: stepX),
                    new Point(x: _width, y: stepX)
                    );

            for (int stepY = 0; stepY < _height; stepY += _stepHeight)
                _graphic.DrawLine(
                    penAxis,
                    new Point(x: stepY, y: 0),
                    new Point(x: stepY, y: _height)
                    );

            _graphic.DrawLine(this.Pen, new Point(x: 0, y: _centerY), new Point(x: _width, y: _centerY));
            _graphic.DrawLine(this.Pen, new Point(x: _centerX, y: 0), new Point(x: _centerX, y: _height));
        }
    }
}