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
    public class PagesInitializer : IEntityInitializer
    {
        private DatabaseContext Context { get; set; }

        public PagesInitializer(DatabaseContext context)
        {
            Context = context;
        }


        public void Initialize()
        {
            Context.Pages.Add(new Page() { Name = "Главная", URL = "Home/Index" });
            Context.Pages.Add(new Page() { Name = "Менеджер пользователей", URL = "Home/Index" });
            Context.Pages.Add(new Page() { Name = "Менеджер ролей", URL = "Home/Index" });
            Context.Pages.Add(new Page() { Name = "Тест1", URL = "Home/Index" });
            Context.Pages.Add(new Page() { Name = "Тест2", URL = "Home/Index" });

            Context.SaveChanges();
        }
    }
}
