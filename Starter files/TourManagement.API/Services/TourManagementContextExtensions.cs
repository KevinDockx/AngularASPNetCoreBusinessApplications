using System;
using System.Collections.Generic;
using TourManagement.API.Entities;

namespace TourManagement.API.Services
{
    public static class TourManagementContextExtensions
    {
        public static void EnsureSeedDataForContext(this TourManagementContext context)
        {
            // first, clear the database.  This ensures we can always start 
            // fresh with each demo.  Not advised for production environments, obviously :-)

            context.Tours.RemoveRange(context.Tours);
            context.Bands.RemoveRange(context.Bands);
            context.Managers.RemoveRange(context.Managers);

            context.SaveChanges();

            // init seed data
            var managers = new List<Manager>()
            {
                new Manager()
                {
                    ManagerId = new Guid("fec0a4d6-5830-4eb8-8024-272bd5d6d2bb"),
                    Name = "Kevin",
                    CreatedBy = "system",
                    CreatedOn = DateTime.UtcNow
                },
                new Manager()
                {
                    ManagerId = new Guid("c3b7f625-c07f-4d7d-9be1-ddff8ff93b4d"),
                    Name = "Sven",
                    CreatedBy = "system",
                    CreatedOn = DateTime.UtcNow
                }
            };

            var bands = new List<Band>()
            {
                new Band()
                {
                    BandId = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    Name = "Queens of the Stone Age",
                    CreatedBy = "system",
                    CreatedOn = DateTime.UtcNow
                },
                new Band()
                {
                    BandId = new Guid("83b126b9-d7bf-4f50-96dc-860884155f8b"),
                    Name = "Nick Cave and the Bad Seeds",
                    CreatedBy = "system",
                    CreatedOn = DateTime.UtcNow
                }
            };

            var tours = new List<Tour>()
            {
                new Tour()
                {
                    TourId = new Guid("c7ba6add-09c4-45f8-8dd0-eaca221e5d93"),
                    BandId = new Guid("25320c5e-f58a-4b1f-b63a-8ee07a840bdf"),
                    ManagerId = new Guid("fec0a4d6-5830-4eb8-8024-272bd5d6d2bb"),
                    Title = "Villains World Tour",
                    Description = "The Villains World Tour is a concert tour in support of the band's seventh studio album, Villains.",
                    StartDate = new DateTimeOffset(2017,6,22,0,0,0, new TimeSpan()),
                    EndDate = new DateTimeOffset(2018,3,18,0,0,0, new TimeSpan()),
                    EstimatedProfits = 2500000,
                    CreatedBy = "system",
                    CreatedOn = DateTime.UtcNow,
                    Shows = new List<Show>()
                    {
                        new Show() {
                            Venue = "The Rapids Theatre",
                            City = "Niagara Falls",
                            Country = "United States",
                            Date = new DateTimeOffset(2017,6,22,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Marina de Montebello",
                            City = "Montebello",
                            Country = "Canada",
                            Date = new DateTimeOffset(2017,6,24,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Ventura Theatre",
                            City = "Venture",
                            Country = "United States",
                            Date = new DateTimeOffset(2017,8,10,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Golden Gate Park",
                            City = "San Francisco",
                            Country = "United States",
                            Date = new DateTimeOffset(2017,8,12,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Capitol Theatre",
                            City = "Port Chester",
                            Country = "United States",
                            Date = new DateTimeOffset(2017,9,6,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Festival Pier",
                            City = "Philadelphia",
                            Country = "United States",
                            Date = new DateTimeOffset(2017,9,7,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Budweiser Stage",
                            City = "Toronto",
                            Country = "Canada",
                            Date = new DateTimeOffset(2017,9,9,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        }
                    }
                },
                new Tour()
                {
                    TourId = new Guid("f67ba678-b6e0-4307-afd9-e804c23b3cd3"),
                    BandId = new Guid("83b126b9-d7bf-4f50-96dc-860884155f8b"),
                    ManagerId = new Guid("c3b7f625-c07f-4d7d-9be1-ddff8ff93b4d"),
                    Title = "Skeleton Tree European Tour",
                    Description = "Nick Cave and The Bad Seeds have announced an 8-week European tour kicking off in the UK at Bournemouth’s International Centre on 24th September. The tour will be the first time European audiences can experience live songs from new album Skeleton Tree alongside other Nick Cave & The Bad Seeds classics.  The touring line up features Nick Cave, Warren Ellis, Martyn Casey, Thomas Wydler, Jim Sclavunos, Conway Savage, George Vjestica and Larry Mullins.",
                    StartDate = new DateTimeOffset(2017,9,24,0,0,0, new TimeSpan()),
                    EndDate = new DateTimeOffset(2017,11,20,0,0,0, new TimeSpan()),
                    EstimatedProfits = 1200000,
                    CreatedBy = "system",
                    CreatedOn = DateTime.UtcNow,
                    Shows = new List<Show>()
                    {
                        new Show() {
                            Venue = "Bournemouth International Centre",
                            City = "Bournemouth",
                            Country = "United Kingdom",
                            Date = new DateTimeOffset(2017,9,24,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Arena",
                            City = "Manchester",
                            Country = "United Kingdom",
                            Date = new DateTimeOffset(2017,9,25,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "The SSE Hydro",
                            City = "Glasgow",
                            Country = "United Kingdom",
                            Date = new DateTimeOffset(2017,9,27,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Motorpoint Arena",
                            City = "Nottingham",
                            Country = "United Kingdom",
                            Date = new DateTimeOffset(2017,9,28,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "The O2",
                            City = "London",
                            Country = "United Kingdom",
                            Date = new DateTimeOffset(2017,9,30,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Zénith",
                            City = "Paris",
                            Country = "France",
                            Date = new DateTimeOffset(2017,10,3,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Ziggo Dome",
                            City = "Amsterdam",
                            Country = "The Netherlands",
                            Date = new DateTimeOffset(2017,10,6,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Jahrhunderthalle",
                            City = "Frankfurt",
                            Country = "Germany",
                            Date = new DateTimeOffset(2017,10,7,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Sporthalle",
                            City = "Hamburg",
                            Country = "Germany",
                            Date = new DateTimeOffset(2017,10,9,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Rockhal",
                            City = "Luxembourg",
                            Country = "Luxembourg",
                            Date = new DateTimeOffset(2017,10,10,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Mitsubishi Electric Halle",
                            City = "Düsseldorf",
                            Country = "Germany",
                            Date = new DateTimeOffset(2017,10,10,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        },
                        new Show() {
                            Venue = "Sportpaleis",
                            City = "Antwerp",
                            Country = "Belgium",
                            Date = new DateTimeOffset(2017,10,13,0,0,0, new TimeSpan()),
                            CreatedBy = "system",
                            CreatedOn = DateTime.UtcNow
                        }
                    }
                }
             };

            context.Managers.AddRange(managers);
            context.Bands.AddRange(bands);
            context.Tours.AddRange(tours);

            context.SaveChanges();
        }
    }
}
