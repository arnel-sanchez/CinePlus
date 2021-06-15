using System;
using System.Collections.Generic;
using System.Text;
using CinePlus.DataAccess;
using CinePlus.Models;

namespace CinePlusXUnit.Mocks
{
    class FakeCardReposity:ICartRepository
    {
        public Show GetShowById(string id)
        {
            return new Show();
        }

        public List<ArmChairByRoom> GetArmChairsByRoomById(string id)
        {
            return new List<ArmChairByRoom>();
        }

        public void AddCart(Cart cart)
        {
           
        }

        public int GetCartCout(string userId)
        {
            return 1;
        }

        public List<Cart> GetCartByUserId(string id)
        {
            return new List<Cart>();
        }

        public void DeleteCartById(string id)
        {
            
        }

        public List<DiscountsByShow> GetDiscountsByShowId(string id)
        {
            return new List<DiscountsByShow>();
        }

        public double GetPointsByUserId(string id)
        {
            return 0;
        }

        public string GetPartnerCodeById(string id)
        {
            return "";
        }

        public void UdateAddPointsPartner(string userId, double points)
        {
            throw new NotImplementedException();
        }

        public void UdateRestPointsPartner(string userId, double points)
        {
           
        }

        public ArmChairByRoom GetArmChairByRoomById(string armChairId)
        {
            return new ArmChairByRoom();
        }

        public void AddArmChairByRoom(ArmChairByRoom armChairByRoom)
        {
            throw new NotImplementedException();
        }

        public void UpdateArmChair(ArmChair armChair)
        {
            
        }

        public ArmChair GetArmChairById(string id)
        {
            return new ArmChair();
        }

        public UserBoughtArmChair GetUserBoughtArmChair(string showId, string userId, string armchairByRoomId)
        {
            throw new NotImplementedException();
        }

        public void AddUserBoughtArmChair(UserBoughtArmChair userBoughtArmChair)
        {
           
        }

        public void AddPay(Pay pay)
        {
            throw new NotImplementedException();
        }

        public Cart GetCartById(string id)
        {
            if (id == "acceptedNotNullOrEmptyQuitArmChair")
            {
                Cart cart = new Cart()
                {
                    UserId = Guid.NewGuid().ToString(),
                    ArmChairId = Guid.NewGuid().ToString(),
                    DiscountsByShow = new DiscountsByShow() {Show = new Show()}
                };

                return cart;
            }
            
            return new Cart();

        }

        public Discount GetDiscountById(string id)
        {
            return new Discount();
        }

        public void AddPayCart(PayCart pay)
        {
            
        }

        public DiscountsByShow GetDiscountByShowById(string id)
        {
            return new DiscountsByShow();
        }

