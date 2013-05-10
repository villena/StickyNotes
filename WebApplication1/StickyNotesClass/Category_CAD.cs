using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SickyNotesClass
{
    public class Category_CAD
    {
        private Category_Class categoria;

        private string database;

        public Category_CAD(string db)
        {
            database = db;
        }

        public bool addCategoria(Category_Class categoria)
        {
            //String connection = "Base de datos";
            //SqlConnection con = new SqlConnection(connection);
            //string sql = "INSERT INTO CATEGORIES VALUES "()";
            //SqlCommand cmd = new SqlCommand(sql,con);

            return false;
        }

        public Category_Class obtainCategoria(int id)
        {

        }
    }
}