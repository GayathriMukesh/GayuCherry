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
    public class AdminController : ApiController
    {
        // GET: api/Admin

        static List<ExamenStack> examen = new List<ExamenStack>();
        QuesBAL bl = new QuesBAL();
        public IEnumerable<ExamenStack> Get()
        {
            examen = bl.GetAdminDetails();
            return examen;
        }

        // GET: api/Admin/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Admin
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Admin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Admin/5
        public void Delete(int id)
        {
        }
    }
}
