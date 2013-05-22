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
        private string connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";

        public Party_CAD()
        {
        }

        public bool createParty(Party_Class party)
        {
            bool creada;

            SqlConnection con = new SqlConnection(connection);

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

            SqlConnection con = new SqlConnection(connection);

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
            SqlConnection con = new SqlConnection(connection);

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

        public List<Note_Class> obtainNotes(int id_party)
        {
            SqlConnection con = new SqlConnection(connection);

            try
            {
                con.Open();
                string sql = "SELECT * FROM NOTES WHERE PARTY_ID =" + id_party;
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Note_Class notaAux = new Note_Class();
                    
                    notaAux.Id = int.Parse(reader["ID"].ToString());
                    notaAux.Type = Convert.ToChar(reader["KIND"]);
                    notaAux.Date = reader["CREATION_DATE"].ToString();
                    notaAux.Text = reader["TEXT"].ToString();

                    myNotes.Add(notaAux);
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

            return myNotes;
        }

        public List<User_Class> obtainUsers(int party_id)
        {
            SqlConnection con = new SqlConnection(connection);

            try
            {
                con.Open();
                string sql = "SELECT * FROM US_PA_REL WHERE PID =" + party_id + ")";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    User_Class userTemp = new User_Class();
                    userTemp.Id = int.Parse(reader["ID"].ToString());
                    userTemp.Nick = reader["NICK"].ToString();
                    userTemp.Email = reader["EMAIL"].ToString();
                    userTemp.Name = reader["NAME"].ToString();
                    userTemp.Surname = reader["SURNAME"].ToString();
                    userTemp.Pass = reader["PASS"].ToString();
                    userTemp.Gender = char.Parse(reader["GENDER"].ToString());
                    userTemp.Entry_date = reader["ENTRY_DATE"].ToString();
                    userTemp.Birth_date = reader["BIRTH_DATE"].ToString();
                    userTemp.Image_url = reader["IMAGE_URL"].ToString();

                    myUsers.Add(userTemp);
                }
            }
            catch (Exception ex) { }
            finally
            {
                con.Close();
            }

            return myUsers;
        }

        public bool update(Party_Class myParty)
        {

            bool actualizado; 

            SqlConnection con = new SqlConnection(connection);
            string sql = "UPDATE PARTY SET NAME = " + myParty.Name + "WHERE ID = " +  myParty.Id;
            SqlCommand cmd = new SqlCommand(sql,con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                actualizado = true;
            }
            catch (Exception ex)
            {
                actualizado = false;
            }
            finally
            {
                con.Close();
            }

            return actualizado;
        }

        public bool deleteParty(Party_Class myParty)
        {
            bool borrado;

            SqlConnection con = new SqlConnection(connection);

            try
            {
                string sql1 = "DELETE FROM PARTY WHERE ID =" + myParty.Id + ")";
                string sql2 = "DELETE FROM US_PA_REL WHERE ID =" + myParty.Id + ")";
                SqlCommand cmd1 = new SqlCommand(sql1,con);
                SqlCommand cmd2 = new SqlCommand(sql2,con);

                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

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
    }
}
