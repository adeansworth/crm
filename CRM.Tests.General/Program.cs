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
                CoreInstallation coreInstallation = new CoreInstallation()
                {
                    Name = "Core"
                };


                try
                {
                    Console.WriteLine(uow.CoreInstallations.CollectionName);

                    List<CoreInstallation> query = uow.CoreInstallations.GetAll().ToList();
                    foreach(var i in query)
                    {
                        Console.WriteLine("{0} - {1}", i.ID, i.Name);
                    }

                    uow.CoreInstallations.Create(coreInstallation);
                }
                catch(Exception ex)
                {

                }

                Console.ReadKey();
            }
            
        }
    }
}
