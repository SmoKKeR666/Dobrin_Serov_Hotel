//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dobrin_Serov_Hotel.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        public Client()
        {
            this.Booking = new HashSet<Booking>();
        }
    
        public int Id { get; set; }
        public string Fullname { get; set; }
    
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
