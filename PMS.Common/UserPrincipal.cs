using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using PMS.Common.Dto;

namespace PMS.Common
{
    public class UserPrincipal: GenericPrincipal
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        protected UserPrincipal(IIdentity identity, string[] roles) : base(identity, roles)
        {
        }

        protected UserPrincipal(): base(new GenericIdentity(string.Empty), new string[0])
        {
            SessionId = Guid.Empty;
        }

        public UserPrincipal(PrincipalDto typedResult): base(new GenericIdentity(typedResult.Id.ToString()), typedResult.RoleEntities.Select(x=>x.Name).ToArray())
        {
            Id = typedResult.Id;
            Username = typedResult.Username;
            Email = typedResult.Email;
            SessionId = Guid.NewGuid();
            PermittedActions = typedResult.Actions.Select(x => x.Id).ToList();
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