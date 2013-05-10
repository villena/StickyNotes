using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace SickyNotesClass
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
            //String connection = "Base de datos";
            //SqlConnection con = new SqlConnection(connection);
            //con.Open();
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
            //NI PERRA DE SI ESTO VA AQUI.
            return false;
        }

        public Party_Class obtainData()
        {
            //myParty.Users = this.obtainUsers();
            //myParty.Notes = this.obtainNotes();
        }

        public List<Note_Class> obtainNotes()
        {
            //String connection = "Base de datos";
            //SqlConnection con = new SqlConnection(connection);
            //string sql = "SELECT * FROM nOTES WHERE (PERTENEZCAN AL GRUPO)";
            //SqlCommand cmd = new SqlCommand(sql,con);


            return myNotes;
        }

        public List<User_Class> obtainUsers()
        {
            //String connection = "Base de datos";
            //SqlConnection con = new SqlConnection(connection);
            //string sql = "SELECT * FROM USER WHERE (PERTENEZCAN AL GRUPO)";
            //SqlCommand cmd = new SqlCommand(sql,con);

            return myNotes;
        }

        public bool update(Party_Class myParty)
        {
            //String connection = "Base de datos";
            //SqlConnection con = new SqlConnection(connection);
            //string sql = "UPDATE 
            //SqlCommand cmd = new SqlCommand(sql,con);
        }

        public bool deleteParty(Party_Class myParty)
        {
            //String connection = "Base de datos";
            //SqlConnection con = new SqlConnection(connection);
            //string sql = "DELETE FROM PARTY WHERE nombre = myParty.nombre;
            //SqlCommand cmd = new SqlCommand(sql,con);
        }
    }
}
