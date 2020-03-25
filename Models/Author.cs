using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TDB
{
    public partial class Author
    {
        public Author()
        {
            Founder = new HashSet<Founder>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата Народження")]
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Founder> Founder { get; set; }
    }
}
