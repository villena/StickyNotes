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

        public Events_CAD(){}


        public bool addEvent(Events_Class item)
        {

            bool añadido;

            SqlConnection con = new SqlConnection(connection);
            string sql = "INSERT INTO EVENTS (DATE,DESCRIPTION,LOCATION) VALUES ("+ item.Date + "," + item.Description + ","+ item.Location+ ")";
            SqlCommand cmd = new SqlCommand(sql,con);

            try
            {
                con.Open();
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

        public bool deleteEvent(Events_Class item)
        {
            bool borrado;

            SqlConnection con = new SqlConnection(connection);
            string sql = "DELETE FROM EVENTS WHERE ID = " + item.Id;
            SqlCommand cmd = new SqlCommand(sql,con);

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
    }
}
