using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace HelloApp.Infrastructure
{
    public class CustomDateTimeModelBinder : IModelBinder // наследуется для реализации метода привязки модели
    {
        // поле, необходимое для срабатывания если необходимые данные в запросе отсуттвуют
        private readonly IModelBinder fallbackBinder;
        public CustomDateTimeModelBinder(IModelBinder fallbackBinder)
        {
            this.fallbackBinder = fallbackBinder;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // в случае ошибки возвращаем исключение
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            // с помощью поставщика значений получаем данные из запроса
            var datePartValues = bindingContext.ValueProvider.GetValue("Date");
            var timePartValues = bindingContext.ValueProvider.GetValue("Time");

            // если не найдено значений с данными ключами, вызываем привязчик модели по умолчанию
            if (datePartValues == ValueProviderResult.None ||
                    timePartValues == ValueProviderResult.None)
            {
                return fallbackBinder.BindModelAsync(bindingContext);
            }

            // получаем зачения
            string date = datePartValues.FirstValue;
            string time = timePartValues.FirstValue;

            // Парсим дату и время
            DateTime.TryParse(date, out var parsedDateValue);
            DateTime.TryParse(time, out var parsedTimeValue);

            // Объединяем полученые значения в одном объекте
            var result = new DateTime(parsedDateValue.Year,
                            parsedDateValue.Month,
                            parsedDateValue.Day,
                            parsedTimeValue.Hour,
                            parsedTimeValue.Minute,
                            parsedTimeValue.Second);

            // устанавливаем результат привязки
            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
}
