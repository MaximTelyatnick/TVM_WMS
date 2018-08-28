namespace TVM_WMS.GUI
{
    partial class RequirementMaterialsEditFm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.materialsGrid = new DevExpress.XtraGrid.GridControl();
            this.materialsGridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.articleCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.materialNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.storeQuantityCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.unitLocalNameCol = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cancelBtn = new DevExpress.XtraEditors.SimpleButton();
            this.saveBtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.materialsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // materialsGrid
            // 
            this.materialsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialsGrid.Location = new System.Drawing.Point(4, 8);
            this.materialsGrid.MainView = this.materialsGridView;
            this.materialsGrid.Name = "materialsGrid";
            this.materialsGrid.Size = new System.Drawing.Size(904, 617);
            this.materialsGrid.TabIndex = 0;
            this.materialsGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.materialsGridView});
            // 
            // materialsGridView
            // 
            this.materialsGridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.articleCol,
            this.materialNameCol,
            this.storeQuantityCol,
            this.unitLocalNameCol});
            this.materialsGridView.GridControl = this.materialsGrid;
            this.materialsGridView.Name = "materialsGridView";
            this.materialsGridView.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Default;
            this.materialsGridView.OptionsSelection.CheckBoxSelectorColumnWidth = 50;
            this.materialsGridView.OptionsSelection.MultiSelect = true;
            this.materialsGridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.materialsGridView.OptionsView.ShowAutoFilterRow = true;
            this.materialsGridView.OptionsView.ShowGroupPanel = false;
            // 
            // articleCol
            // 
            this.articleCol.AppearanceHeader.Options.UseTextOptions = true;
            this.articleCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.articleCol.Caption = "Код";
            this.articleCol.FieldName = "Article";
            this.articleCol.Name = "articleCol";
            this.articleCol.OptionsColumn.AllowEdit = false;
            this.articleCol.OptionsColumn.AllowFocus = false;
            this.articleCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.articleCol.Visible = true;
            this.articleCol.VisibleIndex = 1;
            this.articleCol.Width = 147;
            // 
            // materialNameCol
            // 
            this.materialNameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.materialNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.materialNameCol.Caption = "Наименование";
            this.materialNameCol.FieldName = "MaterialName";
            this.materialNameCol.Name = "materialNameCol";
            this.materialNameCol.OptionsColumn.AllowEdit = false;
            this.materialNameCol.OptionsColumn.AllowFocus = false;
            this.materialNameCol.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.materialNameCol.Visible = true;
            this.materialNameCol.VisibleIndex = 2;
            this.materialNameCol.Width = 546;
            // 
            // storeQuantityCol
            // 
            this.storeQuantityCol.AppearanceHeader.Options.UseTextOptions = true;
            this.storeQuantityCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.storeQuantityCol.Caption = "Доступно";
            this.storeQuantityCol.FieldName = "StoreQuantity";
            this.storeQuantityCol.Name = "storeQuantityCol";
            this.storeQuantityCol.OptionsColumn.AllowEdit = false;
            this.storeQuantityCol.OptionsColumn.AllowFocus = false;
            this.storeQuantityCol.Visible = true;
            this.storeQuantityCol.VisibleIndex = 3;
            this.storeQuantityCol.Width = 118;
            // 
            // unitLocalNameCol
            // 
            this.unitLocalNameCol.AppearanceHeader.Options.UseTextOptions = true;
            this.unitLocalNameCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.unitLocalNameCol.Caption = "Ед.изм.";
            this.unitLocalNameCol.FieldName = "UnitLocalName";
            this.unitLocalNameCol.Name = "unitLocalNameCol";
            this.unitLocalNameCol.OptionsColumn.AllowEdit = false;
            this.unitLocalNameCol.OptionsColumn.AllowFocus = false;
            this.unitLocalNameCol.Visible = true;
            this.unitLocalNameCol.VisibleIndex = 4;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(814, 634);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(83, 28);
            this.cancelBtn.TabIndex = 20;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.saveBtn.Location = new System.Drawing.Point(713, 634);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(83, 28);
            this.saveBtn.TabIndex = 19;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // RequirementMaterialsEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 671);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.materialsGrid);
            this.Name = "RequirementMaterialsEditFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбрать номенклатуру";
            ((System.ComponentModel.ISupportInitialize)(this.materialsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.materialsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl materialsGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView materialsGridView;
        private DevExpress.XtraGrid.Columns.GridColumn articleCol;
        private DevExpress.XtraGrid.Columns.GridColumn materialNameCol;
        private DevExpress.XtraGrid.Columns.GridColumn storeQuantityCol;
        private DevExpress.XtraGrid.Columns.GridColumn unitLocalNameCol;
        private DevExpress.XtraEditors.SimpleButton cancelBtn;
        private DevExpress.XtraEditors.SimpleButton saveBtn;
    }
}