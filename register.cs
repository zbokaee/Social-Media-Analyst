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
    public partial class regfrm : Form
    {
        string[][] majors = BAL.getMajors();
       
        public regfrm()
        {
            InitializeComponent();
        }


        private void registerbtn_Click(object sender, EventArgs e)
        {
            BAL b = new BAL();
            b.name = nametxt.Text;
            b.family = familytxt.Text;
            b.stdno = stdtxt.Text;
            b.address = addresstxt.Text;
            b.telephone = telephonetxt.Text;
            b.majorid = majors[majorcombo.SelectedIndex][0];;

            if (femalerbtn.Checked)
                b.sex = femalerbtn.Text;
            else
                b.sex = malerbtn.Text;
            

            if (b.name.Length == 0 || b.family.Length == 0 || b.family.Length == 0 || b.address.Length==0 || b.telephone.Length==0 || b.sex.Length==0)
            {
                MessageBox.Show("اطلاعات را کامل وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                b.insert();
                MessageBox.Show("ثبت نام شما با موفقیت انجام شد");
                this.Close();
            }
        }

            

        private void regfrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmmain c = new frmmain();
            c.Show();
        }

        private void regfrm_Load(object sender, EventArgs e)
        {
            if (majors.Length == 0) return;
            for (int i = 0; i < majors.Length; i++)
            {
                majorcombo.Items.Add(majors[i][1]);
            }
            majorcombo.SelectedIndex = 0;
        }

        private void majorcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
