using System;
using System.Linq;
using System.Windows.Forms;
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.Interfaces;
using Ninject;
using TVM_WMS.BLL.BusinessLogicModule;

namespace TVM_WMS.GUI
{
    public partial class StoreNameEditFm : DevExpress.XtraEditors.XtraForm
    {
        private IStoreNamesService storeNamesService;
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

        public StoreNameEditFm(Utils.Operation operation, StoreNamesDTO model)
        {
            InitializeComponent();
         
            _operation = operation;
            _storeNameId = (operation == Utils.Operation.Add) ? -1 : model.StoreNameId;

            storeNamesBS.DataSource = Item = model;
            nameTBox.DataBindings.Add("EditValue", storeNamesBS, "Name");

            storeNamesService = Program.kernel.Get<IStoreNamesService>();

            storeTypeEdit.Properties.DataSource = storeNamesService.GetStoreTypes();
            storeTypeEdit.DataBindings.Add("EditValue", storeNamesBS, "StoreTypeId", true, DataSourceUpdateMode.OnPropertyChanged);
            storeTypeEdit.Properties.DisplayMember = "StoreTypeName";
            storeTypeEdit.Properties.ValueMember = "StoreTypeId";

            enableAuthomatizationChk.DataBindings.Add("Checked", storeNamesBS, "EnableAuthomatization");
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
                if (_operation == Utils.Operation.Add)
                    _storeNameId = storeNamesService.StoreNameCreate((StoreNamesDTO)Item);
                else
                    storeNamesService.StoreNameUpdate((StoreNamesDTO)Item);

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
            return storeNamesService.GetStoreNames().Any(s => s.Name == item.Name && s.StoreNameId != item.StoreNameId);
        }

        #region Validation

        private void storeTypeEdit_EditValueChanged(object sender, EventArgs e)
        {
            storeNameValidationProvider.Validate((Control)sender);
        }

        private void storeNameValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void storeNameValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (storeNameValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }

        private void nameTBox_TextChanged(object sender, EventArgs e)
        {
            storeNameValidationProvider.Validate((Control)sender);
        }

        private bool ControlValidation()
        {
            return storeNameValidationProvider.Validate();
        }

        #endregion
    }
}