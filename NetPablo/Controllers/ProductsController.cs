using Microsoft.AspNetCore.Mvc;
using NetPablo.DataAccess;
using NetPablo.Domain;
using NetPablo.Dto;
using NetPablo.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetPablo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly WebDBContext _context;

        public ProductsController(WebDBContext context) 
        {
            this._context= context;
        }


        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<ProductoDTOResponse> Get()
        {
            return _context.Set<Product>().Select(x=> new ProductoDTOResponse
            { 
                  id=x.Id,
                  Name=x.Name,
                  Alt_Name=x.AlternativeName,
                  Price=x.Price
            }).OrderBy(x=>x.id);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id:int}")]
        public ActionResult Get(int id)
        {
            var product = _context.Set<Product>().FirstOrDefault(p => p.Id == id);

            if (product==null) 
            {
                return NotFound(new { Id=id, Message="No se encontro" });
            }

            ProductoDTOResponse p = new ProductoDTOResponse() 
            {
                id= product.Id, Name=product.Name, Alt_Name=product.AlternativeName, Price=product.Price
            };

            return Ok(p);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductDTO product)
        {
            Product p = new Product();
            p.Id= _context.Set<Product>().Max(p=>p.Id)+1;
            p.Name=product.Name;
            p.AlternativeName=product.AlternativeName;
            p.Price = product.Price;
            p.CreationDate=DateTime.Now;
           

            _context.Set<Product>().AddAsync(p);
            _context.SaveChangesAsync();



            return Get(p.Id);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductDTO product)
        {
            var p = _context.Set<Product>().FirstOrDefault(x=>x.Id==id);

            if (p==null)
            {
                return NotFound(new { Id=id, Message="No encontrado" });
            }

            p.Name=product.Name;
            p.AlternativeName=product.AlternativeName;


            _context.SaveChangesAsync();

            return Ok(p);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var p = _context.Set<Product>().FirstOrDefault(x => x.Id == id);

            if (p == null)
            {
                return NotFound(new { Id = id, Message = "No encontrado" });
            }
            _context.Set<Product>().Remove(p);
            _context.SaveChangesAsync();

            return Ok(p);
        }
    }
}
