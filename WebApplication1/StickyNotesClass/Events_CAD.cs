using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SickyNotesClass
{
    public class Events_CAD
    {
        private Events_Class myEvent;
        private string database;

        public Events_CAD(string db)
        {
            database=db;
        }


        public void addEvent(Events_Class item)
        {
            //String connection = "Base de datos";
            //SqlConnection con = new SqlConnection(connection);
            //string sql = "INSERT INTO EVENTS VALUES "()";
            //SqlCommand cmd = new SqlCommand(sql,con);
        }

        public void updateEvent(Events_Class item)
        {
            //LO MISMO QUE EN LAS DEMAS;
        }

        public void deleteEvent(Events_Class item)
        {
            //String connection = "Base de datos";
            //SqlConnection con = new SqlConnection(connection);
            //string sql = "DELETE FROM EVENTS WHERE id = item.id;
            //SqlCommand cmd = new SqlCommand(sql,con);
        }

        public Events_Class obtainEvent(int id)
        {

        }
    }
}
