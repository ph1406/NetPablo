using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPablo.Dto
{
    public class ProductoDTOResponse
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Alt_Name { get; set; }
        public double Price { get; set; }
    }
}
