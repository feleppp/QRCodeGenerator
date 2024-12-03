using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeGenerator
{
    internal class Authorization
    {
        public static string authorizationRole;
        public static string authorisationName;

        public static string GetRole(string login, string password)
        {
            var account = QRCodeGeneratorDBEntities.GetContext().Account.FirstOrDefault(a => a.login_ == login && a.password_ == password);
            if (account != null)
            {
                authorisationName = login;
                return authorizationRole = account.Roles.name_role;
            }
            return null;
        }

        public static int BanStatus(string login)
        {
            var account = QRCodeGeneratorDBEntities.GetContext().Account.FirstOrDefault(a => a.login_ == login && a.is_banned == true);
            if (account != null) return 1;
            return 0;
        }
    }
}
