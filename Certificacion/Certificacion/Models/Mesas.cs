namespace Certificacion.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Mesas
    {
        [Key]
        public int idMesa { get; set; }

        [StringLength(150)]
        public string Ubicacion { get; set; }

        [Column(TypeName = "text")]
        public string Estado { get; set; }

        [Column(TypeName = "money")]
        public decimal? Consumo { get; set; }

        public int? CantSillas { get; set; }
    }
}
