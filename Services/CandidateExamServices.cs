using Project2.Models;

namespace Project2.Services
{
    public class CandidateExamServices
    {
        private readonly ApplicationDBContext context;
       

        public CandidateExamServices(ApplicationDBContext context)
        {
            this.context = context;
        }



        public bool CreateCandidateExam(CandidateExamDTO candidateExamDTO)
        {

            var candidate = context.CandidateCertificates.FirstOrDefault(x => x.CandidateId == candidateExamDTO.CandidateId);
            var exam = context.Exams.FirstOrDefault(x => x.ExamId == candidateExamDTO.ExamId);

            var already = context.CandidateExams.FirstOrDefault(x => x.CandidateId == candidate.CandidateId && x.ExamId == exam.ExamId);

            if (candidate == null || exam == null || already != null)
            {
                return false;
            }

            CandidateExam enrollment = new CandidateExam
            {
                
                CandidateId = candidate.CandidateId,
                ExamId = exam.ExamId,
                ExamMark=candidateExamDTO.ExamMark,

            };

            context.CandidateExams.Add(enrollment);
            context.SaveChanges();
            return true;
        }
    }
}
