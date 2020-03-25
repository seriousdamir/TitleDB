using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TDB
{
    public partial class Directors
    {
        public Directors()
        {
            Studio = new HashSet<Studio>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата Народження")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }

        public virtual ICollection<Studio> Studio { get; set; }
    }
}
