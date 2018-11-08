using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloApp.Models
{
    public interface IRepository
    {
        List<Phone> GetPhones();
    }
}
