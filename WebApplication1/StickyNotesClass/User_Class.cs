using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SickyNotesClass
{
    public class User_Class
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nick;
        public string Nick
        {
            get { return nick; }
            set { nick = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string pass;
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        private char gender;
        public char Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        private string entry_date;
        public string Entry_date
        {
            get { return entry_date; }
            set { entry_date = value; }
        }

        private string birth_date;
        public string Birth_date
        {
            get { return birth_date; }
            set { birth_date = value; }
        }

        private string image_url;
        public string Image_url
        {
            get { return image_url; }
            set { image_url = value; }
        }

        private List<Note_Class> notes;
        public List<Note_Class> Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        private List<Party_Class>parties;
        public List<Party_Class> Parties
        {
            get { return parties; }
            set { parties = value; }
        }

        private List<User_Class> friends;
        public List<User_Class> Friends
        {
            get { return friends; }
            set { friends = value; }
        }

        private List<Events_Class> events;
        public List<Events_Class> Events
        {
            get{return events;}
            set{events=value;}
        }
            

        //Constructor
        public User_Class()
        {
            id = -1;
            nick = "";
            email = "";
            name = "";
            pass = "";
            gender = ' ';
            entry_date = "";
            birth_date = "";
            image_url = "";
        }

        //Add new friend
        public bool addFriend(string nick)
        {
            User_CAD u = new User_CAD("../../hada_database/Database");
            if (u.addFriendCad(nick))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete friend
        public bool deleteFriend(string nick)
        {
            User_CAD u = new User_CAD("../../hada_database/Database");
            if (u.deleteFriendCad(nick))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Add user
        public bool addUser()
        {
            User_CAD u = new User_CAD("../../hada_database/Database");
            if (u.addUserCad(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete user
        public bool deleteUser()
        {
            User_CAD u = new User_CAD("../../hada_database/Database");
            if (u.deleteUserCad(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User_Class getUser(int id)
        {
            User_CAD u = new User_CAD("../../hada_database/Database");
            return u.getUser(id);
        }
        //Recovery pass
        public string recoverPass()
        {
           return this.Pass;
        }
        //Change the pass
        public bool changePass(string new_pass)
        {
            User_CAD u = new User_CAD("../../hada_database/Database");
            if (u.changePassCad(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Update user
        public bool updateUser()
        {
            User_CAD u = new User_CAD("../../hada_database/Database");
            if (u.updateUserCad(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void salirGrupo(int id)
        {
            foreach (Party_Class pc in parties)
            {
                if (pc.Id == id)
                {
                    parties.Remove(pc);
                }
            }

            this.updateUser();
        }

        public void unirEvento(Events_Class ec)
        {
            events.Add(ec);
            this.updateUser();
        }

        public void dejarEvento(int id)
        {
            foreach (Events_Class ec in events)
            {
                if (ec.Id == id)
                {
                    events.Remove(ec);
                }
            }

            this.updateUser();
        }

        //Show all the data
        public override string ToString()
        {
            string str;
            str = nick + "\n" + email + "\n" + name + "\n" + gender + "\n" + entry_date + "\n" + birth_date + "\n" + image_url;
            return str;
        }
    }
}
