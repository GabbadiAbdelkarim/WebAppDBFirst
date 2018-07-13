using System;
using System.Collections.Generic;

namespace WebAppDBFirst.Models.DB
{
    public partial class CarteIdentite
    {
        public CarteIdentite()
        {
            Citoyen = new HashSet<Citoyen>();
        }

        public int Id { get; set; }
        public int IdTypeCarte { get; set; }
        public string Code { get; set; }

        public TypeCarte IdTypeCarteNavigation { get; set; }
        public ICollection<Citoyen> Citoyen { get; set; }
    }
}
