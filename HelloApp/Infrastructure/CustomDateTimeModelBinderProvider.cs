using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;

namespace HelloApp.Infrastructure
{
    public class CustomDateTimeModelBinderProvider : IModelBinderProvider
    {
        // Содержит пользовательскую модель привязки
        private readonly IModelBinder binder =
            new CustomDateTimeModelBinder(new SimpleTypeModelBinder(typeof(DateTime)));

        // Метод, где можно получить тип данных, для которых выполняется привязка.
        // Если тип совпадает с запрашиваемым ему передаётся необходимая модель.
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            return context.Metadata.ModelType == typeof(DateTime) ? binder : null;
        }
    }
}
