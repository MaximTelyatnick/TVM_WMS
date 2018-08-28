using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using System.Collections;
using DevExpress.XtraTreeList;

using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.Services;
using TVM_WMS.BLL.DTO;
using System.Collections.Generic;
using DevExpress.XtraGrid.Columns;
using System;

namespace TVM_WMS.GUI
{
    public partial class SpravochFm : DevExpress.XtraEditors.XtraForm 
    {

        private IUnitsService unitsService;
        private BindingSource unitsBS = new BindingSource();

        private IUsersService usersService;
        private BindingSource usersBS = new BindingSource();
        
        private IMeasuresService measuresService;
        private BindingSource measuresBS = new BindingSource();

        private IContractorsService contractorsService;
        private BindingSource contractorsBS = new BindingSource();

        private ICurrencyService currencyService;
        private BindingSource currencyBS = new BindingSource();
         
        private IZoneNamesService zoneNamesService;
        private IWareHousesService wareHousesService;
        private BindingSource zoneNamesBS = new BindingSource();
        
        private IStorageGroupsService storageGroupsService;
        private BindingSource storageGroupsBS = new BindingSource();

        private IPersonsService personsService;
        private BindingSource personsBS = new BindingSource();

        private IProfessionService professionService;
        private BindingSource professionBS = new BindingSource();

        private ISettingsService settingsService;
        private BindingSource alarmsBS = new BindingSource();

        private Utils.GridName gridName;
        private bool access;
        
        private List<WareHousesDTO> cellList = new List<WareHousesDTO>(); 

        public SpravochFm(Utils.GridName aName)
        {            
            InitializeComponent();

            gridName = aName;
   
            splashScreenManager.ShowWaitForm();
            
            switch (aName)
            {
                case Utils.GridName.Units:
                     unitsService = Program.kernel.Get<IUnitsService>();
                     unitsBS.DataSource =unitsService.GetUnits();
                     GridColumnCreate(Utils.dictUnits, gridName);
                     spravochGrid.DataSource = unitsBS;
                     this.Text = "Справочник единиц измерения";
                     access = UsersService.AuthorizatedUserAccess.Any(c => c.TaskName == "unitsItem" && c.AccessRightId == 1);//чтение
                     if (access)
                            AuthorizatedUserAccess();

                    break;

                case Utils.GridName.Users:
                    usersService = Program.kernel.Get<IUsersService>();
                    usersBS.DataSource = usersService.GetUsers();
                    GridColumnCreate(Utils.dictUsers, gridName);
                    spravochGrid.DataSource = usersBS;
                    this.Text = "Справочник пользователей";
                    access = UsersService.AuthorizatedUserAccess.Any(c => c.TaskName == "usersItem" && c.AccessRightId == 1);

                    break;

                case Utils.GridName.Contractors:
                    contractorsService = Program.kernel.Get<IContractorsService>();
                    contractorsBS.DataSource = contractorsService.GetContractors();
                    GridColumnCreate(Utils.dictContractors, gridName);
                    spravochGrid.DataSource = contractorsBS;
                     this.Text = "Справочник контрагентов";
                     access = UsersService.AuthorizatedUserAccess.Any(c => c.TaskName == "contractorsItem" && c.AccessRightId == 1);
                     break;

                case Utils.GridName.Measures:
                    measuresService = Program.kernel.Get<IMeasuresService>();
                    measuresBS.DataSource = measuresService.GetMeasures();
                    GridColumnCreate(Utils.dictMeasures, gridName);
                    spravochGrid.DataSource = measuresBS;
                    this.Text = "Справочник габаритов/размеров";
                    access = UsersService.AuthorizatedUserAccess.Any(c => c.TaskName == "measuresItem" && c.AccessRightId == 1);
                    break;

                case Utils.GridName.Currency:
                    currencyService = Program.kernel.Get<ICurrencyService>();
                    currencyBS.DataSource = currencyService.GetCurrency();
                    GridColumnCreate(Utils.dictCurrency, gridName);
                    spravochGrid.DataSource = currencyBS;
                    this.Text = "Справочник валют";
                    access = UsersService.AuthorizatedUserAccess.Any(c => c.TaskName == "currencyItem" && c.AccessRightId == 1);
                    break;
                case Utils.GridName.ZoneNames:
                    zoneNamesService = Program.kernel.Get<IZoneNamesService>();
                    wareHousesService = Program.kernel.Get<IWareHousesService>();
                    zoneNamesBS.DataSource = zoneNamesService.GetZones();
                    GridColumnCreate(Utils.dictZoneNames, gridName);
                    spravochGrid.DataSource = zoneNamesBS;
                    this.Text = "Зоны хранения";

                    break;
                case Utils.GridName.StorageGroups:
                    storageGroupsService = Program.kernel.Get<IStorageGroupsService>();
                    storageGroupsBS.DataSource = storageGroupsService.GetStorageGroups();
                    GridColumnCreate(Utils.dictStorageGroups, gridName);
                    spravochGrid.DataSource = storageGroupsBS;
                    this.Text = "Складские группы";
                    access = UsersService.AuthorizatedUserAccess.Any(c => c.TaskName == "storageGroupsItem" && c.AccessRightId == 1);
                    break;
                case Utils.GridName.Persons:
                    personsService = Program.kernel.Get<IPersonsService>();
                    personsBS.DataSource = personsService.GetPersons();
                    GridColumnCreate(Utils.dictPersons, gridName);
                    spravochGrid.DataSource = personsBS;
                    this.Text = "Ответственные лица";
                    access = UsersService.AuthorizatedUserAccess.Any(c => c.TaskName == "personsItem" && c.AccessRightId == 1);
                    break;
                case Utils.GridName.Profession:
                    professionService = Program.kernel.Get<IProfessionService>();
                    professionBS.DataSource = professionService.GetProfession();
                    GridColumnCreate(Utils.dictProfession, gridName);
                    spravochGrid.DataSource = professionBS;
                    this.Text = "Профессии";
                    access = UsersService.AuthorizatedUserAccess.Any(c => c.TaskName == "professionItem" && c.AccessRightId == 1);
                    break;
                case Utils.GridName.Alarms:
                    settingsService = Program.kernel.Get<ISettingsService>();
                    alarmsBS.DataSource = settingsService.GetAlarms();
                    GridColumnCreate(Utils.dictAlarms, gridName);
                    spravochGrid.DataSource = alarmsBS;
                    this.Text = "Журнал сообшений об ошибках";
                    access = UsersService.AuthorizatedUserAccess.Any(c => c.TaskName == "alarmItem" && c.AccessRightId == 1);
                    break;
                default:

                    break;
            }

            if (access)
                AuthorizatedUserAccess();
            splashScreenManager.CloseWaitForm();
        }

