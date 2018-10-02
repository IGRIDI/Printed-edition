using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace lr3
{
    public partial class Form1 : Form
    {
        private BindingList<Publication> list;
        public Form1()
        {

            InitializeComponent();
            list = new BindingList<Publication>();

            dataGridView1.DataSource = list;
            dataGridView1.Columns["Name"].DisplayIndex = 0;
            dataGridView1.Columns["Cost"].DisplayIndex = 1;
            dataGridView1.Columns["Author"].DisplayIndex = 2;
            dataGridView1.Columns["Purchases"].DisplayIndex = 3;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
       

        private void readFromFile(string filename)
        {
            list.Clear();
            Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            Console.WriteLine(stream.Length);
            while (stream.Position != stream.Length)
            {
                Publication m = (Publication)formatter.Deserialize(stream);
                list.Add(m);
            }
            stream.Close();
        }
               
        private void saveToFile(string filename)
        {
            Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);
            IFormatter formatter = new BinaryFormatter();
            foreach (Publication m in list)
            {
                formatter.Serialize(stream, m);
            }
            stream.Close();
        }
        
        public void addOrEdit(int id, Publication m)
        {
            if (id >= 0)
            {
                list[id] = m;
            }
            else
            {
                list.Add(m);
            }
        }

        private void открытьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void добавитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form2 df = new Form2(this, -1, null);
            df.ShowDialog();
        }

        private void изменитьToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                Form2 df = new Form2(this, dataGridView1.CurrentRow.Index, list[dataGridView1.CurrentRow.Index]);
                df.ShowDialog();
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Удалить выбранное печатное издание?", "Удаление", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                int index = dataGridView1.CurrentRow.Index;
                list.RemoveAt(index);
                dataGridView1.Refresh();
            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            pictureBox1.Visible = false;
            richTextBox1.Visible = true;
            groupBox1.Visible = false;
            button1.Visible = true;

        }

       private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr;
            if (list.Count > 0)
            {
                dr = MessageBox.Show("Сохранить данные в файл перед закрытием?", "Закрытие", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    saveFileDialog1.ShowDialog();

                    e.Cancel = false;
                }
                else if (dr == DialogResult.No)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                dr = MessageBox.Show("Закрыть программу?", "Закрытие", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            pictureBox1.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            dataGridView1.Visible = true;

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Загрузить данные из файла?", "Загрузка", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                openFileDialog1.ShowDialog();
            }

            radioButton1.Checked = true;
            richTextBox1.Visible = false;
            button1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Visible = false;
            groupBox1.Visible = true;
            button1.Visible = false;
            pictureBox1.Visible = true;
         
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           readFromFile(openFileDialog1.FileName);
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            saveToFile(saveFileDialog1.FileName);
        }
    }
}
