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

        public void AddCart(Cart cart)
        {
            _context.Carts.Add(cart);
            _context.SaveChanges();
        }

        public void DeleteCartById(string id)
        {
            var cart = _context.Carts.Where(x => x.CartId == id).FirstOrDefault();
            _context.Carts.Remove(cart);
            _context.SaveChanges();
        }

        public List<Cart> GetCartByUserId(string id)
        {
            return _context.Carts
                .Include(x => x.Show)
                .Include(x=>x.ArmChair)
                .Include(x=>x.Show.Movie)
                .Include(x=>x.Show.Room)
                .Where(x => x.UserId == id)
                .ToList();
        }

        public int GetCartCout(string userId)
        {
            return _context.Carts.Where(x => x.UserId == userId).Count();
        }

        public Show GetShowById(string id)
        {
            return _context.Show
                .Include(x => x.Room)
                .Include(x => x.Movie)
                .Where(x => x.ShowId == id)
                .FirstOrDefault();
        }

        public List<ArmChairByRoom> GetUserBoughtArmChairsByRoomId(string id)
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
    }
}
