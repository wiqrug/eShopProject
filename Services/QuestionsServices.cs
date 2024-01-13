using Project2.Models;

namespace Project2.Services
{
    public class QuestionsServices
    {
        private readonly ApplicationDBContext context;

        public QuestionsServices(ApplicationDBContext context)
        {
            this.context = context;
        }

        public void createQuestion(QuestionsDto questionDto)
        {
            var question = new Questions()
            {
                ExamId = questionDto.ExamId,
                Question = questionDto.Question,
                AnswerA = questionDto.AnswerA,
                AnswerB = questionDto.AnswerB,
                AnswerC = questionDto.AnswerC,
                AnswerD = questionDto.AnswerD,
                CorrectAnswer = questionDto.CorrectAnswer
            };
            context.Questions.Add(question);
            context.SaveChanges();
        }

        public List<Questions> getAllQuestions()
        {
            var response = context.Questions.ToList();
            return response;
        }

        public Questions getQuestion(Guid questionId)
        {
            var response = context.Questions.FirstOrDefault(x => x.QuestionId == questionId);

            return response;
        }

        public void updateQuestion(Guid questionId, QuestionsDto newQuestion)
        {
            var question = context.Questions.FirstOrDefault(x => x.QuestionId == questionId);

            if (question == null)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(newQuestion.Question))
            {
                question.Question = newQuestion.Question;
            }

            if (!string.IsNullOrWhiteSpace(newQuestion.AnswerA))
            {
                question.AnswerA = newQuestion.AnswerA;
            }

            if (!string.IsNullOrWhiteSpace(newQuestion.AnswerB))
            {
                question.AnswerB = newQuestion.AnswerB;
            }

            if (!string.IsNullOrWhiteSpace(newQuestion.AnswerC))
            {
                question.AnswerC = newQuestion.AnswerC;
            }

            if (!string.IsNullOrWhiteSpace(newQuestion.AnswerD))
            {
                question.AnswerD = newQuestion.AnswerD;
            }

            if (!string.IsNullOrWhiteSpace(newQuestion.CorrectAnswer))
            {
                question.CorrectAnswer = newQuestion.CorrectAnswer;
            }
            context.SaveChanges();
        }

        public void deleteQuestion(Guid questionId)
        {
            var question = context.Questions.FirstOrDefault(x => x.QuestionId == questionId);

            if (question == null)
            {
                return;
            }

            context.Questions.Remove(question);
            context.SaveChanges();
        }
    }
}
