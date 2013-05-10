using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StickyNotesClass
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
            return false;
        }

        public Category_Class obtainCategoria(int id)
        {
            return categoria;
        }
    }
}