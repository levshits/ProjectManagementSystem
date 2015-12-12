using Levshits.Data;
using Levshits.Data.Data;
using PMS.Data.Enity;

namespace PMS.Data.Data
{
    public class CommentData: BaseData<CommentEntity>
    {
        public CommentData(DataProvider dataProvider) : base(dataProvider)
        {
        }
    }
}