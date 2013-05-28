using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;


namespace StickyNotesClass
{
    public class Events_CAD
    {
        private Events_Class myEvent;
        private string connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";

        public Events_CAD() { }


        public bool addEvent(Events_Class item)
        {

            bool añadido=false;

            try
            {

                SqlConnection con = new SqlConnection(connection);
                string sql = "INSERT INTO EVENTS (DATE,DESCRIPTION,LOCATION) OUTPUT INSERTED.ID VALUES ('" + item.Date.ToString() + "', '" + item.Description + "', '" + item.Location + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    item.Id = Int32.Parse(reader["ID"].ToString());
                }
                cmd.Connection.Close();


                SqlCommand cmd1;
                String sql2;
                foreach (User_Class user in item.Users)
                {

                    sql2 = "INSERT INTO US_EV_REL(UID, EID) VALUES (" + user.Id + "," + item.Id + ")";
                    cmd1 = new SqlCommand(sql2, con);
                    cmd1.Connection.Open();
                    cmd1.ExecuteNonQuery();
                    cmd1.Connection.Close();
                }

                //con.Open();
                //cmd.ExecuteNonQuery();
                añadido = true;
            }
            catch (Exception ex)
            {
                añadido = false;
            }
            finally
            {
                //con.Close();
            }

            return añadido;

        }

        public void updateEvent(Events_Class item)
        {
            SqlConnection con = new SqlConnection(connection);
            string sql = "UPDATE EVENTS SET DATE = " + item.Date + ", DESCRIPTION = " + item.Description + ", LOCATION = " + item.Location + "WHERE ID = " + item.Id;
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally
            {
                con.Close();
            }
        }

        public bool addUser(User_Class userm, int eventID)
        {
            bool añadido;

            SqlConnection con = new SqlConnection(connection);

            try
            {
                con.Open();
                string sql = "INSERT INTO US_EV_REL (UID,EID) VALUES (" + userm.Id + "," + eventID + ")";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                añadido = true;

            }
            catch (Exception ex)
            {
                añadido = false;
            }
            finally
            {
                con.Close();
            }

            return añadido;

        }

        public bool deleteEvent(Events_Class item)
        {
            bool borrado;

            SqlConnection con = new SqlConnection(connection);
            string sql = "DELETE FROM EVENTS WHERE ID = " + item.Id;
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                borrado = true;
            }
            catch (Exception ex)
            {
                borrado = false;
            }
            finally
            {
                con.Close();
            }

            return borrado;

        }

        public Events_Class obtainEvent(int id)
        {
            SqlConnection con = new SqlConnection(connection);
            string sql = "SELECT * FROM EVENTS WHERE ID = " + id;
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            try
            {
                con.Open();
                while (reader.Read())
                {
                    myEvent.Id = id;
                    myEvent.Date = reader["DATE"].ToString();
                    myEvent.Location = reader["LOCATION"].ToString();
                    myEvent.Description = reader["DESCRIPTION"].ToString();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }

            return myEvent;
        }

        public List<Events_Class> userEvents(int userID)
        {
            SqlConnection con = new SqlConnection(connection);
            List<Events_Class> eventsList = new List<Events_Class>();

            try
            {

                string sql = "SELECT * FROM EVENTS WHERE ID IN(SELECT EID FROM US_EV_REL WHERE UID = " + userID + ")";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Events_Class events = new Events_Class();

                while (reader.Read())
                {
                    events = new Events_Class();
                    events.Id = int.Parse(reader["ID"].ToString());
                    events.Date = reader["DATE"].ToString();
                    events.Description = reader["DESCRIPTION"].ToString();
                    events.Location = reader["LOCATION"].ToString();

                    eventsList.Add(events);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return eventsList;
        }
    }
}
