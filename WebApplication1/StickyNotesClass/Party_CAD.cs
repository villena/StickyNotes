using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SickyNotesClass
{
    public class Party_CAD
    {
        private Party_Class myParty;
        private List<Note_Class> myNotes;
        private List<User_Class> myUsers;
        private string database;

        public Party_CAD(string db)
        {
            database = db;
        }

        public bool createParty(Party_Class party)
        {
            return false;
        }

        public bool addUser(User_Class user)
        {
            return false;
        }

        public Party_Class obtainData()
        {
            return myParty;
        }

        public List<Note_Class> obtainNotes()
        {
            return myNotes;
        }

        public List<User_Class> obtainUsers()
        {
            return myUsers;
        }

        public bool update(Party_Class myParty)
        {
            return false;
        }

        public bool deleteParty(Party_Class myParty)
        {
            return false;
        }
    }
}
