using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project2.Models;
using Project2.Services;

namespace Project2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        public QuestionsServices questionsServices;

        public QuestionsController(QuestionsServices questionsServices)
        {
            this.questionsServices = questionsServices;
        }

        // GET: api/Questions
        [HttpGet]
        public IActionResult GetQuestions()
        {
            questionsServices.getAllQuestions();
            return Ok();
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public IActionResult GetQuestion(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = questionsServices.getQuestion(id);
            return Ok(response);
        }

        // PUT: api/Questions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult UpdateQuestions(Guid id, Questions questions)
        {
            if (id != questions.QuestionId)
            {
                return BadRequest();
            }

            context.Entry(questions).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Questions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Questions>> PostQuestions(QuestionsDto questions)
        {
          if (context.Questions == null)
          {
              return Problem("Entity set 'ApplicationDBContext.Questions'  is null.");
          }

            

            return CreatedAtAction("GetQuestions", new { id = questions.QuestionId }, questions);
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestions(Guid id)
        {
            if (context.Questions == null)
            {
                return NotFound();
            }
            var questions = await context.Questions.FindAsync(id);
            if (questions == null)
            {
                return NotFound();
            }

            context.Questions.Remove(questions);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionsExists(Guid id)
        {
            return (context.Questions?.Any(e => e.QuestionId == id)).GetValueOrDefault();
        }
    }
}
