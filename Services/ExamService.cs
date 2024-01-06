using Project2.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project2.Services
{
    public class ExamService
    {
        private readonly ApplicationDBContext _context;

        public ExamService(ApplicationDBContext context)
        {
            _context = context;
        }

        public List<Exam> GetAllExams()
        {
            return _context.Exams.ToList();
        }

        public Exam GetExamById(Guid examId)
        {
            return _context.Exams.FirstOrDefault(e => e.ExamId == examId);
        }

        public void AddExam(ExamDto examDto)
        {
            var exam = new Exam
            {
                ExamDescription = examDto.ExamDescription,
                AwardedMarks = examDto.AwardedMarks,
                PossibleMarks = examDto.PossibleMarks,
                CertificateId = examDto.CertificateId,
                Title= examDto.Title,
                Time= examDto.Time,

            };

            _context.Exams.Add(exam);
            _context.SaveChanges();
        }

        public void UpdateExam(Guid examId, ExamDto examDto)
        {
            var exam = _context.Exams.FirstOrDefault(e => e.ExamId == examId);
            if (exam != null)
            {
                exam.ExamDescription = examDto.ExamDescription;
                exam.AwardedMarks = examDto.AwardedMarks;
                exam.PossibleMarks = examDto.PossibleMarks;
                exam.CertificateId = examDto.CertificateId;
               exam.Title = examDto.Title;
                exam.Time = examDto.Time;

                _context.SaveChanges();
            }
        }

        public void DeleteExam(Guid examId)
        {
            var exam = _context.Exams.FirstOrDefault(e => e.ExamId == examId);
            if (exam != null)
            {
                _context.Exams.Remove(exam);
                _context.SaveChanges();
            }
        }
    }
}
