using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Models
{
    public class Chamado
    {
        public string Titulo { get; private set; }
        public void AlterarTitulo(string novoTitulo)
        {
            Titulo = novoTitulo;
        }

        public string Descricao { get; private set; }
        public void AlterarDescricao(string novaDescricao)
        {
            Descricao = novaDescricao;
        }
    }
}