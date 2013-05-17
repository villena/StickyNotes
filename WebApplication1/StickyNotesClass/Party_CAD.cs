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
    public class Party_CAD
    {
        private Party_Class myParty;
        private List<Note_Class> myNotes;
        private List<User_Class> myUsers;
        private string conection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";

        public Party_CAD()
        {
        }

        public bool createParty(Party_Class party)
        {
            bool creada;

            SqlConnection con = new SqlConnection(conection);

            try
            {
                con.Open();
                string sql = "INSERT INTO PARTY (NAME) VALUES (" + party.Name + ")";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();

                creada = true;
            }
            catch (Exception ex)
            {
                creada = false;
            }
            finally
            {
                con.Close();
            }

            return creada;
        }

        public bool addUser(User_Class userm,int id_party)
        {
            bool añadido;

            SqlConnection con = new SqlConnection(conection);

            try
            {
                con.Open();
                string sql = "INSERT INTO US_PA_REL (UID,PID) VALUES ("+ userm.Id + "," + id_party +")";
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

        public Party_Class obtainData(int id)
        {

            SqlConnection con = new SqlConnection(conection);

            try
            {
                con.Open();
                string sql = "SELECT * FROM PARTY WHERE ID ="+ id;
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    myParty.Id = id;
                    myParty.Name = reader["NAME"].ToString();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }

            return myParty;
        }

        public List<Note_Class> obtainNotes(int id)
        {
            SqlConnection con = new SqlConnection(conection);

            try
            {
                con.Open();
                string sql = "SELECT * FROM NOTE WHERE ID =" + id;
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    myParty.Id = id;
                    myParty.Name = reader["NAME"].ToString();

                    myNotes.Add(my
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                con.Close();
            }

            return myParty;
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
