using CinePlus.DataAccess;
using CinePlus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinePlus.Test.Mocks
{
    class FakeIAuthRepository : IAuthRepository
    {
        public void CreatePartner(Partner partner)
        {
            return;
        }

        public Partner GetPartnerById(string userId)
        {
            return new Partner { };
        }
    }
}
