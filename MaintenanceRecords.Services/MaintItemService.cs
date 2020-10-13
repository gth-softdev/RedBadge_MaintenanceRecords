using MaintenanceRecords.Data;
using MaintenanceRecords.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceRecords.Services
{
    public class MaintItemService
    {
        private readonly Guid _userId;

        public MaintItemService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMaintItem(MaintItemCreate model)
        {
            var entity = new MaintItem();

            entity.ItemName = model.ItemName;
            entity.Year = model.Year;
            entity.Make = model.Make;
            entity.ItemModel = model.ItemModel;
            entity.MiscInfo = model.MiscInfo;
            entity.LocationId = model.LocationId;

              

            using (var ctx = new ApplicationDbContext())
            {
                ctx.MaintItems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<MaintItemListItem> GetMaintItems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .MaintItems
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new MaintItemListItem
                                {
                                    ItemId = e.ItemId,
                                    ItemName = e.ItemName,
                                    Year = e.Year,
                                    Make = e.Make,
                                    ItemModel = e.ItemModel,
                                    MiscInfo = e.MiscInfo,
                                    LocationId = e.LocationId,
                                    ItemLocation = e.ItemLocation
                                }
                        );

                return query.ToArray();
            }
        }

        public MaintItemDetail GetMaintItemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MaintItems
                        .Single(e => e.ItemId == id);
                return
                    new MaintItemDetail
                    {
                        ItemId = entity.ItemId,
                        ItemName = entity.ItemName,
                        Year = entity.Year,
                        Make = entity.Make,
                        ItemModel = entity.ItemModel,
                        MiscInfo = entity.MiscInfo,
                        LocationId = entity.LocationId,
                        ItemLocation = entity.ItemLocation
                    };
            }
        }

        public bool UpdateMaintItem(MaintItemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MaintItems
                        .Single(e => e.ItemId == model.ItemId);

                entity.ItemName = model.ItemName;
                entity.Year = model.Year;
                entity.Make = model.Make;
                entity.ItemModel = model.ItemModel;
                entity.MiscInfo = model.MiscInfo;
                entity.LocationId = model.LocationId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMaintItem(int itemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MaintItems
                        .Single(e => e.ItemId == itemId);

                ctx.MaintItems.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
