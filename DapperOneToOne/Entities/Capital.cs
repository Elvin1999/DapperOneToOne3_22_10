using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperOneToOne.Entities
{
    public class Capital
    {
        public int CapitalId { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
