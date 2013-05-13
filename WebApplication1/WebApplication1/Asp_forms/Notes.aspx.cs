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
        protected void Page_Load(object sender, EventArgs e)
        {
            /* Falta implementar las notas del usuario */
        }

        protected void Create_Note(object sender, EventArgs e)
        {
            /* Create note with the button 'New Note' */
            Note_Class note = new Note_Class();
            note.Text = DescripcionNota.Text;
            note.Date = DateTime.Now.ToLongDateString();

            /* Label that contains the note info */
            Label l = new Label();
            l.Text = note.Text;
            l.CssClass = "postit";
            placeholder.Controls.Add(l);

            /* Add note in the Database */
            note.addNote(note.Text);
        }

    }
}
