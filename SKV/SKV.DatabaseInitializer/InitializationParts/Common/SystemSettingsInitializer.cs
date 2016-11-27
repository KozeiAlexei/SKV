using SKV.DAL.Concrete.EntityFramework;
using SKV.DatabaseInitializer.Abstract;
using SKV.ML.Concrete.Model.CommonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKV.DatabaseInitializer.InitializationParts.Common
{
    public class SystemSettingsInitializer : IEntityInitializer
    {
        private DatabaseContext Context { get; set; }

        public SystemSettingsInitializer(DatabaseContext context)
        {
            Context = context;
        }

        public void Initialize()
        {
            Context.SystemSettings.Add(new SystemSettings()
            {
                DefaultCultureId = 1
            });

            Context.SaveChanges();
        }
    }
}
