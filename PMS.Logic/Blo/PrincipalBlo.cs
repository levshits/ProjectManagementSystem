using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Levshits.Data;
using Levshits.Data.Common;
using PMS.Common.Dto;
using PMS.Common.Immutable;
using PMS.Common.Request;
using PMS.Data.Common;
using PMS.Data.Enity;

namespace PMS.Logic.Blo
{
    public class PrincipalBlo: BloBase<PrincipalEntity>
    {
        public readonly Guid SU_ID = new Guid("FBE76230-FD68-4A88-B023-EB824D2AB9A8");

        public PrincipalBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
            RegisterCommand<LoginRequest>(LoginRequestHandler);
        }

        public PmsRepository PmsRepository => (PmsRepository) Repository;

        private ExecutionResult<PrincipalDto> LoginRequestHandler(LoginRequest request, ExecutionContext context)
        {
            var password = PreparePassword(request.Password);
            PrincipalEntity entity = PmsRepository.PrincipalData.GetUserByUsernameAndPassword(request.Username, password);
            PrincipalDto dto = Mapper.Map<PrincipalDto>(entity);
            dto.Roles = entity.RoleEntities.Select(x => Mapper.Map<RoleDto>(x)).ToList();
            IList<ActionEntity> actions = entity.RoleEntities.SelectMany(x => x.ActionEntities).ToList();
            dto.Actions = actions.Select(x => Mapper.Map<ActionDto>(x)).ToList();
            return new ExecutionResult<PrincipalDto> {TypedResult = dto};
        }

        private string PreparePassword(string password)
        {
            var hasher = SHA512.Create();
            var hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(password));
            string result = string.Concat(hash.Select(x => x.ToString("X2")));
            return result;
        }

        public override int Priority => PriorityLevels.FIRST_LEVEL;
    }
}