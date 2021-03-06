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

    public partial class График_плановых_техобслуживаний
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public График_плановых_техобслуживаний()
        {
            this.Журнал_выполненных_ремонтов = new HashSet<Журнал_выполненных_ремонтов>();
        }

        public System.Guid ID_планового_ремонта { get; set; }
        public System.Guid ID_работника { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime Дата_начала_ремонта { get; set; }
        public int Код_ремонта { get; set; }
        public int Код_экземпляра { get; set; }

        public virtual Работники Работники { get; set; }
        public virtual Типы_ремонта Типы_ремонта { get; set; }

        public virtual Экземпляры_оборудований Экземпляры_оборудований { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Журнал_выполненных_ремонтов> Журнал_выполненных_ремонтов { get; set; }
    }
}
