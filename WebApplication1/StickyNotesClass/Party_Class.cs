using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StickyNotesClass
{
    public class Party_Class
    {
        private int id;
        private List<Note_Class> notes;
        private List<User_Class> users;
        private string name;

        public int Id
        {
            get{return id;}
            set{id = value;}
        }

        public List<Note_Class> Notes
        {
            get{return notes;}
            set{notes = value;}
        }

        public List<User_Class> Users
        {
            get{return users;}
            set{users = value;}
        }

        public string Name
        {
            get {return name;}
            set {name = value;}
        }
        
        //Constructor
        public Party_Class(int id)
        {
            id = -1;
            name = "";
        }

        //Destructor
     

        //Añadir usuario
        public void addUser(User_Class myUser, int id)
        {
            users.Add(myUser);
            this.update();
        }

        public void update()
        {
            Party_CAD item = new Party_CAD();

            item.update(this);

        }

        //Crear grupo
        public void createParty()
        {
            Party_CAD item = new Party_CAD();
            item.createParty(this);
        }

        public void deleteParty()
        {
            Party_CAD item = new Party_CAD();
            item.deleteParty(this);
        }

        public override string ToString()
        {
            string str="";

            str += name + "\nNotes:\n";
            
            foreach (Note_Class nc in notes)
            {
                str += nc.ToString()+ "\n";
            }

            str += "\nUsers:\n";

            foreach (User_Class uc in users)
            {
                str += uc.ToString() + "\n";
            }

            return str;
             
        }
      
    }
}
    