        public void GridColumnCreate(Dictionary<String, String> dict, Utils.GridName grName)
        {
            foreach (var prop in dict)
            {
                GridColumn column = new GridColumn();
                column.Caption = prop.Value;
                column.FieldName = prop.Key;
                spravochGridView.Columns.Add(column);
                column.Visible = true;
                column.OptionsColumn.AllowEdit = false;
                column.OptionsColumn.AllowFocus = false;
                column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                
                if ((grName == Utils.GridName.ZoneNames) && (prop.Key == "ZoneColor"))
                {
                    column.ColumnEdit = repositoryItemColorPickEdit;
                }
            }

        }

        private void addSpravochItemBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (gridName)
            {
                case Utils.GridName.Units:

                    using (UnitEditFm unitEditFm = new UnitEditFm(Utils.Operation.Add, new UnitsDTO()))
                    {
                        if (unitEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            int return_UnitId = unitEditFm.Return();
                            spravochGridView.BeginDataUpdate();

                            unitsService = Program.kernel.Get<IUnitsService>();
                            unitsBS.DataSource = unitsService.GetUnits();
                            spravochGrid.DataSource = unitsBS;

                            spravochGridView.EndDataUpdate();
                            int rowHandle = spravochGridView.LocateByValue("UnitId", return_UnitId);
                            spravochGridView.FocusedRowHandle = rowHandle;
                        }
                    }
                    break;

                case Utils.GridName.Users:

                    using (UserEditFm userEditFm = new UserEditFm(Utils.Operation.Add, new UsersDTO()))
                    {
                        if (userEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            int return_UserId = userEditFm.Return();
                            spravochGridView.BeginDataUpdate();

                            usersService = Program.kernel.Get<IUsersService>();
                            usersBS.DataSource = usersService.GetUsers();
                            spravochGrid.DataSource = usersBS;

                            spravochGridView.EndDataUpdate();
                            int rowHandle = spravochGridView.LocateByValue("UserId", return_UserId);
                            spravochGridView.FocusedRowHandle = rowHandle;
                        }
                    }
                    break;

                case Utils.GridName.Contractors:

                    using (ContractorEditFm contractorEditFm = new ContractorEditFm(Utils.Operation.Add, new ContractorsDTO()))
                    {
                        if ( contractorEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            int return_ContractorId =  contractorEditFm.Return();
                            spravochGridView.BeginDataUpdate();

                            contractorsService = Program.kernel.Get<IContractorsService>();
                            contractorsBS.DataSource = contractorsService.GetContractors();
                            spravochGrid.DataSource = contractorsBS;

                            spravochGridView.EndDataUpdate();
                            int rowHandle = spravochGridView.LocateByValue("ContractorId", return_ContractorId);
                            spravochGridView.FocusedRowHandle = rowHandle;
                        }
                    }
                    break;

                case Utils.GridName.StorageGroups:

                    using (StorageGroupEditFm storageGroupEditFm = new StorageGroupEditFm(Utils.Operation.Add, new StorageGroupsDTO()))
                    {
                        if (storageGroupEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            int return_StorageGroupId = storageGroupEditFm.Return();
                            spravochGridView.BeginDataUpdate();

                            storageGroupsService = Program.kernel.Get<IStorageGroupsService>();
                            storageGroupsBS.DataSource = storageGroupsService.GetStorageGroups();
                            spravochGrid.DataSource = storageGroupsBS;

                            spravochGridView.EndDataUpdate();
                            int rowHandle = spravochGridView.LocateByValue("StorageGroupId", return_StorageGroupId);
                            spravochGridView.FocusedRowHandle = rowHandle;
                        }
                    }
                    break;

                case Utils.GridName.Measures:

                     new MeasureEditFm(Utils.Operation.Add, (MeasuresDTO)measuresBS.Current, (obj) => { measuresBS.Add(obj); }).ShowDialog();
                     measuresService = Program.kernel.Get<IMeasuresService>();
                     measuresBS.DataSource = measuresService.GetMeasures();
                     this.spravochGrid.DataSource = null;
                     this.spravochGrid.DataSource = this.measuresBS;
                     break;

                case Utils.GridName.Currency:

                     //new CurrencyEditFm(Utils.Operation.Add, (CurrencyDTO)currencyBS.Current, (obj) => { CurrencyBS.Add(obj); }).ShowDialog();
                     currencyService = Program.kernel.Get<ICurrencyService>();
                     currencyBS.DataSource = currencyService.GetCurrency();
                     this.spravochGrid.DataSource = null;
                     this.spravochGrid.DataSource = this.currencyBS;
                     break;

                case Utils.GridName.ZoneNames:

                     using (ZoneNameEditFm zoneNameEditFm = new ZoneNameEditFm(Utils.Operation.Add, new ZoneNamesDTO()))
                     {
                         if (zoneNameEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                         {
                             int return_ZoneNameId = zoneNameEditFm.Return();
                             spravochGridView.BeginDataUpdate();

                             zoneNamesService = Program.kernel.Get<IZoneNamesService>();
                             zoneNamesBS.DataSource = zoneNamesService.GetZones();
                             spravochGrid.DataSource = zoneNamesBS;

                             spravochGridView.EndDataUpdate();
                             int rowHandle = spravochGridView.LocateByValue("ZoneNameId", return_ZoneNameId);
                             spravochGridView.FocusedRowHandle = rowHandle;
                         }
                     }
                     break;

                case Utils.GridName.Persons:

                     using (PersonEditFm personEditFm = new PersonEditFm(Utils.Operation.Add, new PersonsDTO()))
                     {
                         if (personEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                         {
                             int return_PersonId = personEditFm.Return();
                             spravochGridView.BeginDataUpdate();

                             personsService = Program.kernel.Get<IPersonsService>();
                             personsBS.DataSource = personsService.GetPersons();
                             spravochGrid.DataSource = personsBS;

                             spravochGridView.EndDataUpdate();
                             int rowHandle = spravochGridView.LocateByValue("PersonId", return_PersonId);
                             spravochGridView.FocusedRowHandle = rowHandle;
                         }
                     }
                     break;

                case Utils.GridName.Profession:

                     using (ProfessionEditFm professionEditFm = new ProfessionEditFm(Utils.Operation.Add, new ProfessionsDTO()))
                     {
                         if (professionEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                         {
                             int return_Id = professionEditFm.Return();
                             spravochGridView.BeginDataUpdate();

                             professionService = Program.kernel.Get<IProfessionService>();
                             professionBS.DataSource = professionService.GetProfession();
                             spravochGrid.DataSource = professionBS;

                             spravochGridView.EndDataUpdate();
                             int rowHandle = spravochGridView.LocateByValue("Id", return_Id);
                             spravochGridView.FocusedRowHandle = rowHandle;
                         }
                     }
                     break;
                case Utils.GridName.Alarms:

                     using (AlarmEditFm alarmEditFm = new AlarmEditFm(Utils.Operation.Add, new AlarmsDTO()))
                     {
                         if (alarmEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                         {
                             int return_Id = alarmEditFm.Return();
                             spravochGridView.BeginDataUpdate();

                             settingsService = Program.kernel.Get<ISettingsService>();
                             alarmsBS.DataSource = settingsService.GetAlarms();
                             spravochGrid.DataSource = alarmsBS;

                             spravochGridView.EndDataUpdate();
                             int rowHandle = spravochGridView.LocateByValue("Id", return_Id);
                             spravochGridView.FocusedRowHandle = rowHandle;
                         }
                     }
                     break;
                default:
                    break;
            }
           
        }

        private void editSpravochItemBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (gridName)
            {
                case Utils.GridName.Units:

                    if (unitsBS.Count != 0)
                    {
                        using (UnitEditFm unitEditFm = new UnitEditFm(Utils.Operation.Update, (UnitsDTO)unitsBS.Current))
                        {
                            if (unitEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                int return_UnitId = unitEditFm.Return();
                                spravochGridView.BeginDataUpdate();

                                unitsService = Program.kernel.Get<IUnitsService>();
                                unitsBS.DataSource = unitsService.GetUnits();
                                spravochGrid.DataSource = unitsBS;

                                spravochGridView.EndDataUpdate();
                                int rowHandle = spravochGridView.LocateByValue("UnitId", return_UnitId);
                                spravochGridView.FocusedRowHandle = rowHandle;
                            }
                        }
                    }
                    break;

                case Utils.GridName.Users:
                    
                    if (usersBS.Count != 0)
                    {
                        using (UserEditFm userEditFm = new UserEditFm(Utils.Operation.Update, (UsersDTO)usersBS.Current))
                        {
                            if (userEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                int return_UserId = userEditFm.Return();
                                spravochGridView.BeginDataUpdate();

                                usersService = Program.kernel.Get<IUsersService>();
                                usersBS.DataSource = usersService.GetUsers();
                                spravochGrid.DataSource = usersBS;

                                spravochGridView.EndDataUpdate();
                                int rowHandle = spravochGridView.LocateByValue("UserId", return_UserId);
                                spravochGridView.FocusedRowHandle = rowHandle;
                            }
                        }
                    }
                    break;

                case Utils.GridName.Contractors:

                    if (contractorsBS.Count != 0)
                    {
                        using (ContractorEditFm contractorEditFm = new ContractorEditFm(Utils.Operation.Update, (ContractorsDTO)contractorsBS.Current))
                        {
                            if (contractorEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                int return_ContractorId = contractorEditFm.Return();
                                spravochGridView.BeginDataUpdate();

                                contractorsService = Program.kernel.Get<IContractorsService>();
                                contractorsBS.DataSource = contractorsService.GetContractors();
                                spravochGrid.DataSource = contractorsBS;

                                spravochGridView.EndDataUpdate();
                                int rowHandle = spravochGridView.LocateByValue("ContractorId", return_ContractorId);
                                spravochGridView.FocusedRowHandle = rowHandle;
                            }
                        }
                        break;
                    }
                    break;

                case Utils.GridName.StorageGroups:

                    if (storageGroupsBS.Count != 0)
                    {
                        using (StorageGroupEditFm storageGroupEditFm = new StorageGroupEditFm(Utils.Operation.Update, (StorageGroupsDTO)storageGroupsBS.Current))
                        {
                            if (storageGroupEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                int return_StorageGroupId = storageGroupEditFm.Return();
                                spravochGridView.BeginDataUpdate();

                                storageGroupsService = Program.kernel.Get<IStorageGroupsService>();
                                storageGroupsBS.DataSource = storageGroupsService.GetStorageGroups();
                                spravochGrid.DataSource = storageGroupsBS;

                                spravochGridView.EndDataUpdate();
                                int rowHandle = spravochGridView.LocateByValue("StorageGroupId", return_StorageGroupId);
                                spravochGridView.FocusedRowHandle = rowHandle;
                            }
                        }
                        break;
                    }
                    break;

                case Utils.GridName.Measures:

                    if (measuresBS.Count != 0)
                    {
                        new MeasureEditFm(Utils.Operation.Update, (MeasuresDTO)measuresBS.Current, (obj) => { }).ShowDialog();
                        measuresService = Program.kernel.Get<IMeasuresService>();
                        measuresBS.DataSource = measuresService.GetMeasures();

                        this.spravochGrid.DataSource = null;
                        this.spravochGrid.DataSource = this.measuresBS;
                    }
                    break;

                case Utils.GridName.Currency:

                    if (currencyBS.Count != 0)
                    {
                        //new CurrencyEditFm(Utils.Operation.Update, (CurrencyDTO)currencyBS.Current, (obj) => { }).ShowDialog();
                        currencyService = Program.kernel.Get<ICurrencyService>();
                        currencyBS.DataSource = currencyService.GetCurrency();
                        this.spravochGrid.DataSource = null;
                        this.spravochGrid.DataSource = this.currencyBS;
                    }
                    break;

                case Utils.GridName.ZoneNames:

                    if (zoneNamesBS.Count != 0)
                    {
                        new ZoneNameEditFm(Utils.Operation.Update, (ZoneNamesDTO)zoneNamesBS.Current).ShowDialog();
                        zoneNamesService = Program.kernel.Get<IZoneNamesService>();
                        zoneNamesBS.DataSource = zoneNamesService.GetZones();
                        this.spravochGrid.DataSource = null;
                        this.spravochGrid.DataSource = this.zoneNamesBS;
                    }
                    break;

                case Utils.GridName.Persons:

                    if (personsBS.Count != 0)
                    {
                        using (PersonEditFm personEditFm = new PersonEditFm(Utils.Operation.Update, (PersonsDTO)personsBS.Current))
                        {
                            if (personEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                int return_PersonId = personEditFm.Return();
                                spravochGridView.BeginDataUpdate();

                                personsService = Program.kernel.Get<IPersonsService>();
                                personsBS.DataSource = personsService.GetPersons();
                                spravochGrid.DataSource = personsBS;

                                spravochGridView.EndDataUpdate();
                                int rowHandle = spravochGridView.LocateByValue("PersonId", return_PersonId);
                                spravochGridView.FocusedRowHandle = rowHandle;
                            }
                        }
                    }
                    break;

                case Utils.GridName.Profession:

                    if (professionBS.Count != 0)
                    {
                        using (ProfessionEditFm professionEditFm = new ProfessionEditFm(Utils.Operation.Update, (ProfessionsDTO)professionBS.Current))
                        {
                            if (professionEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                int return_Id = professionEditFm.Return();
                                spravochGridView.BeginDataUpdate();

                                professionService = Program.kernel.Get<IProfessionService>();
                                personsBS.DataSource = professionService.GetProfession();
                                spravochGrid.DataSource = professionBS;

                                spravochGridView.EndDataUpdate();
                                int rowHandle = spravochGridView.LocateByValue("Id", return_Id);
                                spravochGridView.FocusedRowHandle = rowHandle;
                            }
                        }
                    }
                    break;
                case Utils.GridName.Alarms:

                    if (alarmsBS.Count != 0)
                    {
                        using (AlarmEditFm alarmEditFm = new AlarmEditFm(Utils.Operation.Update, (AlarmsDTO)alarmsBS.Current))
                        {
                            if (alarmEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                int return_Id = alarmEditFm.Return();
                                spravochGridView.BeginDataUpdate();

                                settingsService = Program.kernel.Get<ISettingsService>();
                                alarmsBS.DataSource = settingsService.GetAlarms();
                                spravochGrid.DataSource = alarmsBS;

                                spravochGridView.EndDataUpdate();
                                int rowHandle = spravochGridView.LocateByValue("Id", return_Id);
                                spravochGridView.FocusedRowHandle = rowHandle;
                            }
                        }
                    }
                    break;
                default:
                    
                    break;
            }
        }

        private void deleteSpravochItemBtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            switch (gridName)
            {
                case Utils.GridName.Units:
                   
                    if (unitsBS.Count != 0)
                    {
                        if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                          Error.ErrorCRUD result = this.unitsService.UnitDelete((UnitsDTO)unitsBS.Current);
                          if (result == Error.ErrorCRUD.NoError)
                          {
                              this.unitsBS.RemoveCurrent();
                              unitsService = Program.kernel.Get<IUnitsService>();
                              unitsBS.DataSource = unitsService.GetUnits();
                              this.spravochGrid.DataSource = null;
                              this.spravochGrid.DataSource = this.unitsBS;
                          }
                          else
                          {
                              switch (result)
                              {
                                  case Error.ErrorCRUD.RelationError:
                                      MessageBox.Show("Ед.измерения нельзя удалить. Есть связанные данные!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                      break;
                                  case Error.ErrorCRUD.DatabaseError:
                                      MessageBox.Show("Ошибка Базы данных!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                      break;
                                  default:
                                      break;
                              }
                          }
                        }
                    }
                    break;

                case Utils.GridName.Users:

                    if (usersBS.Count != 0)
                    {
                        if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (this.usersService.UserDeleteById(((UsersDTO)usersBS.Current).UserId))
                            {
                                int rowHandle = spravochGridView.FocusedRowHandle - 1;
                                spravochGridView.BeginDataUpdate();

                                usersService = Program.kernel.Get<IUsersService>();
                                usersBS.DataSource = usersService.GetUsers();
                                spravochGrid.DataSource = usersBS;

                                spravochGridView.EndDataUpdate();
                                spravochGridView.FocusedRowHandle = (spravochGridView.IsValidRowHandle(rowHandle)) ? rowHandle : -1;
                            }
                        }
                    }
                    break;

                case Utils.GridName.Contractors:

                    if (contractorsBS.Count != 0)
                    {
                        if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                          Error.ErrorCRUD result = this.contractorsService.ContractorDelete((ContractorsDTO)contractorsBS.Current);
                          if (result == Error.ErrorCRUD.NoError)
                          {
                              this.contractorsBS.RemoveCurrent();

                              contractorsService = Program.kernel.Get<IContractorsService>();
                              contractorsBS.DataSource = contractorsService.GetContractors();
                              this.spravochGrid.DataSource = null;
                              this.spravochGrid.DataSource = this.contractorsBS;
                          }
                          else
                          {
                              switch (result)
                              {
                                  case Error.ErrorCRUD.RelationError:
                                      MessageBox.Show("Поставщика нельзя удалить. Есть связанные данные!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                      break;
                                  case Error.ErrorCRUD.DatabaseError:
                                      MessageBox.Show("Ошибка Базы данных!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                      break;
                                  default:
                                      break;
                              }
                          }
                        }
                    }
                    break;

                case Utils.GridName.StorageGroups:

                    if (storageGroupsBS.Count != 0)
                    {
                        if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                           Error.ErrorCRUD result = this.storageGroupsService.StorageGroupsDelete((StorageGroupsDTO)storageGroupsBS.Current);
                          if (result == Error.ErrorCRUD.NoError)
                          {
                             this.storageGroupsBS.RemoveCurrent();

                            storageGroupsService = Program.kernel.Get<IStorageGroupsService>();
                            storageGroupsBS.DataSource = storageGroupsService.GetStorageGroups();
                            this.spravochGrid.DataSource = null;
                            this.spravochGrid.DataSource = this.storageGroupsBS;
                          }
                          else
                          {
                               switch (result)
                              {
                                  case Error.ErrorCRUD.RelationError:
                                      MessageBox.Show("Складскую группу нельзя удалить. Есть связанные данные!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                      break;
                                  case Error.ErrorCRUD.DatabaseError:
                                      MessageBox.Show("Ошибка Базы данных!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                      break;
                                  default:
                                      break;
                              }
                          }
                        }
                    }
                    break;

                case Utils.GridName.Measures:
                   
                    if (measuresBS.Count != 0)
                    {
                        if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (this.measuresService.MeasureDelete((MeasuresDTO)measuresBS.Current))
                                this.measuresBS.RemoveCurrent();

                            measuresService = Program.kernel.Get<IMeasuresService>();
                            measuresBS.DataSource = measuresService.GetMeasures();
                            this.spravochGrid.DataSource = null;
                            this.spravochGrid.DataSource = this.measuresBS;
                        }
                    }
                    break;

                case Utils.GridName.Currency:

                    if (currencyBS.Count != 0)
                    {
                        if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (this.currencyService.CurrencyDelete((CurrencyDTO)currencyBS.Current))
                                this.currencyBS.RemoveCurrent();

                            currencyService = Program.kernel.Get<ICurrencyService>();
                            currencyBS.DataSource = currencyService.GetCurrency();
                            this.spravochGrid.DataSource = null;
                            this.spravochGrid.DataSource = this.currencyBS;
                        }
                    }
                    break;

                case Utils.GridName.ZoneNames:

                    if (zoneNamesBS.Count != 0)
                    {
                        cellList = wareHousesService.GetWareHouses().ToList();
                        bool anyCellLoading = cellList.Any(s => s.ZoneNameId == (((ZoneNamesDTO)zoneNamesBS.Current).ZoneNameId) && s.LoadingStatusId > 1);// проверка загруженности зоны

                         if (anyCellLoading)
                         {
                             if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                             {
                                 if (this.zoneNamesService.ZoneAllDelete(((ZoneNamesDTO)zoneNamesBS.Current).ZoneNameId)) //удаление данных по всем связанным таблицам
                                 {
                                     if (this.zoneNamesService.ZoneNameDelete((ZoneNamesDTO)zoneNamesBS.Current))
                                         this.zoneNamesBS.RemoveCurrent();

                                     zoneNamesService = Program.kernel.Get<IZoneNamesService>();
                                     zoneNamesBS.DataSource = zoneNamesService.GetZones();
                                     this.spravochGrid.DataSource = null;
                                     this.spravochGrid.DataSource = this.zoneNamesBS;
                                 }
                             }
                         }
                         else
                             MessageBox.Show("Нельзя удалить зону. В выбранной зоне находиться ТОВАР.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;

                case Utils.GridName.Persons:

                    if (personsBS.Count != 0)
                    {
                        if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (this.personsService.PersonDelete((PersonsDTO)personsBS.Current))
                                this.personsBS.RemoveCurrent();

                            personsService = Program.kernel.Get<IPersonsService>();
                            personsBS.DataSource = personsService.GetPersons();
                            this.spravochGrid.DataSource = null;
                            this.spravochGrid.DataSource = this.personsBS;
                        }
                    }
                    break;

                case Utils.GridName.Profession:

                    if (professionBS.Count != 0)
                    {
                        if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (this.professionService.ProfessionDelete((ProfessionsDTO)professionBS.Current))
                                this.professionBS.RemoveCurrent();

                            professionService = Program.kernel.Get<IProfessionService>();
                            professionBS.DataSource = professionService.GetProfession();
                            this.spravochGrid.DataSource = null;
                            this.spravochGrid.DataSource = this.professionBS;
                        }
                    }
                    break;
                case Utils.GridName.Alarms:

                    if (alarmsBS.Count != 0)
                    {
                        if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (this.settingsService.AlarmDelete((AlarmsDTO)alarmsBS.Current))
                                this.alarmsBS.RemoveCurrent();

                            settingsService = Program.kernel.Get<ISettingsService>();
                            alarmsBS.DataSource = settingsService.GetAlarms();
                            this.spravochGrid.DataSource = null;
                            this.spravochGrid.DataSource = this.alarmsBS;
                        }
                    }
                    break;
                default:

                    break;
            }
           
        }

        private void AuthorizatedUserAccess()
        {

                addSpravochItemBtn.Enabled = false;
                editSpravochItemBtn.Enabled = false;
                deleteSpravochItemBtn.Enabled = false;

        }
    }
}
