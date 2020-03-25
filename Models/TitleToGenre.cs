using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TDB
{
    public partial class TitleToGenre
    {
        public int TitleId { get; set; }
        public int GenreId { get; set; }
        public int Id { get; set; }

        [Display(Name = "Жанр")]
        public virtual Genre Genre { get; set; }
        [Display(Name = "Тайтл")]
        public virtual Title Title { get; set; }
    }
}
