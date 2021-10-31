using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projectforstudy
{
    public partial class registerform : Form
    {
        public registerform()
        {
            InitializeComponent();
        }

        private void registerform_Load(object sender, EventArgs e)
        {

        }
        Point lastPoint;
        private void registerform_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;

            }
        }

        private void registerform_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
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

        private void registerbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginform loginform = new loginform();
            loginform.Show();
        }

        private void passshowcheck_CheckedChanged(object sender, EventArgs e)
        {
            passwordbox.PasswordChar = passshowcheck.Checked ? '\0' : '●';
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            if (loginbox.Text == "")
            {
                MessageBox.Show("Enter a login");
                return;
            }
            if (passwordbox.Text == "")
            {
                MessageBox.Show("Enter a password");
                return;
            }

            if (passwordbox.Text.Length < 5)
            {
                MessageBox.Show("Password is very short!\nMinimum length is 5");
                return;
            }
            if (!passwordbox.Text.Any(char.IsUpper) || !passwordbox.Text.Any(char.IsLower) || !passwordbox.Text.Any(char.IsDigit))
            {

                MessageBox.Show("Password is very sick!\nPassword must contain a digit, uppercase and lovercase symbol");
                return;

            }
            else
            {
                //MessageBox.Show("Password is very sick!\nPassword must contain a digit, uppercase and lovercase symbol");
                //return;
            }

            if (!emailbox.Text.Contains("@"))
            {
                MessageBox.Show("Enter correct email adress");
                return;
            }


            if (namebox.Text == "")
            {
                MessageBox.Show("Enter a name");
                return;
            }
            if (emailbox.Text == "")
            {
                MessageBox.Show("Enter a email");
                return;
            }
            student Newstudent = new student(0, loginbox.Text, passwordbox.Text, namebox.Text, emailbox.Text, 0, ComboGender.Text);
            if (Newstudent.IsUserExist())
            {
                MessageBox.Show("User exist! Please enter different login");
                return;
            }
            if (Newstudent.IsEmailExist())
            {
                MessageBox.Show("Email exit! Please enter different email");
                return;
            }
            if (ComboGender.Text == "")
            {
                MessageBox.Show("Select a gender");
                return;
            }



            if (Newstudent.Register()) {
                MessageBox.Show("Account is created!");
            }
            else
            {
                MessageBox.Show("Account is NOT created! Please try again!");
            }
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*
                    String userlogin = loginbox.Text;
                    String userpassword = passwordbox.Text;
                    String username = namebox.Text;
                    String useremailbox = emailbox.Text;

                    DB db = new DB();
                    MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`id`, `login`, `password`, `name`, `email`, `warden`, `gender`) VALUES (NULL, @uL, @uP, @uN, @uE, 0, @uG);", db.getConnection());

                    command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = userlogin;
                    command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = userpassword;
                    command.Parameters.Add("@uN", MySqlDbType.VarChar).Value = username;
                    command.Parameters.Add("@uE", MySqlDbType.VarChar).Value = useremailbox;
                    command.Parameters.Add("@uG", MySqlDbType.VarChar).Value = ComboGender.Text;



                    db.openConnection();

                    if(command.ExecuteNonQuery() == 1){
                        MessageBox.Show("Account is created");

                    }
                    else
                    {
                        MessageBox.Show("Account is not created");
                    }

                    db.closeConnection();
        */
    }
    /*
    public Boolean IsUserExist()
    {
        DB db = new DB();

        DataTable table = new DataTable();

        MySqlDataAdapter adapter = new MySqlDataAdapter();

        MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.getConnection());

        command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginbox.Text;

        adapter.SelectCommand = command;
        adapter.Fill(table);


        if (table.Rows.Count > 0)
        {
            MessageBox.Show("The username exist");
            return true;
        }

        else
            return false;
    }

    public Boolean IsEmailExist()
    {
        DB db = new DB();

        DataTable table1 = new DataTable();

        MySqlDataAdapter adapter = new MySqlDataAdapter();

        MySqlCommand command1 = new MySqlCommand("SELECT * FROM `users` WHERE `email` = @uE", db.getConnection());

        command1.Parameters.Add("@uE", MySqlDbType.VarChar).Value = emailbox.Text;

        adapter.SelectCommand = command1;
        adapter.Fill(table1);


        if (table1.Rows.Count > 0)
        {
            MessageBox.Show("The email exist!");
            return true;
        }

        else
            return false;
    }
    */



    
}
