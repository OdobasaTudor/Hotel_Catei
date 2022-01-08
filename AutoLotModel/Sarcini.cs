namespace AutoLotModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sarcini")]
    public partial class Sarcini
    {
        [Key]
        public int Id_sarcina { get; set; }

        public int? Id_angajat { get; set; }

        public int? Id_rezervare { get; set; }

        public virtual Angajati Angajati { get; set; }

        public virtual Rezervari Rezervari { get; set; }
    }
}
