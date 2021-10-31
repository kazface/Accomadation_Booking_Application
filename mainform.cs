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
using MaterialSkin;
using MaterialSkin.Controls;
using MySqlConnector;

namespace Projectforstudy
{
    public partial class mainform : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        string userlogin;
        string userid;
        string username;
        string useremail;
        string usergender;
        string userpassword;
        string userphone;
        student Student;

        public mainform(string _userlogin)
        {
            userlogin = _userlogin;
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Indigo500, MaterialSkin.Primary.Indigo700, MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.Blue200, MaterialSkin.TextShade.WHITE);
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.getConnection());

            command1.Parameters.Add("@uL", MySqlDbType.VarChar).Value = userlogin;

            adapter.SelectCommand = command1;
            adapter.Fill(table);

            userid = table.Rows[0]["id"].ToString();
            username = table.Rows[0]["name"].ToString();
            useremail = table.Rows[0]["email"].ToString();
            usergender = table.Rows[0]["gender"].ToString();
            userpassword = table.Rows[0]["password"].ToString();
            userphone = table.Rows[0]["Phone"].ToString();

            Student = new(int.Parse(userid), userlogin, userpassword, username, useremail, 0, usergender, userphone);


        }

        private void materialButton1_Click(object sender, EventArgs e)
        {

        }




        private void mainform_Load(object sender, EventArgs e)
        {


            //TextBoxes loading

            TextBoxGender.Text = Student.Gender;
            TextBoxStudenName.Text = Student.Name;
            TextBoxIdNum.Text = Student.ID.ToString();
            TextBoxPhoneNum.Text = Student.Phone;

            if (usergender == "Male")
            {
                ComboBlock.Items.Add("Block A");
                ComboBlockChange.Items.Add("Block A");
            }
            else
            {
                ComboBlock.Items.Add("Block B");
                ComboBlockChange.Items.Add("Block B");
            }

            TextWelcomeStudent.Text = "Welcome " + Student.Name + "!";
            textStudentName.Text = Student.Name;
            TextStudentID.Text = "TP" + Student.ID.ToString();

            textStudentName.BackColor = Color.FromArgb(117, 37, 252);
            TextStudentID.BackColor = Color.FromArgb(117, 37, 252);

            textStudentName.ForeColor = Color.White;
            TextStudentID.ForeColor = Color.White;

            textStudentName.Font = new Font("Roboto", 16, FontStyle.Regular);
            TextStudentID.Font = new Font("Roboto", 8, FontStyle.Regular);


            Update_Table();


        }


        private void Update_Table()
        {

            materialListViewDetails.Items.Clear();
            materialListViewDetails1.Items.Clear();

            DataTable AccAprDetails = Student.GetApprovedAccomadationDetails();

            foreach (DataRow row in AccAprDetails.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < AccAprDetails.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }

                materialListViewDetails.Items.Add(item);
            }

            DataTable AccNewDetails = Student.GetApprovedAccomadationDetails();
            foreach (DataRow row in AccNewDetails.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < AccNewDetails.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }

                materialListViewDetails1.Items.Add(item);
            }
        }


            private void textBoxContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }

        private void pageBook_Click(object sender, EventArgs e)
        {

        }
        private int colorSchemeIndex;
        private void btnSettingsColor_Click(object sender, EventArgs e)
        {
            colorSchemeIndex++;
            if (colorSchemeIndex > 2)
                colorSchemeIndex = 0;
            updateColor();
        }
        private void updateColor()
        {
            //These are color schemes
            switch (colorSchemeIndex)
            {
                case 0:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal500 : Primary.Indigo500,
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal700 : Primary.Indigo700,
                        materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? Primary.Teal200 : Primary.Indigo100,
                        Accent.Pink200,
                        TextShade.WHITE);
                    break;

                case 1:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.Green600,
                        Primary.Green700,
                        Primary.Green200,
                        Accent.Red100,
                        TextShade.WHITE);
                    break;

                case 2:
                    materialSkinManager.ColorScheme = new ColorScheme(
                        Primary.BlueGrey800,
                        Primary.BlueGrey900,
                        Primary.BlueGrey500,
                        Accent.LightBlue200,
                        TextShade.WHITE);
                    break;
            }
            Invalidate();
        }

        private void btnSettingsTheme_Click(object sender, EventArgs e)
        {
            if (materialSkinManager.Theme == MaterialSkinManager.Themes.DARK)
            {
                btnSettingsTheme.Text = "Dark scheme";
            }
            else
                btnSettingsTheme.Text = "Light theme";


            materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
            updateColor();

        }


        private void switchHideDrawer_CheckedChanged(object sender, EventArgs e)
        {
            DrawerShowIconsWhenHidden = switchHideDrawer.Checked;
        }

        // Drawer overlay and speed improvements
        private bool _drawerShowIconsWhenHidden;



        private MaterialDrawer drawerControl = new MaterialDrawer();

        private void SwitchColorDrawer_CheckedChanged(object sender, EventArgs e)
        {
            DrawerUseColors = SwitchColorDrawer.Checked;
        }

        private void materialButton1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginform loginform = new loginform();
            loginform.Show();
        }


        private void pageSettings_Click(object sender, EventArgs e)
        {

        }

        private void checkShowPassword_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxCurrentPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialButton3_Click(object sender, EventArgs e)
        {

            if (Student.IsPasswordIsNotRight())
            {
                MaterialMessageBox.Show("You have entered incorrect current password", "Error", false);
                return;
            }

            string newuserpassword = TextBoxNewPassword.Text;

            if (newuserpassword.Length < 5)
            {
                MaterialMessageBox.Show("Password is very short!\nMinimum length is 5", "Error", false);
                return;
            }
            if (!newuserpassword.Any(char.IsUpper) || !newuserpassword.Any(char.IsLower) || !newuserpassword.Any(char.IsDigit))
            {

                MaterialMessageBox.Show("Password is very sick!\nPassword must contain a digit, uppercase and lovercase symbol", "Error", false);
                return;

            }


            DB db = new DB();
            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `password` = @uP WHERE `login` = @uL;", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = userlogin;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = newuserpassword;


            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MaterialMessageBox.Show("Password is changed", "Error", false);
            }
            else
            {
                MaterialMessageBox.Show("Password is not changed\nPlease try again", "Error", false);
            }

            db.closeConnection();

        }
         
        private void materialLabel11_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel13_Click(object sender, EventArgs e)
        {

        }

        private void TextBoxStudenName_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel9_Click(object sender, EventArgs e)
        {

        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            RoomTypes RoomTypes = new RoomTypes();
            RoomTypes.ShowDialog();
        }

        private void TextWelcomeStudent_Click(object sender, EventArgs e)
        {

        }

        private void materialCard15_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ButtonFeedBackHistory_Click(object sender, EventArgs e)
        {

            FeedBackHistory feedBackHistory = new FeedBackHistory();
            feedBackHistory.Student = Student;
            feedBackHistory.ShowDialog();

        }

        private void materialListViewDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxPhoneNum_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnPrice_Click(object sender, EventArgs e)
        {

            int dur;
            if (ComboCheckOut.Text == "3 months")
            {
                dur = 3;
            }
            else if (ComboCheckOut.Text == "6 months")
            {
                dur = 6;
            }
            else if (ComboCheckOut.Text == "9 months")
            {
                dur = 9;
            }
            else
            {
                MaterialMessageBox.Show("Choose check-out!");
                return;
            }

            int amount;
            if (ComboRoomType.Text == "Standart")
            {
                amount = 600;
            }

            else if (ComboRoomType.Text == "Premium")
            {
                amount = 850;
            }
            else if (ComboRoomType.Text == "Suite")
            {
                amount = 1100;
            }
            else
            {
                MaterialMessageBox.Show("Choose a room type!");
                return;
            }

            int Price = dur * amount;
            btnPrice.Text = Price.ToString();


        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
    
            DateTime Start_Date;
            DateTime End_Date;

            string ChoosenBlock = ComboBlock.Text;
            int dur;
            if (ComboCheckOut.Text == "3 months")
            {
                dur = 3;
            }
            else if (ComboCheckOut.Text == "6 months")
            {
                dur = 6;
            }
            else if (ComboCheckOut.Text == "9 months")
            {
                dur = 9;
            }
            else
            {
                MaterialMessageBox.Show("Choose check-out!");
                return;
            }

            if (TextBoxPhoneNum.Text.Length < 5)
            {
                MaterialMessageBox.Show("Write your correct phone number!");
                return;
            }

            if (ChoosenBlock == "Block A")
            {
                ChoosenBlock = "A";
            }
            else if (ChoosenBlock == "Block B")
            {
                ChoosenBlock = "B";
            }
            else
            {
                MaterialMessageBox.Show("Choose Block!");
                return;
            }

            if (Student.IsReqExist())
            {
                MaterialMessageBox.Show("You allready have approved request!");
                return;
            }

            if (dateTimeCheckIn.Value < DateTime.Today)
            {
                MaterialMessageBox.Show("Please choose correct day! You cannot choose past days!");

                return;
            }

            Start_Date = dateTimeCheckIn.Value;
            End_Date = dateTimeCheckIn.Value.AddMonths(dur);
            string Room_Type = ComboRoomType.Text;
            string NewPhone = TextBoxPhoneNum.Text;


            //Update DB
            if (Student.SendRoomReq(Start_Date, End_Date, Room_Type, ChoosenBlock) & Student.UpdatePhoneNum(NewPhone))
            {
                MessageBox.Show("Successful!");
            }
            else
            {
                MessageBox.Show("Error! Please check details that you provided! Please contact with help center!");
            }
 


        }

        private void materialButton3_Click_1(object sender, EventArgs e)
        {
            string Block_Changed = ComboBlockChange.Text;
            string RoomType_Changed = ComboChangeRoom.Text;

            if (Block_Changed == "" | RoomType_Changed == "")
            {
                MaterialMessageBox.Show("Please enter details!");
            }

            if (Block_Changed == "Block A")
            {
                Block_Changed = "A";
            }
            else
            {
                Block_Changed = "B";
            }


            if (Student.SendChangeReq(Block_Changed, RoomType_Changed)){
                MaterialMessageBox.Show("Successful!");
            }
            else
            {
                MaterialMessageBox.Show("Error!\nYou dont have any approved room requests");
            }

            Update_Table();
        }

        private void ButtonFeedBackSubmit_Click(object sender, EventArgs e)
        {
            string Problem_Type;

            if (RadioButtonProblem1.Checked)
            {
                Problem_Type = "Cleaning";
            }
            else if (RadioButtonProblem2.Checked)
            {
                Problem_Type = "Facilities";
            }
            else if (RadioButtonProblem3.Checked)
            {
                Problem_Type = "Breaking";
            }
            else if (RadioButtonProblem4.Checked)
            {
                Problem_Type = "Another";
            }
            else
            {
                MaterialMessageBox.Show("Choose type of problem!");
                return;
            }

            if (TextBoxFeedBackSubmit.Text.Length < 50 | TextBoxFeedBackSubmit.Text.Length > 200)
            {
                MaterialMessageBox.Show("Problem description must be greater than 50 and less than 200 words");
                return;
            }

            string Problem_Decr = TextBoxFeedBackSubmit.Text;

            if (Student.SendFeedback(Problem_Type, Problem_Decr))
            {
                MaterialMessageBox.Show("Successful!");
            }
            else
            {
                MaterialMessageBox.Show("Error!\nPlease try again later or check details that you have entered!");
            }

        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            if (textBoxTermDescr.Text.Length < 50 | textBoxTermDescr.Text.Length > 250)
            {
                MaterialMessageBox.Show("Description must be greater than 50 and less than 250 words");
                return;
            }


            if (dateTimePickerTerm.Value < DateTime.Today)
            {
                MaterialMessageBox.Show("Choose correct date! You cannot choose the past days!");
                return;
            }

            string TermDescr = textBoxTermDescr.Text;
            DateTime TermCheckout = dateTimePickerTerm.Value;

            if (Student.SendTerminationReq(TermDescr, TermCheckout))
            {
                MaterialMessageBox.Show("Successful!");
            }
            else
            {
                MaterialMessageBox.Show("Error!\nYou dont have any approved room requests");
            }

            Update_Table();

        }

        private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdateTable_Click(object sender, EventArgs e)
        {
            Update_Table();
        }
    }
}
