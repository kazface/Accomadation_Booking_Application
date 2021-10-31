using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using MySqlConnector;


namespace Projectforstudy
{
    public partial class WardenForm : MaterialForm
    {

        readonly MaterialSkin.MaterialSkinManager materialSkinManager;

        string userlogin;
        string userid;
        string username;
        string useremail;
        string usergender;
        string userpassword;

        warden Warden;


        public WardenForm(string _userlogin)

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


            Warden = new(int.Parse(userid), userlogin, userpassword, username, useremail, 1, usergender);

        }

        private void WardenForm_Load(object sender, EventArgs e)
        {
            textWelcomeWarden.Text = "Welcome " + Warden.Name;


            Update_Table();



        }
      
        //Additional feature (if you guys want can add):
        /// </summary>
/*
        private void Send_Mail() //add later
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("nilusilu3@gmail.com");
                msg.To.Add(Studentmail);
                msg.Subject = MessSubject;
                msg.Body = MessBody;

                SmtpClient smt = new SmtpClient();
                smt.Host = "smtp.gmail.com";
                System.Net.NetworkCredential ntcd = new NetworkCredential();
                ntcd.UserName = "nilusilu3@gmail.com";
                ntcd.Password = "";
                smt.Credentials = ntcd;
                smt.EnableSsl = true;
                smt.Port = 587;
                smt.Send(msg);

                MessageBox.Show("Your Mail is sended");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
*/

        private void Update_Table()
        {



            DataTable Details = Warden.GetNewBookingDetails();
            DataTable Details1 = Warden.GetChangeReqDetails();
            DataTable Details2 = Warden.GetTerminationReqs();
            DataTable Details3 = Warden.GetFeedbackReqs();
             

            //CLEAR TABLES

            listviewAssignRooms.Items.Clear();
            materialListViewRoomReqs.Items.Clear();
            lsitViewTerm.Items.Clear();
            listViewFeedbacks.Items.Clear();



            //INSERT DATA TO TABLES

            foreach (DataRow row in Details.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < Details.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }

                listviewAssignRooms.Items.Add(item);
            }



            foreach (DataRow row in Details1.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < Details1.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }

