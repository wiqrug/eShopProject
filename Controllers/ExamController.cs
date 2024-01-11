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
            var exams = examService.GetAllExams();
            return Ok(exams);
        }

        [HttpGet("{Title}")]
        public IActionResult GetByTitle(string Title)
        {
            var exam = examService.GetExamByTitle(Title);
            if (exam == null)
                return NotFound();

            return Ok(exam);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ExamDto examDto, string Title)
        {
            examService.AddExam(examDto, Title);
            return Ok();
        }

        [HttpPut("{Title}")]
        public IActionResult Update(string Title, [FromBody] ExamDto examDto)
        {
            examService.UpdateExam(Title, examDto);
            return Ok();
        }

        [HttpDelete("{Title}")]
        public IActionResult Delete(string Title)
        {
            examService.DeleteExam(Title);
            return Ok();
        }
    }
}