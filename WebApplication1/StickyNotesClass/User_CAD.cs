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
        private string db;

        public User_CAD(string dbf)
        {

        }

        public bool addFriendCad(string nick)
        {
            return false;
        }

        public bool deleteFriendCad(string nick)
        {
            return false;
        }

        public bool addUserCad(User_Class userc)
        {
            return false;
        }

        public bool deleteUserCad(User_Class userc)
        {
            return false;
        }

        public bool changePassCad(User_Class userc)
        {
            return false;
        }

        public bool updateUserCad(User_Class userc)
        {
            return false;
        }

        public void showDataUserCad(User_Class userc)
        {

        }

        public User_Class getUser(int id)
        {
            return userc;
        }

        

    }
}
