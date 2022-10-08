using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormDataPass
{
    public partial class Form1 : Form
    {
        static List<string> names = new List<string>();
        BindingSource bs = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        internal void receiveData(string text)
        {
            names.Add(text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Here we are going to add some value so that we are seeing what we are working with.  
            names.Add("Adam");
            names.Add("Ken");
            names.Add("Alika");
            names.Add("Sakura");
            names.Add("Anna");
            names.Add("Anna");
            names.Add("Alex");
            bs.DataSource = names;
            listBox1.DataSource = bs;
        }

        // When switching form FORM 2 to one.  We are going to reset BINDING so that we can show the result on the form. 
        private void Form1_Activated(object sender, EventArgs e)
        {
            bs.ResetBindings(false);
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            if(i >= 0)
            {
                names.RemoveAt(i);
                bs.ResetBindings(false);
            }
        }

        // Sorting
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int comboBoxIndex = comboBox1.SelectedIndex;
            Console.WriteLine(comboBoxIndex);
            if(comboBoxIndex == 0)
            {
                names.Sort();
                bs.ResetBindings(false);
            }else if( comboBoxIndex == 1)
            {
                names.Reverse();
                bs.ResetBindings(false);
            }
        }
    }
}
