namespace la_mia_pizzeria_static.Models
{
    public class Pizza
    {
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public string Foto { get; set; }
        public double Prezzo { get; set; }
        public Pizza(string nome, string descrizione, string foto, double prezzo)
        {
            Nome = nome;
            Descrizione = descrizione;
            Foto = foto;
            Prezzo = prezzo;

        }
    }
}
