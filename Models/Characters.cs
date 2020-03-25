using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TDB
{
    public partial class Characters
    {
        public Characters()
        {
            Acting = new HashSet<Acting>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Ім'я")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [StringLength(280, MinimumLength = 1)]
        [Display(Name = "Зовнішність")]
        public string AppDescription { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [StringLength(280, MinimumLength = 1)]
        [Display(Name = "Характер")]
        public string Temper { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "Роль")]
        public string Role { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [StringLength(280, MinimumLength = 1)]
        [Display(Name = "Перша Поява")]
        public string FirstApp { get; set; }
        public int VoiceActId { get; set; }

        [Display(Name = "Актор Озвучування")]
        public virtual VoiceActors VoiceAct { get; set; }
        public virtual ICollection<Acting> Acting { get; set; }
    }
}
