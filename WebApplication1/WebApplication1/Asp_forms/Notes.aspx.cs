using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace WebApplication1
{
    public partial class Notes : System.Web.UI.Page
    {
        public int i;

        protected void increaseCounter()
        {
            i++;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            /* Falta implementar las notas del usuario */
        }

        protected void Create_Note(object sender, EventArgs e)
        {
            
            /* Create note with the button 'New Note' */
            Note_Class note = new Note_Class();
            note.Text = DescripcionNota.Text;
            note.Date = DateTime.Now.ToShortDateString();

            /* Label that contains the note info */
            if (note.Text != "")
            {
                Label l = new Label();
                l.Text = i.ToString();
                l.CssClass = "postit";
                l.ID = "label" + i;
                increaseCounter();

                placeholder.Controls.Add(l); 
                
            }

            /* Add note in the Database */
            note.addNote();
        }

    }
}
