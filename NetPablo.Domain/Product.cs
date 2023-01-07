namespace NetPablo.Domain
{
    public class Product : DomainBase
    {
        public string Name { get; set; } = default!;
        public string AlternativeName { get; set; } 
        public double Price { get; set; }
        


    }
}
