using System;
using System.Collections.Generic;

namespace WebAppDBFirst.Models.DB
{
    public partial class Ville
    {
        public int Id { get; set; }
        public int IdPays { get; set; }
        public string Ville1 { get; set; }

        public Pays IdPaysNavigation { get; set; }
    }
}
