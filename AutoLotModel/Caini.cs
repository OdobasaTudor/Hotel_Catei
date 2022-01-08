namespace AutoLotModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Caini")]
    public partial class Caini
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Caini()
        {
            Rezervaris = new HashSet<Rezervari>();
        }

        [Key]
        public int Id_caine { get; set; }

        [StringLength(50)]
        public string nume_caine { get; set; }

        [StringLength(50)]
        public string rasa_caine { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezervari> Rezervaris { get; set; }
    }
}
