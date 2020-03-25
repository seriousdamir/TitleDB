using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TDB
{
    public partial class Genre
    {
        public Genre()
        {
            TitleToGenre = new HashSet<TitleToGenre>();
        }

        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [StringLength(280, MinimumLength = 1)]
        [Display(Name = "Опис")]
        public string Description { get; set; }
        public int Id { get; set; }

        public virtual ICollection<TitleToGenre> TitleToGenre { get; set; }
    }
}
