#nullable disable warnings

using Microsoft.EntityFrameworkCore;
using WatersportsManager.Application.Persistence.Configurations;
using WatersportsManager.Domain;

namespace WatersportsManager.Application.Persistence
{
    public class WatersportsManagerDbContext : DbContext
    {
        public DbSet<Reservation> Boats { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<TimeType> TimeTypes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<BoatType> BoatTypes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<PriorityType> PriorityTpes { get; set; }
        public DbSet<Report> Reports { get; set; }

        public WatersportsManagerDbContext(DbContextOptions<WatersportsManagerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RoleModels(modelBuilder);
            LocationModels(modelBuilder);
            TimeTypeModels(modelBuilder);
            PriceModels(modelBuilder);
            BoatTypeModels(modelBuilder);
            ReservationModels(modelBuilder);
            PersonModels(modelBuilder);
            ReviewModels(modelBuilder);
            PriorityTypeModels(modelBuilder);
            ReportModels(modelBuilder);

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BoatTypeConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BoatConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PriceConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReportConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReviewConfiguration).Assembly);
        }

        private static void RoleModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                            new Role()
                            {
                                Id = 1,
                                Code = "USER"
                            },
                            new Role()
                            {
                                Id = 2,
                                Code = "ADMIN"
                            });
        }

        private static void LocationModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(
                            new Location()
                            {
                                Id = 1,
                                City = "Rovinj",
                                Camp = "Amarin",
                                Latitude = 45.1024,
                                Longitude = 13.6245
                            },
                            new Location()
                            {
                                Id = 2,
                                City = "Rovinj",
                                Camp = "Veštar",
                                Latitude = 45.0450,
                                Longitude = 13.6778
                            },
                            new Location()
                            {
                                Id = 3,
                                City = "Rovinj",
                                Camp = "Vilas",
                                Latitude = 45.0620,
                                Longitude = 13.6635
                            },
                            new Location()
                            {
                                Id = 4,
                                City = "Poreč",
                                Camp = "Lanterna",
                                Latitude = 45.2970,
                                Longitude = 13.5944
                            });
        }

        private static void TimeTypeModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeType>().HasData(
                            new TimeType()
                            {
                                Id = 1,
                                Type = "15 Min"
                            },
                            new TimeType()
                            {
                                Id = 2,
                                Type = "30 Min"
                            },
                            new TimeType()
                            {
                                Id = 3,
                                Type = "60 Min"
                            },
                            new TimeType()
                            {
                                Id = 4,
                                Type = "1/2 Day"
                            },
                            new TimeType()
                            {
                                Id = 5,
                                Type = "1 Day"
                            },
                            new TimeType()
                            {
                                Id = 6,
                                Type = "Sunset"
                            });
        }

        private static void PriceModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Price>().HasData(
                            new Price()
                            {
                                Id = 1,
                                TimeTypeId = 1,
                                Value = 50
                            },
                            new Price()
                            {
                                Id = 2,
                                TimeTypeId = 2,
                                Value = 70
                            },
                            new Price()
                            {
                                Id = 3,
                                TimeTypeId = 3,
                                Value = 100
                            },
                            new Price()
                            {
                                Id = 4,
                                TimeTypeId = 4,
                                Value = 70
                            },
                            new Price()
                            {
                                Id = 5,
                                TimeTypeId = 5,
                                Value = 120
                            },
                            new Price()
                            {
                                Id = 6,
                                TimeTypeId = 6,
                                Value = 150
                            },
                            new Price()
                            {
                                Id = 7,
                                TimeTypeId = 4,
                                Value = 150
                            },
                            new Price()
                            {
                                Id = 8,
                                TimeTypeId = 5,
                                Value = 200
                            });
        }

        private static void BoatTypeModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoatType>().HasData(
                            new BoatType()
                            {
                                Id = 1,
                                PriceId = 5,
                                Name = "Pasara",
                                Registration = "RV324",
                                Length = 6,
                                MaxCapacity = 5,
                                HorsePower = 5,
                                FuelPercentage = 100,
                                LifeJackets = 5,
                                IsFunctional = true
                            },
                            new BoatType()
                            {
                                Id = 2,
                                PriceId = 4,
                                Name = "Pasara",
                                Registration = "RV372",
                                Length = 6,
                                MaxCapacity = 5,
                                HorsePower = 5,
                                FuelPercentage = 100,
                                LifeJackets = 5,
                                IsFunctional = true
                            },
                            new BoatType()
                            {
                                Id = 3,
                                PriceId = 4,
                                Name = "Pasara",
                                Registration = "RV826",
                                Length = 6,
                                MaxCapacity = 5,
                                HorsePower = 5,
                                FuelPercentage = 100,
                                LifeJackets = 5,
                                IsFunctional = true
                            },
                            new BoatType()
                            {
                                Id = 4,
                                PriceId = 5,
                                Name = "Pasara",
                                Registration = "RV437",
                                Length = 6,
                                MaxCapacity = 5,
                                HorsePower = 5,
                                FuelPercentage = 100,
                                LifeJackets = 5,
                                IsFunctional = true
                            },
                            new BoatType()
                            {
                                Id = 5,
                                PriceId = 7,
                                Name = "QS 675",
                                Registration = "RV652",
                                Length = 6.75,
                                MaxCapacity = 8,
                                HorsePower = 120,
                                FuelPercentage = 100,
                                LifeJackets = 10,
                                IsFunctional = true
                            },
                            new BoatType()
                            {
                                Id = 6,
                                PriceId = 5,
                                Name = "QS 600",
                                Registration = "RV354",
                                Length = 6,
                                MaxCapacity = 5,
                                HorsePower = 100,
                                FuelPercentage = 100,
                                LifeJackets = 7,
                                IsFunctional = true
                            },
                            new BoatType()
                            {
                                Id = 7,
                                PriceId = 5,
                                Name = "Fisher",
                                Registration = "RV917",
                                Length = 5,
                                MaxCapacity = 5,
                                HorsePower = 60,
                                FuelPercentage = 70,
                                LifeJackets = 5,
                                IsFunctional = false
                            });
        }

        private static void PersonModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                            new Person()
                            {
                                Id = 1,
                                RoleId = 1,
                                LocationId = 1,
                                FirstName = "Dino",
                                LastName = "Pejić",
                                IsSkipper = true,
                                Username = "dpejic",
                                Password = "cc/fPftYw6FMM2JUEAwTCVWTbkduQUB/OGjg6fBq24KRtcVg",
                                Token = "",
                                Email = "dinop@gmail.com"

                            },
                            new Person()
                            {
                                Id = 2,
                                RoleId = 2,
                                LocationId = 2,
                                FirstName = "Luka",
                                LastName = "Simić",
                                IsSkipper = true,
                                Username = "lsimic",
                                Password = "+0NdS3qrFh/2fG4DjeVv+0f8Mmjz2qUZcpUsmJo093i3JHMG",
                                Token = "",
                                Email = "lukas@gmail.com"
                            },
                            new Person()
                            {
                                Id = 3,
                                RoleId = 2,
                                FirstName = "Marko",
                                LastName = "Galiman",
                                IsSkipper = false,
                                Username = "mgaliman",
                                Password = "+ISSutLrMesoLKQdNXlR3LMGD2AqRLN9Y9gjaN4G8mmZ9xKI",
                                Token = "",
                                Email = "markog@gmail.com"
                            },
                            new Person()
                            {
                                Id = 4,
                                RoleId = 1,
                                FirstName = "Ivo",
                                LastName = "Ivic",
                                IsSkipper = false,
                                Username = "iivic",
                                Password = "2brs42UnA7pVKmMkONMmlfRGXbC7zjgRi0QVK+KuLDjFfoI3",
                                Token = "",
                                Email = "iivic@gmail.com"
                            },
                            new Person()
                            {
                                Id = 5,
                                RoleId = 1,
                                FirstName = "Pero",
                                LastName = "Peric",
                                IsSkipper = false,
                                Username = "pperic",
                                Password = "XN9RParphd4gb4HFklcrcCxUlW6r2Xgf2znx20+VdL0Ozpuw",
                                Token = "",
                                Email = "pperic@gmail.com"
                            },
                            new Person()
                            {
                                Id = 6,
                                RoleId = 2,
                                FirstName = "Anthony",
                                LastName = "Poropat",
                                IsSkipper = true,
                                Username = "aporopat",
                                Password = "Xw6Tap8f0WIO0bywoBP3CYkVOOQPT/tOTiKN2SI4YbtdvFVL",
                                Token = "",
                                Email = "aporopat@gmail.com"
                            },
                            new Person()
                            {
                                Id = 7,
                                RoleId = 1,
                                FirstName = "Matia",
                                LastName = "Poljak",
                                IsSkipper = false,
                                Username = "mpoljak",
                                Password = "+ISSutLrMesoLKQdNXlR3LMGD2AqRLN9Y9gjaN4G8mmZ9xKI",
                                Token = "",
                                Email = "mpoljak@gmail.com"
                            });
        }

        private static void ReservationModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().HasData(
                            new Reservation()
                            {
                                Id = 1,
                                PersonId = 1,
                                BoatTypeId = 1,
                                LocationId = 1,
                                Date = DateTime.Now,
                                IsPaid = true,
                            },
                            new Reservation()
                            {
                                Id = 2,
                                PersonId = 2,
                                BoatTypeId = 2,
                                LocationId = 2,
                                Date = DateTime.Now,
                                IsPaid = false,
                            },
                            new Reservation()
                            {
                                Id = 3,
                                PersonId = 3,
                                BoatTypeId = 3,
                                LocationId = 3,
                                Date = DateTime.Now,
                                IsPaid = false,
                            },
                            new Reservation()
                            {
                                Id = 4,
                                PersonId = 4,
                                BoatTypeId = 4,
                                LocationId = 4,
                                Date = DateTime.Now,
                                IsPaid = true,
                            });
        }

        private static void ReviewModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().HasData(
                            new Review()
                            {
                                Id = 1,
                                Name = "Austin22",
                                Description = "Great boat, it sank during the trip",
                                Star = 3,
                                Date = DateTime.Now,
                                PersonId = null,
                                ResevationId = 2
                            },
                            new Review()
                            {
                                Id = 2,
                                Name = "Mirko66",
                                Description = "Akward service",
                                Star = 1,
                                Date = DateTime.Now,
                                PersonId = 1,
                                ResevationId = 1
                            },
                            new Review()
                            {
                                Id = 3,
                                Name = "Marin28",
                                Description = "Good service",
                                Star = 2,
                                Date = DateTime.Now,
                                PersonId = 3,
                                ResevationId = 3
                            },
                            new Review()
                            {
                                Id = 4,
                                Name = "Peter55",
                                Description = "Everything was awesome",
                                Star = 5,
                                Date = DateTime.Now,
                                PersonId = 5,
                                ResevationId = 4
                            });
        }

        private static void PriorityTypeModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PriorityType>().HasData(
                            new PriorityType()
                            {
                                Id = 1,
                                Type = "Critical"
                            },
                            new PriorityType()
                            {
                                Id = 2,
                                Type = "High"
                            },
                            new PriorityType()
                            {
                                Id = 3,
                                Type = "Moderate"
                            },
                            new PriorityType()
                            {
                                Id = 4,
                                Type = "Low"
                            });
        }

        private static void ReportModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Report>().HasData(
                            new Report()
                            {
                                Id = 1,
                                PriorityTypeId = 1,
                                PersonId = 1,
                                Title = "Jet Ski problem",
                                Description = "Fix Jet Ski"
                            },
                            new Report()
                            {
                                Id = 2,
                                PriorityTypeId = 3,
                                PersonId = 2,
                                Title = "Paper problem", 
                                Description = "Need more paper"
                            },
                            new Report()
                            {
                                Id = 3,
                                PriorityTypeId = 2,
                                PersonId = 3,
                                Title = "Gasoline",
                                Description = "Need more gasoline"
                            },
                            new Report()
                            {
                                Id = 4,
                                PriorityTypeId = 4,
                                PersonId = 5,
                                Title = "Check register",
                                Description = "Need to check money count"
                            });
        }
    }
}
