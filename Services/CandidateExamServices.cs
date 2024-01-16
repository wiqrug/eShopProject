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

        public List<CandidateExam> GetCandidateExam()
        {
            var candidateExam = context.CandidateExams.ToList();
            return candidateExam;

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
                //ExamMark=candidateExamDTO.ExamMark,

            };

            context.CandidateExams.Add(enrollment);
            context.SaveChanges();
            return true;
        }
        public bool DeleteCandidateExam(Guid candidateId)
        {
           
            var candidateExam = context.CandidateExams.FirstOrDefault(x => x.CandidateId == candidateId);

            if (candidateExam == null)
            {
                return false;
            }
            else
            {
                context.CandidateExams.Remove(candidateExam);
                context.SaveChanges();

                return true;
            }
        }

        public void UpdateCandidateExam(Guid candidateExamId, CandidateExamDTO candidateExamDTO)
        {
            var candidateExam= context.CandidateExams.FirstOrDefault(x=>x.CandidateExamId == candidateExamId);
            if (candidateExam == null)
            {
                return;
            }
            if (candidateExamDTO.ExamMark!=null)
            {
                candidateExam.ExamMark=candidateExamDTO.ExamMark;
            }
            context.SaveChanges();
        }
    }
}
