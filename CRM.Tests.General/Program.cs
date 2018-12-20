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

                    var x = uow.CoreInstallations.GetAll().Where(m => m.ID == "378ff7b3-3a62-46c5-867e-cb7750d1284f").First();

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


                    uow.ProjectInstallations.Update( new ProjectInstallation()
                    {
                        ID = x.ID,
                        Name = x.FriendlyName,
                        DefaultProject = true,
                        Port = x.Port,
                        Secure = x.Secure,
                        Server = x.Server
                    });

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
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }

                //Console.ReadKey();
            }
            
        }
    }
}
