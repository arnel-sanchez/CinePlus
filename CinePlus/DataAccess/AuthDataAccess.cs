using CinePlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.DataAccess
{
    public class AuthDataAccess : IAuthRepository
    {
        private CinePlusDBContext _context;

        public AuthDataAccess(CinePlusDBContext context)
        {
            _context = context;
        }

        public void CreatePartner(Partner partner)
        {
            _context.Partner.Add(partner);
            _context.SaveChanges();
        }

        public Partner GetPartnerById(string userId)
        {
            return _context.Partner.Where(x => x.UserId == userId).First();
        }
    }
}
