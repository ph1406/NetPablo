namespace NetPablo.Domain
{
    public class DomainBase
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public DateTime CreationDate { get; set; }

        protected DomainBase() 
        {
            this.Status = true;
        }
    }
}
