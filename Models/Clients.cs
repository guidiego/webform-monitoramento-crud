namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clients
    {
        public int Id { get; set; }

        [Required]
        [StringLength(90)]
        public string Name { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public int Cams { get; set; }

        public double Price { get; set; }

        public int Discount { get; set; }

        public bool Fidelity { get; set; }

        public static Clients New(string name, string desc, int cams, float price, bool fidl) {
            var c = new Clients();
            c.Name = name;
            c.Description = desc;
            c.Fidelity = fidl;
            c.Price = price;
            c.Cams = cams;
            c.Discount = Clients.getDiscount(cams, fidl);

            return c;
        }

        public static int getDiscount(int cams, bool fidelity) {
            int discount = 0;

            if (cams > 0 && cams <= 2) {
                discount = 5;
            } else if (cams > 2 && cams <= 4) {
                discount = 10;
            } else if (cams > 4) {
                discount = 15;
            }

            if (fidelity) {
                discount = discount * 2;
            }

            return discount;
        }
    }
}
