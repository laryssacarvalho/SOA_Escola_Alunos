using System;

namespace SOA_Escola_Alunos.Models
{
    public class Student : BaseModel
    {
        public string Name { get; set; }

        public Student(string name)
        {
            Name = name;
        }
    }
}
