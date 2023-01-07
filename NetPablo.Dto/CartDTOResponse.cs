using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetPablo.Dto
{
    public class CartDTOResponse
    {
        public int idLine { get; set; }
        public int quantity { get; set; }
        public double priceCalculated { get; set; }
        public ProductoDTOResponse product { get; set; }
        
    }
}
