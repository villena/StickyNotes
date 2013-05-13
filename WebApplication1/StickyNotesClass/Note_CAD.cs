using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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
            //String connection = "Base de datos";
            //SqlConnection con = new SqlConnection(connection);
            //string sql = "INSERT INTO NOTES VALUES "(" + notec.id + "," + notec.text + "," + resto campos + ")";
            //SqlCommand cmd = new SqlCommand(sql,con);
            return false;
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
