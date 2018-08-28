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
    public partial class PackingTypeEditFm : Form
    {
       
        private IPackingTypesService packingTypesService;
        private BindingSource packingTypesBS = new BindingSource();

        private Utils.Operation operation;
        private Action<object> callback;
        private PackingTypesDTO packingType1, packingType2;

        private PackingTypeEditFm(Utils.Operation operation)
        {
            InitializeComponent();
            LoadData();
            this.operation = operation;

            nameTBox.DataBindings.Add("EditValue",packingTypesBS, "PackingName");
           
        }

        private void LoadData()
        {
            packingTypesService = Program.kernel.Get<IPackingTypesService>();
        }

        public PackingTypeEditFm(Utils.Operation operation, PackingTypesDTO packingType, Action<object> callback)
            : this(operation)
        {
            this.callback = callback;
            this.packingType1 = packingType;

            if (this.callback.Target == null)// null - в режиме изменение
            {
                this.packingType2 = new PackingTypesDTO { PackingTypeId = packingType.PackingTypeId, PackingName = packingType.PackingName };
            }
            else
                if (packingType != null)
                    this.packingType2 = new PackingTypesDTO() { PackingTypeId = packingType.PackingTypeId };
                else
                    this.packingType2 = new PackingTypesDTO();

            this.packingTypesBS.DataSource = this.packingType2;

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (nameTBox.Text.Trim().Length == 0)
            {
                MessageBox.Show("Не указаны данные!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.operation == Utils.Operation.Add)
            {
                this.packingType2.PackingTypeId = this.packingTypesService.PackingTypeCreate(this.packingType2);
                if (this.callback != null)
                    this.callback(this.packingType2);

            }
            else
            {
                packingTypesService.PackingTypeUpdate(this.packingType2);
                this.packingType1.PackingName = this.packingType2.PackingName;
            }

            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
