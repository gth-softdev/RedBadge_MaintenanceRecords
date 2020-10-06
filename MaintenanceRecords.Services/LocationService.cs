using MaintenanceRecords.Data;
using MaintenanceRecords.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceRecords.Services
{
    public class LocationService
    {
        private readonly Guid _userId;

        public LocationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLocation(LocationCreate model)
        {
            var entity =
                new ItemLocation()
                {
                    SiteName = model.SiteName,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    State = model.State
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ItemLocations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LocationListItem> GetLocations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .ItemLocations
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new LocationListItem
                                {
                                    LocationId = e.LocationId,
                                    SiteName = e.SiteName,
                                    StreetAddress = e.StreetAddress,
                                    City = e.City,
                                    State = e.State
                                }
                        );

                return query.ToArray();
            }
        }
        public LocationDetail GetLocationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ItemLocations
                        .Single(e => e.LocationId == id);
                return
                    new LocationDetail
                    {
                        LocationId = entity.LocationId,
                        SiteName = entity.SiteName,
                        StreetAddress = entity.StreetAddress,
                        City = entity.City,
                        State = entity.State
                    };
            }
        }

        public bool UpdateLocation(LocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ItemLocations
                        .Single(e => e.LocationId == model.LocationId);

                entity.SiteName = model.SiteName;
                entity.StreetAddress = model.StreetAddress;
                entity.City = model.City;
                entity.State = model.State;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLocation(int locationId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ItemLocations
                        .Single(e => e.LocationId == locationId);

                ctx.ItemLocations.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
