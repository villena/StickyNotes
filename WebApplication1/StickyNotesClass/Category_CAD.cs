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

        public List<Category_Class> Categories(string name)
        {
            List<Category_Class> list = new List<Category_Class>();
            SqlConnection c = new SqlConnection(conection);
            try
            {
                c.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM CATEGORY WHERE NOMBRE = " + name, c);
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
    }
}