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
        public List<Historico> Historico { get; private set; } = new List<Historico>();

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

            AdicionarHistorico("Chamado criado.");
        }

        public void AlterarCondicao(string novaCondicao)
        {
            Condicao = novaCondicao;
            AdicionarHistorico($"Condição alterada para {novaCondicao}.");
        }

        private void AdicionarHistorico(string descricao)
        {
            Historico novoHistorico = new Historico(descricao);

            Historico.Add(novoHistorico);
        }

    }
}