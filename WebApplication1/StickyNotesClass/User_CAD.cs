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
    public class User_CAD
    {
        private User_Class userc;
        private string db = "Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";

        public User_CAD()
        {

        }

        public bool addFriendCad(int id1, int id2)
        {
            bool added = false;
            SqlConnection c = new SqlConnection(db);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("INSERT INTO US_REL VALUES (" + id2 + ", " + id1 + ")", c);
                com.ExecuteNonQuery();
                added = true;
            }
            catch (Exception ex) { }
            finally { 
                c.Close();
            }
            return added;
        }

        public bool deleteFriendCad(int id1, int id2)
        {
            bool deleted = false;
            SqlConnection c = new SqlConnection(db);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("DELETE FROM US_REL WHERE UID1 = " + id2 + " AND UID2 = " + id1, c);
                com.ExecuteNonQuery();
                deleted = true;
            }
            catch (Exception ex) { }
            finally
            {
                c.Close();
            }
            return deleted;
        }

        public bool addUserCad(User_Class userc)
        {
            bool added = false;
            SqlConnection c = new SqlConnection(db);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("INSERT INTO USERS (NAME, SURNAME, EMAIL, NICK, PASS, GENDER, ENTRY_DATE, BIRTH_DATE, IMAGE_URL) VALUES ('" +
                    userc.Name + "', '" + userc.Surname + "', '" + userc.Email + "', '" + userc.Nick + "', '" + userc.Pass + "', '" + userc.Gender +
                    "', '" + userc.Entry_date + "', '" + userc.Birth_date + "', '" + userc.Image_url + "')", c);
                com.ExecuteNonQuery();
                added = true;
            }
            catch (Exception ex) { }
            finally
            {
                c.Close();
            }
            return added;
        }

        public bool deleteUserCad(User_Class userc)
        {
            bool deleted = false;
            SqlConnection c = new SqlConnection(db);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("DELETE FROM USERS WHERE NICK = '" + userc.Nick + "'", c);
                com.ExecuteNonQuery();
                deleted = true;
            }
            catch (Exception ex) { }
            finally
            {
                c.Close();
            }
            return deleted;
        }

        public bool changePassCad(User_Class userc)
        {
            bool changed = false;
            SqlConnection c = new SqlConnection(db);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("UPDATE USERS SET PASS = '" + userc.Pass + "' WHERE NICK = '" + userc.Nick + "'" , c);
                com.ExecuteNonQuery();
                changed = true;
            }
            catch (Exception ex) { }
            finally
            {
                c.Close();
            }
            return changed;
        }

        public bool updateUserCad(User_Class userc)
        {
            bool updated = false;
            SqlConnection c = new SqlConnection(db);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("UPDATE USERS SET NAME = '" + userc.Name +"' , SURNAME = '" + userc.Surname + "', EMAIL =  '" + userc.Email + "', NICK = '" + userc.Nick +
                    "', PASS = '" + userc.Pass + "', GENDER = '" + userc.Gender + "', BIRTH_DATE = '" + userc.Birth_date + "', IMAGE_URL = '" + userc.Image_url + "' WHERE NICK = '" + userc.Nick + "'", c);
                com.ExecuteNonQuery();
                updated = true;
            }
            catch (Exception ex) { }
            finally
            {
                c.Close();
            }
            return updated;
        }

        public User_Class getUserCAD(string nick)
        {
            User_Class userc = new User_Class();
            SqlConnection c = new SqlConnection(db);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM USERS WHERE NICK = '" + nick + "'", c);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    userc.Id = int.Parse(dr["ID"].ToString());
                    userc.Nick = dr["NICK"].ToString();
                    userc.Email = dr["EMAIL"].ToString();
                    userc.Name = dr["NAME"].ToString();
                    userc.Surname = dr["SURNAME"].ToString();
                    userc.Pass = dr["PASS"].ToString();
                    userc.Gender = char.Parse(dr["GENDER"].ToString());
                    userc.Entry_date = dr["ENTRY_DATE"].ToString();
                    userc.Birth_date = dr["BIRTH_DATE"].ToString();
                    userc.Image_url = dr["IMAGE_URL"].ToString();
                    dr.Close();
                }
            }
            catch (Exception ex) { }
            finally
            {
                c.Close();
            }
            return userc;
        }

        public User_Class getUserCAD(int id)
        {
            User_Class userc = new User_Class();
            SqlConnection c = new SqlConnection(db);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM USERS WHERE ID = " + id, c);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    userc.Id = int.Parse(dr["ID"].ToString());
                    userc.Nick = dr["NICK"].ToString();
                    userc.Email = dr["EMAIL"].ToString();
                    userc.Name = dr["NAME"].ToString();
                    userc.Surname = dr["SURNAME"].ToString();
                    userc.Pass = dr["PASS"].ToString();
                    userc.Gender = char.Parse(dr["GENDER"].ToString());
                    userc.Entry_date = dr["ENTRY_DATE"].ToString();
                    userc.Birth_date = dr["BIRTH_DATE"].ToString();
                    userc.Image_url = dr["IMAGE_URL"].ToString();
                    dr.Close();
                }
            }
            catch (Exception ex) { }
            finally
            {
                c.Close();
            }
            return userc;
        }

        public bool Existe_UsuarioCAD(string nick)
        {
            bool found = false;
            SqlConnection c = new SqlConnection(db);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("SELECT NICK FROM USERS WHERE NICK = '" + nick + "'", c);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    found = true;
                }
            }
            catch (Exception ex) { }
            finally
            {
                c.Close();
            }
            return found;
        }

        public List<User_Class> getFriendsCAD(int id)
        {
            List<User_Class> fr = new List<User_Class>();
            SqlConnection c = new SqlConnection(db);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM US_REL WHERE UID1 = " + id, c);
                SqlDataReader dr = com.ExecuteReader();

                while(dr.Read()) {
                    fr.Add(getUserCAD(int.Parse(dr["UID2"].ToString())));
                }
            }
            catch (Exception ex) { }
            finally
            {
                c.Close();
            }
            return fr;
        }

        public List<User_Class> getAllUserCAD(int id)
        {
            List<User_Class> fr = new List<User_Class>();
            SqlConnection c = new SqlConnection(db);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM USERS WHERE ID != " + id, c);
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    fr.Add(getUserCAD(int.Parse(dr["ID"].ToString())));
                }
            }
            catch (Exception ex) { }
            finally
            {
                c.Close();
            }
            return fr;
        }

        public bool isFriendCAD(int id1, int id2)
        {
            bool friend = false;
            SqlConnection c = new SqlConnection(db);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM US_REL WHERE UID1 = " + id2 + " and UID2 = " + id1, c);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    friend = true;
                }
            }
            catch (Exception ex) { }
            finally
            {
                c.Close();
            }
            return friend;
        }
    }
}
