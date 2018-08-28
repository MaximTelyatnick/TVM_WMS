using System.Collections.Generic;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.BLL.Interfaces
{
    public interface IUsersService
    {
        IEnumerable<UsersDTO> GetUsers();
        UsersDTO GetUserByLogin(string login);
        IEnumerable<UserRolesDTO> GetUserRoles();
        IEnumerable<UserTasksDTO> GetUserTasks(int userRoleId);

        IEnumerable<TasksDTO> GetTasks(int roleId);
        IEnumerable<StorageGroupUsersDTO> GetStorageGroupUsers(int userId);

        void UsersUpdateRange(List<UsersDTO> users);
        int UserRoleCreate(UserRolesDTO urdto);
        void UserRoleUpdate(UserRolesDTO urdto);
        bool UserRoleDeleteById(int? id);
        int UserCreate(UsersDTO udto);
        void UserUpdate(UsersDTO udto);
        bool UserDeleteById(int? id);
        void UserTasksCreateRange(List<UserTasksDTO> userTasks);
        bool UserTaskDeleteRange(List<UserTasksDTO> userTasks);
        void UserTasksUpdateRange(List<UserTasksDTO> userTasks);
        void StorageGroupUsersCreateRange(List<StorageGroupUsersDTO> storageGroupUsersList);
        bool StorageGroupUsersDeleteRange(List<StorageGroupUsersDTO> storageGroupUsersList);

        bool TryAuthorize(string login, string password);

        void Dispose();
    }
}
