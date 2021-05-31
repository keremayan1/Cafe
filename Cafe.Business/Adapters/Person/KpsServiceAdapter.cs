using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cafe.Entities.Concrete;
using KpsServiceReferance;

namespace Cafe.Business.Adapters.Person
{
  public  class KpsServiceAdapter:IKpsService
    {
        public async Task<bool> Verify(Entities.Concrete.Person person)
        {
            return await VerifyId(person);
        }

        private static async Task<bool> VerifyId(Entities.Concrete.Person person)
        {
            var svc = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var cmd = await svc.TCKimlikNoDogrulaAsync(Convert.ToInt64(person.NationalId), person.Name.ToUpper(),
                person.LastName.ToUpper(), person.DateOfBirth.Year);
            return cmd.Body.TCKimlikNoDogrulaResult;
        }
    }
}
