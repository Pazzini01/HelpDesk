namespace HelpDesk.Models
{
    public class Categoria
    {
        public string Nome { get; private set; }

        public Categoria(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome da categoria não pode ficar vazio.");
            }

            Nome = nome;
        }
    }
}