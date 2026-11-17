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
            if (string.IsNullOrWhiteSpace(titulo))
            {
              throw new ArgumentException("O título não deve ficar em branco");
            }

            if (string.IsNullOrWhiteSpace(descricao))
            {
                throw new ArgumentException("A descrição não deve ficar em branco");
            }


            Titulo = titulo;
            Descricao = descricao;
        }

        public void AlterarCondicao(string novaCondicao)
        {
            Condicao = novaCondicao;
        
        }
    }
}