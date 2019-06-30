using System.Drawing;

namespace WindowsFormsApp14
{
    class Elem
    {
        int key;        // ключ
        Point location; // позиция левого верхнего угла
        Color color;    // цвет

        public Elem(int _key, int num, int y)
        {
            key = _key;
            location = new Point(100 + num * (size.Height + 10), y);
            color = Color.White;
        }

        // переопределение операторов сравнения
        public static bool operator <=(Elem a, Elem b)
        {

            bool res = a.Key <= b.Key;
            if (res) a.Color = Color.Yellow;
            else
                b.Color = Color.Yellow;
            return res;
        }

        public static bool operator >=(Elem a, Elem b)
        {
            return !(a.Key <= b.Key);
        }

        public static bool operator <(Elem a, Elem b)
        {
            return a.key < b.key;
        }

        public static bool operator >(Elem a, Elem b)
        {
            return a.key > b.key;
        }

        // Свойства
        public int Key { get { return key; } set { key = value; } }
        public Point Location { get { return location; } set { location = value; } }
        public int Y { get { return location.Y; } set { location.Y = value; } }
        public int X { get { return location.X; } set { location.X = value; } }
        public Color Color { get { return color; } set { color = value; } }
        public static Size size = new Size(30, 30);
    }
}