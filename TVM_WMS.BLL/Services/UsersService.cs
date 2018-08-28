using System.Collections.Generic;
using System.Linq;
using AutoMapper;

using TVM_WMS.DAL.Entities;
using TVM_WMS.DAL.Interfaces;
using TVM_WMS.DAL.Repositories;

using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.Infrastructure;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.BusinessLogicModule;
using System;
using NLog;

namespace TVM_WMS.BLL.Services
{
    public class UsersService : IUsersService
    {
        private IUnitOfWork Database { get; set; }
        private IRepository<Users> Users;
        private IRepository<UserRoles> UserRoles;
        private IRepository<UserTasks> UserTasks;
        private IRepository<StorageGroupUsers> StorageGroupUsers;
        private IRepository<Tasks> Tasks;
        private IRepository<AccessRights> AccessRights;
        private IRepository<StorageGroups> StorageGroups; 

        private IMapper mapper;
        
        public static UsersDTO AuthorizatedUser { get; internal set; }
        
        //public static UserGroupsDTO AuthorizatedUserGroup { get; internal set; }
        //public static UserRightsDTO AuthorizatedUserRights { get; internal set; }
        public static IEnumerable<UserTasksDTO> AuthorizatedUserAccess { get; internal set; }
        
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public UsersService(IUnitOfWork uow)
        {
            Database = uow;
            Users = Database.GetRepository<Users>();
            UserRoles = Database.GetRepository<UserRoles>();
            UserTasks = Database.GetRepository<UserTasks>();
            StorageGroupUsers = Database.GetRepository<StorageGroupUsers>();
            Tasks = Database.GetRepository<Tasks>();
            AccessRights = Database.GetRepository<AccessRights>();
            StorageGroups = Database.GetRepository<StorageGroups>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Users, UsersDTO>();
                cfg.CreateMap<UsersDTO, Users>();
                cfg.CreateMap<UserRoles, UserRolesDTO>();
                cfg.CreateMap<UserRolesDTO, UserRoles>();
                cfg.CreateMap<UserTasks, UserTasksDTO>();
                cfg.CreateMap<UserTasksDTO, UserTasks>();
                cfg.CreateMap<StorageGroupUsers, StorageGroupUsersDTO>();
                cfg.CreateMap<StorageGroupUsersDTO, StorageGroupUsers>();
                cfg.CreateMap<Tasks, TasksDTO>();
                cfg.CreateMap<StorageGroups, StorageGroupsDTO>();
            });

