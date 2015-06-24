using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocDifEntities.cs
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Telefone { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Cep { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Email { get; set; }

        public string Apelido { get; set; }

        public string Twitter { get; set; }
    }
}
