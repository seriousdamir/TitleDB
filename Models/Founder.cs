using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TDB
{
    public partial class Founder
    {
        public int TitleId { get; set; }
        public int AuthorId { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Автор")]
        public virtual Author Author { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Назва")]
        public virtual Title Title { get; set; }
    }
}
