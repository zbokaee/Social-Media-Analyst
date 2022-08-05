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
    public partial class frmmain : Form
    {
        String[][] majors = BAL.getMajors();
        public frmmain()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            regfrm r = new regfrm();
            r.Show();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("لطفا ابتدا یک رشته را انتخاب نید");
                return;
            }
            BAL b = new BAL();
            getcoursefrm g=new getcoursefrm();
            b.majorid = majors[comboBox1.SelectedIndex][0];//0 = id ; 1 = name
            b.stdno = stdtxt.Text;

            if (b.stdno.Length != 0 && b.majorid.Length != 0 && b.check_login(b.stdno, b.majorid))
            {
                MessageBox.Show("به سامانه خوش آمدید");
                this.Hide();
                g.majorID = majors[comboBox1.SelectedIndex][0];
                g.Show();
            }
            else
                  MessageBox.Show("اطلاعات وارد شده اشتباه می باشد");
        }

        private void frmmain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmmain_Load(object sender, EventArgs e)
        {
            if (majors.Length == 0) return;
            for (int i = 0; i < majors.Length ; i++)
            {
                comboBox1.Items.Add(majors[i][1]);
            }
            comboBox1.SelectedIndex = 0;
        }
    }
}
