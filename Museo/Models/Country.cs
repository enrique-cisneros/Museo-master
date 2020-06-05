using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Museo.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Display(Name = "Nombre del pais de Origen de la Obra")]
        public string NombrePais { get; set; }
        public int? ArtistId { get; set; }
        [ForeignKey("ArtistId")]
        public Artist Artist { get; set; }
        public int? ArtworkId { get; set; }
        [ForeignKey("ArtworkId")]
        public Artwork Artwork { get; set; }
    }
}