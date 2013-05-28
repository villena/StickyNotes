using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StickyNotesClass
{
    public class Events_Class
    {
        private int id;
        private string date;
        private string description;
        private string location;
        private List<User_Class> users;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public List<User_Class> Users
        {
            get { return users; }
            set { users = value; }
        }

        //Constructor
        public Events_Class()
        {
            id = -1;
            date = "";
            description = "";
            location = "";
            users = new List<User_Class>();
        }

        public void addEvent()
        {
            Events_CAD item = new Events_CAD();
            item.addEvent(this);
        }

        public void updateEvent()
        {
            Events_CAD item = new Events_CAD();
            item.updateEvent(this);
        }

        public void deleteEvent()
        {
            Events_CAD item = new Events_CAD();
            item.deleteEvent(this);
        }

        public Events_Class getEvent(int myId)
        {
            Events_CAD item = new Events_CAD();
            return item.obtainEvent(myId);
        }

        public List<Events_Class> userEvents(int userID)
        {
            Events_CAD eventsCad = new Events_CAD();

            return eventsCad.userEvents(userID);
        }

        public void addUser(User_Class myUser)
        {
            Events_CAD eventsCad = new Events_CAD();

            bool correcto = eventsCad.addUser(myUser, Id);
        }

        public override string ToString()
        {
            string str;
            str = date.ToString() + "\n" + description + "\n" + location;
            return str;
        }
    }
}