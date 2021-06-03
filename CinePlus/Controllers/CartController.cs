using CinePlus.DataAccess;
using CinePlus.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository CartRepository;
        private readonly UserManager<User> UserManager;

        public CartController(ICartRepository cartRepository, UserManager<User> userManager)
        {
            CartRepository = cartRepository;
            UserManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userId = UserManager.FindByNameAsync(User.Identity.Name).Result.Id;
            var res = CartRepository.GetCartByUserId(userId);
            return View(res);
        }

        public IActionResult SelectArmChair(string id)
        {
            if (id == null || id == "")
                return NotFound();
            var res = new SelectArmChairResult
            {
                Show = CartRepository.GetShowById(id),
                ArmChairByRooms = CartRepository.GetUserBoughtArmChairsByRoomId(CartRepository.GetShowById(id).RoomId)
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
            var cart = new Cart
            {
                ArmChairId = armChairId,
                CartId = Guid.NewGuid().ToString(),
                ShowId = showId,
                User = UserManager.FindByNameAsync(User.Identity.Name).Result
            };
            CartRepository.AddCart(cart);
            return RedirectToAction("SelectArmChair", new Dictionary<string, string> { { "id", showId} });
        }

        [Authorize]
        public IActionResult QuitArmChair(string id)
        {
            if (id == "" || id == null)
            {
                return NotFound();
            }
            CartRepository.DeleteCartById(id);
            return RedirectToAction("Index");
        }
    }
}
