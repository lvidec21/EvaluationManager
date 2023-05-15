using EvaluationManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluationManager.Models {
    public abstract class Person : object
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string ToString() 
        {
            return FirstName + " " + LastName;
        }
    }
    public class Teacher : Person 
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public bool CheckPassword(string password) {
            return Password == password;
        }
        public void PerformEvaluation(Student student, Activity activity, int points) 
        {
            var evaluation = EvaluationRepository.GetEvaluation(student, activity);
            if(evaluation!=null) 
            {
                EvaluationRepository.InsertEvaluation(student, activity, this, points);
            }
            else 
            {
                EvaluationRepository.UpdateEvaluation(evaluation, this, points);
            }
        }
    }
    public class Student : Person 
    {
        public int Grade { get; set; }
    }

}
