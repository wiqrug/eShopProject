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
        [HttpGet("all")]
        public IActionResult GetQuestions()
        {
            var response = questionsServices.getAllQuestions();
            return Ok(response);
        }

        [Authorize(Roles = "Admin, Candidate")]
        [HttpGet("{id}")]
        public IActionResult GetQuestion(Guid id)
        {
            var response = questionsServices.getQuestion(id);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult UpdateQuestions(Guid id, QuestionsDto question)
        {
            if(id == null)
            {
                return BadRequest("No question with this id");
            }

            if(question == null)
            {
                return BadRequest("Provide inputs");
            }

            questionsServices.updateQuestion(id, question);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateQuestion(QuestionsDto question, string Title)
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
            questionsServices.createQuestion(question,ExamId);

            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(Guid id)
        {
            if (id == null)
            {
                return BadRequest("What do you want me to delete?");
            }
                questionsServices.deleteQuestion(id);
    
            return Ok();
        }

        [Authorize(Roles ="Admin,Candidate")]
        [HttpGet("Exam/{Title}")]
        public IActionResult GetQuestionsByTitle(string Title)
        {
            
            
               var response= questionsServices.getQuestionsByTitle(Title);
                return Ok(response);
           
            
        }

    }
}
