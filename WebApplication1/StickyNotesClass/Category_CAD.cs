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
    public class Category_CAD
    {
        private Category_Class categoria;

        private string conection = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\Database.mdf;User Instance=true";

        public Category_CAD()
        {
        }

        public bool addCategoria(Category_Class categoria)
        {
            bool añadido;

            SqlConnection con = new SqlConnection(conection);

            try
            {
                con.Open();
                string sql = "INSERT INTO CATEGORIES (NAME) VALUES (" + categoria.Nombre + ")";
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

        public Category_Class obtainCategoria(int id)
        {
            Category_Class categoria = new Category_Class();

            SqlConnection con = new SqlConnection(conection);

            try
            {
                con.Open();
                string sql = "SELECT * FROM CATEGORY WHERE ID = " + id;
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    categoria.Id = id;
                    categoria.Nombre = reader["NAME"].ToString();
                }
            }
            catch (Exception ex) { }
            finally
            {
                con.Close();
            }

            return categoria;

        }

        public List<Category_Class> Categories()
        {
            List<Category_Class> list = new List<Category_Class>();
            SqlConnection c = new SqlConnection(conection);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM CATEGORY", c);
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    Category_Class category = new Category_Class();
                    category.Id = int.Parse(reader["ID"].ToString());
                    category.Nombre = reader["NAME"].ToString();
                    list.Add(category);
                }
            }
            catch (Exception ex) { }
            finally
            {
                c.Close();
            }
            return list;
        }

        public int getCategoryId(string category)
        {
            int id = 0;
            SqlConnection c = new SqlConnection(conection);
            try
            {
                
                SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) AS Expr1 FROM CATEGORY WHERE NAME LIKE '" + category + "'", c);
                cmd1.Connection.Open();
                SqlDataReader reader = cmd1.ExecuteReader();

                if (reader.Read())
                {
                    if (Int32.Parse(reader["Expr1"].ToString()) > 0)
                    {
                        cmd1.Connection.Close();
                        SqlCommand cmd2 = new SqlCommand("SELECT ID FROM CATEGORY WHERE (NAME LIKE '" + category + "')", c);
                        cmd2.Connection.Open();
                        SqlDataReader reader2 = cmd2.ExecuteReader();

                        if (reader2.Read())
                        {
                            id = Int32.Parse(reader2["ID"].ToString());

                        }

                        cmd2.Connection.Close();
                    }
                    else
                    {
                        cmd1.Connection.Close();
                        SqlCommand cmd3 = new SqlCommand("INSERT INTO CATEGORY (NAME) OUTPUT INSERTED.ID VALUES ('" + category + "')", c);
                        cmd3.Connection.Open();
                        SqlDataReader reader3 = cmd3.ExecuteReader();

                        if (reader3.Read())
                        {
                            id = Int32.Parse(reader3["ID"].ToString());
                        }
                        cmd3.Connection.Close();
                    }

                }
                else
                {
                    cmd1.Connection.Close();
                }

            }
            catch (Exception ex) { }
            finally
            {
                
            }

            return id;
            
        }


    }
}