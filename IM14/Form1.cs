using System;
using System.Windows.Forms;

namespace IM.IM14
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rnd = new Random();
        }
        Flow f;
        Operators opers;
        double T=0;
        Random rnd;
        private void button1_Click(object sender, EventArgs e)
        {
            double l1 = (double)numericUpDown3.Value;
            double l2 = (double)numericUpDown2.Value;
            int num = (int) numericUpDown1.Value;
            f = new Flow(l1);
            opers = new Operators(num, l2);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            T +=opers.GetTime(f.GetTime(), rnd);
            label1.Text = "Number of Clients: " + opers.InfC();
            Queue q = opers.InfQ();
            foreach (Client c in q.qu)
            {
                dataGridView2.Rows.Add("Client " + Convert.ToString(c.number));
            }
                foreach (Operator op in opers.InfB())
            {
                string str;
                if (op.cust != null) str  = "Client " + Convert.ToString(op.cust.number); else str = "free";

                dataGridView1.Rows.Add((op.number+1),str);
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            T = 0;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}