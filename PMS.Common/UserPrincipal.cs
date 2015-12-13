using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace PMS.Common
{
    public class UserPrincipal: GenericPrincipal
    {
        public UserPrincipal(IIdentity identity, string[] roles) : base(identity, roles)
        {
        }

        public UserPrincipal(): base(new GenericIdentity(string.Empty), new string[0])
        {
            SessionId = Guid.Empty;
        }

        /// <summary>
        /// Gets or sets the user associated with the current executing thread.
        /// </summary>
        public static UserPrincipal CurrentUser
        {
            get
            {
                UserPrincipal principal = System.Threading.Thread.CurrentPrincipal as UserPrincipal;

                if (principal == null)
                {
                    return Empty;
                }
                return principal;
            }
            set { System.Threading.Thread.CurrentPrincipal = value; }
        }

        public static bool IsAuthenticated => CurrentUser != null && CurrentUser != Empty;

        public static UserPrincipal Empty { get; } = new UserPrincipal();

        public List<Guid> PermittedActions { get; set; }
        public Guid SessionId { get; set; }
    }
}