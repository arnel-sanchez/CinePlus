using CinePlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.DataAccess
{
    public interface ICartRepository
    {
        public Show GetShowById(string id);

        public List<ArmChairByRoom> GetUserBoughtArmChairsByRoomId(string id);

        public void AddCart(Cart cart);

        public int GetCartCout(string userId);

        public List<Cart> GetCartByUserId(string id);

        public void DeleteCartById(string id);

        public List<DiscountsByShow> GetDiscountByShowId(string id);
    }
}
