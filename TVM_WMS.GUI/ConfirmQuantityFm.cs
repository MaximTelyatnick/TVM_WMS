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
using TVM_WMS.BLL.Infrastructure.PlcWrapper;
using TVM_WMS.BLL.DTO.QueryDTO;
using TVM_WMS.BLL.Interfaces;
using Ninject;
using TVM_WMS.BLL.DTO;
using TVM_WMS.BLL.Infrastructure.SerialPortListener;
using TVM_WMS.BLL.BusinessLogicModule;
using DevExpress.XtraEditors.DXErrorProvider;

namespace TVM_WMS.GUI
{
    public partial class ConfirmQuantityFm : DevExpress.XtraEditors.XtraForm
    {
        private ConfirmQuantityDTO _sourceModel = new ConfirmQuantityDTO();
        private BindingSource quantityBS = new BindingSource();

        private PLC _plc;
        private SerialPortManager _spManager;

        private List<DataItemsQueryDTO> TagList = new List<DataItemsQueryDTO>();

        private bool _canEditQuantity;
        private decimal _maxQuantity;

        public ConfirmQuantityFm(PLC plc, SerialPortManager spManager, ConfirmQuantityDTO sourceModel, bool canEditQuantity)
        {
            _sourceModel = sourceModel;
            _plc = plc;
            _spManager = spManager;
            _canEditQuantity = canEditQuantity;
            _maxQuantity = sourceModel.Quantity;

            quantityBS.DataSource = _sourceModel;

            InitializeComponent();

            articleLbl.Text = _sourceModel.Article;
            materialLbl.Text = _sourceModel.MaterialName;
            unitLocalNameLbl.Text = _sourceModel.UnitLocalName;
            maxQuantityLbl.Text = _sourceModel.Quantity.ToString();

            quantityEdit.DataBindings.Add("EditValue", quantityBS, "Quantity", true, DataSourceUpdateMode.OnPropertyChanged);
            currentWeightTBox.DataBindings.Add("EditValue", quantityBS, "CurrentWeight", true, DataSourceUpdateMode.OnPropertyChanged);
            oldWeightTBox.DataBindings.Add("EditValue", quantityBS, "OldWeight", true, DataSourceUpdateMode.OnPropertyChanged);
            
            quantityEdit.ReadOnly = (canEditQuantity) ? false : true;

            ConditionValidationRule rule = new ConditionValidationRule();
            rule.ConditionOperator = ConditionOperator.Between;
            rule.ErrorText = "Введенное количество превышает доступное, либо равно 0";
            rule.ErrorType = ErrorType.Critical;
            rule.Value1 = 0.01m;
            rule.Value2 = _maxQuantity;
            confirmValidationProvider.SetValidationRule(quantityEdit, rule);

            StartTimer();
        }

        private void StartTimer()
        {
            if (_plc.ConnectionState == ConnectionStates.Online)
            {
                waitTimer.Start();
            }
            else
            {
                MessageBox.Show("Ошибка при соединении!", "Cоединение с контроллером PLC", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();

            }
        }

        private void ConnectBarcode()
        {
            try
            {
                if (_spManager != null)
                    _spManager.StopListening();

                var scannerItem = ConfigClass.Instance.BarcodeSettingList.FirstOrDefault();

                _spManager = new SerialPortManager(scannerItem);

                _spManager.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved);

                _spManager.StartListening();

            }
            catch (Exception)
            {
                _spManager.NewSerialDataRecieved -= new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved);
            }
        }

        #region Barcode scanner

        private void _spManager_NewSerialDataRecieved(object sender, SerialDataEventArgs e)
        {
            if (this.InvokeRequired)
            {
                // Using this.Invoke causes deadlock when closing serial port, and BeginInvoke is good practice anyway.
                this.BeginInvoke(new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved), new object[] { sender, e });
                return;
            }

            string str = Encoding.UTF8.GetString(e.Data);

            BarcodeParseOperation(str);
        }

        private void BarcodeParseOperation(string source)
        {
            if (source.Substring(0, 1) == "*")
            {
                var bcSourceStr = source.Replace("\r", "").Split('*');

                if (bcSourceStr[0] == "3")
                {
                    int scanAcceptanceId = 0;
                    bool getNumber = Int32.TryParse(bcSourceStr[1], out scanAcceptanceId);
                    
                    if (getNumber && _sourceModel.ReceiptAcceptanceId == scanAcceptanceId)
                    {
                        SetConfirmQuantity();
                    }
                }
            }
        }

        #endregion

        private void waitTimer_Tick(object sender, EventArgs e)
        {
            TagList = _plc.Return();

            cellTBox.EditValue = TagList.First(s => s.Name == "CellNumber").CurrentValue;
            oldWeightTBox.EditValue = Convert.ToDecimal(TagList.First(s => s.Name == "OldWeight").CurrentValue);
            currentWeightTBox.EditValue = Convert.ToDecimal(TagList.First(s => s.Name == "CurrentWeight").CurrentValue);
        }

        public ConfirmQuantityDTO Return()
        {
            return (ConfirmQuantityDTO)quantityBS.Current;        
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            SetConfirmQuantity();
        }

        private void ConfirmQuantityFm_FormClosed(object sender, FormClosedEventArgs e)
        {
            waitTimer.Stop();
        }

        private void SetConfirmQuantity()
        {
            quantityBS.EndEdit();

            DialogResult = System.Windows.Forms.DialogResult.OK;

            this.Close();
        }

        private bool ControlValidation()
        {
            return confirmValidationProvider.Validate();
        }

        private void confirmValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.okBtn.Enabled = false;
        }

        private void confirmValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (confirmValidationProvider.GetInvalidControls().Count == 0);
            this.okBtn.Enabled = isValidate;
        }

        private void quantityEdit_TextChanged(object sender, EventArgs e)
        {
            confirmValidationProvider.Validate((Control)sender);
        }
    }
}