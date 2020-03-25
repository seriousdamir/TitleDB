using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TDB
{
    public partial class BookTypes
    {
        public BookTypes()
        {
            Book = new HashSet<Book>();
        }

        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
