using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ef_test2.Models
{
    public class Owner
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public List<Pet> Pets { get; set; }
    }
}
