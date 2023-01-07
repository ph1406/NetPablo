using Microsoft.AspNetCore.Mvc;
using NetPablo.DataAccess;
using NetPablo.Domain;
using NetPablo.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetPablo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly WebDBContext _context;

        public CartController (WebDBContext context)
        {
            this._context = context;
        }


        // GET: api/<CartController>
        [HttpGet]
        public IEnumerable<CartDTOResponse> Get()
        {
            var cartRes = _context.Set<Cart>().Select(x=> new CartDTOResponse{ 
                idLine=x.lineId, priceCalculated=x.priceCalculated, quantity=x.quantity,
                product = _context.Set<Product>().Where(q => q.Id == x.idProduct).Select(q=>new ProductoDTOResponse { id=q.Id, Name=q.Name, Alt_Name=q.AlternativeName, Price=q.Price }).First()                
            });

            return cartRes;
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            var cartRes = _context.Set<Cart>().Where(x=>x.lineId==id).Select(x => new CartDTOResponse
            {
                idLine = x.lineId,
                priceCalculated = x.priceCalculated,
                quantity = x.quantity,
                product = _context.Set<Product>().Where(q=>q.Id==x.idProduct).Select(q => new ProductoDTOResponse { id = q.Id, Name = q.Name, Alt_Name = q.AlternativeName, Price = q.Price }).First()
            }).FirstOrDefault();


            if (cartRes==null)
            {
                return NotFound(new { Id = id, Message = "No se encontro linea" });
            }

            return Ok(cartRes);
        }

        // POST api/<CartController>
        [HttpPost]
        public ActionResult Post([FromBody] CartDTO cart)
        {

            Product p = _context.Set<Product>().Where(q => q.Id == cart.idProduct).FirstOrDefault();

            if (p==null)
            {
                return NotFound(new { Id=cart.idProduct,  Message = "Producto indicado no existe" });
            }


            Cart c = new Cart();
            c.idProduct=cart.idProduct;
            c.quantity=cart.quantity;
            c.idUser=cart.idUser;
            c.dateCreated = DateTime.Now;
            c.priceCalculated = (p.Price * c.quantity);

            _context.Set<Cart>().Add(c);
            _context.SaveChanges();
            return Ok(new { Id=c.lineId });
        }

        // PUT api/<CartController>/5
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] CartDTO cart)
        {
            Cart c = _context.Set<Cart>().Where(x=>x.lineId==id).FirstOrDefault();

            if (c == null)
            {
                return NotFound(new { Id = id, Message = "Detalle de carro no existe" });
            }

            Product p = _context.Set<Product>().Where(q => q.Id == cart.idProduct).FirstOrDefault();

            if (p==null) 
            {
                return NotFound(new { Id = cart.idProduct, Message = "Producto indicado no existe" });
            }

            c.idProduct = cart.idProduct;
            c.quantity=cart.quantity;
            c.priceCalculated= (p.Price * c.quantity);



            //_context.Set<Cart>().Add(c);

            _context.SaveChanges();

            return Ok(new { Id = id });
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            Cart c = _context.Set<Cart>().Where(x => x.lineId == id).FirstOrDefault();

            if (c == null)
            {
                return NotFound(new { Id = id, Message = "Detalle de carro no existe" });
            }


            _context.Set<Cart>().Remove(c);
            _context.SaveChanges();

            return Ok();

        }
    }
}
