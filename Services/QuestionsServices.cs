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

        public void createQuestion(QuestionsDto questions)
        {
            var question = new Questions()
            {
                ExamId = questions.ExamId,
                Question = questions.Question,
                AnswerA = questions.AnswerA,
                AnswerB = questions.AnswerB,
                AnswerC = questions.AnswerC,
                AnswerD = questions.AnswerD,
                CorrectAnswer = questions.CorrectAnswer
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
            return context.Questions.FirstOrDefault(x => x.QuestionId == questionId);
        }

        public void updateQuestion(Guid questionId, QuestionsDto newQuestion)
        {
            var question = context.Questions.FirstOrDefault(x => x.QuestionId == questionId);

            question.ExamId = newQuestion.ExamId;
            question.Question = newQuestion.Question;
            question.AnswerA = newQuestion.AnswerA;
            question.AnswerB = newQuestion.AnswerB;
            question.AnswerC = newQuestion.AnswerC;
            question.AnswerD = newQuestion.AnswerD;
            question.CorrectAnswer = newQuestion.CorrectAnswer;

            context.SaveChanges();
        }

        public void deleteQuestion(Guid questionId)
        {
            var question = context.Questions.FirstOrDefault(x => x.QuestionId == questionId);
            context.Questions.Remove(question);
            context.SaveChanges();
        }
    }
}
