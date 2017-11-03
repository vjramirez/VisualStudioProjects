using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace WcfService
{
    public class ServiceAuthenticator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName)) {
                throw new ArgumentNullException("UserName Empty");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("UserName Empty");
            }
            if((userName != "Victor") || (password != "12345"))
            {
                throw new FaultException("ERROR: credenciales de autenticación invalidas");

            }
        }
    }
}