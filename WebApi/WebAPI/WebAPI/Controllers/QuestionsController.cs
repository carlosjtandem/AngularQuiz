using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Context;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly AppDbContext context;
        public QuestionsController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<QuestionsController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.question.ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message); ;
            }
        }

        // GET api/<QuestionsController>/5
        [HttpGet("{id}",Name ="GetQestion")]
        public ActionResult Get(int id)
        {
            try
            {
                var question = context.question.FirstOrDefault(q => q.QnID == id);
                return Ok(question);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message); ;
            }
        }

        // POST api/<QuestionsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<QuestionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<QuestionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
