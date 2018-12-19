using CRM.Data;
using CRM.Data.Abstracts;
using CRM.Data.Classes;
using CRM.Data.Entities;
using CRM.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CRM.Tests.General
{
    class Program
    {
        static void Main(string[] args)
        {
            using(UnitOfWork uow = new UnitOfWork("terrysautomotive"))
            {
                


                try
                {
                    Console.WriteLine(uow.CoreInstallations.CollectionName);

                    //var x = uow.CoreInstallations.GetAll().Where(m => m.ID == "add36292-f81a-456a-8f06-7178400da8d6").First();

                    //x.Name = "Terrys Vehicle Spares";

                    //uow.CoreInstallations.Update(x);


                    //uow.CoreInstallations.UpdateMany(
                    //    new List<CoreInstallation>()
                    //    {
                    //        new CoreInstallation() { Name = "Core" },
                    //        new CoreInstallation() { Name = "Kayleighs Hair Dressers" },
                    //        new CoreInstallation() { Name = "Nooshas Vegan Food Store" },
                    //        new CoreInstallation() { Name = "Terrys Automotive" }
                    //    });

                    var x = uow.ProjectInstallations.GetAll().Where(m => m.ID == "ab77eef7-9cbb-49b1-9fd4-49cc9cea5aae").First();

                    x.Name = "Terrys Vehicle Spares";

                    uow.ProjectInstallations.Update(x);

                    //uow.ProjectInstallations.UpdateMany(
                    //    new List<ProjectInstallation>()
                    //    {
                    //        new ProjectInstallation(){ID = "ab77eef7-9cbb-49b1-9fd4-49cc9cea5aae", Name = "terrysautomotive"}
                    //    });

                    //uow.CoreInstallations.Create(new CoreInstallation() { Name = "Core" });
                    //uow.CoreInstallations.Create(new CoreInstallation() { Name = "Kayleighs Hair Dressers" });
                    //uow.CoreInstallations.Create(new CoreInstallation() { Name = "Nooshas Vegan Food Store" });
                    //uow.CoreInstallations.Create(new CoreInstallation() { Name = "Terrys Automotive" });
                }
                catch (Exception ex)
                {

                }

                //Console.ReadKey();
            }
            
        }
    }
}
