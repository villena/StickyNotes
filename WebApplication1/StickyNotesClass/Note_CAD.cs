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

        public bool addNote(Note_Class notec)
        {
            bool insertado = false;

            String connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";
            SqlConnection con = new SqlConnection(connection);

            try
            {
                con.Open();
                string sql = "INSERT INTO NOTES (KIND,CREATION_DATE,TEXT)  VALUES (" + "'a'" + "," + "'" + notec.Date + "'" + "," + "'" + notec.Text + "'" + ")";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
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
                string sql = "UPDATE NOTAS SET TEXT = " + "'" + notec.Id + "'" + "WHERE ID =" + notec.Id +")";
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

        

    }
}
