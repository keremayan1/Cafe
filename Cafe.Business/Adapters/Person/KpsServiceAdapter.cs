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
        public async Task<bool> Verify(kullanici kullanici)
        {
            return await VerifyId(kullanici);
        }

        private static async Task<bool> VerifyId(kullanici kullanici)
        {
            var svc = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var cmd = await svc.TCKimlikNoDogrulaAsync(Convert.ToInt64(kullanici.NationalId), kullanici.Name.ToUpper(),
                kullanici.LastName.ToUpper(), kullanici.DateOfBirth.Year);
            return cmd.Body.TCKimlikNoDogrulaResult;
        }
    }
}
