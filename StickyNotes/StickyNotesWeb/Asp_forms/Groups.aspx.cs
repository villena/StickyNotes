using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StickyNotesClass;


namespace StickyNotesWeb
{
    public partial class Groups : System.Web.UI.Page
    {

       

        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            if (userCookie == null)
            {
                Response.Redirect("../Account/Login.aspx");
            }
            else
            {
                Party_Class party = new Party_Class();
                List<Party_Class> partyList = new List<Party_Class>();

                User_Class myUser = new User_Class();
                myUser = myUser.getUser(userCookie.Value);
                

                partyList = party.userGroups(myUser.Id);
             
                
                HyperLink link = new HyperLink();
                Panel p = new Panel();

                int i = partyList.Count() - 1;

                while(i>=0)
                {
                    string id = partyList[i].Id.ToString();
                    link = new HyperLink();
                    link.CssClass = "button white";
                    link.Width=300;
                    link.Height = 30;
                    
                    p = new Panel();
                    link.ID = "link" + id;
                    p.ID = "panel" + id;




                    link.Text = partyList[i].Name;
                    link.NavigateUrl = "~/Asp_forms/Groups_Notes.aspx?ID=" + id;
                    
                    p.Controls.Add(link);
                    Panel2.Controls.Add(p);
                    i--;

                }
            }
        }


        protected void Create(object sender, EventArgs e)
        {
           Response.Redirect("../Asp_forms/Create_Group.aspx");
        }


        
    }
}