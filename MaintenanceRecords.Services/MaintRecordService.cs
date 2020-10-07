using MaintenanceRecords.Data;
using MaintenanceRecords.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceRecords.Services
{
    public class MaintRecordService
    {
        private readonly Guid _userId;
        //private ApplicationDbContext _db = new ApplicationDbContext();

        public MaintRecordService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMaintRecord(MaintRecordCreate model)
        {
            var entity =
                new MaintRecord()
                {
                    //OwnerId = _userId,
                    ItemId = model.ItemId,
                    RecordText = model.RecordText,
                    //RecordDate = DateTime.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.MaintRecords.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MaintRecordListItem> GetMaintRecords()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .MaintRecords
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new MaintRecordListItem
                                {
                                    RecordId = e.RecordId,
                                    ItemId = e.ItemId,
                                    RecordText = e.RecordText,
                                    RecordDate = e.RecordDate,
                                    MaintItem = e.MaintItem
                                }
                        ) ;

                return query.ToArray();
            }
        }

        public MaintRecordDetail GetMaintRecordById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MaintRecords
                        .Single(e => e.RecordId == id);
                return
                    new MaintRecordDetail
                    {
                        RecordId = entity.RecordId,
                        ItemId = entity.ItemId,
                        RecordText = entity.RecordText,
                        RecordDate = entity.RecordDate,
                        MaintItem = entity.MaintItem
                    };
            }
        }

        public bool UpdateMaintRecord(MaintRecordEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MaintRecords
                        .Single(e => e.RecordId == model.RecordId);
                entity.RecordText = model.RecordText;
                //entity.RecordDate = DateTime.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRecord(int recordId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MaintRecords
                        .Single(e => e.RecordId == recordId);

                ctx.MaintRecords.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
