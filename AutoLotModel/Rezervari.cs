namespace AutoLotModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rezervari")]
    public partial class Rezervari
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rezervari()
        {
            Sarcinis = new HashSet<Sarcini>();
        }

        [Key]
        public int Id_rezervare { get; set; }

        public int id_stapan { get; set; }

        public int id_caine { get; set; }

        public DateTime? data_start { get; set; }

        public DateTime? data_final { get; set; }

        public virtual Caini Caini { get; set; }

        public virtual Stapani Stapani { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sarcini> Sarcinis { get; set; }
    }
}
