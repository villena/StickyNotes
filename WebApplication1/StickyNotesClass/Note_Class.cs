﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SickyNotesClass
{
    public class Note_Class
    {
        private int id;
        private char type;
        private int category;
        private string text;
        private int date;

        //Constructor
        public Note_Class()
        {
            id = -1;
            type = ' ';
            category = -1;
            text = "";
            date = -1;
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

        //Add new note
        public bool addNote()
        {
            Note_CAD u = new Note_CAD("../../hada_database/Database");
            if (u.addNote(this)) 
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
            Note_CAD u = new Note_CAD("../../hada_database/Database");
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
        public bool modifyNote(string text)
        {
            Note_CAD u = new Note_CAD("../../hada_database/Database");
            if (u.modifyNote(text))
            {
                return true;
            }
            else
            {
                return false;
            }
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