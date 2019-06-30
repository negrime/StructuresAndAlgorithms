using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Form1 : Form
    {
        Graphics g;
        NaturalMergeSortGUI elemList;
        Thread thread;
        Pen myPen = new Pen(Color.White);
        public Form1()
        {
            InitializeComponent();
            Application.Idle += OnIdle;

            // привязка холста и задание размеров
            g = this.CreateGraphics();
            g.Clip = new Region(new Rectangle(new Point(0, 0), new Size(this.Width, this.Height)));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Black);
            Random rand = new Random();
                elemList = new NaturalMergeSortGUI(14, g);
                elemList.RandomSet();                                
                elemList.Display();
            InputTextBox.Text = elemList.ToString();
        }

        private void Sort_Click(object sender, EventArgs e)
        {
            if (elemList != null)
            {
                elemList.Speed = trackBar.Value;
                thread = new Thread(elemList.NaturalMergeSort);
                thread.Start();
            }
            else
                MessageBox.Show("Попытка отсортировать не созданную последовательность", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            if (elemList != null)
            {
                if (thread != null && thread.IsAlive)

                    if (trackBar.Value == trackBar.Minimum)
                        thread.Suspend();
                    else
                    {
                        if (thread.ThreadState == ThreadState.Suspended) thread.Resume();
                    }

                elemList.Speed = trackBar.Value;

            }
        }
        private void OnIdle(object sender, EventArgs e)
        {
            Sort.Enabled = CreateButton.Enabled = !(InputTextBox.ReadOnly = thread != null && thread.IsAlive);
        }
    }
}
