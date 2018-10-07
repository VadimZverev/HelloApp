using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string User { get; set; }            // Имя Фамилия покупателя
        public string Address { get; set; }         // Адрес покупателя
        public string ContactPhone { get; set; }    // контактный телефон покупателя

        public int PhoneId { get; set; } // ссылка на связанную модель Phone
        public Phone Phone { get; set; }
    }
}
