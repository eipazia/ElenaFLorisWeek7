using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsWeek7
{
    internal class Utente
    {
      
            public string Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }

            public Utente()
            {
            }

            public Utente(string id, string uname, string pwd)
            {
                Id = id;
                Username = uname;
                Password = pwd;
            }

            public override string ToString()
            {
                return $"{Username}";
            }
     }
}

