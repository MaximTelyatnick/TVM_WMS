using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TVM_WMS.BLL.Infrastructure.SerialPortListener;

namespace TVM_WMS.GUI
{
    public partial class OperationCustomWaitFm : DevExpress.XtraEditors.XtraForm
    {
        private Utils.ProcessComand _command;
        private Utils.ProcessComand _returnCommand;

        public OperationCustomWaitFm(Utils.ProcessComand command)
        {
            InitializeComponent();

            _returnCommand = Utils.ProcessComand.None;
            _command = command;
            
            SetReturnCommandStatus();

            if (_command == Utils.ProcessComand.OpenCell)
            {
                operationRGroup.Properties.Items[0].Description = "Продолжить доставку кассеты на стол выдачи";
                operationRGroup.Properties.Items[1].Description = "Вернуть кассету на склад";
            }
            else
            {
                operationRGroup.Properties.Items[0].Description = "Продолжить доставку кассеты на склад";
                operationRGroup.Properties.Items[1].Description = "Вернуть кассету на стол выдачи";
            }
        }

        public Utils.ProcessComand Return()
        {
            return _returnCommand;
        }

        private void SetReturnCommandStatus()
        {
            if ((int)operationRGroup.EditValue == 0)
            {
                _returnCommand = (_command == Utils.ProcessComand.OpenCell) ? Utils.ProcessComand.CellOpenAgain : Utils.ProcessComand.CellCloseAgain;
            }
            else
            {
                _returnCommand = (_command == Utils.ProcessComand.OpenCell) ? Utils.ProcessComand.CellCloseAgain : Utils.ProcessComand.CellOpenAgain;
            }
        }

        private void operationRGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetReturnCommandStatus();
        }

        
        private void applyBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}