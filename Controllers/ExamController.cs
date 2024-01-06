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
        private readonly ExamService _examService;

        public ExamsController(ExamService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var exams = _examService.GetAllExams();
            return Ok(exams);
        }

        [HttpGet("{Title}")]
        public IActionResult GetById(Guid id)
        {
            var exam = _examService.GetExamById(id);
            if (exam == null)
                return NotFound();

            return Ok(exam);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ExamDto examDto)
        {
            _examService.AddExam(examDto);
            return Ok();
        }

        [HttpPut("{Title}")]
        public IActionResult Update(Guid id, [FromBody] ExamDto examDto)
        {
            _examService.UpdateExam(id, examDto);
            return Ok();
        }

        [HttpDelete("{Title}")]
        public IActionResult Delete(Guid id)
        {
            _examService.DeleteExam(id);
            return Ok();
        }
    }
}
