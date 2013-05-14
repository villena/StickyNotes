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
    public class Note_CAD
    {
        private Note_CAD userc;
        private string database;

        public Note_CAD()
        {
        }

        public bool addNote(Note_Class notec, int id)
        {
            bool insertado = false;

            String connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";
            SqlConnection con = new SqlConnection(connection);

            try
            {
                con.Open();
                string sql1 = "INSERT INTO NOTES (KIND,CREATION_DATE,TEXT)  VALUES (" + "'a'" + "," + "'" + notec.Date + "'" + "," + "'" + notec.Text + "'" + ")";
                int note_id = getIDfromDB() +1;
                string sql2 = "INSERT INTO US_NO_REL (UID,NID) VALUES (" + id + "," + note_id + ")";
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

                insertado = true;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }

            return insertado;
        }

        public bool deleteNote(Note_Class notec)
        {
            bool borrado = false;

            String connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";
            SqlConnection con = new SqlConnection(connection);

            try
            {
                con.Open();
                string sql = "DELETE FROM NOTES WHERE id = notec.id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                borrado = true;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }

            return borrado;
        }

        public bool modifyNote(Note_Class notec)
        {
            bool modificacion = false;

            String connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";
            SqlConnection con = new SqlConnection(connection);

            try
            {
                string sql = "UPDATE NOTAS SET TEXT = " + "'" + notec.Id + "'" + "WHERE ID =" + notec.Id + ")";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                modificacion = true;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }

            return modificacion;
        }

        public int getIDfromDB()
        {
            int id = -1;

            String connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";
            SqlConnection con = new SqlConnection(connection);

            try
            {
                con.Open();
                string sql = "SELECT ID FROM NOTES WHERE (ID = (SELECT MAX(ID) FROM NOTES))";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rd = cmd.ExecuteReader();

                while(rd.Read())
                {
                    id = int.Parse(rd["ID"].ToString());
                }

                con.Close();

            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }

            return id;

        }
    }
}
