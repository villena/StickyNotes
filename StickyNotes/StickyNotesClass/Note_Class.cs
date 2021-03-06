﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StickyNotesClass
{
    public class Note_Class
    {
        private int id;
        private char type;
        private int category;
        private string text;
        private string date;
        private int author;

        //Constructor
        public Note_Class()
        {
            id = -1;
            type = ' ';
            category = -1;
            text = "";
            date = "dd/mm/yyyy";
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public char Type
        {
            get { return type; }
            set { type = value; }
        }

              
        public int Category
        {
            get { return category; }
            set { category = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public int Author
        {
            get { return author; }
            set { author = value; }
        }

        //Add new note
        public bool addNote(int id)
        {
            Note_CAD u = new Note_CAD();
            if (u.addNote(this,id)) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool addNote(int authorid, List<User_Class> users)
        {
            Note_CAD u = new Note_CAD();
            if (u.addNote(this, authorid, users))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete friend
        public bool deleteNote()
        {
            Note_CAD u = new Note_CAD();
            if (u.deleteNote(this))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Modify text
        public bool modifyNote(Note_Class notec)
        {
            Note_CAD u = new Note_CAD();
            if (u.modifyNote(notec))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Note_Class getNote(int id)
        {
            Note_CAD ncad = new Note_CAD();

            Note_Class note = ncad.getNote(id);

            return note;
        }

        public List<Note_Class> getNotesUser(int id)
        {
            Note_CAD cadNote = new Note_CAD();

            return cadNote.notesUser(id);
        }

        public List<Note_Class> getNotesUserOpen(int id)
        {
            Note_CAD cadNote = new Note_CAD();

            return cadNote.notesUserOpen(id);
        }

        public List<Note_Class> getNotesUserPrivate(int id)
        {
            Note_CAD cadNote = new Note_CAD();

            return cadNote.notesUserPrivate(id);
        }

        public List<Note_Class> getNotesOpen()
        {
            Note_CAD cadNote = new Note_CAD();

            return cadNote.notesOpen();
        }

        public List<Note_Class> getNotesGroup(int id_group)
        {
            Note_CAD cadNote = new Note_CAD();

            return cadNote.notesGroups(id_group);
        }
        //Show all the data
        public override string ToString()
        {
            string str;
            str = text + "\n" + type + "\n" + category + "\n";
            return str;
        }

    }
}
