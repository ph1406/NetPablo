using System.Dynamic;

namespace NetPablo.Domain
{
    public class Cart
    {
        public int lineId { get; set; }
        public string idUser { get; set; }
        public DateTime dateCreated { get; set; }
        public int idProduct { get; set; }
        public int quantity { get; set; }
        public double priceCalculated { get; set; }

    }
}
