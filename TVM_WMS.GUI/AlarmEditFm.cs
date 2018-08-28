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
using Ninject;

using TVM_WMS.BLL.BusinessLogicModule;
using TVM_WMS.BLL.Interfaces;
using TVM_WMS.BLL.Services;
using TVM_WMS.BLL.DTO;

namespace TVM_WMS.GUI
{
    public partial class AlarmEditFm : DevExpress.XtraEditors.XtraForm
    {
        private BindingSource alarmBS = new BindingSource();
        private ISettingsService settingsService;
        private Utils.Operation operation;

        public ObjectBase Item
        {
            get { return alarmBS.Current as ObjectBase; }
            set
            {
                alarmBS.DataSource = value;
                //set in edit mode
                value.BeginEdit();
            }
        }

        public AlarmEditFm(Utils.Operation operation, AlarmsDTO alarmItem)
        {
            InitializeComponent();

            settingsService = Program.kernel.Get<ISettingsService>();
            this.operation = operation;
            alarmBS.DataSource = Item = alarmItem;

            alarmNumberTBox.DataBindings.Add("EditValue", alarmBS, "AlarmNumber");
            alarmTextTBox.DataBindings.Add("EditValue", alarmBS, "AlarmText");
        }

        #region Event's

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (!ControlValidation()) return;

            if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (operation == Utils.Operation.Add && IsDuplicateRecord(((AlarmsDTO)Item).AlarmNumber ?? 0))
                {
                    MessageBox.Show("Код ошибки уже существует!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    alarmNumberTBox.Focus();
                    return;
                }

                SaveAlarm();

                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Item.CancelEdit();
            this.Close();
        }
                
        #endregion

        #region Method's

        private void SaveAlarm()
        {
            this.Item.EndEdit();

            if (this.operation == Utils.Operation.Add)
                ((AlarmsDTO)Item).Id = settingsService.AlarmCreate((AlarmsDTO)Item);
            else
                settingsService.AlarmUpdate((AlarmsDTO)Item);
        }

        private bool ControlValidation()
        {
            return alarmValidationProvider.Validate();
        }

        private bool IsDuplicateRecord(int alarmNumber)
        {
            int itemCount = settingsService.GetAlarms().Count(s => s.AlarmNumber == alarmNumber);

            return (itemCount > 0);
        }

        public int Return()
        {
            return ((AlarmsDTO)Item).Id;
        }

        #endregion

        #region Validation's

        private void alarmNumberTBox_TextChanged(object sender, EventArgs e)
        {
            alarmValidationProvider.Validate((Control)sender);
        }

        private void alarmTextTBox_TextChanged(object sender, EventArgs e)
        {
            alarmValidationProvider.Validate((Control)sender);
        }

        private void alarmValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void alarmValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (alarmValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }

        #endregion

    }
}