using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly AppDbContext context;
        public ParticipantController(AppDbContext context)
        {
            this.context = context;
        }
        // GET: ParticipantController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ParticipantController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ParticipantController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ParticipantController/Create
        [HttpPost]
        [Route("api/InsertParticipant")]

        public Participant Create([FromBody] Participant participant)
        {
            //try
            //{
            context.participant.Add(participant);
            context.SaveChanges();
            return participant;
            //return CreatedAtRoute("GetParticipant", new { id = participant.ParticipantID }, participant);
            //}
            //catch (Exception ex)
            //{

            //    return BadRequest(ex.Message); ;
            //}
        }


        [HttpPut]
        public ActionResult Put(int id, [FromBody] Participant participant)
        {
            try
            {
                if (participant.ParticipantID == id)
                {
                    context.Entry(participant).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetParticipant", new { id = participant.ParticipantID }, participant);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message); ;
            }
        }
    }
}
