using CinePlus.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Services
{
    public class SeedData
    {
        public static async Task CreateManagerAccount(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager =
            serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string name = configuration["Data:ManagerUser:Name"];
            string email = configuration["Data:ManagerUser:Email"];
            string lastName = configuration["Data:ManagerUser:LastName"];
            string userName = configuration["Data:ManagerUser:UserName"];
            string password = configuration["Data:ManagerUser:Password"];
            string role = configuration["Data:ManagerUser:Role"];
            var rol = new IdentityRole(role);
            if (await userManager.FindByNameAsync(userName) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(rol);
                }
                User user = new User
                {
                    UserName = userName,
                    Email = email,
                    LastName = lastName,
                    Name = name,
                    Role = await roleManager.GetRoleNameAsync(rol),
                    EmailConfirmed = true
                };
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }

        public static async Task CreateClientAndPartnerAccount(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager =
            serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string name = configuration["Data:PartnerUser:Name"];
            string email = configuration["Data:PartnerUser:Email"];
            string lastName = configuration["Data:PartnerUser:LastName"];
            string userName = configuration["Data:PartnerUser:UserName"];
            string password = configuration["Data:PartnerUser:Password"];
            string role = configuration["Data:PartnerUser:Role"];
            var rol = new IdentityRole(role);
            if (await userManager.FindByNameAsync(userName) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(rol);
                }
                User user = new User
                {
                    UserName = userName,
                    Email = email,
                    LastName = lastName,
                    Name = name,
                    Role = await roleManager.GetRoleNameAsync(rol),
                    EmailConfirmed = true
                };
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }

            name = configuration["Data:ClientUser:Name"];
            email = configuration["Data:ClientUser:Email"];
            lastName = configuration["Data:ClientUser:LastName"];
            userName = configuration["Data:ClientUser:UserName"];
            password = configuration["Data:ClientUser:Password"];
            role = configuration["Data:ClientUser:Role"];
            rol = new IdentityRole(role);
            if (await userManager.FindByNameAsync(userName) == null)
            {
                if (await roleManager.FindByNameAsync(role) == null)
                {
                    await roleManager.CreateAsync(rol);
                }
                User user = new User
                {
                    UserName = userName,
                    Email = email,
                    LastName = lastName,
                    Name = name,
                    Role = await roleManager.GetRoleNameAsync(rol),
                    EmailConfirmed = true
                };
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }

        public static async Task AddRoles(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            RoleManager<IdentityRole> roleManager =
            serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var rol = new List<IdentityRole> { new IdentityRole(Roles.Client), new IdentityRole(Roles.Manager), new IdentityRole(Roles.Partner) };
            for (int i = 0; i < rol.Count; i++)
            {
                if (await roleManager.FindByNameAsync(rol[i].Name) == null)
                {
                    await roleManager.CreateAsync(rol[i]);
                }
            }
        }

        public static void SeedDataBase(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<CinePlusDBContext>();
            if (!context.MovieType.Any())
            {
                var type = new MovieType
                {
                    Name = "Acción",
                    MovieTypeId = Guid.NewGuid().ToString()
                };
                context.MovieType.Add(type);
                context.SaveChanges();

                type = new MovieType
                {
                    Name = "Terror",
                    MovieTypeId = Guid.NewGuid().ToString()
                };
                context.MovieType.Add(type);
                context.SaveChanges();

                type = new MovieType
                {
                    Name = "Horror",
                    MovieTypeId = Guid.NewGuid().ToString()
                };
                context.MovieType.Add(type);
                context.SaveChanges();

                type = new MovieType
                {
                    Name = "Comedia",
                    MovieTypeId = Guid.NewGuid().ToString()
                };
                context.MovieType.Add(type);
                context.SaveChanges();

                type = new MovieType
                {
                    Name = "Drama",
                    MovieTypeId = Guid.NewGuid().ToString()
                };
                context.MovieType.Add(type);
                context.SaveChanges();

                type = new MovieType
                {
                    Name = "Aventura",
                    MovieTypeId = Guid.NewGuid().ToString()
                };
                context.MovieType.Add(type);
                context.SaveChanges();
            }
            
            if (!context.Movie.Any())
            {
                var movie = new Movie
                {
                    Name = "Rápido y Furioso I",
                    DateUpload = DateTime.Now,
                    Description = "Película de Carrera de Autos, protagonizada por Paul Walker and Vin Diesel.",
                    Director = "Rob Cohen",
                    MovieType = context.MovieType.Where(x=>x.Name == "Acción").FirstOrDefault(),
                    MovieTypeId = context.MovieType.Where(x => x.Name == "Acción").FirstOrDefault().MovieTypeId,
                    URL = "https://localhost:44304/img/movie.jpg",
                    MovieId = Guid.NewGuid().ToString()
                };
                context.Movie.Add(movie);
                context.SaveChanges();

                movie = new Movie
                {
                    Name = "Titanic",
                    DateUpload = DateTime.Now,
                    Description = "Película basada en hechos reales que relata los sucesos del zarpe, travesía y hundimiento del trasatlántico Titanic.",
                    Director = "James Cameron",
                    MovieType = context.MovieType.Where(x => x.Name == "Drama").FirstOrDefault(),
                    MovieTypeId = context.MovieType.Where(x => x.Name == "Drama").FirstOrDefault().MovieTypeId,
                    URL = "https://localhost:44304/img/movie.jpg",
                    MovieId = Guid.NewGuid().ToString()
                };
                context.Movie.Add(movie);
                context.SaveChanges();

                movie = new Movie
                {
                    Name = "The Curse of La Llorona",
                    DateUpload = DateTime.Now,
                    Description = "Es protagonizada por Linda Cardellini, Patricia Velásquez, Sean Patrick Thomas y Raymond Cruz.​ James Wan es el productor a través de su compañía Atomic Monster Productions.",
                    Director = "Michael Chaves",
                    MovieType = context.MovieType.Where(x => x.Name == "Terror").FirstOrDefault(),
                    MovieTypeId = context.MovieType.Where(x => x.Name == "Terror").FirstOrDefault().MovieTypeId,
                    URL = "https://localhost:44304/img/movie.jpg",
                    MovieId = Guid.NewGuid().ToString()
                };
                context.Movie.Add(movie);
                context.SaveChanges();

                movie = new Movie
                {
                    Name = "Ocho Apellidos Bascos",
                    DateUpload = DateTime.Now,
                    Description = "Relata la historia de amor entre una vasca y un sevillano a pesar de las diferencias políticas y culturales.",
                    Director = "Emilio Martínez-Lázaro",
                    MovieType = context.MovieType.Where(x => x.Name == "Comedia").FirstOrDefault(),
                    MovieTypeId = context.MovieType.Where(x => x.Name == "Comedia").FirstOrDefault().MovieTypeId,
                    URL = "https://localhost:44304/img/movie.jpg",
                    MovieId = Guid.NewGuid().ToString()
                };
                context.Movie.Add(movie);
                context.SaveChanges();

                movie = new Movie
                {
                    Name = "Harry Potter I",
                    DateUpload = DateTime.Now,
                    Description = "Relata la historia de un mago en la escuela de Howarts.",
                    Director = "Chris Columbus",
                    MovieType = context.MovieType.Where(x => x.Name == "Comedia").FirstOrDefault(),
                    MovieTypeId = context.MovieType.Where(x => x.Name == "Comedia").FirstOrDefault().MovieTypeId,
                    URL = "https://localhost:44304/img/movie.jpg",
                    MovieId = Guid.NewGuid().ToString()
                };
                context.Movie.Add(movie);
                context.SaveChanges();
            }

            if (!context.Top10.Any())
            {
                var top = new Top10
                {
                    Name = "Las más vistas",
                    Top10Id = Guid.NewGuid().ToString()
                };
                context.Top10.Add(top);
                context.SaveChanges();
            }

            if(!context.MovieOnTop10.Any())
            {
                var movieOnTop10 = new MovieOnTop10
                {
                    MovieOnTop10Id = Guid.NewGuid().ToString(),
                    Top10 = context.Top10.Where(x=>x.Name == "Las más vistas").FirstOrDefault(),
                    Top10Id = context.Top10.Where(x => x.Name == "Las más vistas").FirstOrDefault().Top10Id,
                    Movie = context.Movie.Where(x => x.Name == "Rápido y Furioso I").FirstOrDefault(),
                    MovieId = context.Movie.Where(x => x.Name == "Rápido y Furioso I").FirstOrDefault().MovieId,
                };
                context.MovieOnTop10.Add(movieOnTop10);
                context.SaveChanges();

                movieOnTop10 = new MovieOnTop10
                {
                    MovieOnTop10Id = Guid.NewGuid().ToString(),
                    Top10 = context.Top10.Where(x => x.Name == "Las más vistas").FirstOrDefault(),
                    Top10Id = context.Top10.Where(x => x.Name == "Las más vistas").FirstOrDefault().Top10Id,
                    Movie = context.Movie.Where(x => x.Name == "Titanic").FirstOrDefault(),
                    MovieId = context.Movie.Where(x => x.Name == "Titanic").FirstOrDefault().MovieId,
                };
                context.MovieOnTop10.Add(movieOnTop10);
                context.SaveChanges();

                movieOnTop10 = new MovieOnTop10
                {
                    MovieOnTop10Id = Guid.NewGuid().ToString(),
                    Top10 = context.Top10.Where(x => x.Name == "Las más vistas").FirstOrDefault(),
                    Top10Id = context.Top10.Where(x => x.Name == "Las más vistas").FirstOrDefault().Top10Id,
                    Movie = context.Movie.Where(x => x.Name == "The Curse of La Llorona").FirstOrDefault(),
                    MovieId = context.Movie.Where(x => x.Name == "The Curse of La Llorona").FirstOrDefault().MovieId,
                };
                context.MovieOnTop10.Add(movieOnTop10);
                context.SaveChanges();

                movieOnTop10 = new MovieOnTop10
                {
                    MovieOnTop10Id = Guid.NewGuid().ToString(),
                    Top10 = context.Top10.Where(x => x.Name == "Las más vistas").FirstOrDefault(),
                    Top10Id = context.Top10.Where(x => x.Name == "Las más vistas").FirstOrDefault().Top10Id,
                    Movie = context.Movie.Where(x => x.Name == "Ocho Apellidos Bascos").FirstOrDefault(),
                    MovieId = context.Movie.Where(x => x.Name == "Ocho Apellidos Bascos").FirstOrDefault().MovieId,
                };
                context.MovieOnTop10.Add(movieOnTop10);
                context.SaveChanges();

                movieOnTop10 = new MovieOnTop10
                {
                    MovieOnTop10Id = Guid.NewGuid().ToString(),
                    Top10 = context.Top10.Where(x => x.Name == "Las más vistas").FirstOrDefault(),
                    Top10Id = context.Top10.Where(x => x.Name == "Las más vistas").FirstOrDefault().Top10Id,
                    Movie = context.Movie.Where(x => x.Name == "Harry Potter I").FirstOrDefault(),
                    MovieId = context.Movie.Where(x => x.Name == "Harry Potter I").FirstOrDefault().MovieId,
                };
                context.MovieOnTop10.Add(movieOnTop10);
                context.SaveChanges();
            }

            if(!context.Show.Any())
            {
                var room = new Room
                {
                    RoomId = Guid.NewGuid().ToString(),
                    Name = "Principal",
                    NoArmChairs = 200
                };
                for (int i = 0; i < 200; i++)
                {
                    string id = "";
                    if (i + 1 < 10)
                        id = "00" + (i+1).ToString();
                    else if (i + 1 < 100)
                        id = "0" + (i+i).ToString();
                    var armChair = new ArmChair
                    {
                        ArmChairId = id+"-"+Guid.NewGuid().ToString(),
                        No = (i+1).ToString(),
                        StateArmChair = StateArmChair.ready,
                    };
                    var armChairByRoom = new ArmChairByRoom
                    {
                        ArmChair = armChair,
                        ArmChairByRoomId = Guid.NewGuid().ToString(),
                        ArmChairId = armChair.ArmChairId,
                        Room = room,
                        RoomId = room.RoomId
                    };
                    context.ArmChair.Add(armChair);
                    context.ArmChairByRoom.Add(armChairByRoom);
                    context.SaveChanges();
                }
                var discount = new Discount
                {
                    DiscountId = Guid.NewGuid().ToString(),
                    Name = "Estudiantes de la FEU",
                    Percent = 50
                };
                var show = new Show
                {
                    Room = room,
                    RoomId = room.RoomId,
                    DateTime = DateTime.Now,
                    Price = 50,
                    ShowId = Guid.NewGuid().ToString(),
                    Movie = context.Movie.Where(x => x.Name == "Rápido y Furioso I").FirstOrDefault(),
                    MovieId = context.Movie.Where(x => x.Name == "Rápido y Furioso I").FirstOrDefault().MovieId
                };
                var discountByShow = new DiscountsByShow
                {
                    Discount = discount,
                    DiscountId = discount.DiscountId,
                    DiscountsByShowId = Guid.NewGuid().ToString(),
                    Show = show,
                    ShowId = show.ShowId
                };
                
                context.Discount.Add(discount);
                context.Show.Add(show);
                context.DiscountsByShow.Add(discountByShow);
                context.SaveChanges();

                show = new Show
                {
                    Room = room,
                    RoomId = room.RoomId,
                    DateTime = DateTime.Now,
                    Price = 20,
                    ShowId = Guid.NewGuid().ToString(),
                    Movie = context.Movie.Where(x => x.Name == "Titanic").FirstOrDefault(),
                    MovieId = context.Movie.Where(x => x.Name == "Titanic").FirstOrDefault().MovieId
                };
                discountByShow = new DiscountsByShow
                {
                    Discount = discount,
                    DiscountId = discount.DiscountId,
                    DiscountsByShowId = Guid.NewGuid().ToString(),
                    Show = show,
                    ShowId = show.ShowId
                };

                context.Show.Add(show);
                context.DiscountsByShow.Add(discountByShow);
                context.SaveChanges();

                show = new Show
                {
                    Room = room,
                    RoomId = room.RoomId,
                    DateTime = DateTime.Now,
                    Price = 20,
                    ShowId = Guid.NewGuid().ToString(),
                    Movie = context.Movie.Where(x => x.Name == "The Curse of La Llorona").FirstOrDefault(),
                    MovieId = context.Movie.Where(x => x.Name == "The Curse of La Llorona").FirstOrDefault().MovieId
                };
                discountByShow = new DiscountsByShow
                {
                    Discount = discount,
                    DiscountId = discount.DiscountId,
                    DiscountsByShowId = Guid.NewGuid().ToString(),
                    Show = show,
                    ShowId = show.ShowId
                };

                context.Show.Add(show);
                context.DiscountsByShow.Add(discountByShow);
                context.SaveChanges();

                show = new Show
                {
                    Room = room,
                    RoomId = room.RoomId,
                    DateTime = DateTime.Now,
                    Price = 20,
                    ShowId = Guid.NewGuid().ToString(),
                    Movie = context.Movie.Where(x => x.Name == "Ocho Apellidos Bascos").FirstOrDefault(),
                    MovieId = context.Movie.Where(x => x.Name == "Ocho Apellidos Bascos").FirstOrDefault().MovieId
                };
                discountByShow = new DiscountsByShow
                {
                    Discount = discount,
                    DiscountId = discount.DiscountId,
                    DiscountsByShowId = Guid.NewGuid().ToString(),
                    Show = show,
                    ShowId = show.ShowId
                };

                context.Show.Add(show);
                context.DiscountsByShow.Add(discountByShow);
                context.SaveChanges();

                show = new Show
                {
                    Room = room,
                    RoomId = room.RoomId,
                    DateTime = DateTime.Now,
                    Price = 20,
                    ShowId = Guid.NewGuid().ToString(),
                    Movie = context.Movie.Where(x => x.Name == "Harry Potter I").FirstOrDefault(),
                    MovieId = context.Movie.Where(x => x.Name == "Harry Potter I").FirstOrDefault().MovieId
                };
                discountByShow = new DiscountsByShow
                {
                    Discount = discount,
                    DiscountId = discount.DiscountId,
                    DiscountsByShowId = Guid.NewGuid().ToString(),
                    Show = show,
                    ShowId = show.ShowId
                };

                context.Show.Add(show);
                context.DiscountsByShow.Add(discountByShow);
                context.SaveChanges();
            }
        }
    }
}
