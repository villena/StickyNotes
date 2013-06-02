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
        public Party_Class()
        {
            id = -1;
            name = "";
            Users = new List<User_Class>();
            Notes = new List<Note_Class>();
        }

        //Destructor
     

        //Añadir usuario
        public void addUser(User_Class myUser, int id)
        {
            users.Add(myUser);
            this.update();
        }

        public bool addNote(Note_Class note, int author_id)
        {
            Party_CAD cad = new Party_CAD();
            return cad.addNote(note, this.Id, author_id);
        }

        public void getName()
        {
            Party_CAD cad=new Party_CAD();
            name = cad.getName(id);
            
        }


        public void obtainNotes()
        {
            Party_CAD cad = new Party_CAD();
            this.Notes = new List<Note_Class>();

            this.notes = cad.obtainNotes(this.Id);
        }


        public void update()
        {
            Party_CAD item = new Party_CAD();

            item.update(this);

        }

        //Crear grupo
        public bool createParty()
        {
            Party_CAD item = new Party_CAD();
            return item.createParty(this);
        }

        public bool deleteParty()
        {
            Party_CAD item = new Party_CAD();
            return item.deleteParty(this);
        }

        //Obtener los grupos 
        public List<Party_Class> userGroups(int id)
        {
            Party_CAD partyCad = new Party_CAD();

            return partyCad.userGroups(id);
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
    

