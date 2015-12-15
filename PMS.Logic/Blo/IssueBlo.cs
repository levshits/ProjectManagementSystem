using System;
using AutoMapper;
using Levshits.Data;
using Levshits.Data.Common;
using Newtonsoft.Json;
using PMS.Common;
using PMS.Common.Dto;
using PMS.Common.Immutable;
using PMS.Common.ListItem;
using PMS.Common.Request;
using PMS.Data.Common;
using PMS.Data.Enity;

namespace PMS.Logic.Blo
{
    public class IssueBlo:BloBase<IssueEntity>
    {
        public PmsRepository PmsRepository => (PmsRepository)Repository;
        public IssueBlo(Repository repository) : base(repository)
        {
            
        }

        private ExecutionResult IssueListRequestHandler(IssueListRequest request, ExecutionContext context)
        {
            if (request == null)
            {
                return null;
            }
            int itemsCount = 0;
            var list = PmsRepository.IssueData.GetList(request.Page, request.SearchString, out itemsCount);
            return new ExecutionResult<ListResultDto<IssueListItem>>
            {
                TypedResult = new ListResultDto<IssueListItem> { ItemsCount = itemsCount, Items = list }
            };
        }

        public override void Init()
        {
            RegisterCommand<IssueListRequest>(IssueListRequestHandler);
            RegisterCommand<SaveIssueRequest>(SaveIssueRequestHandler);
            RegisterCommand<GetIssueEntitybyIdRequest>(GetIssueEntitybyIdRequestHandler);
            RegisterCommand<SaveCommentRequest>(SaveCommentRequestHandler);
        }

        private ExecutionResult SaveCommentRequestHandler(SaveCommentRequest request, ExecutionContext context)
        {
            if (request == null)
            {
                return null;
            }
            PmsRepository.CommentData.Save(new CommentEntity()
            {
                CreateTime = DateTime.Now,
                CreatorId = UserPrincipal.CurrentUser.Id,
                IssueId = request.IssueId,
                Text = request.Text
            });
            return new ExecutionResult();
        }

        private ExecutionResult GetIssueEntitybyIdRequestHandler(GetIssueEntitybyIdRequest request, ExecutionContext context)
        {
            if (request == null)
            {
                return null;
            }
            var entity = PmsRepository.IssueData.GetEntityById(request.EntityId);
            IssueDto dto = Mapper.Map<IssueDto>(entity);
            return new ExecutionResult<IssueDto> { TypedResult = dto };
        }

        private ExecutionResult SaveIssueRequestHandler(SaveIssueRequest request, ExecutionContext context)
        {
            if (request == null || request.Dto == null)
            {
                return null;
            }
            var dto = request.Dto;
            IssueDto sourceDto = new IssueDto(); 
            IssueEntity entity = new IssueEntity();
            if (request.Dto.Id != Guid.Empty)
            {
                entity = PmsRepository.IssueData.GetEntityById(request.Dto.Id);
                sourceDto = Mapper.Map<IssueDto>(entity);
            }
            Mapper.Map<IssueDto, IssueEntity>(request.Dto, entity);
            entity.CreateTime = DateTime.Now;
            Guid guid = (Guid) PmsRepository.IssueData.Save(entity);

            PmsRepository.ActivityData.Save(new ActivityEntity()
            {
                ActivityType = (int) request.ActivityType,
                CreateTime = DateTime.Now,
                CreatorId = UserPrincipal.CurrentUser.Id,
                IssueId = guid,
                NewValue = JsonConvert.SerializeObject(dto),
                OldValue = JsonConvert.SerializeObject(sourceDto)
            });
            return new ExecutionResult<Guid> {TypedResult = guid};
        }
        
        public override int Priority => PriorityLevels.FIRST_LEVEL;
    }
}