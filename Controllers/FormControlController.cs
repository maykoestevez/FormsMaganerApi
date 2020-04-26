using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicFormApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DynamicFormApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormControlController : ControllerBase
    {
        private readonly DynamicFormDbContext _context;
        public FormControlController(DynamicFormDbContext context)
        {
            _context = context;
        }

        // GET api/formcontrols
        [HttpGet("")]
        public ActionResult<IEnumerable<DynamicFormControl>> Get()
        {
           

            var dynamicCoontrols = _context.DynamicForm.Include(x => x.Options).ToList();
            return dynamicCoontrols;
        }

        // GET api/formcontrol/5
        [HttpGet("{id}")]
        public ActionResult<string> GetstringById(int id)
        {
            return null;
        }

        // POST api/formcontrol
        [HttpPost("")]
        public void Poststring(string value)
        {
        }

        // PUT api/formcontrol/5
        [HttpPut("{id}")]
        public void Putstring(int id, string value)
        {
        }

        // DELETE api/formcontrol/5
        [HttpDelete("{id}")]
        public void DeletestringById(int id)
        {
        }
    }
}