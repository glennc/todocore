using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoCore.Model
{
    public class User
    {
        public User()
        {
            Todos = new List<Todo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public List<Todo> Todos { get; set; }
    }
}
