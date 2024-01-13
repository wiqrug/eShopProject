﻿using System;
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

        [ServiceFilter(typeof(AuthenticationFilterBoth))]
        [HttpGet]
        public IActionResult GetQuestions()
        {
            var response = questionsServices.getAllQuestions();
            return Ok(response);
        }

        [ServiceFilter(typeof(AuthenticationFilterBoth))]
        [HttpGet("{id}")]
        public IActionResult GetQuestion(Guid id)
        {
            if (id == null)
            {
                return NotFound("No question with this id");
            }

            var response = questionsServices.getQuestion(id);
            return Ok(response);
        }

        [ServiceFilter(typeof(AuthenticationFilterAdmin))]
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

        [ServiceFilter(typeof(AuthenticationFilterAdmin))]
        [HttpPost]
        public IActionResult CreateQuestion(QuestionsDto question)
        {
          if (question == null)
          {
              return BadRequest("Missing values");
          }

            questionsServices.createQuestion(question);

            return Ok();
        }

        [ServiceFilter(typeof(AuthenticationFilterAdmin))]
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
    }
}