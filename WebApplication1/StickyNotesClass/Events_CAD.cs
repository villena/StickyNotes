using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StickyNotesClass
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

        }

        public void updateEvent(Events_Class item)
        {

        }

        public void deleteEvent(Events_Class item)
        {

        }

        public Events_Class obtainEvent(int id)
        {
            return myEvent;
        }
    }
}
