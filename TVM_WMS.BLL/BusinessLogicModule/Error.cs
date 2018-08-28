
namespace TVM_WMS.BLL.BusinessLogicModule
{
    public static class Error
    {
        public enum ErrorCRUD
        {
            NoError,
            DatabaseError,
            RelationError,
            CanDelete
        }
    }
}
