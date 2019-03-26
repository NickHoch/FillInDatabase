using Bogus;
using System;
using System.Collections.Generic;
using WebSiteCore.DAL.Entities;

namespace InitHotelDb
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var _ctx = new EFDbContext())
            {
                var conviences = new List<ConvenienceType>();
                var faker = new Faker("en");
                _ctx.ConvenienceTypes.AddRange(
                    new ConvenienceType { Name = "Standart" },
                    new ConvenienceType { Name = "Superior" },
                    new ConvenienceType { Name = "Junior suite" }
                );
                _ctx.RoomTypes.AddRange(
                    new RoomType { Name = "Single" },
                    new RoomType { Name = "Twin" },
                    new RoomType { Name = "Double room" }
                );
                _ctx.Floors.AddRange(
                    new Floor { Number = 1, Description = "Administrative floor" },
                    new Floor { Number = 2, Description = "Standart floor" },
                    new Floor { Number = 3, Description = "Luxurious floor" }
                );

                var apartIds = 1;
                var apartmentsName = new[] { "Family Standart", "Single Standart", "Studio Double", "DBL Standart", "Twin Standart", "Superior Double", "Junior Suite(with min-kitchen)" };
                var apartGenerator = new Faker<Apartment>()
                                        .StrictMode(false)
                                        //.RuleFor(a => a.Id, f => apartIds++)
                                        .RuleFor(a => a.Name, f => f.PickRandom(apartmentsName))
                                        .RuleFor(a => a.Description, f => f.Lorem.Sentence())
                                        .RuleFor(a => a.Equipment, f => f.Lorem.Sentence())
                                        .RuleFor(a => a.Area, f => f.Random.Number(20, 80))
                                        .RuleFor(a => a.Price, f => f.Random.Number(120, 250))
                                        .RuleFor(a => a.RoomQuantity, f => f.Random.Number(1, 2))
                                        .RuleFor(a => a.ConvenienceTypeId, f => f.Random.Number(1, 3))
                                        .RuleFor(a => a.RoomTypeId, f => f.Random.Number(1, 3))
                                        .RuleFor(a => a.FloorId, f => f.Random.Number(2, 3));
                _ctx.AddRange(apartGenerator.Generate(200000).ToArray());
                Console.WriteLine("Bingo1!");
                //apartIds = 1;
                //var imageId = 1;
                var imageGenerator = new Faker<ApartmentImage>()
                                        .StrictMode(false)
                                        .RuleFor(i => i.Name, f => f.Lorem.Sentence())
                                        //.RuleFor(i => i.Id, f => imageId++)
                                        .RuleFor(i => i.AppartmentId, apartIds%3 == 0 ? ++apartIds : apartIds);
                _ctx.ApartmentImages.AddRange(imageGenerator.Generate(400000).ToArray());
                Console.WriteLine("Bingo2!");
                _ctx.SaveChanges();
            }
            Console.WriteLine("Bingo3!");
        }
    }
}
