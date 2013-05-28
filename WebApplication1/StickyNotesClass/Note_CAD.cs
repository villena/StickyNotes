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
                
                string sql1 = "INSERT INTO NOTES (KIND,CREATION_DATE,TEXT, AUTHOR) OUTPUT INSERTED.ID VALUES (" + "'"+notec.Type+"'" + "," + "'" + notec.Date + "'" + "," + "'" + notec.Text + "'," + id+ ")";
                int note_id = 0;
               
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                
                cmd1.Connection.Open();
                SqlDataReader reader = cmd1.ExecuteReader();

                if (reader.Read())
                {
                    cmd1.Connection.Close();
                    note_id = Int32.Parse(reader["ID"].ToString());

                    string sql2 = "INSERT INTO US_NO_REL (UID,NID) VALUES (" + id + "," + note_id + ")";

                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    cmd2.Connection.Open();
                    cmd2.ExecuteNonQuery();
                    cmd2.Connection.Close();
                }

                insertado = true;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                
            }

            return insertado;
        }

        public bool addNote(Note_Class notec, int id, List<User_Class> users)
        {
            bool insertado = false;

            String connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";
            SqlConnection con = new SqlConnection(connection);

            try
            {
                string sql1;
                if (notec.Category == -1)
                {
                    sql1 = "INSERT INTO NOTES (KIND,CREATION_DATE,TEXT, AUTHOR) OUTPUT INSERTED.ID VALUES (" + "'" + notec.Type + "'" + "," + "'" + notec.Date + "'" + "," + "'" + notec.Text + "'," + id.ToString() + ")";
                }
                else
                {
                    sql1 = "INSERT INTO NOTES (KIND,CREATION_DATE,TEXT, CATEGORY_ID, AUTHOR) OUTPUT INSERTED.ID VALUES (" + "'" + notec.Type + "'" + "," + "'" + notec.Date + "'" + "," + "'" + notec.Text + "',"+notec.Category.ToString()+"," + id.ToString() + ")";
                }



                int note_id = 0;

                SqlCommand cmd1 = new SqlCommand(sql1, con);

                cmd1.Connection.Open();
                SqlDataReader reader = cmd1.ExecuteReader();

                if (reader.Read())
                {
                    
                    note_id = Int32.Parse(reader["ID"].ToString());
                    cmd1.Connection.Close();

                    string sql2 = "INSERT INTO US_NO_REL (UID,NID) VALUES (" + id + "," + note_id + ")";

                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    cmd2.Connection.Open();
                    cmd2.ExecuteNonQuery();
                    cmd2.Connection.Close();

                    foreach (User_Class user in users)
                    {
                        sql2 = "INSERT INTO US_NO_REL (UID,NID) VALUES (" + user.Id + "," + note_id + ")";
                        cmd2 = new SqlCommand(sql2, con);
                        cmd2.Connection.Open();
                        cmd2.ExecuteNonQuery();
                        cmd2.Connection.Close();
                        
                    }
                }

                insertado = true;
            }
            catch (Exception ex)
            {
            }
            finally
            {

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
                string sql1 = "DELETE FROM US_NO_REL WHERE NID=" + notec.Id;
                string sql2 = "DELETE FROM NOTES WHERE ID =" + notec.Id;
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                SqlCommand cmd = new SqlCommand(sql2, con);
                cmd1.ExecuteNonQuery();
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
                con.Open();
                string sql = "UPDATE NOTES SET TEXT = " + "'" + notec.Text + "'" + "WHERE ID =" + notec.Id;
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

                while (rd.Read())
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

        }// Este creo que ya no hace falta[Victor]


        public Note_Class getNote(int id)
        {
            Note_Class note = new Note_Class();

            String connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";
            SqlConnection con = new SqlConnection(connection);

            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM NOTES WHERE ID=" + id, con);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {

                    note.Id = id;
                    note.Type = Convert.ToChar(dr["KIND"]);
                    note.Date = dr["CREATION_DATE"].ToString();
                    note.Text = dr["TEXT"].ToString();
                }
            }
            catch (Exception ex) { }
            finally
            {
                con.Close();
            }
            return note;
        }

        //Old version
       /* public List<Note_Class> notesUser(int id)
        {
            List<Note_Class> notesList = new List<Note_Class>();

            String connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";
           String sql = "SELECT * FROM NOTES WHERE ID IN (SELECT NID FROM US_NO_REL WHERE UID = " + id + ")";
           // string sql = "SELECT * FROM NOTES ORDER BY ID DESC";
            SqlConnection con = new SqlConnection(connection);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                Note_Class notaTemp = new Note_Class();

                while (reader.Read())
                {
                    notaTemp = new Note_Class();

                    notaTemp.Id = int.Parse(reader["ID"].ToString());
                    notaTemp.Text = reader["TEXT"].ToString();
                    notaTemp.Date = reader["CREATION_DATE"].ToString();
                    notaTemp.Type = Convert.ToChar(reader["KIND"]);
                   

                    notesList.Add(notaTemp);
                }
            }
            catch (Exception ex) { }
            finally
            {
                con.Close();
            }


            return notesList;
        }*/


        public List<Note_Class> notesUser(int id)
        {
            List<Note_Class> notesList = new List<Note_Class>();

            String connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";
            String sql = "SELECT * FROM NOTES WHERE ID IN (SELECT NID FROM US_NO_REL WHERE UID = " + id + ")";
            // string sql = "SELECT * FROM NOTES ORDER BY ID DESC";
            SqlConnection con = new SqlConnection(connection);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                Note_Class notaTemp = new Note_Class();

                while (reader.Read())
                {
                    notaTemp = new Note_Class();

                    notaTemp.Id = int.Parse(reader["ID"].ToString());
                    notaTemp.Text = reader["TEXT"].ToString();
                    notaTemp.Date = reader["CREATION_DATE"].ToString();
                    notaTemp.Type = Convert.ToChar(reader["KIND"]);


                    notesList.Add(notaTemp);
                }
            }
            catch (Exception ex) { }
            finally
            {
                con.Close();
            }


            return notesList;
        }

        public List<Note_Class> notesUserOpen(int id)
        {
            List<Note_Class> notesList = new List<Note_Class>();

            String connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";
            String sql = "SELECT * FROM NOTES WHERE KIND = 'O' AND ID IN (SELECT NID FROM US_NO_REL WHERE UID = " + id + ")";
            // string sql = "SELECT * FROM NOTES ORDER BY ID DESC";
            SqlConnection con = new SqlConnection(connection);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                Note_Class notaTemp = new Note_Class();

                while (reader.Read())
                {
                    notaTemp = new Note_Class();

                    notaTemp.Id = int.Parse(reader["ID"].ToString());
                    notaTemp.Text = reader["TEXT"].ToString();
                    notaTemp.Date = reader["CREATION_DATE"].ToString();
                    notaTemp.Type = Convert.ToChar(reader["KIND"]);


                    notesList.Add(notaTemp);
                }
            }
            catch (Exception ex) { }
            finally
            {
                con.Close();
            }


            return notesList;
        }

        public List<Note_Class> notesUserPrivate(int id)
        {
            List<Note_Class> notesList = new List<Note_Class>();

            String connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";
            String sql = "SELECT * FROM NOTES WHERE KIND = 'P' AND ID IN (SELECT NID FROM US_NO_REL WHERE UID = " + id + ")";
            // string sql = "SELECT * FROM NOTES ORDER BY ID DESC";
            SqlConnection con = new SqlConnection(connection);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                Note_Class notaTemp = new Note_Class();

                while (reader.Read())
                {
                    notaTemp = new Note_Class();

                    notaTemp.Id = int.Parse(reader["ID"].ToString());
                    notaTemp.Text = reader["TEXT"].ToString();
                    notaTemp.Date = reader["CREATION_DATE"].ToString();
                    notaTemp.Type = Convert.ToChar(reader["KIND"]);


                    notesList.Add(notaTemp);
                }
            }
            catch (Exception ex) { }
            finally
            {
                con.Close();
            }


            return notesList;
        }

        public List<Note_Class> notesOpen()
        {
            List<Note_Class> notesList = new List<Note_Class>();

            String connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";
            String sql = "SELECT * FROM NOTES WHERE KIND = 'O'";
            // string sql = "SELECT * FROM NOTES ORDER BY ID DESC";
            SqlConnection con = new SqlConnection(connection);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                Note_Class notaTemp = new Note_Class();

                while (reader.Read())
                {
                    notaTemp = new Note_Class();

                    notaTemp.Id = int.Parse(reader["ID"].ToString());
                    notaTemp.Text = reader["TEXT"].ToString();
                    notaTemp.Date = reader["CREATION_DATE"].ToString();
                    notaTemp.Type = Convert.ToChar(reader["KIND"]);


                    notesList.Add(notaTemp);
                }
            }
            catch (Exception ex) { }
            finally
            {
                con.Close();
            }


            return notesList;
        }

        public List<Note_Class> notesGroups(int id_group)
        {
            List<Note_Class> notesList = new List<Note_Class>();

            String connection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";
            String sql = "SELECT * FROM NOTES WHERE ID = " + id_group;
            SqlConnection con = new SqlConnection(connection);

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                Note_Class notaTemp = new Note_Class();

                while (reader.Read())
                {
                    notaTemp = new Note_Class();

                    notaTemp.Id = int.Parse(reader["ID"].ToString());
                    notaTemp.Text = reader["TEXT"].ToString();
                    notaTemp.Date = reader["CREATION_DATE"].ToString();
                    notaTemp.Type = Convert.ToChar(reader["KIND"]);

                    notesList.Add(notaTemp);
                }
            }
            catch (Exception ex) { }
            finally
            {
                con.Close();
            }


            return notesList;
        }

    }
}