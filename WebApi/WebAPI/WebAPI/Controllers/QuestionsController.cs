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
        //var question = context.question.FirstOrDefault(q => q.QnID == id);
        var Qns = context.question
            .Select(x => new { QnID = x.QnID, Qn = x.Qn, ImageName = x.ImageName, x.Option1, x.Option2, x.Option3, x.Option4 })
            .OrderBy(y => Guid.NewGuid())
            .Take(10)
            .ToArray();
        var updated = Qns.AsEnumerable()
            .Select(x => new
            {
              QnID = x.QnID,
              Qn = x.Qn,
              ImageName = x.ImageName,
              Options = new string[] { x.Option1, x.Option2, x.Option3, x.Option4 }
            }).ToList();
        return Ok(updated);
      }
      catch (Exception ex)
      {

        return BadRequest(ex.Message); ;
      }
    }

    //// GET api/<QuestionsController>/5
    //[HttpGet("{id}", Name = "GetQestion")]
    //public ActionResult Get(int id)
    //{
    //  try
    //  {
    //    //var question = context.question.FirstOrDefault(q => q.QnID == id);
    //    var Qns = context.question
    //        .Select(x => new { QnID = x.QnID, Qn = x.Qn, ImageName = x.ImageName, x.Option1, x.Option2, x.Option3, x.Option4 })
    //        .OrderBy(y => Guid.NewGuid())
    //        .Take(10)
    //        .ToArray();
    //    var updated = Qns.AsEnumerable()
    //        .Select(x => new
    //        {
    //          QnID = x.QnID,
    //          Qn = x.Qn,
    //          ImageName = x.ImageName,
    //          Options = new string[] { x.Option1, x.Option2, x.Option3, x.Option4 }
    //        }).ToList();
    //    return Ok(updated);
    //  }
    //  catch (Exception ex)
    //  {

    //    return BadRequest(ex.Message); ;
    //  }
    //}

    // POST api/<QuestionsController>
    [HttpPost]
    //[Route("api/Answers")]
    public void Post(int[] qIDs)
    {
      var result = context.question
                    .AsEnumerable()
                    .Where(y =>  qIDs.Contains(y.QnID))
                    .OrderBy(x => { return Array.IndexOf(qIDs, x.QnID); })
                    .Select(z => z.Answer)
                    .ToArray();
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
