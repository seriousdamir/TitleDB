using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TDB
{
    public partial class Games
    {

        public int Year { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [StringLength(280, MinimumLength = 1)]
        [Display(Name = "Опис")]
        public string Description { get; set; }
        public int TitleId { get; set; }
        public int Id { get; set; }

        [Display(Name = "Назва")]
        public virtual Title Title { get; set; }
    }
}
