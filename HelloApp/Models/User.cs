using Microsoft.AspNetCore.Mvc.ModelBinding; // пространство имен для использования привязок

namespace HelloApp.Models
{
    public class User
    {
        public int Id { get; set; }

        //[BindRequired] // атрибут используется для указания обязательного указания свойства
        [BindingBehavior(BindingBehavior.Required)] // аналогичное действие предыдущему
        public string Name { get; set; }

        [BindingBehavior(BindingBehavior.Optional)] // указывает на опциональность выбора
        public int Age { get; set; }

        //[BindNever] // указывает, что свойства никогда не участвует в привязке(даже если указать данные).
        [BindingBehavior(BindingBehavior.Never)] //аналогичное действие предыдущему
        public bool HasRight { get; set; }
    }
}
