using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionModelLibrary;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace QuesDALLibrary
{
    public class QuesDAL
    {
        SqlConnection conn;
        SqlCommand cmdAddQuestion, cmdUpdateQuestion, cmdGetTestQuestion, cmdGetQuestions, cmdGetAllQuestions, cmdDeleteQuestion, cmdGetRegisterDetails, cmdGetAdminDetails, cmdGetPaidUsers,cmdGetScoreDetails;
        public QuesDAL()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connExamen"].ConnectionString);
        }
        public List<ExamenStack> GetAllQuestions(string testmodel)
        {
            conn.Open();
            List<ExamenStack> examens = new List<ExamenStack>();
            cmdGetQuestions = new SqlCommand("proc_GetAllQuestions", conn);
            cmdGetQuestions.Parameters.Add("@TestModel", SqlDbType.VarChar, 50);
            cmdGetQuestions.CommandType = CommandType.StoredProcedure;
            cmdGetQuestions.Parameters[0].Value = testmodel;


            ExamenStack examen;
            SqlDataReader dataReader = cmdGetQuestions.ExecuteReader();
            while (dataReader.Read())
            {
                examen = new ExamenStack();
                examen.SNo = Convert.ToInt32(dataReader[0]);
                examen.Testmodel = dataReader[1].ToString();
                examen.Questions = dataReader[2].ToString();
                examen.Answers = dataReader[3].ToString();
                examen.Option1 = (dataReader[4].ToString());
                examen.Option3 = (dataReader[5].ToString());
                examen.Option2 = (dataReader[6].ToString());
                examen.Option4 = (dataReader[7].ToString());
                examen.Mark = Convert.ToInt32(dataReader[8]);
                examens.Add(examen);
            }
            conn.Close();
            return examens;
        }
        public List<ExamenStack> GetQuestions()
        {
            conn.Open();
            List<ExamenStack> examens = new List<ExamenStack>();
            cmdGetAllQuestions = new SqlCommand("proc_GetQuestions", conn);
            cmdGetAllQuestions.CommandType = CommandType.StoredProcedure;
            ExamenStack examen;
            SqlDataReader dataReader = cmdGetAllQuestions.ExecuteReader();
            while (dataReader.Read())
            {
                examen = new ExamenStack();
                examen.SNo = Convert.ToInt32(dataReader[0]);
                examen.Testmodel = dataReader[1].ToString();
                examen.Questions = dataReader[2].ToString();
                examen.Answers = dataReader[3].ToString();
                examen.Option1 = (dataReader[4].ToString());
                examen.Option3 = (dataReader[5].ToString());
                examen.Option2 = (dataReader[6].ToString());
                examen.Option4 = (dataReader[7].ToString());
                examen.Mark = Convert.ToInt32(dataReader[8]);
                examens.Add(examen);
            }
            conn.Close();
            return examens;
        }
        public ExamenStack AddQuestions(ExamenStack examen)
        {
            try
            {
                conn.Open();
                cmdAddQuestion = new SqlCommand("proc_AddQuestion", conn);
                cmdAddQuestion.CommandType = CommandType.StoredProcedure;
                cmdAddQuestion.Parameters.AddWithValue("@SNo", examen.SNo);
                cmdAddQuestion.Parameters.AddWithValue("@TestModel", examen.Testmodel);
                cmdAddQuestion.Parameters.AddWithValue("@Questions", examen.Questions);
                cmdAddQuestion.Parameters.AddWithValue("@Answers", examen.Answers);
                cmdAddQuestion.Parameters.AddWithValue("@option1", examen.Option1);
                cmdAddQuestion.Parameters.AddWithValue("@option2", examen.Option2);
                cmdAddQuestion.Parameters.AddWithValue("@option3", examen.Option3);
                cmdAddQuestion.Parameters.AddWithValue("@option4", examen.Option4);
                cmdAddQuestion.Parameters.AddWithValue("@Mark", examen.Mark);
                if (cmdAddQuestion.ExecuteNonQuery() > 0)
                {
                    examen = null;
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.Message);

            }
            conn.Close();
            return examen;
        }
        public List<ExamenStack> GetTestType(string testType)
        {
            List<ExamenStack> list = new List<ExamenStack>();
            conn.Open();
            cmdGetTestQuestion = new SqlCommand("proc_GetTestTypeQuestions", conn);
            cmdGetTestQuestion.Parameters.AddWithValue("@TestModel", testType);
            cmdGetTestQuestion.CommandType = CommandType.StoredProcedure;
            cmdGetTestQuestion.Parameters[0].Value = testType;
            SqlDataReader drQuestionType = cmdGetTestQuestion.ExecuteReader();
            ExamenStack examen = null;
            while (drQuestionType.Read())
            {
                examen = new ExamenStack();
                examen.SNo = Convert.ToInt32(drQuestionType[0]);
                examen.Questions = drQuestionType[2].ToString();
                examen.Answers = drQuestionType[3].ToString();
                examen.Option1 = drQuestionType[4].ToString();
                examen.Option2 = drQuestionType[5].ToString();
                examen.Option3 = drQuestionType[6].ToString();
                examen.Option4 = drQuestionType[7].ToString();
                examen.Mark = Convert.ToInt32(drQuestionType[8]);

                list.Add(examen);
            }
            conn.Close();
            return list;
        }

        public ExamenStack UpdateQuestion(ExamenStack examen)
        {
            conn.Open();
            cmdUpdateQuestion = new SqlCommand("proc_UpdateQuestion", conn);
            cmdUpdateQuestion.CommandType = CommandType.StoredProcedure;
            cmdUpdateQuestion.Parameters.AddWithValue("@SNo", examen.SNo);
            cmdUpdateQuestion.Parameters.AddWithValue("@TestModel", examen.Testmodel);
            cmdUpdateQuestion.Parameters.AddWithValue("@Question", examen.Questions);
            cmdUpdateQuestion.Parameters.AddWithValue("@Answer", examen.Answers);
            cmdUpdateQuestion.Parameters.AddWithValue("@option1", examen.Option1);
            cmdUpdateQuestion.Parameters.AddWithValue("@option2", examen.Option2);
            cmdUpdateQuestion.Parameters.AddWithValue("@option3", examen.Option3);
            cmdUpdateQuestion.Parameters.AddWithValue("@option4", examen.Option4);
            cmdUpdateQuestion.Parameters.AddWithValue("@Mark", examen.Mark);
            if (cmdUpdateQuestion.ExecuteNonQuery() > 0)
            {
                examen = null;
            }
            conn.Close();
            return examen;
        }
        public string DeleteQuestion(int Sno)
        {
            string result;
            conn.Open();
            cmdDeleteQuestion = new SqlCommand("proc_DeleteQuestion", conn);
            cmdDeleteQuestion.CommandType = CommandType.StoredProcedure;
            cmdDeleteQuestion.Parameters.AddWithValue("@SNo", Sno);
            //cmdDeleteQuestion.Parameters.AddWithValue("@TestModel", examen.Testmodel);
            if (cmdDeleteQuestion.ExecuteNonQuery() > 0)
            {

                result = "deleted";
            }
            else
            {
                result = "not deleted";
            }
            conn.Close();
            return result;
        }
        public List<ExamenStack> GetRegisterDetails()
        {
            conn.Open();
            List<ExamenStack> examens = new List<ExamenStack>();
            cmdGetRegisterDetails = new SqlCommand("proc_GetUserDetails", conn);
            cmdGetRegisterDetails.CommandType = CommandType.StoredProcedure;
            ExamenStack examen;
            SqlDataReader dataReader = cmdGetRegisterDetails.ExecuteReader();
            while (dataReader.Read())
            {
                examen = new ExamenStack();
                examen.Name = dataReader[0].ToString();
                examen.Email = dataReader[1].ToString();
                examen.Phone = dataReader[2].ToString();
                examen.Username = dataReader[3].ToString();
                examens.Add(examen);
            }
            conn.Close();
            return examens;

        }

        public List<ExamenStack> GetAdminDetails()
        {
            conn.Open();
            List<ExamenStack> examens = new List<ExamenStack>();
            cmdGetAdminDetails = new SqlCommand("proc_AdminDetails", conn);
            cmdGetAdminDetails.CommandType = CommandType.StoredProcedure;
            ExamenStack examen;
            SqlDataReader dataReader = cmdGetAdminDetails.ExecuteReader();
            while (dataReader.Read())
            {
                examen = new ExamenStack();
                examen.Admin_name = dataReader[0].ToString();
                examen.Admin_email = dataReader[1].ToString();
                examen.Admin_phone = dataReader[2].ToString();
                examen.Admin_username = dataReader[3].ToString();
                examens.Add(examen);
            }
            conn.Close();
            return examens;
        }
        public List<ExamenStack> GetPaidUsers()
        {
            conn.Open();
            List<ExamenStack> examens = new List<ExamenStack>();
            cmdGetPaidUsers = new SqlCommand("proc_GetPaidUsers", conn);
            cmdGetPaidUsers.CommandType = CommandType.StoredProcedure;
            ExamenStack examen;
            SqlDataReader dataReader = cmdGetPaidUsers.ExecuteReader();
            while (dataReader.Read())
            {
                examen = new ExamenStack();
                examen.Name = dataReader[0].ToString();
                examen.Email = dataReader[1].ToString();
                examen.Phone = dataReader[2].ToString();
                examen.Testmodel = dataReader[3].ToString();
                examen.Date = dataReader[4].ToString();
                examens.Add(examen);
            }
            conn.Close();
            return examens;
        }

        public List<ExamenStack> GetScoreDetails()
        {
            conn.Open();
            List<ExamenStack> examens = new List<ExamenStack>();
            cmdGetScoreDetails = new SqlCommand("proc_GetScoreDetails", conn);
            cmdGetScoreDetails.CommandType = CommandType.StoredProcedure;
            ExamenStack examen;
            SqlDataReader dataReader = cmdGetScoreDetails.ExecuteReader();
            while(dataReader.Read())
            {
                examen = new ExamenStack();
                examen.Name = dataReader[0].ToString();
                examen.Email = dataReader[1].ToString();
                examen.Phone = dataReader[2].ToString();
                examen.Testmodel = dataReader[3].ToString();
                examen.Score = Convert.ToInt32(dataReader[4]);
                examens.Add(examen);
            }
            conn.Close();
            return examens;

        }
    }


}
