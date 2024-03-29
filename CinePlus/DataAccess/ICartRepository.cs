﻿using CinePlus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.DataAccess
{
    public interface ICartRepository
    {
        public Show GetShowById(string id);

        public List<ArmChairByRoom> GetArmChairsByRoomById(string roomId, string showId);

        public void AddCart(Cart cart);

        public int GetCartCout(string userId);

        public List<Cart> GetCartByUserId(string id);

        public void DeleteCartById(string id);

        public List<DiscountsByShow> GetDiscountsByShowId(string id);

        public double GetPointsByUserId(string id);

        public string GetPartnerCodeById(string id);

        public void UdateAddPointsPartner(string userId, double points);

        public void UdateRestPointsPartner(string userId, double points);

        public ArmChairByRoom GetArmChairByRoomById(string armChairId, string showId);

        public void AddArmChairByRoom(ArmChairByRoom armChairByRoom);

        public void UpdateArmChairByRoom(ArmChairByRoom armChairByRoom);

        public ArmChair GetArmChairById(string id);

        public UserBoughtArmChair GetUserBoughtArmChair(string showId, string userId, string armchairByRoomId);

        public void AddUserBoughtArmChair(UserBoughtArmChair userBoughtArmChair);

        public void AddPay(Pay pay);

        public Cart GetCartById(string id);

        public Discount GetDiscountById(string id);

        public void AddPayCart(PayCart pay);

        public DiscountsByShow GetDiscountByShowById(string id);

        public List<Pay> GetPayByUserIdAndPayCartId(string userId, string payCartId);

        public List<PayCart> GetPayCartByUserId(string id);

        public PayCart GetPayCartById(string id);

        public List<Cart> GetCartsByDate(DateTime date);

        public void DeleteUserBoughtArmChairByShowIdAndUserIdAndArmChairId(string showId, string userId, string armChairId);

        public PayCart GetPayCartByHashCode(string hash);

        public Partner GetPartnerByUserId(string userId);

        public void UpdatePartner(Partner partner);

        public void DeletePayCart(PayCart payCart);

        public void DeletePay(Pay pay);
    }
}
