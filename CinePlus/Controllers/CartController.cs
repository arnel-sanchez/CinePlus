using CinePlus.DataAccess;
using CinePlus.Models;
using CinePlus.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CinePlus.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository CartRepository;
        private readonly UserManager<User> UserManager;
        private readonly ILogger<CartController> Logger;

        public CartController(ILogger<CartController> logger, ICartRepository cartRepository, UserManager<User> userManager)
        {
            CartRepository = cartRepository;
            UserManager = userManager;
            Logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userId = UserManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var res = CartRepository.GetCartByUserId(userId);
            var list = new ListCartResult
            {
                Carts = res
            };
            if (User.IsInRole(Roles.Partner))
            {
                list.Points = CartRepository.GetPointsByUserId(userId);
                double total = 0;
                double points = 0;
                foreach (var item in res)
                {
                    if (item.DiscountsByShow.DiscountId != "ninguno")
                    {
                        var discount = CartRepository.GetDiscountById(item.DiscountsByShow.DiscountId);
                        total += item.DiscountsByShow.Show.Price - (item.DiscountsByShow.Show.Price * discount.Percent / 100);
                        points += item.DiscountsByShow.Show.PriceInPoints - (item.DiscountsByShow.Show.PriceInPoints * discount.Percent / 100);
                    }
                    else
                    {
                        total += item.DiscountsByShow.Show.Price;
                        points += item.DiscountsByShow.Show.PriceInPoints;
                    }
                }
                list.PointsTotals = points;
                list.CostMoney = total;
            }
            else
            {
                double total = 0;
                foreach (var item in res)
                {
                    if (item.DiscountsByShow.DiscountId != "ninguno")
                    {
                        var discount = CartRepository.GetDiscountById(item.DiscountsByShow.DiscountId);
                        total += item.DiscountsByShow.Show.Price - (item.DiscountsByShow.Show.Price * discount.Percent / 100);
                    }
                    else
                    {
                        total += item.DiscountsByShow.Show.Price;
                    }
                }
                list.CostMoney = total;
            }
            return View(list);
        }

        [Authorize]
        public IActionResult SelectArmChair(string id)
        {
            if (id == null || id == "")
                return NotFound();
            var res = new SelectArmChairResult
            {
                Show = CartRepository.GetShowById(id),
                ArmChairByRooms = CartRepository.GetArmChairsByRoomById(CartRepository.GetShowById(id).RoomId)
            };

            return View(res);
        }

        [Authorize]
        [Route("/Cart/AddArmChair",Name = "addCart")]
        public IActionResult AddArmChair(string armChairId, string showId)
        {
            if(armChairId=="" || armChairId==null || showId=="" || showId==null)
            {
                return NotFound();
            }
            var discounts = CartRepository.GetDiscountsByShowId(showId);
            return View("SelectDiscount", new Tuple<string, List<DiscountsByShow>>(armChairId, discounts));
        }
        
        [Authorize]
        public IActionResult SelectDiscount(string armChairId, string discountByShowId)
        {
            if (armChairId == "" || armChairId == null || discountByShowId == "" || discountByShowId == null)
            {
                return NotFound();
            }
            var cart = new Cart
            {
                ArmChairId = armChairId,
                CartId = Guid.NewGuid().ToString(),
                User = UserManager.FindByNameAsync(User.Identity.Name).Result,
                DiscountsByShowId = discountByShowId,
                DateTime = DateTime.Now
            };
            var armChair = CartRepository.GetArmChairById(armChairId);
            armChair.StateArmChair = StateArmChair.sold;
            CartRepository.UpdateArmChair(armChair);
            CartRepository.AddCart(cart);
            var discounstByShow = CartRepository.GetDiscountByShowById(discountByShowId);
            var userBouthArmChair = new UserBoughtArmChair
            {
                ShowId = discounstByShow.ShowId,
                Show = discounstByShow.Show,
                UserBoughtArmChairId = Guid.NewGuid().ToString(),
                UserId = UserManager.FindByNameAsync(User.Identity.Name).Result.Id,
                ArmChairByRoomId = CartRepository.GetArmChairByRoomById(armChairId).ArmChairByRoomId
            };
            CartRepository.AddUserBoughtArmChair(userBouthArmChair);
            return RedirectToAction("SelectArmChair", new Dictionary<string, string> { { "id", discounstByShow.ShowId } });
        }

        [Authorize]
        public IActionResult QuitArmChair(string id)
        {
            if (id == "" || id == null)
            {
                return NotFound();
            }
            var cart = CartRepository.GetCartById(id);
            var armChair = CartRepository.GetArmChairById(cart.ArmChairId);
            armChair.StateArmChair = StateArmChair.ready;
            CartRepository.UpdateArmChair(armChair);
            CartRepository.DeleteUserBoughtArmChairByShowIdAndUserIdAndArmChairId(cart.DiscountsByShow.ShowId, cart.UserId, cart.ArmChairId);
            CartRepository.DeleteCartById(id);
            return RedirectToAction("Index");
        }
        
        [Authorize]
        [HttpPost]
        public IActionResult PayTicketWithMoney(PayTicketRequest request)
        {
            if(ModelState.IsValid)
            {
                var user = UserManager.FindByNameAsync(User.Identity.Name).Result;
                var res = CartRepository.GetCartByUserId(user.Id);
                if (User.IsInRole(Roles.Partner))
                {
                    CartRepository.UdateAddPointsPartner(user.Id, res.Count * 5);
                }
                string hashValue = HasherCard.Hash(request.Card.ToString());

                double payed = 0;
                foreach (var item in res)
                {
                    if (item.DiscountsByShow.DiscountId != "ninguno")
                    {
                        var discount = CartRepository.GetDiscountById(item.DiscountsByShow.DiscountId);
                        payed += item.DiscountsByShow.Show.Price - (item.DiscountsByShow.Show.Price * discount.Percent / 100);
                    }
                    else
                    {
                        payed += item.DiscountsByShow.Show.Price;
                    }
                }

                var payCart = new PayCart
                {
                    DateTime = DateTime.Now,
                    UserId = user.Id,
                    CardHash = hashValue,
                    User = user,
                    PayCartId = Guid.NewGuid().ToString(),
                    PayedMoney = payed,
                    PayedPoints = 0
                };
                CartRepository.AddPayCart(payCart);
                foreach (var item in res)
                {
                    var armChairByRoom = CartRepository.GetArmChairByRoomById(item.ArmChairId);
                    var userBoughtArmChair = CartRepository.GetUserBoughtArmChair(item.DiscountsByShow.ShowId, user.Id, armChairByRoom.ArmChairByRoomId);
                    var pay = new Pay
                    {
                        PayId = Guid.NewGuid().ToString(),
                        PayCart = payCart,
                        PayCartId = payCart.PayCartId,
                        DiscountId = item.DiscountsByShow.DiscountId,
                        UserBoughtArmChair = userBoughtArmChair,
                        UserBougthArmChairId = userBoughtArmChair.UserBoughtArmChairId
                    };
                    CartRepository.AddPay(pay);
                    CartRepository.DeleteCartById(item.CartId);
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = Roles.Partner)]
        [HttpPost]
        public IActionResult PayTicketWithPoints()
        {
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result;
            var partner = CartRepository.GetPartnerCodeById(user.Id);
            var res = CartRepository.GetCartByUserId(user.Id);
            string hashValue = HasherCard.Hash(partner);

            double payed = 0;
            foreach (var item in res)
            {
                if (item.DiscountsByShow.DiscountId != "ninguno")
                {
                    var discount = CartRepository.GetDiscountById(item.DiscountsByShow.DiscountId);
                    payed += item.DiscountsByShow.Show.PriceInPoints - (item.DiscountsByShow.Show.PriceInPoints * discount.Percent / 100);
                }
                else
                {
                    payed += item.DiscountsByShow.Show.PriceInPoints;
                }
            }
            CartRepository.UdateRestPointsPartner(user.Id, payed);
            var payCart = new PayCart
            {
                DateTime = DateTime.Now,
                UserId = user.Id,
                CardHash = hashValue,
                User = user,
                PayCartId = Guid.NewGuid().ToString(),
                PayedPoints = payed,
                PayedMoney = 0
            };
            CartRepository.AddPayCart(payCart);
            foreach (var item in res)
            {
                var armChairByRoom = CartRepository.GetArmChairByRoomById(item.ArmChairId);
                var userBoughtArmChair = CartRepository.GetUserBoughtArmChair(item.DiscountsByShow.ShowId, user.Id, armChairByRoom.ArmChairByRoomId);
                var pay = new Pay
                {
                    PayId = Guid.NewGuid().ToString(),
                    PayCart = payCart,
                    PayCartId = payCart.PayCartId,
                    DiscountId = item.DiscountsByShow.DiscountId,
                    UserBoughtArmChair = userBoughtArmChair,
                    UserBougthArmChairId = userBoughtArmChair.UserBoughtArmChairId
                };
                CartRepository.AddPay(pay);
                CartRepository.DeleteCartById(item.CartId);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult GetPayCarts()
        {
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result;
            var payCarts = CartRepository.GetPayCartByUserId(user.Id);
            var list = new List<ListPayCart> { };
            foreach (var item in payCarts)
            {
                var temp = new ListPayCart { PayCart = item, Pays = CartRepository.GetPayByUserIdAndPayCartId(user.Id, item.PayCartId) };
                list.Add(temp);
            }
            return View(list);
        }

        [Authorize]
        public IActionResult Print(string id)
        {
            if(id == null || id == "")
            {
                return NotFound();
            }
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result;
            var list = CartRepository.GetPayByUserIdAndPayCartId(user.Id, id);
            var export = new Export();
            return export.ExportToPDF(list);
        }

        [Authorize]
        public IActionResult CancelPay(string id)
        {
            if (id == null || id == "")
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
