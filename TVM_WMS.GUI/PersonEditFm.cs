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

namespace TVM_WMS.GUI
{
    public partial class PersonEditFm : DevExpress.XtraEditors.XtraForm
    {

        private IPersonsService personsService;
        private BindingSource personsBS = new BindingSource();
        private IProfessionService professionService;
        private Utils.Operation operation;

        public ObjectBase Item
        {
            get { return personsBS.Current as ObjectBase; }
            set
            {
                personsBS.DataSource = value;
                //set in edit mode
                value.BeginEdit();
            }
        }

        public PersonEditFm(Utils.Operation operation, PersonsDTO person)
        {
            InitializeComponent();
            personsService = Program.kernel.Get<IPersonsService>();
            professionService = Program.kernel.Get<IProfessionService>();
            this.operation = operation;
            personsBS.DataSource = Item = person;

            personNameTBox.DataBindings.Add("EditValue", personsBS, "PersonName");

            professionEdit.DataBindings.Add("EditValue", personsBS, "ProfessionId", true, DataSourceUpdateMode.OnPropertyChanged);
            professionEdit.Properties.DataSource = professionService.GetProfession();
            professionEdit.Properties.ValueMember = "Id";
            professionEdit.Properties.DisplayMember = "ProfessionName";
            professionEdit.Properties.NullText = "[нет данных]";

            if (operation == Utils.Operation.Add)
                professionEdit.EditValue = 0;
 
        }

        # region Metod's

     
          private void SavePerson()
            {
                this.Item.EndEdit();

                if (this.operation == Utils.Operation.Add)
                    ((PersonsDTO)Item).PersonId = personsService.PersonCreate((PersonsDTO)Item);
                else
                    personsService.PersonUpdate((PersonsDTO)Item);
            }

            private bool ControlValidation()
            {
                return personValidationProvider.Validate();
            }

            private bool IsDuplicateRecord(string personName)
            {
                int itemCount = personsService.GetPersons().Count(s => s.PersonName== personName);

                return (itemCount > 0);
            }

            public int Return()
            {
                return ((PersonsDTO)Item).PersonId;
            }

           #endregion

        #region Events's

            private void professionEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
            {
                switch (e.Button.Index)
                {
                    case 1: //Добавить
                        {
                            using (ProfessionEditFm professionEditFm = new ProfessionEditFm(Utils.Operation.Add, new ProfessionsDTO()))
                            {
                                if (professionEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    int return_Id = professionEditFm.Return();

                                    professionService = Program.kernel.Get<IProfessionService>();
                                    professionEdit.Properties.DataSource = professionService.GetProfession();
                                    professionEdit.EditValue = return_Id;
                                }
                            }
                            break;
                        }
                    case 2: //Корректировать
                        {
                            if (professionEdit.ItemIndex == -1) return;

                            using (ProfessionEditFm professionEditFm = new ProfessionEditFm(Utils.Operation.Update, (ProfessionsDTO)professionEdit.GetSelectedDataRow()))
                            {
                                if (professionEditFm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    int return_Id = professionEditFm.Return();

                                    professionService = Program.kernel.Get<IProfessionService>();
                                    professionEdit.Properties.DataSource = professionService.GetProfession();
                                    professionEdit.EditValue = return_Id;
                                }
                            }
                            break;
                        }



                    default:
                        {
                            break;
                        }
                }
            }
            private void saveBtn_Click(object sender, EventArgs e)
            {
             if (!ControlValidation()) return;

                 if (MessageBox.Show("Сохранить изменения?", "Сохранение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 {
                     if (operation == Utils.Operation.Add && IsDuplicateRecord(((PersonsDTO)Item).PersonName))
                     {
                         MessageBox.Show("Человек с таким ФИО уже существует!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                         personNameTBox.Focus();
                         return;
                     }

                     SavePerson();

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

        #region Validation's

        private void personNameTBox_TextChanged(object sender, EventArgs e)
        {
            personValidationProvider.Validate((Control)sender);
         }

        
        private void professionEdit_EditValueChanged(object sender, EventArgs e)
        {
           personValidationProvider.Validate((Control)sender);
        }

        private void personValidationProvider_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {
            this.saveBtn.Enabled = false;
            this.validateLbl.Visible = true;
        }

        private void personValidationProvider_ValidationSucceeded(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationSucceededEventArgs e)
        {
            bool isValidate = (personValidationProvider.GetInvalidControls().Count == 0);
            this.saveBtn.Enabled = isValidate;
            this.validateLbl.Visible = !isValidate;
        }
        #endregion
    }

}