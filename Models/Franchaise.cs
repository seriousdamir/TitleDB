using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TDB
{
    public partial class Franchaise
    {
        public Franchaise()
        {
            Title = new HashSet<Title>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Назва")]
        public string Name { get; set; }

        public virtual ICollection<Title> Title { get; set; }
    }
}
