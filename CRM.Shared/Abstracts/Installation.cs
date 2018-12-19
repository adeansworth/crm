using CRM.Extensions;
using CRM.Shared.Enums;
using CRM.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Shared.Abstracts
{
    public abstract class Installation : IInstallation
    {
        public string Name
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(FriendlyName))
                    return FriendlyName.ToLower().RemoveSpecialCharacters();

                return null;
            }
            set
            {
                FriendlyName = value;
            }
        }
        public string DatabaseName
        {
            get
            {
                return string.Format("{0}_{1}", Name, Deployment.ToString().ToLower());
            }
        }
        public string FriendlyName { get; set; }
        public string Server { get; set; } = "localhost";
        public int Port { get; set; } = 27017;
        public bool Secure { get; set; } = false;
        public Deployment Deployment { get; set; } = Deployment.Development;
    }
}
