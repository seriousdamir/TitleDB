using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TDB
{
    public partial class Acting //хочу тупицы
    {
        public int TitleId { get; set; }
        public int CharacterId { get; set; }
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Персонаж")]
        public virtual Characters Character { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Тайтл")]
        public virtual Title Title { get; set; }
    }
}
