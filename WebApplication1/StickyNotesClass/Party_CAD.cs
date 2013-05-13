using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StickyNotesClass
{
    public class Party_CAD
    {
        private Party_Class myParty;
        private List<Note_Class> myNotes;
        private List<User_Class> myUsers;
        private string database;

        public Party_CAD(string db)
        {
            database = db;
        }

        public bool createParty(Party_Class party)
        {
            //String connection = "Base de datos";
            //SqlConnection con = new SqlConnection(connection);
            //string nombre = textbox_nombre.text;
            //string sql = "INSERT INTO PARTY VALUES (" + ID + "," + nombre + ")";
            //SqlCommand cmd = new SqlCommand(sql,con);
            return false;
        }

        public bool addUser(User_Class user)
        {
            //NECESITO TABLAS
            return false;
        }

        public Party_Class obtainData()
        {
            return myParty;
            //myParty.Users = this.obtainUsers();
            //myParty.Notes = this.obtainNotes();
        }

        public List<Note_Class> obtainNotes()
        {
            //METODO READER, RELEER.
            return myNotes;
        }

        public List<User_Class> obtainUsers()
        {
            //String connection = "Base de datos";
            //SqlConnection con = new SqlConnection(connection);
            //string sql = "SELECT * FROM nOTES WHERE (PERTENEZCAN AL GRUPO)";
            //SqlCommand cmd = new SqlCommand(sql,con);
            return myUsers;
        }

        public bool update(Party_Class myParty)
        {
            //String connection = "Base de datos";
            //SqlConnection con = new SqlConnection(connection);
            //string sql = "UPDATE 
            //SqlCommand cmd = new SqlCommand(sql,con);

            return false;
        }

        public bool deleteParty(Party_Class myParty)
        {

            //String connection = "Base de datos";
            //SqlConnection con = new SqlConnection(connection);
            //string sql = "DELETE FROM PARTY WHERE nombre = myParty.nombre;
            //SqlCommand cmd = new SqlCommand(sql,con);
            return false;
        }
    }
}
