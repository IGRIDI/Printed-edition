using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lr3
{
     public partial class Form2 : Form
    {
        private bool IsEdit = false;
        private int ElementID = 0;
        private Publication CurPub = null;
        private Form1 Parent = null;

        public Form2(Form1 parent, int elID, Publication m)
        {
            InitializeComponent();
            Parent = parent;
            IsEdit = elID >= 0 && m != null;
            ElementID = elID;
            CurPub = m;

            if (IsEdit)
            {
                button1.Text = "Save";
                textBox1.Text = m.Name;
                textBox2.Text = Convert.ToString(m.Cost);
                textBox3.Text = m.Author;
                textBox4.Text = Convert.ToString(m.Purchases);
            }
            else
            {
                button1.Text = "Add";
            }
        }

       private void button1_Click(object sender, EventArgs e)
        {
            Parent.addOrEdit(ElementID, new Publication(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text));
            Close();
        }
    }
}
