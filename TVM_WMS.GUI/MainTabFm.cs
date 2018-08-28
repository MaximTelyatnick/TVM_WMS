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
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.Services;
using TVM_WMS.BLL.DTO;
using Ninject;
using DevExpress.XtraNavBar;

namespace TVM_WMS.GUI
{
    public partial class MainTabFm : DevExpress.XtraEditors.XtraForm
    {
        private IUsersService usersService;
        private IEnumerable<UserTasksDTO> userAccess;

        public MainTabFm()
        {
            InitializeComponent();
            usersService = Program.kernel.Get<IUsersService>();
            documentManager.MdiParent = this;
            documentManager.View = new TabbedView();

            #if !DEBUG
               UserAccessMenu();
            #endif
        }

        private void UserAccessMenu()
        {
            var adminId = usersService.GetUserRoles().FirstOrDefault(s => s.RoleName == "Администратор").RoleId;

            if (UsersService.AuthorizatedUser.UserRoleId != adminId)
            {
                userAccess = usersService.GetUserTasks(UsersService.AuthorizatedUser.UserRoleId);
                var category = menuBarControl.Groups.Select(s => s.Name).ToList();
                for (int i = 0; i < category.Count; i++)
                {
                    var categoryMenu = userAccess.Where(s => s.TaskName == category[i]).ToList();
                    bool availableCategory = (categoryMenu.Count > 0 ? true : false);

                    if (availableCategory == true) // пункт меню(категория) доступен
                    {
                        menuBarControl.Groups[i].Visible = true;
                        var item = menuBarControl.Groups[i].NavBar.Items.Select(s => s.Name).ToList();
                        for (int j = 0; j < item.Count; j++)
                        {
                            var itemMenu = userAccess.Where(s => s.TaskName == item[j]).ToList();
                            bool availableItem = (itemMenu.Count > 0 ? true : false);

                            if (availableItem == true) // пункт меню доступен
                                menuBarControl.Groups[i].NavBar.Items[j].Enabled = true;
                            else
                                menuBarControl.Groups[i].NavBar.Items[j].Enabled = false;
                        }
                    }
                    else
                        menuBarControl.Groups[i].Visible = false;
                }
            }

        }
        
