using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _241_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        dbcontrol sql = new dbcontrol();

        private void button1_Click(object sender, EventArgs e)
        {
            mainForm mf = new mainForm();
            Hide();
            mf.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            registerForm register = new registerForm();
            register.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is Form1)
                {
                    frm.Show();
                }
            }
        }



        private void button1_login(object sender, EventArgs e)
        {
            if (Login()== true)
            {
                mainForm mf = new mainForm();
                Hide();
                mf.ShowDialog();
            }
        }
        bool Login()
        {
            sql.Param("@usr", textBox_userName.Text);
            sql.Param("@pwd", textBox_Password.Text);
            sql.query("select count(*) from tbluser where usr=@usr and pwd=@pwd");
            if ((int)sql.dt.Rows[0][0] == 1)
            {
                return true;
            }
            MessageBox.Show("Invalid !!");
            return false;
        }

        private void button_reg(object sender, EventArgs e)
        {
            registerForm reg = new registerForm();
            Hide();
            reg.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
