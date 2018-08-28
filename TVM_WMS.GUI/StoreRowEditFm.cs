using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;
using System;
using System.Collections;
using System.IO;
using System.ComponentModel;

using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.Services;
using TVM_WMS.BLL.DTO;
using System.Collections.Generic;

namespace TVM_WMS.GUI
{
    public partial class StoreRowEditFm : DevExpress.XtraEditors.XtraForm
    {
        private IStoreNamesService storeNamesService;
        private IEnumerationTypesService enumerationTypesService;
        
        private BindingSource storeNamesBS = new BindingSource();

        private Utils.Operation _operation;
        public int _storeNameId;

        public ObjectBase Item
        {
            get { return storeNamesBS.Current as ObjectBase; }
            set
            {
                storeNamesBS.DataSource = value;
                //set in edit mode
                value.BeginEdit();
            }
        }

        public StoreRowEditFm(Utils.Operation operation, StoreNamesDTO model)
        {
            InitializeComponent();

            _storeNameId = (operation == Utils.Operation.Add) ? -1 : model.StoreNameId;
            _operation = operation;
            storeNamesBS.DataSource = Item = model;
            
            nameTBox.DataBindings.Add("EditValue", storeNamesBS, "Name");
            cellCountTBox.DataBindings.Add("EditValue", storeNamesBS, "CellCount", true);
            lineCountTBox.DataBindings.Add("EditValue", storeNamesBS, "LineCount", true);
            columnCountTBox.DataBindings.Add("EditValue", storeNamesBS, "ColumnCount", true);
            
            SetEnumerationType(model);
        }
               
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!ControlValidation()) return;

            if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Item.EndEdit();

                if (SaveStoreName())
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Item.CancelEdit();
            this.Close();
        }

        private void storeRowValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void storeRowValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (storeRowValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }

        private void nameTBox_TextChanged(object sender, EventArgs e)
        {
            storeRowValidationProvider.Validate((Control)sender);
        }

        private void cellCountTBox_TextChanged(object sender, EventArgs e)
        {
            storeRowValidationProvider.Validate((Control)sender);
        }

        private void lineCountTBox_TextChanged(object sender, EventArgs e)
        {
            storeRowValidationProvider.Validate((Control)sender);
        }

        private void columnCountTBox_TextChanged(object sender, EventArgs e)
        {
            storeRowValidationProvider.Validate((Control)sender);
        }

        private bool ControlValidation()
        {
            return storeRowValidationProvider.Validate();
        }

        public int Return()
        {
            return _storeNameId;
        }

        private bool SaveStoreName()
        {
            storeNamesService = Program.kernel.Get<IStoreNamesService>();

            if (FindStoreNameDuplicate((StoreNamesDTO)storeNamesBS.Current))
            {
                MessageBox.Show("Склад с таким наименование уже существует. Введите другое наименование.\n",
                                "Проверка уникальности наименования устройства", MessageBoxButtons.OK, MessageBoxIcon.Information);
                nameTBox.Focus();

                return false;
            }

            try
            {
                int enumTypeId = GetEnumerationTypeId();
                if (enumTypeId > 0)
                    ((StoreNamesDTO)storeNamesBS.Current).EnumerationTypeId = enumTypeId; 

                if (_operation == Utils.Operation.Add)
                    _storeNameId = storeNamesService.StoreNameCreate((StoreNamesDTO)storeNamesBS.Current);
                else
                    storeNamesService.StoreNameUpdate((StoreNamesDTO)storeNamesBS.Current);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении склада!\n" + ex.Message, "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool FindStoreNameDuplicate(StoreNamesDTO item)
        {
            return storeNamesService.GetStoreNames().Any(s => s.Name == item.Name && s.ParentId == item.ParentId && s.StoreNameId != item.StoreNameId);
        }

        private int GetEnumerationTypeId()
        {
            enumerationTypesService = Program.kernel.Get<IEnumerationTypesService>();
            var typeSource = enumerationTypesService.GetEnumerationTypes();

            switch (numberingRGroup.SelectedIndex)
            {
                case 0:
                    return typeSource.FirstOrDefault(s => s.EnumerationTypeName == "LeftToRight").EnumerationTypeId;
                case 1:
                    return typeSource.FirstOrDefault(s => s.EnumerationTypeName == "LeftToRight(Snake)").EnumerationTypeId;
                default:
                    return -1;
            }
        }

        private void SetEnumerationType(StoreNamesDTO model)
        {
            switch (model.EnumerationTypeId)
            {
                case 1:
                    numberingRGroup.SelectedIndex = 0;
                    break;
                case 2:
                    numberingRGroup.SelectedIndex = 1;
                    break;
                default:
                    numberingRGroup.SelectedIndex = 0;
                    break;
            }       
        }
    }
}