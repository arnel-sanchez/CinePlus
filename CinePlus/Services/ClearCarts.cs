using CinePlus.DataAccess;
using CinePlus.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Services
{
    [DisallowConcurrentExecution]
    public class ClearCarts : IJob
    {
        private readonly ILogger<ClearCarts> _logger;
        private readonly ICartRepository _cartRepository;

        public ClearCarts(ILogger<ClearCarts> logger, ICartRepository cartRepository)
        {
            _logger = logger;
            _cartRepository = cartRepository;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var cart = _cartRepository.GetCartsByDate(DateTime.Now);
            foreach (var item in cart)
            {
                item.ArmChair.StateArmChair = Models.StateArmChair.ready;
                _cartRepository.UpdateArmChair(item.ArmChair);
                _cartRepository.DeleteCartById(item.CartId);
                _cartRepository.DeleteUserBoughtArmChairByShowIdAndUserIdAndArmChairId(item.DiscountsByShow.ShowId, item.UserId, item.ArmChairId);
                _logger.LogInformation($"Se eliminó del carrito del usuario [{item.User.UserName}] el asiento {item.ArmChair.No}.");
            }
            return Task.CompletedTask;
        }
    }
}
