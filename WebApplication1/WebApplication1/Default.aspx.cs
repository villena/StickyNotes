using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel p = new Panel();

            Label t = new Label();
            Label f = new Label();
            
            Note_CAD notaTemp = new Note_CAD();
            List<Note_Class> notes = new List<Note_Class>();

            notes = notaTemp.notesOpen();

            int i = notes.Count() - 1;
            int j = i-12;

            while (i >= 0 && i > j)
            {
                p = new Panel();

                t = new Label();
                f = new Label();

                p = new Panel();

                string id = notes[i].Id.ToString();

                p.ID = "p" + id;
                p.CssClass = "postitnotes";
                t.ID = "t" + id;

                t.Text = notes[i].Text.ToString() + "<BR>";

                p.Controls.Add(t);
                p.Controls.Add(f);

                Panel1.Controls.Add(p);

                i--;

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
