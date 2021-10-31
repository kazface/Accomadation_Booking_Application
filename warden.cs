using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projectforstudy
{
    class warden
    {
        //id`, `login`, `password`, `name`, `email`, `warden`, `gender`
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Warden { get; set; }
        public string Gender { get; set; }
        //Student data
        public warden(int ID, string Login, string Password, string Name, string Email, int Warden, string Gender)
        {
            this.ID = ID;
            this.Login = Login;
            this.Password = Password;
            this.Name = Name;
            this.Email = Email;
            this.Warden = Warden;
            this.Gender = Gender;
        }




        public DataTable GetNewBookingDetails()
        {

            DB db = new DB();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT DISTINCT b.Booking_ID, u.name, b.Booking_Block, b.Booking_Type, u.Phone, b.Booking_Start_Date, b.Booking_End_Date FROM bookings b LEFT JOIN users u ON u.id=b.User_ID LEFT JOIN `room_id-user_id` ru ON ru.User_ID=b.User_ID LEFT JOIN rooms r ON r.Room_ID=ru.Room_ID LEFT JOIN block bl ON bl.Block_ID=r.Block_ID WHERE b.Booking_Status = 'New'", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            return dt;
        }

        public DataTable GetChangeReqDetails()
        {
            DB db = new DB();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT DISTINCT cr.Change_Req_ID, u.name, cr.Change_Block, cr.Change_Type, u.Phone, b.Booking_Start_Date, b.Booking_End_Date, r.Room_Name FROM change_req cr LEFT JOIN bookings b ON b.Booking_ID = cr.Booking_ID LEFT JOIN users u ON u.ID = b.User_ID LEFT JOIN `room_id-user_id` ru ON ru.User_ID = b.User_ID LEFT JOIN rooms r ON r.Room_ID = ru.Room_ID WHERE cr.Change_Req_Status='New' and b.Booking_Status = 'Approved'", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            return dt;
        }

        public DataTable GetTerminationReqs()
        {

            DB db = new DB();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT DISTINCT tr.Ter_ID, u.name, r.Room_Name, u.Phone, b.Booking_Start_Date, tr.Ter_Check_Out, r.Room_Name FROM terminations_req tr LEFT JOIN bookings b ON tr.User_ID = b.User_ID LEFT JOIN users u ON u.ID = tr.User_ID LEFT JOIN `room_id-user_id` ru ON ru.User_ID = b.User_ID LEFT JOIN rooms r ON r.Room_ID = ru.Room_ID WHERE b.Booking_Status = 'Approved' and tr.Ter_Status = 'New'", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            return dt;
        }

        public DataTable GetFeedbackReqs()
        {

            DB db = new DB();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT DISTINCT f.Feedback_ID, u.name, bl.Block_Name,r.Room_Name, f.Feedback_Type, f.Feedback_Status FROM feedbacks f LEFT JOIN bookings b ON f.User_ID = b.User_ID LEFT JOIN users u ON f.User_ID = u.ID LEFT JOIN `room_id-user_id` ru ON ru.User_ID = f.User_ID LEFT JOIN rooms r ON r.Room_ID = ru.Room_ID LEFT JOIN block bl ON bl.Block_ID = r.Block_ID WHERE bl.Block_Name IS NOT NULL AND r.Room_Name is NOT NULL", db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            return dt;
        }






        public string GetFeedbackDescr(int Feedback_ID)
        {

            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT f.Feedback_Description FROM feedbacks f WHERE f.Feedback_ID = @fID", db.getConnection());

            command.Parameters.Add("@fID", MySqlDbType.Int32).Value = Feedback_ID;

            adapter.SelectCommand = command;
            adapter.Fill(dt);
            string Feedback_Descr = dt.Rows[0]["Feedback_Description"].ToString();

            return Feedback_Descr;

        }


        public string GetTerminationDescr(int Ter_ID)
        {

            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT tr.Ter_Description FROM terminations_req tr WHERE tr.Ter_ID = @tID AND tr.Ter_Status='New'", db.getConnection());

            command.Parameters.Add("@tID", MySqlDbType.Int32).Value = Ter_ID;

            adapter.SelectCommand = command;
            adapter.Fill(dt);
            string Ter_Descr = dt.Rows[0]["Ter_Description"].ToString();

            return Ter_Descr;

        }


        public DataTable GetAvailableRooms(DateTime Start_Date, DateTime End_Date, string Room_Type, string Block_Name, int Room_Floor)
        {

            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT DISTINCT Room_Name FROM rooms r LEFT JOIN `room_id-user_id` ru ON ru.Room_ID=r.Room_ID LEFT JOIN bookings b ON b.User_ID=ru.User_ID LEFT JOIN block bl ON r.Block_ID=bl.Block_ID WHERE r.Room_ID NOT IN (SELECT r.Room_ID FROM rooms r LEFT JOIN `room_id-user_id` ru ON ru.Room_ID=r.Room_ID LEFT JOIN bookings b ON b.User_ID=ru.User_ID WHERE @Start_Date < b.Booking_End_Date and @End_Date > b.Booking_Start_Date and b.Booking_Status='Approved') AND Room_Type = @Room_Type AND Block_Name = @Block_Name AND Room_Floor = @Room_Floor", db.getConnection());

            command.Parameters.Add("@Start_Date", MySqlDbType.Date).Value = Start_Date;
            command.Parameters.Add("@End_Date", MySqlDbType.Date).Value = End_Date;
            command.Parameters.Add("@Room_Type", MySqlDbType.VarChar).Value = Room_Type;
            command.Parameters.Add("@Block_Name", MySqlDbType.VarChar).Value = Block_Name;
            command.Parameters.Add("@Room_Floor", MySqlDbType.Int32).Value = Room_Floor;

            adapter.SelectCommand = command;
            adapter.Fill(dt);

            return dt;

        }



        public bool IsStudentInRoom(int Booking_ID, string Room_Name)
        {
            DB db = new DB();
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT ru.User_ID, ru.Room_ID FROM `room_id-user_id` ru LEFT JOIN rooms r ON r.Room_ID = ru.Room_ID WHERE ru.User_ID = (SELECT User_ID FROM bookings WHERE Booking_ID = @Booking_ID) AND r.Room_Name = @Room_Name", db.getConnection());
            command.Parameters.Add("@Booking_ID", MySqlDbType.Int32).Value = Booking_ID;
            command.Parameters.Add("@Room_Name", MySqlDbType.VarChar).Value = Room_Name;

            adapter.SelectCommand = command;
            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
                //Error
                return true;
            else
            {
                return false;
            }
        }


        public bool AssignRoom(int Booking_ID, string Room_Name)
        {

            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("INSERT INTO `room_id-user_id` (Room_ID, User_ID) VALUES((SELECT Room_ID FROM rooms WHERE Room_Name = @rN), (SELECT User_ID FROM bookings WHERE Booking_ID = @bID))", db.getConnection());
            command.Parameters.Add("@bID", MySqlDbType.Int32).Value = Booking_ID;
            command.Parameters.Add("@rN", MySqlDbType.VarChar).Value = Room_Name;
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

        public bool ApproveRequest(int Booking_ID)
        {

            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("UPDATE bookings b, `room_id-user_id` ru SET b.Booking_Status = 'Approved' WHERE b.Booking_ID = @bID", db.getConnection());
            command.Parameters.Add("@bID", MySqlDbType.Int32).Value = Booking_ID;
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


        public bool RejectRequest(int Booking_ID)
        {

            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("UPDATE bookings b, `room_id-user_id` ru SET b.Booking_Status = 'Rejected' WHERE b.Booking_ID = @bID", db.getConnection());
            command.Parameters.Add("@bID", MySqlDbType.Int32).Value = Booking_ID;
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


        public bool ApproveChangeRequest(int Booking_ID)
        {

            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("UPDATE bookings b, `room_id-user_id` ru SET b.Booking_Status = 'Approved' WHERE b.Booking_ID = @bID", db.getConnection());
            command.Parameters.Add("@bID", MySqlDbType.Int32).Value = Booking_ID;
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




        //add bellow to wardenform
        public bool AssignChangedRoom(int Change_ID, string Room_Name)
        {

            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("UPDATE `room_id-user_id` ru SET Room_ID = (SELECT Room_ID FROM rooms where Room_Name = @Room_Name) WHERE User_ID = (SELECT User_ID From bookings b left join change_req cr ON cr.Booking_ID = b.Booking_ID WHERE cr.Change_Req_ID = @Change_Req_ID)", db.getConnection());
            command.Parameters.Add("@Change_Req_ID", MySqlDbType.Int32).Value = Change_ID;
            command.Parameters.Add("@Room_Name", MySqlDbType.VarChar).Value = Room_Name;
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


        public bool ApproveChangedRoom(int Change_ID)
        {

            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("UPDATE change_req cr SET cr.Change_Req_Status = 'Approved' WHERE cr.Change_Req_ID = @Change_Req_ID", db.getConnection());
            command.Parameters.Add("@Change_Req_ID", MySqlDbType.Int32).Value = Change_ID;
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


        public bool RejectChangedRoom(int Change_ID)
        {

            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("UPDATE change_req cr SET cr.Change_Req_Status = 'Rejected' WHERE cr.Change_Req_ID = @Change_Req_ID", db.getConnection());
            command.Parameters.Add("@Change_Req_ID", MySqlDbType.Int32).Value = Change_ID;
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

        public bool UpdateFeedbackStatus(int Feedback_ID, string Feedback_Status)
        {

            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("UPDATE feedbacks SET Feedback_Status = @Feedback_Status WHERE Feedback_ID = @Feedback_ID", db.getConnection());
            command.Parameters.Add("@Feedback_ID", MySqlDbType.Int32).Value = Feedback_ID;
            command.Parameters.Add("@Feedback_Status", MySqlDbType.Int32).Value = Feedback_Status;
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


        public bool ApproveTermRequest(int Ter_ID, DateTime Booking_End_Date)
        {

            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("UPDATE terminations_req tr SET tr.Ter_Status = 'Approved' WHERE tr.Ter_ID = @Ter_ID; UPDATE bookings b SET b.Booking_End_Date=@Booking_End_Date WHERE b.User_ID = (SELECT tr.User_ID FROM terminations_req tr WHERE tr.Ter_ID = @Ter_ID) and b.Booking_Status='Approved'", db.getConnection());
            command.Parameters.Add("@Ter_ID", MySqlDbType.Int32).Value = Ter_ID;
            command.Parameters.Add("@Booking_End_Date", MySqlDbType.Date).Value = Booking_End_Date;
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

        public bool RejectTermRequest(int Ter_ID)
        {

            DB db = new DB();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("UPDATE terminations_req tr SET tr.Ter_Status = 'Rejected' WHERE tr.Ter_ID = @Ter_ID;", db.getConnection());
            command.Parameters.Add("@Ter_ID", MySqlDbType.Int32).Value = Ter_ID;
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

        public DataTable GetReport(string Block)
        {

            DB db = new DB();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT r.Room_Name, ru.User_ID, u.name, b.Booking_Start_Date, b.Booking_End_Date FROM rooms r LEFT JOIN `room_id-user_id` ru ON ru.Room_ID = r.Room_ID LEFT JOIN users u ON u.id = ru.User_ID LEFT JOIN bookings b ON ru.User_ID = b.User_ID WHERE b.Booking_Status = 'Approved' and b.Booking_Start_Date IS NOT NULL and b.Booking_End_Date IS NOT NULL and b.Booking_Block = @Block", db.getConnection());
            command.Parameters.Add("@Block", MySqlDbType.VarChar).Value = Block;

            adapter.SelectCommand = command;
            adapter.Fill(dt);

            dt.Columns.Add("Today", typeof(System.DateTime));

            int columnNumber = 5; //TodayDate

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][columnNumber] = DateTime.Today; //Helping Column that contain Today date for every row to make expression
            }
            dt.Columns.Add("Status", typeof(String), "IIF(Today >= Booking_Start_Date  and Today <= Booking_End_Date, 'Occupied', 'Vacant')");
                                                 //SSRS expression using Columns.Add(column_name, type, expression)

            System.Data.DataView view = new System.Data.DataView(dt);
            System.Data.DataTable selected =
                    view.ToTable("Selected", false, "Room_Name", "User_ID", "name", "Booking_Start_Date", "Booking_End_Date", "Status");
            //Create DataView with no Today

            



            return selected;


        }

        //Bellow???

    }


}
