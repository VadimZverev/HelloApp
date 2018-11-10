using Microsoft.AspNetCore.Mvc.ModelBinding; // пространство имен для использования привязок

namespace HelloApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [BindRequired] // атрибут используется для указания обязательного указания свойства
        public string Name { get; set; }
        public int Age { get; set; }

        [BindNever] // указывает, что свойства никогда не участвует в привязке(даже если указать данные).
        public bool HasRight { get; set; }
    }
}
