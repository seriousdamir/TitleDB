using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TDB
{

    public partial class VoiceActors
    {

        public VoiceActors()
        {
            Characters = new HashSet<Characters>();
            VoiceActing = new HashSet<VoiceActing>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата Народження")]
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Characters> Characters { get; set; }
        public virtual ICollection<VoiceActing> VoiceActing { get; set; }
    }
}
