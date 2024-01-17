using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin, Candidate")]
        [HttpGet]
        public IActionResult GetQuestions()
        {
            try
            {
                var response = questionsServices.getAllQuestions();
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [Authorize(Roles = "Admin, Candidate")]
        [HttpGet("{id}")]
        public IActionResult GetQuestion(Guid id)
        {
            try
            {
                var response = questionsServices.getQuestion(id);
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateQuestions(Guid id, QuestionsDto question)
        {
            try
            {
                if (id == null)
                {
                    return NotFound("No question with this id");
                }

                if (question == null)
                {
                    return BadRequest("Provide inputs");
                }

                questionsServices.updateQuestion(id, question);
                return Ok("Questions updated");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateQuestion(QuestionsDto question, string Title)
        {
            try
            {
                if (question == null)
                {
                    return BadRequest("Missing values");
                }



                if (questionsServices.CheckExamId == null)
                {
                    return BadRequest("Invalid Exam Title");
                }
                Guid ExamId = questionsServices.CheckExamId(Title);
                questionsServices.createQuestion(question, ExamId);

                return Ok("Question created");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(Guid id)
        {
            try
            {
                if (id == null)
                {
                    return BadRequest("No value for Id");
                }
                questionsServices.deleteQuestion(id);

                return Ok("Question deleted");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [Authorize(Roles ="Admin,Candidate")]
        [HttpGet("Exam/{Title}")]
        public IActionResult GetQuestionsByTitle(string Title)
        {
            try
            {
                var response = questionsServices.getQuestionsByTitle(Title);
                if(response == null)
                {
                   return BadRequest("No questions matching the exam Title");
                }
                return Ok(response);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
                       
        }

    }
}
