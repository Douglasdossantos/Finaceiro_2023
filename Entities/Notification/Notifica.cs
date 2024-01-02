using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Notification
{
    public class Notifica
    {
        public Notifica()
        {
            Notificacoes = new List<Notifica>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<Notifica> Notificacoes;
        public bool ValidaPropriedadeString( string valor, string nomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor)|| string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifica()
                {
                    Mensagem = "Campo Obrigatório",
                    NomePropriedade = nomePropriedade,
                });
                return false;
            }
            return true;
        }
        public bool validaProprieadeInt(int Valor, string nomePropriedade)
        {
            if (Valor < 1 || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                Notificacoes.Add(new Notifica
                {
                    Mensagem= "Campo Obrigatório",
                    NomePropriedade = nomePropriedade,
                });
                return false;
            }
            return true;    
        }
    }
}
