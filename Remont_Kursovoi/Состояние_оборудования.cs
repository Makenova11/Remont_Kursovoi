//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Remont_Kursovoi
{
    using System;
    using System.Collections.Generic;
    
    public partial class Состояние_оборудования
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Состояние_оборудования()
        {
            this.Экземпляры_оборудований = new HashSet<Экземпляры_оборудований>();
        }
    
        public int Код_состояния_оборудования { get; set; }
        
        public string Наименование { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Экземпляры_оборудований> Экземпляры_оборудований { get; set; }
    }
}
