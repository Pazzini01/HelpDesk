using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Models
{
    public class Chamado
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Condicao { get; private set; } = "Aberto";

        public Chamado(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
        }

        public void AlterarCondicao(string novaCondicao)
        {
            Condicao = novaCondicao;
        
        }
    }
}