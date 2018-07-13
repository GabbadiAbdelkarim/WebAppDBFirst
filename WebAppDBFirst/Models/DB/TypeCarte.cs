using System;
using System.Collections.Generic;

namespace WebAppDBFirst.Models.DB
{
    public partial class TypeCarte
    {
        public TypeCarte()
        {
            CarteIdentite = new HashSet<CarteIdentite>();
        }

        public int Id { get; set; }
        public string Libelle { get; set; }

        public ICollection<CarteIdentite> CarteIdentite { get; set; }
    }
}
