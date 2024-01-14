﻿using Microsoft.AspNetCore.Authorization;
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
        private readonly ApplicationDBContext context;

        public ExamsController(ExamService examService, ApplicationDBContext context)
        {
            this.examService = examService;
            this.context = context;
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateExam([FromBody] ExamDto examDto, string Title)
        {
            Guid? CertificateId = context.Certificates
                                    .Where(e => e.Title == Title)
                                    .Select(e => e.CertificateId)
                                    .FirstOrDefault();

            if (CertificateId == null)
            {
                return BadRequest("Invalid Certificate Title");
            }

            examService.AddExam(examDto, Title);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{Title}")]
        public IActionResult Update(string Title, [FromBody] ExamDto examDto)
        {
            examService.UpdateExam(Title, examDto);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{Title}")]
        public IActionResult Delete(string Title)
        {
            examService.DeleteExam(Title);
            return Ok();
        }
    }
}