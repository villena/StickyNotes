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
                if(item.Description.Length>=50)
                    item.Description=item.Description.ToString().Substring(0,50);
                if (item.Location.Length >= 50)
                    item.Location=item.Location.ToString().Substring(0, 50); 

                    
                SqlConnection con = new SqlConnection(connection);
                string sql = "INSERT INTO EVENTS (DATE,DESCRIPTION,LOCATION) OUTPUT INSERTED.ID VALUES ('" + item.Date.ToString() + "', '" + item.Description.ToString() + "', '" + item.Location.ToString()+ "')";
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
                añadido = true;
            }
            catch (Exception ex)
            {
                añadido = false;
            }
            finally
            {
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

        public bool deleteUser(User_Class userm, int eventID)
        {
            bool deleted;

            SqlConnection con = new SqlConnection(connection);

            try
            {
                con.Open();
                string sql = "DELETE FROM US_EV_REL WHERE UID = " + userm.Id + "AND EID=" + eventID;
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                deleted = true;

            }
            catch (Exception ex)
            {
                deleted = false;
            }
            finally
            {
                con.Close();
            }

            return deleted;

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
            Events_Class events = new Events_Class();

            try
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    events = new Events_Class();
                    events.Id = int.Parse(reader["ID"].ToString());
                    events.Date = DateTime.Parse(reader["DATE"].ToString()).ToShortDateString();
                    events.Description = reader["DESCRIPTION"].ToString();
                    events.Location = reader["LOCATION"].ToString();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }

            return events;
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
                    events.Date = DateTime.Parse(reader["DATE"].ToString()).ToShortDateString();
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

        public List<Events_Class> userNewEvents(int userID)
        {
            SqlConnection con = new SqlConnection(connection);
            List<Events_Class> eventsList = new List<Events_Class>();

            try
            {

                string sql = "SELECT * FROM EVENTS WHERE ID NOT IN(SELECT EID FROM US_EV_REL WHERE UID = " + userID + ")";
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

        public List<Events_Class> searchEvents(string myDescription, int userID)
        {
            SqlConnection con = new SqlConnection(connection);
            List<Events_Class> eventsList = new List<Events_Class>();

            try
            {

                string sql = "SELECT * FROM EVENTS WHERE DESCRIPTION LIKE '%" + myDescription + "%' AND ID NOT IN(SELECT EID FROM US_EV_REL WHERE UID = " + userID + ")";
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
