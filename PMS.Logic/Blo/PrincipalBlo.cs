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
using PMS.Common.ListItem;
using PMS.Common.Request;
using PMS.Data.Common;
using PMS.Data.Enity;

namespace PMS.Logic.Blo
{
    public class PrincipalBlo: BloBase<PrincipalEntity>
    {
        public static readonly Guid SU_ID = new Guid("FBE76230-FD68-4A88-B023-EB824D2AB9A8");

        public PrincipalBlo(Repository repository) : base(repository)
        {
        }

        public override void Init()
        {
            RegisterCommand<LoginRequest>(LoginRequestHandler);
            RegisterCommand<GetPrincipalEntitybyIdRequest>(GetPrincipalEntitybyIdRequestHandler);
            RegisterCommand<PrincipalSaveRequest>(SavePrincipalRequestHandler);
            RegisterCommand<PrincipalListRequest>(ListRequestHandler);
        }

        private ExecutionResult ListRequestHandler(PrincipalListRequest request, ExecutionContext context)
        {
            if (request == null)
            {
                return null;
            }
            int itemsCount = 0;
            var list = PmsRepository.PrincipalData.GetList(request.Page, request.SearchString, out itemsCount);
            return new ExecutionResult<ListResultDto<PrincipalListItem>>
            {
                TypedResult = new ListResultDto<PrincipalListItem> { ItemsCount = itemsCount, Items = list }
            };
        }

        private ExecutionResult SavePrincipalRequestHandler(PrincipalSaveRequest request, ExecutionContext context)
        {
            if (request == null || request.Dto == null)
            {
                return null;
            }
            var dto = request.Dto;
            PrincipalExtendedEntity entity = null;
            if (request.Dto.Id == Guid.Empty)
            {
                entity = Mapper.Map<PrincipalExtendedEntity>(request.Dto);
                entity.Password = PreparePassword(entity.Password);
                entity.ActionEntities.Clear();
                var id = PmsRepository.PrincipalData.Save(entity);
                entity = (PrincipalExtendedEntity) PmsRepository.PrincipalData.GetEntityById(id);
            }
            entity = (PrincipalExtendedEntity) (entity ?? PmsRepository.PrincipalData.GetEntityById(dto.Id));
            entity.Username = dto.Username;
            entity.Email = dto.Email;
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;

            var availbleRoles = entity.RoleEntities.Select(x => x.Id).ToList();
            foreach (var roleEntity in dto.RolesEntities)
            {
                if (!availbleRoles.Contains(roleEntity.Id))
                {
                    entity.PrincipalRoleEntities.Add(new PrincipalRoleEntity() { PrincipalId = entity.Id, RoleId = roleEntity.Id, CreateTime = DateTime.Now});
                }
            }
            var removedRoles = entity.PrincipalRoleEntities.Where(roleActionEntity => dto.RolesEntities.All(x => x.Id != roleActionEntity.RoleId)).ToList();
            foreach (var principalRoleEntity in removedRoles)
            {
                entity.PrincipalRoleEntities.Remove(principalRoleEntity);
            }

            var availbleProjects = entity.ProjectEntities.Select(x => x.Id).ToList();
            foreach (var projectEntity in dto.ProjectEntities)
            {
                if (!availbleProjects.Contains(projectEntity.Id))
                {
                    entity.PrincipalProjectEntities.Add(new PrincipalProjectEntity() { PrincipalId = entity.Id, ProjectId = projectEntity.Id, CreateTime = DateTime.Now});
                }
            }
            var removedProjects = entity.PrincipalProjectEntities.Where(principalProjectEntity => dto.ProjectEntities.All(x => x.Id != principalProjectEntity.ProjectId)).ToList();
            foreach (var principalProjectEntity in removedProjects)
            {
                entity.PrincipalProjectEntities.Remove(principalProjectEntity);
            }

            PmsRepository.PrincipalData.Save(entity);

            return new ExecutionResult();
        }

        private ExecutionResult GetPrincipalEntitybyIdRequestHandler(GetPrincipalEntitybyIdRequest request, ExecutionContext context)
        {
            var entity = PmsRepository.PrincipalData.GetEntityById(request.EntityId);
            PrincipalDto dto = Mapper.Map<PrincipalDto>(entity);
            IList<ActionEntity> actions = entity.RoleEntities.SelectMany(x => x.ActionEntities).ToList();
            dto.Actions = actions.Select(x => Mapper.Map<ActionDto>(x)).ToList();
            return new ExecutionResult <PrincipalDto> { TypedResult = dto};
        }

        public PmsRepository PmsRepository => (PmsRepository) Repository;

        private ExecutionResult<PrincipalDto> LoginRequestHandler(LoginRequest request, ExecutionContext context)
        {
            var password = PreparePassword(request.Password);
            PrincipalEntity entity = PmsRepository.PrincipalData.GetUserByUsernameAndPassword(request.Username, password);
            PrincipalDto dto = Mapper.Map<PrincipalDto>(entity);
            dto.RolesEntities = entity.RoleEntities.Select(x => Mapper.Map<RoleDto>(x)).ToList();
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