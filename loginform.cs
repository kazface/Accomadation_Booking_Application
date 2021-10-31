using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projectforstudy
{
    public partial class loginform : Form
    {
        public loginform()
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }

        private void loginform_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Point lastPoint;
        private void loginform_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;

            }
        }

        private void loginform_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toploginpanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void toploginpanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void loginbox_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void passwordbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void passwordbox_Click(object sender, EventArgs e)
        {
            
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            String userlogin = textInfo.ToTitleCase(loginbox.Text);
            String userpassword = passwordbox.Text;
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter(); 

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL AND `password` = @uP", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = userlogin;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = userpassword;

            adapter.SelectCommand = command;
            try
            {
                adapter.Fill(table);
            }
            catch
            {
                MessageBox.Show("The DataBase system currently is not available\nReturn later!", "Error");
                return;
            }



            if (table.Rows.Count > 0)
            {
                int id = (from DataRow dr in table.Rows
                          where (string)dr["login"] == userlogin
                          select (int)dr["warden"]).FirstOrDefault();
                

                if (id == 1)
                {
                    //ADD WARDEN FORM
                    this.Hide();
                    WardenForm WardenForm = new WardenForm(userlogin);
                    WardenForm.Show();
                }
                else if (id == 0) {
                    this.Hide();
                    mainform mainform = new mainform(userlogin);
                    mainform.Show();
                    
                    }
                
                
            }
            else
                MessageBox.Show("authorized unsuccessfully", "Error");
                return;

        }

        

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void loginbox_TextChanged(object sender, EventArgs e)
        {

        }



        private void passshowcheck_CheckedChanged(object sender, EventArgs e)
        {
            passwordbox.PasswordChar = passshowcheck.Checked ? '\0' : '●';
        }



        private void registerbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            registerform registerform = new registerform();
            registerform.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