        private void menuBarControl_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            switch (e.Link.Item.Name)
            {
                case "receiptNewItem":
                    OrdersFm ordersFm = new OrdersFm();
                    ordersFm.Text = "Приходные документы";
                    ordersFm.MdiParent = this;
                    ordersFm.Show();
                    break;
                case "receiptsJournalItem":
                    ReceiptsJournalFm receiptsJournalFm = new ReceiptsJournalFm();
                    receiptsJournalFm.Text = "Журнал прихода";
                    receiptsJournalFm.MdiParent = this;
                    receiptsJournalFm.Show();
                    break;
                case "requirementNewItem":
                    RequirementOrdersFm requirementOrdersFm = new RequirementOrdersFm();
                    requirementOrdersFm.Text = "Расходные документы";
                    requirementOrdersFm.MdiParent = this;
                    requirementOrdersFm.Show();
                    break;
                case "expendituresJournalItem":
                    ExpendituresJournalFm expendituresJournalFm = new ExpendituresJournalFm();
                    expendituresJournalFm.Text = "Журнал расхода";
                    expendituresJournalFm.MdiParent = this;
                    expendituresJournalFm.Show();
                    break;
                case "receiptsAcceptanceItem":
                    ReceiptsAcceptanceFm receiptsAcceptanceFm = new ReceiptsAcceptanceFm();
                    receiptsAcceptanceFm.Text = "Зона приемки";
                    receiptsAcceptanceFm.MdiParent = this;
                    receiptsAcceptanceFm.Show();
                    break;
                case "wareHouseMapItem":
                    StoreLoadFm storeLoadFm = new StoreLoadFm();
                    storeLoadFm.Text = "Загруженность склада";
                    storeLoadFm.MdiParent = this;
                    storeLoadFm.Show();
                    break;
                case "zoneNamesItem":
                    ZoneNamesFm zoneNamesFm = new ZoneNamesFm();
                    zoneNamesFm.Text = "Зоны хранения";
                    zoneNamesFm.MdiParent = this;
                    zoneNamesFm.Show();
                    break;
                case "receiptsForKeepingItem":
                    ReceiptsForKeepingFmNew receiptsForKeepingFm = new ReceiptsForKeepingFmNew();
                    receiptsForKeepingFm.Text = "Размещение на склад";
                    receiptsForKeepingFm.MdiParent = this;
                    receiptsForKeepingFm.Show();
                    break;
                case "expenditureFromStorageItem":
                    ExpendituresFromKeepingFm expendituresFromKeepingFm = new ExpendituresFromKeepingFm();
                    expendituresFromKeepingFm.Text = "Списание со склада";
                    expendituresFromKeepingFm.MdiParent = this;
                    expendituresFromKeepingFm.Show();
                    break;
                case "materialsItem":
                    MaterialsFm materialsFm = new MaterialsFm();
                    materialsFm.Text = "Номенклатура";
                    materialsFm.MdiParent = this;
                    materialsFm.Show();
                    break;
                case "contractorsItem":
                    SpravochFm contractorsFm = new SpravochFm(Utils.GridName.Contractors);
                    contractorsFm.Text = "Контрагенты";
                    contractorsFm.MdiParent = this;
                    contractorsFm.Show();
                    break;
                case "measuresItem":
                    SpravochFm measuresFm = new SpravochFm(Utils.GridName.Measures);
                    measuresFm.Text = "Габариты";
                    measuresFm.MdiParent = this;
                    measuresFm.Show();
                    break;
                case "unitsItem":
                    SpravochFm unitsFm = new SpravochFm(Utils.GridName.Units);
                    unitsFm.Text = "Единицы измерения";
                    unitsFm.MdiParent = this;
                    unitsFm.Show();
                    break;
                case "currencyItem":
                    SpravochFm currencyFm = new SpravochFm(Utils.GridName.Currency);
                    currencyFm.Text = "Валюта";
                    currencyFm.MdiParent = this;
                    currencyFm.Show();
                    break;
                case "usersItem":
                    SpravochFm usersFm = new SpravochFm(Utils.GridName.Users);
                    usersFm.Text = "Пользователи";
                    usersFm.MdiParent = this;
                    usersFm.Show();
                    break;
                case "storageGroupsItem":
                    SpravochFm storageGroupsFm = new SpravochFm(Utils.GridName.StorageGroups);
                    storageGroupsFm.Text = "Складские группы";
                    storageGroupsFm.MdiParent = this;
                    storageGroupsFm.Show();
                    break;
                case "personsItem":
                    SpravochFm personsFm = new SpravochFm(Utils.GridName.Persons);
                    personsFm.Text = "Ответственные лица";
                    personsFm.MdiParent = this;
                    personsFm.Show();
                    break;
                case "professionItem":
                    SpravochFm professionFm = new SpravochFm(Utils.GridName.Profession);
                    professionFm.Text = "Профессии";
                    professionFm.MdiParent = this;
                    professionFm.Show();
                    break;
                case "alarmItem":
                    SpravochFm alarmFm = new SpravochFm(Utils.GridName.Alarms);
                    alarmFm.Text = "Журнал кодов ошибок";
                    alarmFm.MdiParent = this;
                    alarmFm.Show();
                    break;
                case "settingsItem":
                    SettingsFm settingsFm = new SettingsFm();
                    settingsFm.ShowDialog();
                    break;
                case "testItem":
                    TestFm testFm = new TestFm();
                    testFm.ShowDialog();
                    break;
                case "deficitItem":
                    DeficitMaterialsFm deficitMaterialsFm = new DeficitMaterialsFm();
                    deficitMaterialsFm.Text = "Расчет дефицита";
                    deficitMaterialsFm.MdiParent = this;
                    deficitMaterialsFm.Show();
                    break;
                case "userRolesItem":
                    UsersByRolesFm usersRolesFm = new UsersByRolesFm();
                    usersRolesFm.Text = "Группы пользователей";
                    usersRolesFm.MdiParent = this;
                    usersRolesFm.Show();
                    break;  
                    
                default:
                    break;
            }
        }

        private void MainTabFm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (e.Cancel = (DialogResult.Yes == MessageBox.Show("Вы действительно хотите выйти ?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question)))
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}