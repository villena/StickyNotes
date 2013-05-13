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
                //string sql = "INSERT INTO NOTES (KIND,CREATION_DATE,TEXT)  VALUES ('a','11/03/2013','Javi es un cabronazo')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
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
            //String connection = "Base de datos";
            //SqlConnection con = new SqlConnection(connection);
            //string sql = "DELETE FROM NOTES WHERE id = notec.id;
            //SqlCommand cmd = new SqlCommand(sql,con);
            return false;
        }

        public bool modifyNote(string text)
        {

            //NO tengo muy claro como modificar la nota

            //String connection = "Base de datos";
            //SqlConnection con = new SqlConnection(connection);
            //string sql = ""s;
            //SqlCommand cmd = new SqlCommand(sql,con);

            return false;
        }

        

    }
}
