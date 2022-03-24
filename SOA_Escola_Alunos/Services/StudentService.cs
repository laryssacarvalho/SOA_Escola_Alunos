using SOA_Escola_Alunos.Database.Repositories;
using SOA_Escola_Alunos.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace SOA_Escola_Alunos.Services
{
    public class StudentService
    {
        private readonly BaseRepository<Student> _studentRepository;

        public StudentService()
        {
            var filePath = Directory.GetCurrentDirectory() + @"..\..\..\..\Database\Students.json";
            _studentRepository = new BaseRepository<Student>(filePath);
        }
        public void Create(string name)
        {            
            if(name is not null)            
                _studentRepository.Add(new Student(name));            
        }

        public void Update(int id)
        {
            var student = _studentRepository.GetById(id);

            if(student == null)
            {
                Console.WriteLine($"Não existe um aluno com esse Id.");
                return;
            }            
            
            Console.WriteLine("Insira o nome do aluno: ");

            student.Name = Console.ReadLine();

            _studentRepository.Update(student);
            Console.WriteLine($"Aluno atualizado com sucesso!");            
        }

        public void GetAll() 
        {
            var students = _studentRepository.GetAll();

            foreach(var student in students)            
                Console.WriteLine($"Id: {student.Id} Nome: {student.Name}");            
        }
        public void Delete(int id) 
        {
            var student = _studentRepository.GetById(id);
            
            if(student == null)
            {
                Console.WriteLine($"Não existe um aluno com esse Id.");
                return;
            }

            _studentRepository.Delete(student);
            Console.WriteLine($"Aluno deletado com sucesso!");            
        }
    }
}
