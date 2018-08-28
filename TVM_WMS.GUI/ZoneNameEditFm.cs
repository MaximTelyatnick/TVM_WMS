using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ninject;

using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.Services;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.GUI
{
    public partial class ZoneNameEditFm : Form
    { 
        private IZoneNamesService zoneNamesService;
        private BindingSource zoneNamesBS = new BindingSource();

        private Utils.Operation operation;

        public ObjectBase Item
        {
            get { return zoneNamesBS.Current as ObjectBase; }
            set
            {
                zoneNamesBS.DataSource = value;
                //set in edit mode
                value.BeginEdit();
            }
        }

        public ZoneNameEditFm(Utils.Operation operation, ZoneNamesDTO zoneName)
        {
            InitializeComponent();

            LoadZoneNamesData();
            this.operation = operation;
            zoneNameTBox.DataBindings.Add("EditValue",zoneNamesBS, "ZoneName");

            zoneTypeEdit.DataBindings.Add("EditValue",zoneNamesBS, "ZoneTypeId", true, DataSourceUpdateMode.OnPropertyChanged);
            zoneTypeEdit.Properties.DataSource = zoneNamesService.GetZoneTypes();
            zoneTypeEdit.Properties.ValueMember = "ZoneTypeId";
            zoneTypeEdit.Properties.DisplayMember = "ZoneTypeName";
            zoneNamesBS.DataSource = Item = zoneName;

            colorPickEdit.Color = ColorTranslator.FromHtml(((ZoneNamesDTO)Item).ZoneColor);
            zoneTypeEdit.EditValue = (operation == Utils.Operation.Add) ? 1 : zoneName.ZoneTypeId;
        }

        private void LoadZoneNamesData()
        {
            zoneNamesService = Program.kernel.Get<IZoneNamesService>();
        }

        public int Return()
        {
            return ((ZoneNamesDTO)Item).ZoneNameId;
        }

        private void SaveZone()
        {
            Color color = (Color)colorPickEdit.EditValue;
            //Color colorName = ColorTranslator.FromHtml('#' + color.Name);
            ((ZoneNamesDTO)Item).ZoneColor = '#' + color.Name;
            this.Item.EndEdit();

            if (this.operation == Utils.Operation.Add)
                ((ZoneNamesDTO)Item).ZoneNameId = zoneNamesService.ZoneNameCreate((ZoneNamesDTO)Item);
            else
                zoneNamesService.ZoneNameUpdate((ZoneNamesDTO)Item);
        }

        private bool ControlValidation()
        {
            return zoneValidationProvider.Validate();
        }

        private bool IsDuplicateRecord(string zoneName)
        {
            int itemCount = zoneNamesService.GetZones().Count(s => s.ZoneName == zoneName);

            return (itemCount > 0);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!ControlValidation()) return;

            if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (operation == Utils.Operation.Add && IsDuplicateRecord(((ZoneNamesDTO)Item).ZoneName))
                {
                    MessageBox.Show("Зона уже существует!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    zoneNameTBox.Focus();
                    return;
                }

                SaveZone();

                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Item.CancelEdit();
            this.Close();
        }

        #region Validation's

        private void zoneNameTBox_TextChanged(object sender, EventArgs e)
        {
            zoneValidationProvider.Validate((Control)sender);
        }


        private void zoneTypeEdit_EditValueChanged(object sender, EventArgs e)
        {
            zoneValidationProvider.Validate((Control)sender);
        }
        private void colorPickEdit_EditValueChanged(object sender, EventArgs e)
        {
            zoneValidationProvider.Validate((Control)sender);
        }

        private void zoneValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void zoneValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (zoneValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }
        #endregion
    }
}
