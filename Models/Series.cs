using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TDB
{
    public partial class Series
    {
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Кількість Серій")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Тривалість Серії")]
        public TimeSpan Duration { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Відкривюча Тема")]
        public string Opening { get; set; }
        public int TitleId { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Закриваюча Тема")]
        public string Ending { get; set; }

        [Display(Name = "Назва")]
        public virtual Title Title { get; set; }
    }
}
