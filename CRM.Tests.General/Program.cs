using CRM.Data;
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
            using(UnitOfWork uow = new UnitOfWork())
            {
                


                try
                {
                    Console.WriteLine(uow.CoreInstallations.CollectionName);

                    //List<CoreInstallation> query = uow.CoreInstallations.GetAll().ToList();
                    //foreach(var i in query)
                    //{
                    //    Console.WriteLine("{0} - {1}", i.ID, i.Name);
                    //}

                    //var x = uow.CoreInstallations.Get(new MongoDB.Bson.ObjectId("5c1950d97f9dd23880fcbeea")).Result;



                    uow.CoreInstallations.CreateMany(
                        new List<CoreInstallation>()
                        {
                            new CoreInstallation() { Name = "Core" },
                            new CoreInstallation() { Name = "Kayleighs Hair Dressers" },
                            new CoreInstallation() { Name = "Nooshas Vegan Food Store" },
                            new CoreInstallation() { Name = "Terrys Automotive" }
                        });

                    //uow.CoreInstallations.Create(new CoreInstallation() { Name = "Core" });
                    //uow.CoreInstallations.Create(new CoreInstallation() { Name = "Kayleighs Hair Dressers" });
                    //uow.CoreInstallations.Create(new CoreInstallation() { Name = "Nooshas Vegan Food Store" });
                    //uow.CoreInstallations.Create(new CoreInstallation() { Name = "Terrys Automotive" });
                }
                catch(Exception ex)
                {

                }

                Console.ReadKey();
            }
            
        }
    }
}
