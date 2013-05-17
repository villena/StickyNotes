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
            catch (Exception ex){}
            finally
            {
                con.Close();
            }

            return categoria;

        }
    }
}