                materialListViewRoomReqs.Items.Add(item);
            }



            foreach (DataRow row in Details2.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < Details2.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }

                lsitViewTerm.Items.Add(item);
            }


            foreach (DataRow row in Details3.Rows)
            {
                ListViewItem item = new ListViewItem(row[0].ToString());
                for (int i = 1; i < Details3.Columns.Count; i++)
                {
                    item.SubItems.Add(row[i].ToString());
                }
                listViewFeedbacks.Items.Add(item);
            }


        }

        




        private void textWelcomeWarden_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel6_Click(object sender, EventArgs e)
        {

        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
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
        private bool _drawerShowIconsWhenHidden;
        private MaterialDrawer drawerControl = new MaterialDrawer();

        private void SwitchColorDrawer_CheckedChanged(object sender, EventArgs e)
        {
            DrawerUseColors = SwitchColorDrawer.Checked;
        }

        private void materialButton7_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void materialButton6_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginform loginform = new loginform();
            loginform.Show();
        }

        int Booking_ID;
        string Student_Name;
        string Booking_Block;
        string Booking_Room_Type;
        string Student_Phone;
        DateTime Check_In;
        DateTime Check_Out;

        private void listviewAssignRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listviewAssignRooms.SelectedItems.Count == 0)

                return;



            int Book_ID = Int32.Parse(this.listviewAssignRooms.SelectedItems[0].Text);

            Booking_ID = int.Parse(this.listviewAssignRooms.SelectedItems[0].SubItems[0].Text);
            Student_Name = this.listviewAssignRooms.SelectedItems[0].SubItems[1].Text;
            Booking_Block = this.listviewAssignRooms.SelectedItems[0].SubItems[2].Text;
            Booking_Room_Type = this.listviewAssignRooms.SelectedItems[0].SubItems[3].Text;
            Student_Phone = this.listviewAssignRooms.SelectedItems[0].SubItems[4].Text;

            Check_In = DateTime.Parse(this.listviewAssignRooms.SelectedItems[0].SubItems[5].Text);
            Check_Out = DateTime.Parse(this.listviewAssignRooms.SelectedItems[0].SubItems[6].Text);


            comboAssignFloor.Items.Clear();

            if (Booking_Block == "A")
            {
                comboAssignFloor.Items.Add("1");
                comboAssignFloor.Items.Add("2");
                comboAssignFloor.Items.Add("3");
                comboAssignFloor.Items.Add("4");
                comboAssignFloor.Items.Add("5");
            }
            else if (Booking_Block == "B")
            {
                comboAssignFloor.Items.Add("1");
                comboAssignFloor.Items.Add("2");
                comboAssignFloor.Items.Add("3");
                comboAssignFloor.Items.Add("4");
            }

            comboAssignFloor.SelectedValue = "1";
        }


        int Change_ID;
        string Change_Name;
        string Change_Block;
        string Change_Room_Type;
        string Change_Phone;


        DateTime Change_Check_In;
        DateTime Change_Check_Out;
        private void materialListViewRoomReqs_SelectedIndexChanged(object sender, EventArgs e)
        {

            materialComboBox1.Items.Clear();
            materialComboBox2.Items.Clear();
            Change_ID = int.Parse(this.materialListViewRoomReqs.SelectedItems[0].SubItems[0].Text);
            Change_Name = this.materialListViewRoomReqs.SelectedItems[0].SubItems[1].Text;
            Change_Block = this.materialListViewRoomReqs.SelectedItems[0].SubItems[2].Text;
            Change_Room_Type = this.materialListViewRoomReqs.SelectedItems[0].SubItems[3].Text;
            Change_Phone = this.materialListViewRoomReqs.SelectedItems[0].SubItems[4].Text;

            Change_Check_In = DateTime.Parse(this.materialListViewRoomReqs.SelectedItems[0].SubItems[5].Text);
            Change_Check_Out = DateTime.Parse(this.materialListViewRoomReqs.SelectedItems[0].SubItems[6].Text);


            comboAssignFloor.Items.Clear();

            if (Change_Block == "A")
            {
                materialComboBox2.Items.Add("1");
                materialComboBox2.Items.Add("2");
                materialComboBox2.Items.Add("3");
                materialComboBox2.Items.Add("4");
                materialComboBox2.Items.Add("5");
            }
            else if (Change_Block == "B")
            {
                materialComboBox2.Items.Add("1");
                materialComboBox2.Items.Add("2");
                materialComboBox2.Items.Add("3");
                materialComboBox2.Items.Add("4");
            }

            materialComboBox2.SelectedValue = "1";

            //
        }


        private void materialComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            materialComboBox1.Items.Clear();
            int Choosen_Floor;


            Choosen_Floor = int.Parse(this.materialComboBox1.GetItemText(this.materialComboBox2.SelectedItem));


            DataTable Available_Rooms = Warden.GetAvailableRooms(Change_Check_Out, Change_Check_Out, Change_Room_Type, Change_Block, Choosen_Floor);

            MaterialMessageBox.Show("Available rooms: " + Available_Rooms.Rows.Count.ToString());

            foreach (DataRow row in Available_Rooms.Rows)
            {
                materialComboBox1.Items.Add(row["Room_Name"].ToString());
            }
        }


        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (this.materialListViewRoomReqs.SelectedItems.Count == 0)
            {
                MaterialMessageBox.Show("Plese choose a request!");
                return;
            }
            if (materialComboBox2.Text == "")
            {
                MaterialMessageBox.Show("Plese choose a Floor!");
                return;
            }
            if (materialComboBox1.Text == "")
            {
                MaterialMessageBox.Show("Plese choose a Room!");
                return;
            }

            string Choosen_Room = materialComboBox1.Text;

            if (Warden.AssignChangedRoom(Change_ID, Choosen_Room)){
                if (Warden.ApproveChangedRoom(Change_ID) )
                    {
                    MaterialMessageBox.Show("Successful!");
                    
                }
                else
                {
                    MaterialMessageBox.Show("Error! Try again!");
                    return;
                }
            }
            else
            {
                MaterialMessageBox.Show("Error! Try again!");
                return;
            }
            Update_Table();
        }




        DateTime Ter_End_Date;
        int Ter_ID;

        private void lsitViewTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lsitViewTerm.SelectedItems.Count == 0)
                return;

            Ter_ID = Int32.Parse(this.lsitViewTerm.SelectedItems[0].Text);
            Ter_End_Date = DateTime.Parse(this.lsitViewTerm.SelectedItems[0].SubItems[5].Text);


            textBoxTermDiscr.Text = Warden.GetTerminationDescr(Ter_ID);

            //
        }
        int Feedback_ID;
        private void listViewFeedbacks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewFeedbacks.SelectedItems.Count == 0)
                return;

            Feedback_ID = Int32.Parse(this.listViewFeedbacks.SelectedItems[0].Text);

            textBoxFeedbackDescr.Text = Warden.GetFeedbackDescr(Feedback_ID);




        }

        private void btnAssignAssign_Click(object sender, EventArgs e)
        {
            if (this.listviewAssignRooms.SelectedItems.Count == 0)
            {
                MaterialMessageBox.Show("Plese choose a request!");
                return;
            }
            if (comboAssignFloor.Text == "")
            {
                MaterialMessageBox.Show("Plese choose a Floor!");
                return;
            }
            if (comboAssignRoom.Text == "")
            {
                MaterialMessageBox.Show("Plese choose a Room!");
                return;
            }

            string Choosen_Room = comboAssignRoom.Text;

            if (!Warden.IsStudentInRoom(Booking_ID, Choosen_Room))
            {
                if (!Warden.AssignRoom(Booking_ID, Choosen_Room))
                {
                    MaterialMessageBox.Show("Please try again later!");
                    return;
                }
            }

            if (Warden.ApproveChangeRequest(Booking_ID))
            {
                MaterialMessageBox.Show("Successful!");
            }
            else
            {
                MaterialMessageBox.Show("Please try again later!");
                return;
            }

                Update_Table();

            }

            


        private void comboAssignFloor_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboAssignRoom.Items.Clear();

            int Choosen_Floor;



            Choosen_Floor = int.Parse(this.comboAssignFloor.GetItemText(this.comboAssignFloor.SelectedItem));


            DataTable Available_Rooms = Warden.GetAvailableRooms(Check_In, Check_Out, Booking_Room_Type, Booking_Block, Choosen_Floor);

            MaterialMessageBox.Show("Available rooms: " + Available_Rooms.Rows.Count.ToString());

            foreach (DataRow row in Available_Rooms.Rows)
            {
                comboAssignRoom.Items.Add(row["Room_Name"].ToString());
            }
        }

        private void btnAssignReject_Click(object sender, EventArgs e)
        {
            if (this.listviewAssignRooms.SelectedItems.Count == 0)
            {
                MaterialMessageBox.Show("Plese choose a request!");
                return;
            }

            if (Warden.RejectRequest(Booking_ID))
            {
                MaterialMessageBox.Show("Successful!");
                return;
            }
            else
            {
                MaterialMessageBox.Show("Please try again!");
            }

            Update_Table();
        }

        private void materialButton5_Click(object sender, EventArgs e)
        {
            if (this.listViewFeedbacks.SelectedItems.Count == 0)
            {
                MaterialMessageBox.Show("Please choose a request!");
                return;
            }
            if (materialComboBox4.Text == "")
            {
                MaterialMessageBox.Show("Please choose status");
                return;
            }


            string Feedback_Status = materialComboBox4.Text;

            if (Warden.UpdateFeedbackStatus(Feedback_ID, Feedback_Status))
            {
                MaterialMessageBox.Show("Successful!");
                

            }
            else
            {
                MaterialMessageBox.Show("Error! Please try again!");
                return;
            }


            Update_Table();
        }

        private void materialButton4_Click(object sender, EventArgs e)
        {
            if (this.lsitViewTerm.SelectedItems.Count == 0)
                return;

            if (Warden.ApproveTermRequest(Ter_ID, Ter_End_Date))
            {
                MaterialMessageBox.Show("Successful!");
            }
            else
            {
                MaterialMessageBox.Show("Error! Please try again later");

            }
            Update_Table();
        }

        private void textWardenName_Click(object sender, EventArgs e)
        {

        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            Update_Table();
        }

        private void materialListView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
  
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            if (materialComboBox5.Text == "")
            {
                return;
                MaterialMessageBox.Show("Please choose a block!");
            }

            if (materialComboBox3.Text == "")
            {
                MaterialMessageBox.Show("Please choose a status!");
                return;
            }

            materialListView4.Items.Clear();

            string Selected_Block = materialComboBox5.Text;
            string Selected_Status = materialComboBox3.Text;
            

            DataTable Details4 = Warden.GetReport(Selected_Block);


            try {
                DataTable Details5 = Details4.AsEnumerable()
                    .Where(row => row.Field<String>("Status") == Selected_Status)
                    .CopyToDataTable();

                foreach (DataRow row in Details5.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    for (int i = 1; i < Details5.Columns.Count; i++)
                    {

                        item.SubItems.Add(row[i].ToString());
                    }
                    materialListView4.Items.Add(item);
                }
            }
            catch
            {
                Details4.Rows.Clear();
                foreach (DataRow row in Details4.Rows)
                {
                    ListViewItem item = new ListViewItem(row[0].ToString());
                    for (int i = 1; i < Details4.Columns.Count; i++)
                    {

                        item.SubItems.Add(row[i].ToString());
                    }
                    materialListView4.Items.Add(item);
                }
            }



            
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (this.materialListViewRoomReqs.SelectedItems.Count == 0)
            {
                MaterialMessageBox.Show("Plese choose a request!");
                return;
            }


            if (Warden.RejectChangedRoom(Change_ID))
            {

                MaterialMessageBox.Show("Successful!");
            }

            else
            {
                MaterialMessageBox.Show("Error! Try again!");
                return;
            }

            Update_Table();


        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            if (this.lsitViewTerm.SelectedItems.Count == 0)
                return;

            if (Warden.RejectTermRequest(Ter_ID))
            {
                MaterialMessageBox.Show("Successful!");
            }
            else
            {
                MaterialMessageBox.Show("Error! Please try again later");

            }
            Update_Table();
        }

        private void pageHome_Click(object sender, EventArgs e)
        {
            
        }

        private void pageAssign_Click(object sender, EventArgs e)
        {

        }
    }
 } 


