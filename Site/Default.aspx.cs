using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Models;

public partial class _Default : Page
{
    protected List<Clients> Items;

    protected void Page_Load(object sender, EventArgs e) {
        using (var db = new Context()) {
            this.Items = db.Clients.ToList();
        }
    }

    protected void removeClient(object sender, EventArgs e) {
        var Id = int.Parse(Request.Form["__EVENTARGUMENT"]);
        using (var db = new Context()) {
            var client = db.Clients.Find(Id);
            db.Entry(client).State = EntityState.Deleted;
            db.SaveChanges();
            Response.Redirect("/");
        }
    }
}