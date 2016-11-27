using SKV.ML.Concrete.Model.UIModel;
using SKV.DAL.Concrete.EntityFramework;
using SKV.DatabaseInitializer.Abstract;

namespace SKV.DatabaseInitializer.InitializationParts.UI.Common
{
    public class UserCulturesInitializer : IEntityInitializer
    {
        private DatabaseContext Context { get; set; }

        public UserCulturesInitializer(DatabaseContext context)
        {
            Context = context;
        }

        public void Initialize()
        {
            Context.UICulture.Add(new UICulture() { Name = "Русский", Culture = "ru-RU" });
            Context.UICulture.Add(new UICulture() { Name = "English", Culture = "en-US" });

            Context.SaveChanges();
        }
    }
}
