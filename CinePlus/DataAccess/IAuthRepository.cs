using CinePlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.DataAccess
{
    public interface IAuthRepository
    {
        public void CreatePartner(Partner partner);

        public Partner GetPartnerById(string userId);
    }
}
