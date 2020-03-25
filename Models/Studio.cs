using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TDB
{
    public partial class Studio
    {
        public Studio()
        {
            Title = new HashSet<Title>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Range(1900, 2020)]
        [Display(Name = "Рік Заснування")]
        public int FoundationYear { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Адреса")]
        public string Address { get; set; }
        public int DirectorId { get; set; }

        [Display(Name = "Директор")]
        public virtual Directors Director { get; set; }
        public virtual ICollection<Title> Title { get; set; }
    }
}