            mapper = config.CreateMapper();
        }

        public IEnumerable<UsersDTO> GetUsers()
        {
           var result = (from u in Users.GetAll()
                         join r in UserRoles.GetAll() on u.UserRoleId equals r.RoleId into ur
                         from r in ur.DefaultIfEmpty()
                         select new UsersDTO
                         {
                             UserId = u.UserId,
                             Login = u.Login,
                             Password = u.Password,
                             Fio = u.Fio,
                             UserRoleId = u.UserRoleId,
                             RoleName = r.RoleName,
                             Checked = "0"
                         })
                         .OrderBy(t => t.Fio)
                         .ToList();

            return result.Select(s => { s.Password = Security.Decoding(s.Password); return s; }).ToList();
        }

        public UsersDTO GetUserByLogin(string login)
        {
            var user = Users.GetAll().SingleOrDefault(c => c.Login == login);
            return mapper.Map<Users, UsersDTO>(user);
        }

        public IEnumerable<UserRolesDTO> GetUserRoles()
        {
            return mapper.Map<IEnumerable<UserRoles>, List<UserRolesDTO>>(UserRoles.GetAll());
        }

        public IEnumerable<TasksDTO> GetTasks(int roleId)
        {
            var userTasks = UserTasks.GetAll().Where(s => s.UserRoleId == roleId);

            var result = (from t in Tasks.GetAll()
                          join u in userTasks on t.TaskId equals u.TaskId into sc
                          from u in sc.DefaultIfEmpty()
                          where (u == null) || (u != null && t.ParentId == null) 
                          select new TasksDTO
                          {
                              TaskId = t.TaskId,
                              TaskName = t.TaskName,
                              TaskCaption = t.TaskCaption,
                              ParentId = t.ParentId,
                              UserTaskId = u.UserTaskId
                          }).ToList();

            return result;
        }

        public IEnumerable<StorageGroupUsersDTO> GetStorageGroupUsers(int userId)
        {
            var result = (from sgu in StorageGroupUsers.GetAll()
                          join sg in StorageGroups.GetAll() on sgu.StorageGroupId equals sg.StorageGroupId
                          where sgu.UserId == userId
                          select new StorageGroupUsersDTO
                          {
                              StorageGroupUserId = sgu.StorageGroupUserId,
                              StorageGroupId = sgu.StorageGroupId,
                              UserId = sgu.UserId,
                              StorageGroupName = sg.StorageGroupName,
                              CheckForDelete = false
                          }
                );

            return result;
        }

        //public UserRightsDTO GetUserRight(int? id)
        //{
        //    var userRight = UserRights.GetAll().SingleOrDefault(c => c.UserRightId == id.Value);
        //   return mapper.Map<UserRights, UserRightsDTO>(userRight);
        //}

        public bool TryAuthorize(string login, string password)
        {
            UsersDTO user = GetUserByLogin(login);
            IEnumerable<UserTasksDTO> userTasks = GetUserTasks(user.UserRoleId);

            if (user != null)
            {
                if (Security.VerifyPassword(password, user.Password))
                {
                    AuthorizatedUser = user;
                    AuthorizatedUserAccess = userTasks;
                                        
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<UserTasksDTO> GetUserTasks(int userRoleId)
        {
            var result = (from u in UserTasks.GetAll()
                          join t in Tasks.GetAll() on u.TaskId equals t.TaskId
                          join a in AccessRights.GetAll() on u.AccessRightId equals a.RightId
                          where u.UserRoleId == userRoleId
                          where t.ParentId != null
                          orderby t.TaskCaption
                          select new UserTasksDTO
                          {
                              UserTaskId = u.UserTaskId,
                              UserRoleId = u.UserRoleId,
                              TaskId = u.TaskId,
                              TaskName = t.TaskName,
                              TaskCaption = t.TaskCaption,
                              AccessRightId = u.AccessRightId,
                              RightAttribute = a.RightAttribute,
                              RightName = a.RightName,
                              CheckForDelete = false
                          });

            return result;
        }

        public void UsersUpdateRange(List<UsersDTO> users)
        {
            for (int i = 0; i <= users.Count - 1; i++)
            {
                Users.Update(mapper.Map<Users>(users[i]));
            }
        }

        public void UserTasksCreateRange(List<UserTasksDTO> userTasks)
        {
            UserTasks.CreateRange(mapper.Map<IEnumerable<UserTasksDTO>, List<UserTasks>>(userTasks));
        }

        public void UserTasksUpdateRange(List<UserTasksDTO> userTasks)
        {
            for (int i = 0; i <= userTasks.Count - 1; i++)
            {
                UserTasks.Update(mapper.Map<UserTasks>(userTasks[i]));
            }
        }


        public bool UserTaskDeleteRange(List<UserTasksDTO> userTasks)
        {
            try
            {
                foreach (var item in userTasks)
                {
                    var delTasks = UserTasks.GetAll().SingleOrDefault(c => c.UserTaskId == item.UserTaskId);
                    UserTasks.Delete(delTasks);                    
                }
                
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return false;
            }
        }

        public void StorageGroupUsersCreateRange(List<StorageGroupUsersDTO> storageGroupUsersList)
        {
            StorageGroupUsers.CreateRange(mapper.Map<IEnumerable<StorageGroupUsersDTO>, List<StorageGroupUsers>>(storageGroupUsersList));
        }

        public bool StorageGroupUsersDeleteRange(List<StorageGroupUsersDTO> storageGroupUsersList)
        {
            try
            {
                foreach (var item in storageGroupUsersList)
                {
                    var delStorageGroupUser = StorageGroupUsers.GetAll().SingleOrDefault(c => c.StorageGroupUserId == item.StorageGroupUserId);
                    StorageGroupUsers.Delete(delStorageGroupUser);
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return false;
            }
        }

        public int UserRoleCreate(UserRolesDTO urdto)
        {
            var newRole = UserRoles.Create(mapper.Map<UserRoles>(urdto));
            return newRole.RoleId;
        }


        public void UserRoleUpdate(UserRolesDTO urdto)
        {
            var eRole = UserRoles.GetAll().SingleOrDefault(c => c.RoleId == urdto.RoleId);

            UserRoles.Update(mapper.Map<UserRolesDTO, UserRoles>(urdto, eRole));
        }

        public bool UserRoleDeleteById(int? id)
        {
            try
            {
                var delUserRole = UserRoles.GetAll().SingleOrDefault(c => c.RoleId == id.Value);
                UserRoles.Delete(delUserRole);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return false;
            }
        }

        public int UserCreate(UsersDTO udto)
        {
            udto.Password = Security.Coding(udto.Password);

            var newUser = Users.Create(mapper.Map<Users>(udto));
            return newUser.UserId;
        }


        public void UserUpdate(UsersDTO udto)
        {
            var eUser = Users.GetAll().SingleOrDefault(c => c.UserId == udto.UserId);

            udto.Password = Security.Coding(udto.Password);
            
            Users.Update(mapper.Map<UsersDTO, Users>(udto, eUser));
        }

        public bool UserDeleteById(int? id)
        {
            try
            {
                var delUser = Users.GetAll().SingleOrDefault(c => c.UserId == id.Value);
                Users.Delete(delUser);
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return false;
            }
        }
                

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
