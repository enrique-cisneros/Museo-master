using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Museo.Models
{
    public class Artwork
    {
        public int Id { get; set; }
        [Display(Name = "Nombre de la Oobra")]
        public string Nombre { get; set; }
        [Display(Name = "Tipo de Arte")]
        public string Tipo { get; set; }
        [Display(Name = "Fecha de Creacion")]
        public DateTime Fecha { get; set; }
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }
        public string ImgUrl { get; set; }
        public int ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }
    }
}