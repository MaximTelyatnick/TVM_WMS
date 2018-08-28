using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using System;
using System.Collections;

using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.Services;
using TVM_WMS.BLL.DTO;
using System.Collections.Generic;

namespace TVM_WMS.GUI
{
    public partial class UsersByRolesEditFm : DevExpress.XtraEditors.XtraForm
    {
        private IUsersService usersService;
        private BindingSource usersByRolesBS = new BindingSource();
        private List<UsersDTO> source;
        private int roleId;

        public UsersByRolesEditFm(int roleId)
        {
            InitializeComponent();
            usersService = Program.kernel.Get<IUsersService>();
            this.roleId = roleId;
            source = usersService.GetUsers().Where(s => s.UserRoleId != roleId).ToList();
            usersByRolesBS.DataSource = source;
            usersByRolesGrid.DataSource = usersByRolesBS;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            var usersList = source.Where(s => s.Checked == "1").Select(s => { s.UserRoleId = roleId; return s; }).ToList();
            if (usersList.Count > 0)
            {
                if (MessageBox.Show("Сохранить пользователей?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    usersService.UsersUpdateRange(usersList);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void repositoryItemCheckEdit1_CheckStateChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CheckEdit editor = sender as DevExpress.XtraEditors.CheckEdit;

            ((UsersDTO)usersByRolesGridView.GetFocusedRow()).Checked = (editor.CheckState == CheckState.Checked ? "1" : "0");
        }
    }
}