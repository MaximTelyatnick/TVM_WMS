using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TVM_WMS.BLL.Interfaces;
using Ninject;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.GUI
{
    public partial class UsersByRolesFm : DevExpress.XtraEditors.XtraForm
    {
        private IUsersService usersService;
        private BindingSource userRolesBS = new BindingSource();
        private BindingSource usersBS = new BindingSource();
        private BindingSource userTasksBS = new BindingSource();
        private BindingSource storageGroupUsersBS = new BindingSource();

        private List<UserRolesDTO> userRolesList = new List<UserRolesDTO>();
        private List<UsersDTO> usersList = new List<UsersDTO>();
        private List<UserTasksDTO> usersTasksList = new List<UserTasksDTO>();
        private List<StorageGroupUsersDTO> storageGroupUsersList = new List<StorageGroupUsersDTO>();
         private List<TasksDTO> listTasks = new List<TasksDTO>();


        public UsersByRolesFm()
        {
            InitializeComponent();

            LoadRoles();
        }

        #region Method's

        private void LoadRoles()
        {
            usersService = Program.kernel.Get<IUsersService>();

            userRolesList = usersService.GetUserRoles().ToList();
            userRolesBS.DataSource = userRolesList;
            userRolesGrid.DataSource = userRolesBS;
        }

        private void LoadData()
        {
            if (userRolesBS.Count > 0)
            {
                usersService = Program.kernel.Get<IUsersService>();

                usersList = usersService.GetUsers().Where(m => m.UserRoleId == ((UserRolesDTO)userRolesBS.Current).RoleId).ToList();
                usersBS.DataSource = usersList;
                usersGrid.DataSource = usersBS;
                
                usersTasksList = usersService.GetUserTasks(((UserRolesDTO)userRolesBS.Current).RoleId).ToList();
                userTasksBS.DataSource = usersTasksList;
                userTasksGrid.DataSource = userTasksBS;
                
                int currentUserId = (usersBS.Count > 0) ? ((UsersDTO)usersBS.Current).UserId : 0;
                storageGroupUsersList = usersService.GetStorageGroupUsers(currentUserId).ToList();
                storageGroupUsersBS.DataSource = storageGroupUsersList;
                bindStorageGroupGrid.DataSource = storageGroupUsersBS;
            }
        }

        private void LoadStorageGroupUsers()
        {
            if (usersBS.Count > 0)
            {
                usersService = Program.kernel.Get<IUsersService>();
                                  
                storageGroupUsersList = usersService.GetStorageGroupUsers(((UsersDTO)usersBS.Current).UserId).ToList();
                userTasksBS.DataSource = usersTasksList;
                userTasksGrid.DataSource = userTasksBS;
            }  
        }

        #endregion

        #region Event's

        private void userRoleAddItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (UserRoleEditFm userRoleEditFm = new UserRoleEditFm(Utils.Operation.Add, new UserRolesDTO()))
            {
                if (userRoleEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    int return_RoleId = userRoleEditFm.Return();
                    userRolesGridView.BeginDataUpdate();

                    LoadRoles();

                    userRolesGridView.EndDataUpdate();
                    int rowHandle = userRolesGridView.LocateByValue("RoleId", return_RoleId);
                    userRolesGridView.FocusedRowHandle = rowHandle;
                }
            }

        }

        private void userRoleEditItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (userRolesBS.Count > 0)
            {
                using (UserRoleEditFm userRoleEditFm = new UserRoleEditFm(Utils.Operation.Update, (UserRolesDTO)userRolesBS.Current))
                {
                    if (userRoleEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        int return_RoleId = userRoleEditFm.Return();
                        userRolesGridView.BeginDataUpdate();

                        LoadRoles();

                        userRolesGridView.EndDataUpdate();
                        int rowHandle = userRolesGridView.LocateByValue("RoleId", return_RoleId);
                        userRolesGridView.FocusedRowHandle = rowHandle;
                    }
                }
            }

        }

        private void userRoleDeleteItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if ((usersBS.Count == 0) && (userTasksBS.Count == 0))
            {
                if (MessageBox.Show("Удалить данные?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (this.usersService.UserRoleDeleteById(((UserRolesDTO)userRolesBS.Current).RoleId))
                        this.userRolesBS.RemoveCurrent();

                    usersService = Program.kernel.Get<IUsersService>();
                    LoadRoles();
                }

            }
            else
            {
                MessageBox.Show("Группа не может быть удалена, так как содержит пользователей или привязку к режимам системы", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void usersByRolesItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (userRolesBS.Count > 0)
            {
                using (UsersByRolesEditFm usersByRolesEditFm = new UsersByRolesEditFm(((UserRolesDTO)userRolesBS.Current).RoleId))
                {
                    if (usersByRolesEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        private void userDeleteItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (usersBS.Count > 0)
            {
                if (MessageBox.Show("Удалить данные?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (this.usersService.UserDeleteById(((UsersDTO)usersBS.Current).UserId))
                        this.usersBS.RemoveCurrent();

                    LoadData();
                }
            }
        }

        private void tasksItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (userRolesBS.Count > 0)
            {
                using (TasksEditFm tasksEditFm = new TasksEditFm(((UserRolesDTO)userRolesBS.Current).RoleId, Utils.Operation.Add, null))
                {
                    if (tasksEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }

        private void taskDeleteItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            userTasksGridView.CloseEditor();

            List<UserTasksDTO> checkedItems = usersTasksList.Where(s => s.CheckForDelete == true).ToList();

            if (checkedItems.Count > 0)
            {
                if (MessageBox.Show("Удалить данные?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (this.usersService.UserTaskDeleteRange(checkedItems))
                        LoadData();
                }
            }
        }

        private void storageGroupsAddItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (usersBS.Count > 0)
            {
                using (StorageGroupUserEditFm storagegroupUserEditFm = new StorageGroupUserEditFm(storageGroupUsersList.Select(c => new StorageGroupsDTO(){StorageGroupId = c.StorageGroupId}).ToList()))
                {
                    if (storagegroupUserEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        var returnSource = storagegroupUserEditFm.Return();
                        int currentUser = ((UsersDTO)usersBS.Current).UserId;

                        var saveSource = returnSource.Select(c => new StorageGroupUsersDTO() { StorageGroupId = c.StorageGroupId, UserId = currentUser }).ToList();

                        usersService = Program.kernel.Get<IUsersService>();
                        usersService.StorageGroupUsersCreateRange(saveSource);
                        
                        LoadData();
                    }
                }
            }
        }

        private void storageGroupsDeleteItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bindStorageGroupGridView.CloseEditor();
                        
            List<StorageGroupUsersDTO> checkedItems = storageGroupUsersList.Where(s => s.CheckForDelete == true).ToList();

            if (checkedItems.Count > 0)
            {
                if (MessageBox.Show("Удалить ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (this.usersService.StorageGroupUsersDeleteRange(checkedItems))
                        LoadData();
                }
            }
        }
        
        private void userRolesGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadData();
        }

        #endregion

        private void usersGridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            LoadStorageGroupUsers();
        }

        private void tasksEditItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (userTasksBS.Count > 0)
            {
                listTasks = usersTasksList.Select(c => new TasksDTO { TaskId = c.TaskId, TaskName = c.TaskName, TaskCaption = c.TaskCaption, UserTaskId = c.UserTaskId, AccessRight = (c.AccessRightId == 1 ? true : false) }).ToList();
                using (TasksEditFm tasksEditFm = new TasksEditFm(((UserRolesDTO)userRolesBS.Current).RoleId, Utils.Operation.Update, listTasks))
                {
                    if (tasksEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }
    }
}