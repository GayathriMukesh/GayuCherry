using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionModelLibrary;
using QuesDALLibrary;

namespace QuesBALLibrary
{
    public class QuesBAL
    {
        QuesDAL dal;
        
        public QuesBAL()
        {
            dal = new QuesDAL();
        }
        public List<ExamenStack> GetAllQuestionsandAnswers(string testmodel)
        {
            return dal.GetAllQuestions(testmodel);
        }
        public List<ExamenStack> GetQuestionsAndAnswers()
        {
            return dal.GetQuestions();
        }
        public ExamenStack AddQuestions(ExamenStack examen)
        {
            return dal.AddQuestions(examen);
        }
        public List<ExamenStack> GetTestTypeQuestions(string testType)
        {
            return dal.GetTestType(testType);
        }
        public ExamenStack UpdateQuestion(ExamenStack examen)
        {
            return dal.UpdateQuestion(examen);
        }
        public string DeleteQuestionAndAnswer(int Sno)
        {
            return dal.DeleteQuestion(Sno);
        }
        public List<ExamenStack> GetRegisterDetails()
        {
            return dal.GetRegisterDetails();
        }

        public List<ExamenStack> GetAdminDetails()
        {
            return dal.GetAdminDetails();
        }
        public List<ExamenStack> GetPaidUserDetails()
        {
            return dal.GetPaidUsers();
        }
        public List<ExamenStack> GetScoreDetails()
        {
            return dal.GetScoreDetails();
        }
    }
}