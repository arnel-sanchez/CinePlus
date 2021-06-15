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
            if (string.IsNullOrEmpty(id))
                return NotFound();
            var res = new SelectArmChairResult
            {
                Show = CartRepository.GetShowById(id),
                ArmChairByRooms = CartRepository.GetArmChairsByRoomById(CartRepository.GetShowById(id).RoomId, id)
            };

            return View(res);
        }

        [Authorize]
        [Route("/Cart/AddArmChair",Name = "addCart")]
        public IActionResult AddArmChair(string armChairId, string showId)
        {
            if(string.IsNullOrEmpty(armChairId) || string.IsNullOrEmpty(showId))
            {
                return NotFound();
            }
            var discounts = CartRepository.GetDiscountsByShowId(showId);
            return View("SelectDiscount", new Tuple<string, string, List<DiscountsByShow>>(armChairId, showId, discounts));
        }
        
        [Authorize]
        [HttpPost]
        public IActionResult SelectDiscount(string armChairId, string showId,string discountByShowId)
        {
            if (string.IsNullOrEmpty(armChairId) || string.IsNullOrEmpty(showId) || string.IsNullOrEmpty(discountByShowId))
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
            var armChairByRoom = CartRepository.GetArmChairByRoomById(armChairId, showId);
            armChairByRoom.StateArmChair = StateArmChair.sold;
            CartRepository.UpdateArmChairByRoom(armChairByRoom);
            CartRepository.AddCart(cart);
            var discounstByShow = CartRepository.GetDiscountByShowById(discountByShowId);
            var userBouthArmChair = new UserBoughtArmChair
            {
                ShowId = discounstByShow.ShowId,
                Show = discounstByShow.Show,
                UserBoughtArmChairId = Guid.NewGuid().ToString(),
                UserId = UserManager.FindByNameAsync(User.Identity.Name).Result.Id,
                ArmChairByRoomId = CartRepository.GetArmChairByRoomById(armChairId, showId).ArmChairByRoomId
            };
            CartRepository.AddUserBoughtArmChair(userBouthArmChair);
            return RedirectToAction("SelectArmChair", new Dictionary<string, string> { { "id", discounstByShow.ShowId } });
        }

        [Authorize]
        public IActionResult QuitArmChair(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var cart = CartRepository.GetCartById(id);
            var armChairByRoom = CartRepository.GetArmChairByRoomById(cart.ArmChairId, cart.DiscountsByShow.ShowId);
            armChairByRoom.StateArmChair = StateArmChair.ready;
            CartRepository.UpdateArmChairByRoom(armChairByRoom);
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
                //descontar de la tarjeta del usuario
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
                    var armChairByRoom = CartRepository.GetArmChairByRoomById(item.ArmChairId, item.DiscountsByShow.ShowId);
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
                Logger.LogInformation("Pay with money.");
                return RedirectToAction("Index");
            }
            foreach (var error in ModelState.Values)
            {
                foreach (var item in error.Errors)
                {
                    Logger.LogError(item.ErrorMessage);
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = Roles.Partner)]
        [HttpPost]
        public IActionResult PayTicketWithPoints()
        {
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result;
            var partnerCode = CartRepository.GetPartnerCodeById(user.Id);
            var res = CartRepository.GetCartByUserId(user.Id);
            string hashValue = HasherCard.Hash(partnerCode);

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
                var armChairByRoom = CartRepository.GetArmChairByRoomById(item.ArmChairId, item.DiscountsByShow.ShowId);
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
                Logger.LogInformation("Pay with money.");
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
            if(string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result;
            var list = CartRepository.GetPayByUserIdAndPayCartId(user.Id, id);
            var export = new Export();
            return export.ExportToPDF(list);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CancelPay(long cardOrCode)
        {
            string hashValue = HasherCard.Hash(cardOrCode.ToString());
            var payCart = CartRepository.GetPayCartByHashCode(hashValue);
            if(payCart==null)
            {
                return RedirectToAction("GetPayCarts");
            }
            var user = UserManager.FindByNameAsync(User.Identity.Name).Result;
            var pays = CartRepository.GetPayByUserIdAndPayCartId(user.Id, payCart.PayCartId);
            if(user.Role==Roles.Partner && payCart.PayedPoints!=0)
            {
                var partner = CartRepository.GetPartnerByUserId(user.Id);
                partner.Points += payCart.PayedPoints;
                CartRepository.UpdatePartner(partner);
            }
            //devolver dinero
            CartRepository.DeletePayCart(payCart);
            foreach (var item in pays)
            {
                item.UserBoughtArmChair.ArmChairByRoom.StateArmChair = StateArmChair.ready;
                CartRepository.UpdateArmChairByRoom(item.UserBoughtArmChair.ArmChairByRoom);
                CartRepository.DeletePay(item);
            }
            return RedirectToAction("GetPayCarts");
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetCartCount()
        {
            return Ok(CartRepository.GetCartCout(UserManager.FindByNameAsync(User.Identity.Name).Result.Id));
        }
    }
}
