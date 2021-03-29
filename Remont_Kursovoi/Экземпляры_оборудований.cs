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
    using System.ComponentModel.DataAnnotations;

    public partial class Экземпляры_оборудований
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Экземпляры_оборудований()
        {
            this.График_плановых_техобслуживаний = new HashSet<График_плановых_техобслуживаний>();
            this.Журнал_выполненных_ремонтов = new HashSet<Журнал_выполненных_ремонтов>();
        }
    
        public int Код_экземпляра { get; set; }
        [StringLength(50, ErrorMessage = "Наименование должно быть не более 50 символов")]
        public string Наименование { get; set; }
        public int Код_состояния_оборудования { get; set; }
        public System.Guid ID_типа_оборудования { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<График_плановых_техобслуживаний> График_плановых_техобслуживаний { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Журнал_выполненных_ремонтов> Журнал_выполненных_ремонтов { get; set; }
        public virtual Состояние_оборудования Состояние_оборудования { get; set; }
        public virtual Типы_оборудования Типы_оборудования { get; set; }
    }
}
