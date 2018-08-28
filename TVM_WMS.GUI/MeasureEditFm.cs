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
    public partial class MeasureEditFm : Form
    {

        private IMeasuresService measuresService;
        private BindingSource measuresBS = new BindingSource();
        private BindingSource unitsBS = new BindingSource();
        private BindingSource packingTypesBS = new BindingSource();

        private IPackingTypesService packingTypesService;
        private IUnitsService unitsService;
   
        private Utils.Operation operation;
        private Action<object> callback;
        private MeasuresDTO measure1, measure2;
       
       // private List<PackingTypesDTO> packingTypes = new List<PackingTypesDTO>();
  
        private MeasureEditFm(Utils.Operation operation)
        {
            InitializeComponent();
            LoadMeasuresData();

            this.operation = operation;

            heightTBox.DataBindings.Add("EditValue", measuresBS, "Height");
            widthTBox.DataBindings.Add("EditValue", measuresBS, "Width");
            lengthTBox.DataBindings.Add("EditValue", measuresBS, "Length");
            weightTBox.DataBindings.Add("EditValue", measuresBS, "UnitWeight");

            packingTypesBS.DataSource = packingTypesService.GetPackingTypes();
            packingTypeEdit.Properties.DataSource = packingTypesBS;
            packingTypeEdit.Properties.ValueMember = "PackingTypeId";
            packingTypeEdit.Properties.DisplayMember = "PackingName";
            packingTypeEdit.Properties.NullText = "Нет данных";

            unitsBS.DataSource = unitsService.GetUnits();
            unitEdit.Properties.DataSource = unitsBS;
            unitEdit.Properties.ValueMember = "UnitId";
            unitEdit.Properties.DisplayMember = "UnitLocalName";
            unitEdit.Properties.NullText = "Нет данных";
           
        }

        private void LoadMeasuresData()
        {
            measuresService = Program.kernel.Get<IMeasuresService>();
            packingTypesService = Program.kernel.Get<IPackingTypesService>();
            unitsService = Program.kernel.Get<IUnitsService>();
        }

        public MeasureEditFm(Utils.Operation operation, MeasuresDTO measure, Action<object> callback)
            : this(operation)
        {
            this.callback = callback;
            this.measure1 = measure;

            if (this.callback.Target == null)// null - в режиме изменение
              {
                this.measure2 = new MeasuresDTO { MeasureId = measure.MeasureId, Height = measure.Height, Length = measure.Length, UnitWeight = measure.UnitWeight ,
                                                  Width = measure.Width,UnitId = measure.UnitId, PackingTypeId = measure.PackingTypeId, UnitLocalName = measure.UnitLocalName, PackingName = measure.PackingName };
                packingTypeEdit.EditValue = measure.PackingTypeId;
                unitEdit.EditValue = measure.UnitId;

                ButtonEnabled();
             }
            else
            {
                this.measure2 = new MeasuresDTO();
                ButtonEnabled();
            }

            this.measuresBS.DataSource = this.measure2;
        }

        private void ButtonEnabled()
        {
             if (!(measure2.UnitId.HasValue))  //если значение UnitId = null, кнопка редактировать и удалить не активна
                    UnitEditBtnEnabled(false);

             if (!(measure2.PackingTypeId.HasValue))
                    PackingTypeEditBtnEnabled(false);
        }

        private void PackingTypeEditBtnEnabled(bool state)
        {
            packingTypeEdit.Properties.Buttons[3].Enabled = state;
            packingTypeEdit.Properties.Buttons[4].Enabled = state;
        }

        private void UnitEditBtnEnabled(bool state)
        {
            unitEdit.Properties.Buttons[3].Enabled = state;
            unitEdit.Properties.Buttons[4].Enabled = state;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            UpdateMeasureBS();
            if (this.operation == Utils.Operation.Add)
            {
                this.measure2.PackingTypeId = (packingTypeEdit.ItemIndex >= 0) ? ((PackingTypesDTO)packingTypeEdit.GetSelectedDataRow()).PackingTypeId : (int?)null;
                this.measure2.UnitId = (unitEdit.ItemIndex >= 0) ? ((UnitsDTO)unitEdit.GetSelectedDataRow()).UnitId : (int?)null;
                this.measure2.MeasureId = measuresService.MeasureCreate(((MeasuresDTO)measuresBS.Current));
                if (this.callback != null)
                    this.callback(this.measure2);
            }
            else
            {
                this.measure2.PackingTypeId = (packingTypeEdit.ItemIndex >= 0) ? ((PackingTypesDTO)packingTypeEdit.GetSelectedDataRow()).PackingTypeId : (int?)null;
                this.measure2.UnitId = (unitEdit.ItemIndex >= 0) ? ((UnitsDTO)unitEdit.GetSelectedDataRow()).UnitId : (int?)null;
                measuresService.MeasureUpdate(((MeasuresDTO)measuresBS.Current));
                this.measure1.PackingName = this.measure2.PackingName;
                this.measure1.Height = this.measure2.Height;
                this.measure1.Width = this.measure2.Width;
                this.measure1.Length = this.measure2.Length;
                this.measure1.UnitWeight = this.measure2.UnitWeight;
                this.measure1.UnitId = this.measure2.UnitId;
                this.measure1.UnitLocalName = this.measure2.UnitLocalName;
                this.measure1.PackingTypeId = this.measure2.PackingTypeId;
            }

            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void UpdateMeasureBS()
        { 
            measuresBS.EndEdit();
        }

        private void packingTypeEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index) //Тип Упаковки PackingTypes
            {
                case 1: //Очистить
                    {
                        packingTypeEdit.EditValue = null;
                        packingTypeEdit.Properties.NullText = "Нет данных";
                        PackingTypeEditBtnEnabled(false);
                        break;
                    }
                case 2: //ДОБАВИТЬ
                    {
                        new PackingTypeEditFm(Utils.Operation.Add, (PackingTypesDTO)packingTypesBS.Current, (obj) => { packingTypesBS.Add(obj); }).ShowDialog();
                        break;
                    }
                case 3://РЕДАКТИРОВАТЬ
                    {
                        new PackingTypeEditFm(Utils.Operation.Update, (PackingTypesDTO)packingTypeEdit.GetSelectedDataRow(), (obj) => { }).ShowDialog();
                        break;
                    }
                case 4://УДАЛИТЬ
                    {
                        if (packingTypesBS.Count != 0)
                        {
                            if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                this.packingTypesService.PackingTypeDelete((PackingTypesDTO)packingTypeEdit.GetSelectedDataRow());
                                packingTypeEdit.EditValue = null;
                                packingTypeEdit.Properties.NullText = "Нет данных";
                            }
                        }
                        break;
                    }

                default:
                    {
                        break;
                    }
            }

            if (e.Button.Index != 0)// для кнопки выбора индекс 0 ,не обновлять
            {
                packingTypesService = Program.kernel.Get<IPackingTypesService>();
                packingTypesBS.DataSource = packingTypesService.GetPackingTypes();
                packingTypeEdit.Properties.DataSource = null;
                packingTypeEdit.Properties.DataSource = packingTypesBS;
            }
        }

        private void unitEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            switch (e.Button.Index)//Единица измерения Units
            {
                case 1: //Очистить
                    {
                        unitEdit.EditValue = null;
                        unitEdit.Properties.NullText = "Нет данных";
                        UnitEditBtnEnabled(false);
                        break;
                    }
                case 2: //ДОБАВИТЬ
                    {
                        new UnitEditFm(Utils.Operation.Add, (UnitsDTO)unitsBS.Current).ShowDialog();
                        break;
                    }
                case 3://РЕДАКТИРОВАТЬ
                    {
                        new UnitEditFm(Utils.Operation.Update, (UnitsDTO)unitEdit.GetSelectedDataRow()).ShowDialog();
                        break;
                    }
                case 4://УДАЛИТЬ
                    {
                        if (unitsBS.Count != 0)
                        {
                            if (MessageBox.Show("Удалить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                this.unitsService.UnitDelete((UnitsDTO)unitEdit.GetSelectedDataRow());
                                unitEdit.EditValue = null;
                                unitEdit.Properties.NullText = "Нет данных";
                            }
                        }
                        break;
                    }

                default:
                    {
                        break;
                    }
            }

            if (e.Button.Index != 0)// для кнопки выбора индекс 0 ,не обновлять
            {
                unitsService = Program.kernel.Get<IUnitsService>();
                unitsBS.DataSource = unitsService.GetUnits();
                unitEdit.Properties.DataSource = null;
                unitEdit.Properties.DataSource = unitsBS;
            }
        }

        private void unitEdit_EditValueChanged(object sender, EventArgs e)
        {
             UnitEditBtnEnabled(true);
             unitEdit.Properties.NullText = "Нет данных";

        }

        private void packingTypeEdit_EditValueChanged(object sender, EventArgs e)
        {
            PackingTypeEditBtnEnabled(true);
            packingTypeEdit.Properties.NullText = "Нет данных";
        }


    }
}