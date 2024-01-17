using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project2.Models;
using Project2.Services;
using System;

namespace Project2.Controllers


{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamsController : ControllerBase
    {
        private readonly ExamService examService;
        

        public ExamsController(ExamService examService)
        {
            this.examService = examService;
            
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var exams = examService.GetAllExams();
                return Ok(exams);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
            
        }


        [HttpGet("{Title}")]
        public IActionResult GetByTitle(string Title)
        {
            try
            {
                var exam = examService.GetExamByTitle(Title);
                if (exam == null)
                    return NotFound("There is no exam with such Title");

                return Ok(exam);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateExam([FromBody] ExamDto examDto, string Title)
        {
            try
            {
                if (examService.CheckExam == null)
                {
                    return NotFound();
                }

                examService.AddExam(examDto, Title);
                return Ok("Exam created");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{Title}")]
        public IActionResult Update(string Title, [FromBody] ExamDto examDto)
        {
            try
            {
                examService.UpdateExam(Title, examDto);
                return Ok("Exam updated");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{Title}")]
        public IActionResult Delete(string Title)
        {
            try
            {
                examService.DeleteExam(Title);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
    }
}