using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Museo.Models
{
    public class Artist
    {
        public int Id { get; set; }
        [Display(Name = "Nombre del Artista")]
        public string Nombre { get; set; }
        [Display(Name = "Nacimiento del Artista")]
        public DateTime FechaNac { get; set; }
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        //public Artwork Artwork { get; set; }
    }
}