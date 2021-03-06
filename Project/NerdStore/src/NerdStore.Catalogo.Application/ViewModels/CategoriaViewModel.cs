using System;
using System.ComponentModel.DataAnnotations;

namespace NerdStore.Catalogo.Application.ViewModels
{
    public class CategoriaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "o Campo {0} é obrigatório")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "o Campo {0} é obrigatório")]
        public int Codigo { get; private set; }
    }
}