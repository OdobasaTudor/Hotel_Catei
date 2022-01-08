namespace AutoLotModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stapani")]
    public partial class Stapani
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Stapani()
        {
            Rezervaris = new HashSet<Rezervari>();
        }

        [Key]
        public int id_stapan { get; set; }

        [StringLength(50)]
        public string Nume_stapan { get; set; }

        [StringLength(50)]
        public string Prenume_stapan { get; set; }

        public int? nrtel_stapan { get; set; }

        [StringLength(50)]
        public string mail_stapan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezervari> Rezervaris { get; set; }
    }
}
