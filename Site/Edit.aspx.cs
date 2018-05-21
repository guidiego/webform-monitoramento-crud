using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models;

public partial class Edit : Page {
    protected Clients client;
    protected void Page_Load(object sender, EventArgs e) {
        var id = Request["id"];

        if (id != "" && id != null) {
            var intId = Convert.ToInt32(id);
            using (var db = new Context()) {
                this.client = this.getClient(intId, db);

                if (!Page.IsPostBack) {
                    this.Name.Text = client.Name;
                    this.Description.Text = client.Description;
                    this.Cams.Text = client.Cams.ToString();
                    this.Price.Text = client.Price.ToString();
                    this.Fidelity.SelectedValue = client.Fidelity ? "true" : "false";
                }
                
            }
        }
    }

    protected Clients getClient(int id, Context db) {
        return (from c in db.Clients where c.Id == id select c).First();
    }
    protected void updateClient(object sender, EventArgs e) {
        var name = this.Name.Text;
        var desc = this.Description.Text;
        var fidelity = this.Fidelity.SelectedValue == "true" ? true : false;
        var cams = int.Parse(this.Cams.Text);
        var price = float.Parse(this.Price.Text);

        using (var db = new Context()) {
            if (this.client != null) {
                client = this.getClient(this.client.Id, db);
                client.Name = name;
                client.Description = desc;
                client.Cams = cams;
                client.Price = price;
                client.Fidelity = fidelity;
                client.Discount = Clients.getDiscount(cams, fidelity);
                db.Entry(client).State = EntityState.Modified;
            } else {
                client = Clients.New(name, desc, cams, price, fidelity);
                db.Entry(client).State = EntityState.Added;
            }
            
            db.SaveChanges();
            Response.Redirect("/");
        }

    }
}