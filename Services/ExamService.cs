﻿using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project2.Services
{
    public class ExamService
    {
        private readonly ApplicationDBContext context;

        public ExamService(ApplicationDBContext context)
        {
            this.context = context;
        }

        public List<Exam> GetAllExams()
        {
            return context.Exams.ToList();
        }

        public Exam GetExamByTitle(string Title)
        {
            return context.Exams.FirstOrDefault(e => e.Title == Title);
        }

        public void AddExam(ExamDto examDto, string Title)
        {
            Guid certificateId = context.Certificates
                                    .Where(e => e.Title == Title)
                                    .Select(e => e.CertificateId)
                                    .FirstOrDefault();
            //must be a check if certificateId is null or not
            var exam = new Exam(certificateId)
            {
                Title = examDto.Title,
                Description = examDto.Description,
                Time = examDto.Time,
            };

            context.Exams.Add(exam);
            context.SaveChanges();
        }

        public void UpdateExam(string Title, ExamDto examDto)
        {
            var exam = context.Exams.FirstOrDefault(e => e.Title == Title);
            if (exam != null)
            {

                if (!string.IsNullOrWhiteSpace(examDto.Title))
                {
                    exam.Title = examDto.Title;
                }

                if (!string.IsNullOrWhiteSpace(examDto.Description))
                {
                    exam.Description = examDto.Description;
                }

                if (examDto.Time != null)
                {
                    exam.Time = examDto.Time;
                }
                context.SaveChanges();
            }
        }

        public void DeleteExam(string Title)
        {
            var exam = context.Exams.FirstOrDefault(e => e.Title == Title);
            if (exam != null)
            {
                context.Exams.Remove(exam);
                context.SaveChanges();
            }
        }
    }
}