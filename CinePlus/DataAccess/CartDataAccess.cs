using CinePlus.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.DataAccess
{
    public class CartDataAccess : ICartRepository
    {
        private readonly CinePlusDBContext _context;

        public CartDataAccess(CinePlusDBContext context)
        {
            _context = context;
        }

        public void AddArmChairByRoom(ArmChairByRoom armChairByRoom)
        {
            _context.ArmChairByRoom.Add(armChairByRoom);
            _context.SaveChanges();
        }

        public void AddCart(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
        }

        public void AddPay(Pay pay)
        {
            _context.Pay.Add(pay);
            _context.SaveChanges();
        }

        public void AddUserBoughtArmChair(UserBoughtArmChair userBoughtArmChair)
        {
            _context.UserBoughtArmChair.Add(userBoughtArmChair);
            _context.SaveChanges();
        }

        public void DeleteCartById(string id)
        {
            var cart = _context.Carts.Where(x => x.CartId == id).FirstOrDefault();
            _context.Carts.Remove(cart);
            _context.SaveChanges();
        }

        public ArmChair GetArmChairById(string id)
        {
            return _context.ArmChair
                .Where(x => x.ArmChairId == id)
                .FirstOrDefault();
        }

        public ArmChairByRoom GetArmChairByRoomById(string armChairId)
        {
            return _context.ArmChairByRoom
                .Where(x => x.ArmChairId == armChairId)
                .FirstOrDefault();
        }

        public List<Cart> GetCartByUserId(string id)
        {
            return _context.Carts
                .Include(x => x.DiscountsByShow.Show)
                .Include(x=>x.DiscountsByShow.Discount)
                .Include(x=>x.ArmChair)
                .Include(x=>x.DiscountsByShow.Show.Movie)
                .Include(x=>x.DiscountsByShow.Show.Room)
                .Where(x => x.UserId == id)
                .ToList();
        }

        public int GetCartCout(string userId)
        {
            return _context.Carts.Where(x => x.UserId == userId).Count();
        }

        public List<DiscountsByShow> GetDiscountsByShowId(string id)
        {
            return _context.DiscountsByShow.Include(x => x.Discount).Where(x => x.ShowId == id).ToList();
        }

        public double GetPointsByUserId(string id)
        {
            return _context.Partner.Where(x => x.UserId == id).FirstOrDefault().Points;
        }

        public string GetPartnerCodeById(string id)
        {
            return _context.Partner.Where(x => x.UserId == id).FirstOrDefault().Code;
        }

        public Show GetShowById(string id)
        {
            return _context.Show
                .Include(x => x.Room)
                .Include(x => x.Movie)
                .Where(x => x.ShowId == id)
                .FirstOrDefault();
        }

        public UserBoughtArmChair GetUserBoughtArmChair(string showId, string userId, string armchairByRoomId)
        {
            return _context.UserBoughtArmChair
                .Where(x => x.ShowId == showId)
                .Where(x => x.UserId == userId)
                .Where(x => x.ArmChairByRoomId == armchairByRoomId)
                .FirstOrDefault();
        }

        public List<ArmChairByRoom> GetArmChairsByRoomById(string id)
        {
            try
            {
                return _context.ArmChairByRoom
                    .Include(x => x.ArmChair)
                    .Include(x=>x.Room)
                    .Where(x => x.RoomId == id)
                    .OrderBy(x=>x.ArmChairId)
                    .ToList();
            }
            catch (Exception)
            {
                return new List<ArmChairByRoom>();
            }
        }

        public void UdateAddPointsPartner(string userId, double points)
        {
            var partner = _context.Partner.Where(x => x.UserId == userId).FirstOrDefault();
            partner.Points += points;
            _context.Partner.Update(partner);
            _context.SaveChanges();
        }

        public void UpdateArmChair(ArmChair armChair)
        {
            _context.ArmChair.Update(armChair);
            _context.SaveChanges();
        }

        public Cart GetCartById(string id)
        {
            return _context.Carts.Where(x => x.CartId == id).FirstOrDefault();
        }

        public Discount GetDiscountById(string id)
        {
            return _context.Discount.Where(x => x.DiscountId == id).FirstOrDefault();
        }

        public void AddPayCart(PayCart pay)
        {
            _context.PayCart.Add(pay);
            _context.SaveChanges();
        }

        public void UdateRestPointsPartner(string userId, double points)
        {
            var partner = _context.Partner.Where(x => x.UserId == userId).FirstOrDefault();
            partner.Points -= points;
            _context.Partner.Update(partner);
            _context.SaveChanges();
        }

        public DiscountsByShow GetDiscountByShowById(string id)
        {
            return _context.DiscountsByShow.Where(x => x.DiscountsByShowId == id).FirstOrDefault();
        }
    }
}
