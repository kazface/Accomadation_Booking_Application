using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectforstudy
{
    public class student
    {
        //id`, `login`, `password`, `name`, `email`, `warden`, `gender`
        public  int ID { get; set; }
        public  string Login { get; set; }
        public  string Password { get; set; }
        public  string Name { get; set; }
        public  string Email { get; set; }
        public  int Warden { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        //Student data
        public student(int ID, string Login, string Password, string Name, string Email, int Warden, string Gender, string Phone = "")
        {
            this.ID = ID;
            this.Login = Login;
            this.Password = Password;
            this.Name = Name;
            this.Email = Email;
            this.Warden = Warden;
            this.Gender = Gender;
            this.Phone = Phone;
    }



        //Methods


        public Boolean IsEmailExist()
        {
            DB db = new DB();

            DataTable table1 = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `users` WHERE `email` = @uE", db.getConnection());

            command1.Parameters.Add("@uE", MySqlDbType.VarChar).Value = Email;

            adapter.SelectCommand = command1;
            adapter.Fill(table1);


            if (table1.Rows.Count > 0)
            {
                return true;
            }

            else
                return false;
        }

        public Boolean IsUserExist()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = Login;

            adapter.SelectCommand = command;
            adapter.Fill(table);


            if (table.Rows.Count > 0)
            { 
                return true;
            }

            else
                return false;
        }
        public Boolean Register()
        {
            DB db = new DB();

            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`id`, `login`, `password`, `name`, `email`, `warden`, `gender`) VALUES (NULL, @uL, @uP, @uN, @uE, 0, @uG);", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = Login;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = Password;
            command.Parameters.Add("@uN", MySqlDbType.VarChar).Value = Name;
            command.Parameters.Add("@uE", MySqlDbType.VarChar).Value = Email;
            command.Parameters.Add("@uG", MySqlDbType.VarChar).Value = Gender;
       
            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                return true;

            }
            else
            {
                return false;
            }

            db.closeConnection();

        }


        public Boolean IsPasswordIsNotRight()
        {

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL and `password`=@uP", db.getConnection());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = Login;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = Password;

            adapter.SelectCommand = command;
            adapter.Fill(table);


            if (table.Rows.Count > 0)
            {
                return false;
            }

            else
            {
                //Password incorrect
                return true;
            }
        }


        public DataTable GetApprovedAccomadationDetails()
        {

            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT u.name, bl.Block_Name, r.Room_Type, r.Room_Name FROM bookings b LEFT JOIN users u ON u.id=b.User_ID LEFT JOIN `room_id-user_id` ru ON ru.User_ID=b.User_ID LEFT JOIN rooms r ON r.Room_ID=ru.Room_ID LEFT JOIN block bl ON bl.Block_ID=r.Block_ID WHERE u.name = @uN AND b.Booking_Status = 'Approved'", db.getConnection());

            command.Parameters.Add("@uN", MySqlDbType.VarChar).Value = Name;

            adapter.SelectCommand = command;
            adapter.Fill(dt);

            return dt;

            }



        public DataTable GetNewAccomadationDetails()
        {

            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT u.name, bl.Block_Name, r.Room_Type, r.Room_Name FROM bookings b LEFT JOIN users u ON u.id=b.User_ID LEFT JOIN `room_id-user_id` ru ON ru.User_ID=b.User_ID LEFT JOIN rooms r ON r.Room_ID=ru.Room_ID LEFT JOIN block bl ON bl.Block_ID=r.Block_ID WHERE u.name = @uN AND b.Booking_Status = 'New'", db.getConnection());

            command.Parameters.Add("@uN", MySqlDbType.VarChar).Value = Name;

            adapter.SelectCommand = command;
            adapter.Fill(dt);

            return dt;

        }



      
        
        public DataTable GetFeedbackHistory()
        {

            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT f.Feedback_ID, f.Feedback_Type, f.Feedback_Description, f.Feedback_Status FROM feedbacks f LEFT JOIN users u ON u.id=f.User_ID WHERE u.name=@uN", db.getConnection());

            command.Parameters.Add("@uN", MySqlDbType.VarChar).Value = Name;

            adapter.SelectCommand = command;
            adapter.Fill(dt);
            return dt;

        }


        public bool IsReqExist()
        {

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `bookings` WHERE `User_ID` = @uID and `Booking_Status` = 'Approved'", db.getConnection());

            command.Parameters.Add("@uID", MySqlDbType.Int32).Value = ID;

            adapter.SelectCommand = command;
            adapter.Fill(table);


            if (table.Rows.Count > 0)
            {
                //Exist
                return true;
            }

            else
            {
                
                return false;
            }

        }


        public bool SendRoomReq(DateTime Start_Date, DateTime End_Date, string Room_Type, string Block)
        {

            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("INSERT INTO `bookings` (`Booking_ID`, `User_ID`, `Booking_Start_Date`, `Booking_End_Date`, `Booking_Status`, `Booking_Type`, `Booking_Block`) VALUES (NULL, @uID, @Start_Date, @End_Date, 'New', @uR, @uB)", db.getConnection());
            command.Parameters.Add("@uID", MySqlDbType.Int32).Value = ID;
            command.Parameters.Add("@Start_Date", MySqlDbType.Date).Value = Start_Date;
            command.Parameters.Add("@End_Date", MySqlDbType.Date).Value = End_Date;
            command.Parameters.Add("@uR", MySqlDbType.VarChar).Value = Room_Type;
            command.Parameters.Add("@uB", MySqlDbType.VarChar).Value = Block;

            db.openConnection();
            int result = command.ExecuteNonQuery();
            db.closeConnection();
            if (result < 0)
                return false;
            else
            {
                return true;
            }


        }

        public bool UpdatePhoneNum(string NewPhone)
        {
            
            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("UPDATE users SET Phone = @uP WHERE id = @uID", db.getConnection());
            command.Parameters.Add("@uID", MySqlDbType.Int32).Value = ID;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = NewPhone;
            db.openConnection();
            int result = command.ExecuteNonQuery();
            db.closeConnection();

            if (result < 0)
                //Error
                return false;
            else
            {
                return true;
            }

        }


        public bool SendChangeReq(string NewBlock, string NewRoomType)
        {

            if (!IsReqExist()) {
                return false;
            }
            string Book_ID = GetApprovedBookingID();

            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("INSERT INTO `change_req` (`Change_Req_ID`, `Booking_ID`, `Change_Block`, `Change_Type`, `Change_Req_Status`) VALUES (NULL, @bID, @nB, @nT, 'New')", db.getConnection());
            command.Parameters.Add("@bID", MySqlDbType.Int32).Value = Book_ID;
            command.Parameters.Add("@nB", MySqlDbType.VarChar).Value = NewBlock;
            command.Parameters.Add("@nT", MySqlDbType.VarChar).Value = NewRoomType;
            db.openConnection();
            int result = command.ExecuteNonQuery();
            db.closeConnection();

            if (result < 0)
                //Error
                return false;
            else
            {
                return true;
            }


        }

        
        public string GetApprovedBookingID()
        {

            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `bookings` WHERE User_ID = @uID and Booking_Status = 'Approved'", db.getConnection());

            command.Parameters.Add("@uID", MySqlDbType.Int32).Value = ID;

            adapter.SelectCommand = command;
            adapter.Fill(dt);
            string BookID = dt.Rows[0]["Booking_ID"].ToString();

            return BookID;

        }


        public bool SendFeedback(string FeedbackType, string FeedbackDescr)
        {
            if (!IsReqExist())
            {
                return false;
            }

            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("INSERT INTO `feedbacks` (`Feedback_ID`, `Feedback_Type`, `Feedback_Description`, `Feedback_Status`, `User_ID`) VALUES (NULL, @fT, @fD, @fS, @uID)", db.getConnection());
            command.Parameters.Add("@uID", MySqlDbType.Int32).Value = ID;
            command.Parameters.Add("@fT", MySqlDbType.VarChar).Value = FeedbackType;
            command.Parameters.Add("@fD", MySqlDbType.VarChar).Value = FeedbackDescr;
            command.Parameters.Add("@fS", MySqlDbType.VarChar).Value = "New";

            db.openConnection();
            int result = command.ExecuteNonQuery();
            db.closeConnection();

            if (result < 0)
                //Error
                return false;
            else
            {
                return true;
            }
        }


        public bool SendTerminationReq(string TermDescr, DateTime TermCheckOut)
        {

            if (!IsReqExist())
            {   
                return false;
            }
            string Book_ID = GetApprovedBookingID();

            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("INSERT INTO `terminations_req` (`Ter_ID`, `Ter_Description`, `Ter_Check_Out`, `Ter_Status`, `User_ID`)VALUES(NULL, @tDescription, @tCheckOut, @tStatus, @uID)", db.getConnection());
            command.Parameters.Add("@uID", MySqlDbType.Int32).Value = ID;
            command.Parameters.Add("@tDescription", MySqlDbType.VarChar).Value = TermDescr;
            command.Parameters.Add("@tCheckOut", MySqlDbType.Date).Value = TermCheckOut;
            command.Parameters.Add("@tStatus", MySqlDbType.VarChar).Value = "New";

            db.openConnection();
            int result = command.ExecuteNonQuery();
            db.closeConnection();

            if (result < 0)
                //Error
                return false;
            else
            {
                return true;
            }


        }




    }
}



