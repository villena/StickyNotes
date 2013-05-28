using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StickyNotesClass
{
    public class Category_Class
    {

        private List<Note_Class> notes;
        private string nombre;
        private int id;

        public List<Note_Class> Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Category_Class()
        {
            nombre = "";
            id = -1;
        }

        public void addCategoria(String name)
        {
            Category_CAD item = new Category_CAD();

            item.addCategoria(this);
        }

        public Category_Class getCategoria(int id)
        {
            Category_CAD item = new Category_CAD();
            return item.obtainCategoria(id);
        }

        public List<Category_Class> Categories()
        {
            Category_CAD category = new Category_CAD();
            List<Category_Class> lista = new List<Category_Class>();
            lista = category.Categories();

            return lista;
        }

        public List<Category_Class> Categories(string name)
        {
            Category_CAD category = new Category_CAD();
            List<Category_Class> lista = new List<Category_Class>();
            lista = category.Categories(name);

            return lista;
        }
        public override string ToString()
        {
            string str;
            str = nombre;
            return str;
        }


    }
}
