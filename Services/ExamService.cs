﻿using Microsoft.EntityFrameworkCore;
using Project2.Models;
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
            var exam = context.Exams.Where(e => e.Title == Title).Include(q => q.Questions);
            var response = exam.FirstOrDefault(e => e.Title == Title);
            return response;
        }

        

        public Guid CheckExam(string Title)
        {
            Guid certificateId = context.Certificates
                                   .Where(e => e.Title == Title)
                                   .Select(e => e.CertificateId)
                                   .FirstOrDefault();
            return certificateId;
        }
        public void AddExam(ExamDto examDto, string Title)
        {
            Guid certificateId = context.Certificates
                                   .Where(e => e.Title == Title)
                                   .Select(e => e.CertificateId)
                                   .FirstOrDefault();
           
            var exam = new Exam(certificateId)
            {
                Title = examDto.Title,
                Description = examDto.Description,
                Time = examDto.Time,
                
                
            };

            context.Exams.Add(exam);
            context.SaveChanges();
        }

        public void UpdateExam(string Title, ExamUpdateDto examDto)
        {
            var exam = context.Exams.FirstOrDefault(e => e.Title == Title);
            var certificate = context.Certificates.FirstOrDefault(c=> c.Title == examDto.CertificateTitle);

            Guid certificateId = context.Certificates
                                   .Where(e => e.Title == examDto.CertificateTitle)
                                   .Select(e => e.CertificateId)
                                   .FirstOrDefault();

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
                    exam.Time = Int32.Parse(examDto.Time);
                }
                if (certificateId != Guid.Empty)
                {
                    exam.CertificateId = certificateId;
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