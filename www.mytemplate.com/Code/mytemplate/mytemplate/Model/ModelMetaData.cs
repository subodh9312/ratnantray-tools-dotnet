using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using mytemplate.Controller.Utilities;
using mytemplate.Model.ModelExtensions;

namespace mytemplate.Model
{
    public partial class Comment : IAuditable
    {
    }

    public partial class MyTemplateEntities
    {
        public override int SaveChanges(SaveOptions options)
        {
            IEnumerable<ObjectStateEntry> AddedEntities = ObjectStateManager.GetObjectStateEntries(EntityState.Added);
            if (AddedEntities.Count() > 0)
                AuditUtility.ProcessInserts(AddedEntities);

            IEnumerable<ObjectStateEntry> ModifiedEntities = ObjectStateManager.GetObjectStateEntries(EntityState.Modified);
            if (ModifiedEntities.Count() > 0)
                AuditUtility.ProcessUpdates(ModifiedEntities);

            return base.SaveChanges(options);
        }
    }
}