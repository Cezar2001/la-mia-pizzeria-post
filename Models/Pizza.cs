using System.ComponentModel.DataAnnotations;

namespace la_mia_pizzeria_static.Models
{
    public class SuperValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validation)
        {
            string fieldValue = (string)value;
            if (fieldValue == null || fieldValue.Trim().IndexOf(" ") == -1)
            {
                return new ValidationResult("Il campo deve contenere Pizza e il tipo, es. Pizza Margherita, Pizza Diavola ecc..");
            }
            return ValidationResult.Success;
        }
    }

    public class Pizza
    {
        [Required(ErrorMessage = "L'ID della Pizza è obbligatorio")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Il Nome della Pizza è obbligatorio")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "La descrizione della Pizza è obbligatorio")]
        public string Descrizione { get; set; }
        
        [Required(ErrorMessage = "La foto della Pizza è obbligatorio")]
        public string Foto { get; set; }
        
        [Required(ErrorMessage = "Il prezzo della Pizza è obbligatorio")]
        public double Prezzo { get; set; }

        public IFormFile File { get; set; }
       
        public Pizza()
        {

        }

        public Pizza(string nome, string descrizione, string foto, double prezzo)
        {
            Nome = nome;
            Descrizione = descrizione;
            Foto = foto;
            Prezzo = prezzo;
        }

    }
}
