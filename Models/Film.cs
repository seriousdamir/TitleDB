using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TDB
{
    public partial class Film
    {
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Тривалість")]
        public TimeSpan Duration { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Саундтрек")]
        public string Soundtrack { get; set; }
        public int Id { get; set; }
        public int TitleId { get; set; }

        [Display(Name = "Назва")]
        public virtual Title Title { get; set; }
    }
}
