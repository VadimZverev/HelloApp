using System.Collections.Generic;

namespace HelloApp.Models
{
    public interface IRepository
    {
        List<Phone> GetPhones();
    }
}
