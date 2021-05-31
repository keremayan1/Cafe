using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Cafe.Business.Adapters.Person
{
    public interface IKpsService
    {
        Task<bool> Verify(Entities.Concrete.Person person);
    }
}
