using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TDB
{
    public partial class Book
    {
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Кількість Глав")]
        public int Chapters { get; set; }
        public int Id { get; set; }
        public int TypeId { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [StringLength(280, MinimumLength = 1)]
        [Display(Name = "Опис")]
        public string Description { get; set; }
        public int TitleId { get; set; }

        [Display(Name = "Назва")]
        public virtual Title Title { get; set; }
        [Display(Name = "Тип")]
        public virtual BookTypes Type { get; set; }
    }
}
