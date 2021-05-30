using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cafe.Entities.Concrete;

namespace Cafe.Business.Adapters.Person
{
    public interface IKpsService
    {
        Task<bool> Verify(kullanici kullanici);
    }
}
