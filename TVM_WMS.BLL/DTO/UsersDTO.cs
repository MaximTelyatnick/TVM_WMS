﻿using TVM_WMS.BLL.BusinessLogicModule;

namespace TVM_WMS.BLL.DTO
{
    public class UsersDTO : ObjectBase
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Fio { get; set; }
        public int UserRoleId { get; set; }
        public string RoleName { get; set; }

        public string Checked { get; set; }
    }
}