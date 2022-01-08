namespace AutoLotModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Angajati")]
    public partial class Angajati
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Angajati()
        {
            Sarcinis = new HashSet<Sarcini>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string nume_angajat { get; set; }

        [StringLength(50)]
        public string prenume_angajat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sarcini> Sarcinis { get; set; }
    }
}
