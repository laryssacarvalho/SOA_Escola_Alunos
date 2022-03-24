using SOA_Escola_Alunos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SOA_Escola_Alunos.Database.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        private string _filePath { get; set; }

        public BaseRepository(string filePath)
        {
            _filePath = filePath;
        }

        private List<T> GetDatabase()
        {
            var registros = File.ReadAllText(_filePath);
            if (registros == "")
            {
                return new List<T>();
            }

            return JsonSerializer.Deserialize<List<T>>(registros);
        }

        public List<T> GetAll() => GetDatabase();        

        public T GetById(int id)
        {
            var database = GetDatabase();
            return database.FirstOrDefault(x => x.Id == id);
        }
        public void Update(T entity)
        {
            Delete(entity);
            Add(entity);
        }

        public void Delete(T entity)
        {
            var database = GetDatabase();
            database.RemoveAll(p => p.Id == entity.Id);
            UpdateDatabase(database);
        }

        public int Add(T entity)
        {
            var database = GetDatabase();
            database.Add(entity);
            UpdateDatabase(database);
            return entity.Id;
        }

        private void UpdateDatabase(List<T> database)
        {
            File.WriteAllTextAsync(_filePath, JsonSerializer.Serialize(database));
        }
    }    
}
