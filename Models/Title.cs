using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TDB
{
    public partial class Title
    {
        public Title()
        {
            Acting = new HashSet<Acting>();
            Book = new HashSet<Book>();
            Film = new HashSet<Film>();
            Founder = new HashSet<Founder>();
            Games = new HashSet<Games>();
            Series = new HashSet<Series>();
            TitleToGenre = new HashSet<TitleToGenre>();
            VoiceActing = new HashSet<VoiceActing>();
        }

        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Назва")]
        public string Name { get; set; }
        public int StudioId { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Рік початку")]
        [Range(1900, 2020)]
        public int StartYear { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Display(Name = "Виходить наразі")]
        public bool Ongoing { get; set; }
        [Required(ErrorMessage = "Поле повинно бути заповненим")]
        [Range(1, 10)]
        [Display(Name = "Оцінка")]
        public int Mark { get; set; }
        public int FranchaiseId { get; set; }

        [Display(Name = "Франшиза")]
        public virtual Franchaise Franchaise { get; set; }
        [Display(Name = "Студія")]
        public virtual Studio Studio { get; set; }
        public virtual ICollection<Acting> Acting { get; set; }
        public virtual ICollection<Book> Book { get; set; }
        public virtual ICollection<Film> Film { get; set; }
        public virtual ICollection<Founder> Founder { get; set; }
        public virtual ICollection<Games> Games { get; set; }
        public virtual ICollection<Series> Series { get; set; }
        public virtual ICollection<TitleToGenre> TitleToGenre { get; set; }
        public virtual ICollection<VoiceActing> VoiceActing { get; set; }
    }
}