        public List<Pay> GetPayByUserIdAndPayCartId(string userId, string payCartId)
        {
            string newPayCartId = Guid.NewGuid().ToString();
            string PayId = Guid.NewGuid().ToString();
            string discoutID = Guid.NewGuid().ToString();
            string movieID = Guid.NewGuid().ToString();
            string movieTypeID = Guid.NewGuid().ToString();
            string room1ID = Guid.NewGuid().ToString();
            string room2ID = Guid.NewGuid().ToString();
            string showID = Guid.NewGuid().ToString();
            string armChairID = Guid.NewGuid().ToString();
            string armChairByRoomID = Guid.NewGuid().ToString();
            string userBoughtArmChairID = Guid.NewGuid().ToString();

            User user = new User
            {
                Role = Roles.Client,
                Name = "Valid",
                LastName = ":)"
            };


            PayCart payCart = new PayCart()
            {
                User = user,
                CardHash = "zwxXyz",
                DateTime = DateTime.Now,
                PayCartId = newPayCartId,
                PayedMoney = 1,
                PayedPoints = 1,
                UserId = Guid.NewGuid().ToString()


            };

            MovieType movieType1 = new MovieType()
            {
                MovieTypeId =Guid.NewGuid().ToString(),
                Name = "Crime"
            };

            Movie movie = new Movie()
            {
                MovieId = movieID,
                DateUpload = DateTime.Now,
                Name ="The Godfather",
                Description = "An organized crime dynasty's aging patriarch transfers control of his clandestine empire to his reluctant son.",
                Director = "Francis Ford Coppola",
                URL = "https://localhost:44304/img/movie.jpg",
                MovieType = movieType1,
                MovieTypeId = movieTypeID
            };

            Room room1 = new Room()
            {
                RoomId = room1ID,
                Name = "2B",
                NoArmChairs = 1
            };

            Room room2 = new Room()
            {
                RoomId = room2ID,
                Name = "A1",
                NoArmChairs = 2
            };

            Show show = new Show()
            {
                ShowId = showID,
                DateTime = DateTime.Now,
                Movie = movie,
                MovieId = movieID,
                Price = 1,
                PriceInPoints = 1,
                Room = room1,
                RoomId = room1ID
            };

            ArmChair armChair = new ArmChair()
            {
                ArmChairId = armChairID,
                No = 2
            };

            ArmChairByRoom armChairByRoom = new ArmChairByRoom()
            {
                ArmChairByRoomId = armChairByRoomID,
                ArmChairId = armChairID,
                ArmChair = armChair,
                RoomId = room2ID,
                Room = room2,
                StateArmChair = StateArmChair.ready,
                Show = show,
                ShowId = show.ShowId
            };

            UserBoughtArmChair userBoughtArmChair = new UserBoughtArmChair()
            {
                UserBoughtArmChairId = userBoughtArmChairID,
                ArmChairByRoomId = armChairByRoomID,
                ArmChairByRoom = armChairByRoom,
                ShowId = showID,
                Show = show,
                UserId = userId,
                User = user
            };

            Discount discount1 = new Discount()
            {
                DiscountId = discoutID,
                Name = "Black Friday",
                Percent = 15
            };



            Pay pay = new Pay()
            {
                PayId =PayId,
                PayCartId = newPayCartId,
                DiscountId = discoutID,
                Discount = discount1,
                PayCart = payCart,
                UserBougthArmChairId = userBoughtArmChairID,
                UserBoughtArmChair = userBoughtArmChair

                
            };


            List<Pay> pays = new List<Pay>();
            pays.Add(pay);
            
            return pays ;
        }

        public List<PayCart> GetPayCartByUserId(string id)
        {
            return new List<PayCart>();
        }

        public PayCart GetPayCartById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Cart> GetCartsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserBoughtArmChairByShowIdAndUserIdAndArmChairId(string showId, string userId, string armChairId)
        {
            
        }

        public PayCart GetPayCartByHashCode(string hash)
        {
            if (hash == "伽�鑽購冝狃䪪䬐풽舠\u18acꅦ썭ﺙ伽")
                return null;
            User user = new User
            {
                Role = Roles.Client,
                Name = "Valid",
                LastName = ":)"
            };
            PayCart payCart = new PayCart()
            {
                User = user,
                CardHash = "fghca",
                DateTime = DateTime.Now,
                PayCartId = Guid.NewGuid().ToString(),
                PayedMoney = 2,
                PayedPoints = 1
            };

            return payCart;
        }

        public Partner GetPartnerByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public void UpdatePartner(Partner partner)
        {
            throw new NotImplementedException();
        }

        public void DeletePayCart(PayCart payCart)
        {
            
        }

        public void DeletePay(Pay pay)
        {
            
        }

        public List<ArmChairByRoom> GetArmChairsByRoomById(string roomId, string showId)
        {
            return new List<ArmChairByRoom>();
        }

        public ArmChairByRoom GetArmChairByRoomById(string armChairId, string showId)
        {
            return new ArmChairByRoom();
        }

        public void UpdateArmChairByRoom(ArmChairByRoom armChairByRoom)
        {
            
        }
    }
}
