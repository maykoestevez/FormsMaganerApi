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
    public class DynamicFormController : ControllerBase
    {
        private readonly DynamicFormDbContext _context;
        public DynamicFormController(DynamicFormDbContext context)
        {
            _context = context;
        }

        // GET api/formcontrols
        [HttpGet("")]
        public ActionResult<IEnumerable<DynamicForm>> Get()
        {
            var dynamicForm = _context.DynamicForm.Include(x => x.FormControls).ThenInclude(x => x.Options).ToList();
            return dynamicForm;
        }

        // GET api/formcontrol/5
        [HttpGet("{id}")]
        public ActionResult<DynamicForm> Get(int id)
        {
            var dynamicForm = _context.DynamicForm
                                       .Include(x => x.FormControls)
                                       .ThenInclude(x => x.Options)
                                       .FirstOrDefault(x => x.Id == id);

            return dynamicForm;
        }

        // POST api/formcontrol
        [HttpPost("")]
        public async Task Post([FromBody] DynamicForm dynamicForm)
        {
            _context.DynamicForm.Add(dynamicForm);
            await _context.SaveChangesAsync();
        }

        // PUT api/formcontrol/5
        [HttpPut("{id}")]
        public async Task Put([FromBody] DynamicForm dynamicForm)
        {
            _context.DynamicForm.Update(dynamicForm);
            await _context.SaveChangesAsync();
        }

        // DELETE api/formcontrol/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var dynamicFromToDelete = _context.DynamicForm.Find(id);

            _context.DynamicForm.Remove(dynamicFromToDelete);
            await _context.SaveChangesAsync();
        }
    }
}