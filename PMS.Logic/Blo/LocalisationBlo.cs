using Levshits.Data;
using Levshits.Data.Common;
using PMS.Common.Immutable;
using PMS.Common.Request;
using PMS.Data.Common;
using PMS.Data.Enity;

namespace PMS.Logic.Blo
{
    public class LocalisationBlo: BloBase<LocalisationEntity>
    {
        public LocalisationBlo(Repository repository) : base(repository)
        {
        }

        public PmsRepository PmsRepository => (PmsRepository) Repository;

        public override void Init()
        {
            RegisterCommand<TranslateRequest>(TranslateHandler);
        }

        private ExecutionResult TranslateHandler(TranslateRequest request, ExecutionContext context)
        {
            return new ExecutionResult<string>
            {
                TypedResult =
                    PmsRepository.LocalisationData.GetTranlations(request.Key, request.Language) ?? request.Key
            };
        }

        public override int Priority => PriorityLevels.FIRST_LEVEL;
    }
}