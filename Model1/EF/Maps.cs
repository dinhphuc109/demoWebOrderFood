namespace Model1.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Maps")]
    public partial class Maps
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Lat { get; set; }

        [StringLength(50)]
        public string Lnq { get; set; }

        public bool? Status { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
    }
}
