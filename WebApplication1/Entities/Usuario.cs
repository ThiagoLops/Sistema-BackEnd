﻿using System.IO.Pipes;

namespace WebApplication1.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Telefone { get; set; }

        public string Genero { get; set; }

        public Guid UsuarioGuid { get; set; }
    }
}
