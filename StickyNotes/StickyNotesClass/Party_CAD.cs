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
            myNotes = new List<Note_Class>();
            myUsers = new List<User_Class>();

        }

        public bool createParty(Party_Class party)
        {
            bool creada=false;

            SqlConnection con = new SqlConnection(connection);

            try
            {
                //con.Open();
                Console.WriteLine("hola");
                string sql = "INSERT INTO PARTY (NAME) OUTPUT INSERTED.ID VALUES ('" + party.Name + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();



                int id = -1;
                if (reader.Read())
                {
                    id = int.Parse(reader["ID"].ToString());
                }
                cmd.Connection.Close();

                SqlCommand cmd1;
                String sql2;
                foreach (User_Class user in party.Users)
                {

                    sql2 = "INSERT INTO US_PA_REL(UID, PID) VALUES (" + user.Id + "," + id + ")";
                    cmd1 = new SqlCommand(sql2, con);
                    cmd1.Connection.Open();
                    cmd1.ExecuteNonQuery();
                    cmd1.Connection.Close();
                }

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
                    notaAux.Author = Int32.Parse(reader["AUTHOR"].ToString());

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

        //Devuelve una lista con los grupos de un usuario
        public List<Party_Class> userGroups(int id)
        {
            SqlConnection con = new SqlConnection(connection);
            List<Party_Class> partyList = new List<Party_Class>();

            try
            {

                con.Open();
                string sql = "SELECT * FROM PARTY WHERE ID IN (SELECT PID FROM US_PA_REL WHERE UID=" + id + ")";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();


                Party_Class party = new Party_Class();

                while (reader.Read())
                {
                    party = new Party_Class();
                    party.Id = int.Parse(reader["ID"].ToString());
                    party.Name = reader["NAME"].ToString();

                    partyList.Add(party);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return partyList;
        }

        public bool deleteParty(Party_Class myParty)
        {
            bool borrado;

            SqlConnection con = new SqlConnection(connection);

            try
            {
                string sql1 = "DELETE FROM PARTY WHERE ID =" + myParty.Id.ToString();
                string sql2 = "DELETE FROM US_PA_REL WHERE PID =" + myParty.Id.ToString();
                string sql3 = "DELETE FROM NOTES WHERE PARTY_ID =" + myParty.Id.ToString();
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                SqlCommand cmd3 = new SqlCommand(sql3, con);

                cmd3.Connection.Open();
                cmd3.ExecuteNonQuery();
                cmd3.Connection.Close();

                cmd2.Connection.Open();
                cmd2.ExecuteNonQuery();
                cmd2.Connection.Close();

                cmd1.Connection.Open();
                cmd1.ExecuteNonQuery();
                cmd2.Connection.Close();


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

        public string getName(int id)
        {
            String connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";
            SqlConnection con = new SqlConnection(connection);
            string sql1 = "SELECT NAME FROM PARTY WHERE ID=" + id.ToString();
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            cmd1.Connection.Open();
            SqlDataReader reader = cmd1.ExecuteReader();

            string s = "";
            if (reader.Read())
            {
                s = reader["NAME"].ToString();
            }
            cmd1.Connection.Close();

            return s;


        }

        public bool addNote(Note_Class note, int g_id, int author_id)
        {
            bool insertado = false;

            String connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";
            SqlConnection con = new SqlConnection(connection);

            try
            {
                con.Open();
                string sql1 = "INSERT INTO NOTES (KIND,CREATION_DATE,TEXT,PARTY_ID,AUTHOR)  VALUES ('G', '" + note.Date.ToString() + "', '" + note.Text + "'," + g_id +", "+author_id+ ")";
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                cmd1.ExecuteNonQuery();
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
    }
}
