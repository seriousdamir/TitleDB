using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TDB
{
    public partial class VoiceActing
    {
        public int TitleId { get; set; }
        public int ActorId { get; set; }
        public int Id { get; set; }

        [Display(Name = "Актор")]
        public virtual VoiceActors Actor { get; set; }
        [Display(Name = "Тайтл")]
        public virtual Title Title { get; set; }
    }
}
