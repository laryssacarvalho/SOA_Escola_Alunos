using System;

namespace SOA_Escola_Alunos.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public BaseModel()
        {
            var random = new Random();
            Id = random.Next();
        }
    }
}
