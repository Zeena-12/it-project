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
    public partial class registerForm : Form
    {
        public registerForm()
        {
            InitializeComponent();
        }
        dbcontrol sql = new dbcontrol();
        void register()
        {
            sql.Param("@usr", textBox_username.Text);
            sql.Param("@pwd", textBox_password.Text);
            sql.Param("@fname", textBox_firstname.Text);
            sql.Param("@mn", textBox_middlename.Text);
            sql.Param("@lname", textBox_middlename.Text);

            sql.query("insert into tbluser (usr,pwd,fname,mn,lname) values(@usr,@pwd,@fname,@mn,@lname)");
            if(sql.Check4error(true))
            {
                return;
            }
            MessageBox.Show("Registered", "Succes");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_register_Click(object sender, EventArgs e)
        {
            register();
        }

        private void registerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach( Form frm in Application.OpenForms)
            {
                if(frm is Form1)
                {
                    frm.Show();
                }
            }
        }

        private void registerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
