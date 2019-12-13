using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using QuestionModelLibrary;
using System.Web.Http.Cors;
using QuesBALLibrary;

namespace QuestionAPI.Controllers
{
    [EnableCors("http://localhost:4200", "*", "GET,POST,PUT,DELETE")]
    public class RegisterController : ApiController
    {
        // GET: api/Register
        static List<ExamenStack> examen = new List<ExamenStack>();
        QuesBAL bl = new QuesBAL();
        public IEnumerable<ExamenStack> Get()
        {
            examen = bl.GetRegisterDetails();
            return examen;
        }

        // GET: api/Register/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Register
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Register/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Register/5
        public void Delete(int id)
        {
        }
    }
}
