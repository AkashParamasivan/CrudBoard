using CrudBoard.Models;
using CrudBoard.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonInfoesController : ControllerBase
    {
        private readonly ICrudRepo _context;

       

        /*public ProductsController()
        { }*/
        public PersonInfoesController(ICrudRepo context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<PersonInfo> GetPerson()
        {
         
            return _context.GetPerson();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var temppro = _context.GetById(id);


            if (temppro == null)
            {
               
                return NotFound();
            }
            
            return Ok(temppro);
        }


        [HttpPost("PostPerson")]

        public async Task<IActionResult> PostPerson(PersonInfo per)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var value = await _context.PostProduct(per);

          
            return Ok(value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, PersonInfo per)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var editedProduct = await _context.PutPerson(id, per);

          
            return Ok(editedProduct);
        }

        [HttpDelete("DeletePerson")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var deletedPerson = await _context.DeletePerson(id);
          
            return Ok(deletedPerson);
        }
    }
}
