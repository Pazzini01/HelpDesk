namespace HelpDesk.Models
{
    public class Historico
    {
        public string Descricao { get; private set; }
       public DateTime DataHora { get; private set; }

       public Historico (string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
            {
                throw new ArgumentException("A descrição não deve ficar em branco");
            }
            Descricao = descricao;
            DataHora = DateTime.Now;
        }

    }

}
