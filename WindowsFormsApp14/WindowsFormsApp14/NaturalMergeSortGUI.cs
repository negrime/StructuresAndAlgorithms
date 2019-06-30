using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp14 
{
    class NaturalMergeSortGUI
    {
        Elem[] baseMas;     // сортируемый массив
        Elem[] helpMas;     // вспомогательный массив
        Graphics graphics;  // холст

        int speed;          // скорость анимации
        int Direction;      // направление перемещения

        Color[] colors = { Color.Red, Color.Green, Color.Violet, Color.Blue, Color.Yellow };
        int currentColor = 0;

        // меняет местами a и b
        static void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        // копирование элементов из А в B
        void CopyMas(Elem[] A, Elem[] B)
        {
            for (int i = 0; i < A.Length; ++i)
                B[i].Key = A[i].Key;

            for (int i = 0; i < A.Length; ++i)
                A[i].Key = 0;

            DrawMas(baseMas);
            DrawMas(helpMas);
        }

        public bool MoveElem(Elem[] B, Elem[] A, ref int rInd, int rD, int rOther, ref int wInd, int wD)
        {
            bool eor = (rInd + rD) * rD >= rOther * rD || A[rInd + rD] < A[rInd];

            // было ли смещение
            bool needMoveBack = IsNeedMoveBackAnimation(A[rOther]);
            // возвращаем другой элемент на место
            if (needMoveBack)
                MoveElemBackAnimation(A[rOther]);
            // если необходимо, определяем цвет следующего элемента
            if (rInd + rD != rOther && A[rInd + rD].Color != Color.Black)
                SetColorNextAnimation(A[rInd + rD], eor);
            // анимация перемещения элемента
            TransportingAnimation(A[rInd], needMoveBack);

            B[wInd].Key = A[rInd].Key;

            rInd += rD;

            DrawColorElem(B[wInd], colors[currentColor]);

            wInd += wD;

            return eor;
        }


        // анимация "выезд элемента"
        protected void MoveOutAnimation(Elem elem, int sleep = 0)
        {
            Color color = elem.Color;
            DrawColorElem(elem, Color.Black, 0);
            elem.Y += 20 * Direction;
            DrawColorElem(elem, color, sleep);
        }

        // Слияние
        public void MergeRun(Elem[] A, Elem[] B, ref int rL, ref int rR, ref int wInd, int wD)
        {
            bool eorL = rL > rR;
            bool eorR = rL >= rR;

            A[rL].Color = colors[currentColor];
            A[rR].Color = colors[currentColor];

            while (!eorL && !eorR)
            {
                MoveOutAnimation(A[rL]);
                MoveOutAnimation(A[rR], 500);

                if (A[rL] <= A[rR])
                    eorL = MoveElem(B, A, ref rL, 1, rR, ref wInd, wD);
                else
                    eorR = MoveElem(B, A, ref rR, -1, rL, ref wInd, wD);
            }

            while (!eorL)
                eorL = MoveElem(B, A, ref rL, 1, rR, ref wInd, wD);

            while (!eorR)
                eorR = MoveElem(B, A, ref rR, -1, rL, ref wInd, wD);

        }

        // Распределение и слияние из A в B
        public int MergeMas(Elem[] A, Elem[] B)
        {

            Direction = -Direction;
            int wInd = A.Length - 1, rIndR = A.Length - 1;
            int wInd2 = 0, rIndL = 0;

            int wD = -1;
            int count = 0;

            do
            {
                Swap(ref wInd, ref wInd2);
                wD = -wD;
                MergeRun(A, B, ref rIndL, ref rIndR, ref wInd, wD);
                count++;
                currentColor = (currentColor + 1) % (colors.Length);
            } while (rIndL <= rIndR);

            SetColor(B, Color.White);
            DrawMas(B);

            return count;
        }

        // сортировка естественным слиянеим 
        public void NaturalMergeSort()
        {
            if (baseMas.Length == 1) return;

            int count;
            Direction = -1;

            do
            {
                count = MergeMas(baseMas, helpMas);
                if (count > 1)
                    count = MergeMas(helpMas, baseMas);
                else
                    CopyMas(helpMas, baseMas);
            } while (count > 1);

            graphics.Clear(Color.Black);
            Display();
        }

        // фабрика массива из элементов типа Elem
        public static Elem[] CreateElems(int n, int y)
        {
            Elem[] result = new Elem[n];
            for (int i = 0; i < n; ++i)
                result[i] = new Elem(0, i, y);
            return result;
        }

        // конструктор
        public NaturalMergeSortGUI(int n, Graphics _graphics)
        {
            graphics = _graphics;
            baseMas = CreateElems(n, 100);
            helpMas = CreateElems(n, 200);
        }

        // конструктор из строки
        public static NaturalMergeSortGUI StringToElemList(string str, Graphics _graphics)
        {
            string[] mas = str.Split(' ');
            if (mas == null)
                return null;
            NaturalMergeSortGUI res = new NaturalMergeSortGUI(mas.Length, _graphics);
            for (int i = 0; i < mas.Length; ++i)
            {
                if (int.TryParse(mas[i], out int buf))
                {
                    res[i] = buf;
                }
                else
                    return null;
            }
            return res;
        }

        // установка рандомных значений
        public void RandomSet()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < baseMas.Length; ++i)
            {
                baseMas[i].Key = random.Next(1, 99);
            }
            Display();
        }

        // установить цвет всем элементам массива
        public void SetColor(Elem[] mas, Color color)
        {
            for (int i = 0; i < mas.Length; ++i)
                mas[i].Color = color;
        }

        // отображение однгого элемента массива
        protected void DrawElem(Elem elem)
        {
            Pen pen = new Pen(elem.Color);
            pen.Color = elem.Color;
            graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(elem.Location, Elem.size));
            graphics.DrawRectangle(pen, new Rectangle(elem.Location, Elem.size));
            graphics.DrawString(elem.Key.ToString(), new Font("Courier New", 13.8f), new SolidBrush(elem.Color), elem.Location);

        }

        // отображение массива
        public void DrawMas(Elem[] mas)
        {
            for (int i = 0; i < mas.Length; ++i)
                DrawElem(mas[i]);
        }

        // устанавливает переданный цвет и отображает с задержой
        protected void DrawColorElem(Elem elem, Color color, int sleep = 500)
        {
            elem.Color = color;
            DrawElem(elem);
            Thread.Sleep(sleep / speed);
        }

        // отображение в исходном формате
        public void Display()
        {
            for (int i = 0; i < baseMas.Length; ++i)
            {
                helpMas[i].Color = Color.Black;
                baseMas[i].Color = Color.White;
            }
            DrawMas(baseMas);
            DrawMas(helpMas);
        }


        // возвращает элемент на исходную позицию
        protected void MoveElemBackAnimation(Elem elem)
        {
            DrawColorElem(elem, Color.Black, 0);
            elem.Y -= 20 * Direction;
            DrawColorElem(elem, colors[currentColor], 500);
        }

        // проверяет на своем ли месте находится элемент
        protected bool IsNeedMoveBackAnimation(Elem elem)
        {
            return elem.Y % 100 != 0;
        }

        // определить цвет следующего элемента
        protected void SetColorNextAnimation(Elem elem, bool eor)
        {
            if (eor)
                DrawColorElem(elem, colors[(currentColor + 1) % (colors.Length)], 500);
            else
                DrawColorElem(elem, colors[currentColor], 500);
        }

        // анимация перемещения элемента
        protected void TransportingAnimation(Elem elem, bool needMoveBack)
        {
            DrawColorElem(elem, Color.Black, 0);
            int pos = elem.Y;
            elem.Y = 140;
            DrawColorElem(elem, colors[currentColor], 500);
            DrawColorElem(elem, Color.Black, 0);
            if (needMoveBack) pos -= 20 * Direction;
            elem.Y = pos;
        }

        // перегрузка преобразования в строку
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < baseMas.Length; ++i)
            {
                res += baseMas[i].Key + " ";
            }
            return res.Trim();
        }


        public int this[int i] { get { return baseMas[i].Key; } set { baseMas[i].Key = value; } }
        // скорость анимации
        public int Speed { get { return speed; } set { if (value == 10) value *= 1000; speed = value; } }

    }

}
