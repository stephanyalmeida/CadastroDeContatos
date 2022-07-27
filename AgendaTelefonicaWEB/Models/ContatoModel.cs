using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaTelefonicaWEB.Models
{
   public class ContatoModel
   {
      public int Id { get; set; }
      
      [Required(ErrorMessage = "Digite o nome do contato")]
      public string Nome { get; set; }
      [Required(ErrorMessage = "Digite o E-mail do contato")]
      [EmailAddress(ErrorMessage = "O e-mail informado é inválido!")]
      public string Email { get; set; }
      [Required(ErrorMessage = "Digite o Telefone do contato")]
      [Phone(ErrorMessage = "O Telefone informado não é válido!")]
      public string Telefone { get; set; }


   }
    

}
