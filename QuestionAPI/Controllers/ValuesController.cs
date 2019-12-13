using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuestionModelLibrary;
using QuesBALLibrary;
using System.Web.Http.Cors;


namespace QuestionAPI.Controllers
{

    [EnableCors("http://localhost:4200", "*", "GET,POST,PUT,DELETE")]

    public class ValuesController : ApiController
    {
        static List<ExamenStack> examen = new List<ExamenStack>();
        QuesBAL bl = new QuesBAL();

        // GET api/values
        public IEnumerable<ExamenStack> Get()
        {
            examen = bl.GetQuestionsAndAnswers();
            return examen;
        }

        // GET api/values/5
        public List<ExamenStack> Get(string testtype)
        {
            List<ExamenStack> examen = new List<ExamenStack>();
            examen = bl.GetTestTypeQuestions(testtype);
            return examen;
        }
        // POST api/values
        public ExamenStack Post([FromBody]ExamenStack examen)
        {
            if (User != null)
                return bl.AddQuestions(examen);
            else
                return new ExamenStack();
        }

        // PUT api/values/5
        public ExamenStack Put([FromBody]ExamenStack examen)
        {
            //var user = (from u in examen
            //            where u.SNo == id
            //            select u).First();

            if (User != null)
                return bl.UpdateQuestion(examen);
            else
                return examen;
        }

        // DELETE api/values/5
        public string Delete(int Sno)
        {
            return bl.DeleteQuestionAndAnswer(Sno);



        }
    }
}