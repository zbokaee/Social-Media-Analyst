using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace register
{
    public partial class getcoursefrm : Form
    {
        List<int> gottenCourses;
        public string majorID ;
        public getcoursefrm()
        {
            InitializeComponent();
            gottenCourses = new List<int>();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           


            BAL b = new BAL();

            DataTable dt = b.showdata(majorID);
            dataGridView1.DataSource = dt;
        }
        private void addbtn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                String s = "";
                Boolean canadd = true;
                for (int i = 0 ; ((i < gottenCourses.Count) && (canadd == true)) ; i++) {
                    if (gottenCourses[i] == Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString())) canadd = false;
                }
                if (canadd) {
                    s = "coursname :" + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    s += " | Teachers name : " + dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                    s += " | course time : " + dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                    listBox1.Items.Add(s);
                    gottenCourses.Add(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
                } else {
                    MessageBox.Show("خطا ! این درس قبلا توسط شما اخذ شده است");
                }

            }
            else
            {

                MessageBox.Show("لطفا ابتدا یک درس را انتخاب کنید");
            }

        }
        
        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.coursetblTableAdapter.FillBy(this.assignment3DataSet.coursetbl);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void getcoursefrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmmain c = new frmmain();
            c.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.coursetblTableAdapter.FillBy1(this.assignment3DataSet.coursetbl);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.coursetblTableAdapter.FillBy1(this.assignment3DataSet.coursetbl);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
            //dataGridView1.Rows[
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                if (MessageBox.Show("آیا عملیات حذف درس مورد تایید شما می باشد ؟ ", "تایید عملیات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return ;

                gottenCourses.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {

                MessageBox.Show("لطفا ابتدا یک درس را انتخاب کنید");
            }

        }



    }
}
