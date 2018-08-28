namespace TVM_WMS.GUI
{
    partial class MeasureEditFm
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            this.heightTBox = new DevExpress.XtraEditors.TextEdit();
            this.widthTBox = new DevExpress.XtraEditors.TextEdit();
            this.lengthTBox = new DevExpress.XtraEditors.TextEdit();
            this.weightTBox = new DevExpress.XtraEditors.TextEdit();
            this.nameCnt = new DevExpress.XtraEditors.LabelControl();
            this.weightCnt = new DevExpress.XtraEditors.LabelControl();
            this.heightCnt = new DevExpress.XtraEditors.LabelControl();
            this.widthCnt = new DevExpress.XtraEditors.LabelControl();
            this.lengthCnt = new DevExpress.XtraEditors.LabelControl();
            this.saveBt = new DevExpress.XtraEditors.SimpleButton();
            this.cancelBt = new DevExpress.XtraEditors.SimpleButton();
            this.groupCnt = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.unitEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.packingTypeEdit = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.heightTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lengthTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightTBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCnt)).BeginInit();
            this.groupCnt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unitEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packingTypeEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // heightTBox
            // 
            this.heightTBox.Location = new System.Drawing.Point(74, 27);
            this.heightTBox.Name = "heightTBox";
            this.heightTBox.Properties.Mask.EditMask = "n";
            this.heightTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.heightTBox.Size = new System.Drawing.Size(126, 20);
            this.heightTBox.TabIndex = 2;
            // 
            // widthTBox
            // 
            this.widthTBox.Location = new System.Drawing.Point(74, 53);
            this.widthTBox.Name = "widthTBox";
            this.widthTBox.Properties.Mask.EditMask = "n";
            this.widthTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.widthTBox.Size = new System.Drawing.Size(126, 20);
            this.widthTBox.TabIndex = 3;
            // 
            // lengthTBox
            // 
            this.lengthTBox.Location = new System.Drawing.Point(74, 82);
            this.lengthTBox.Name = "lengthTBox";
            this.lengthTBox.Properties.Mask.EditMask = "n";
            this.lengthTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.lengthTBox.Size = new System.Drawing.Size(126, 20);
            this.lengthTBox.TabIndex = 4;
            // 
            // weightTBox
            // 
            this.weightTBox.Location = new System.Drawing.Point(241, 92);
            this.weightTBox.Name = "weightTBox";
            this.weightTBox.Properties.Mask.EditMask = "d";
            this.weightTBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.weightTBox.Size = new System.Drawing.Size(77, 20);
            this.weightTBox.TabIndex = 5;
            // 
            // nameCnt
            // 
            this.nameCnt.Location = new System.Drawing.Point(12, 7);
            this.nameCnt.Name = "nameCnt";
            this.nameCnt.Size = new System.Drawing.Size(73, 13);
            this.nameCnt.TabIndex = 18;
            this.nameCnt.Text = "Наименование";
            // 
            // weightCnt
            // 
            this.weightCnt.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.weightCnt.Location = new System.Drawing.Point(241, 60);
            this.weightCnt.Name = "weightCnt";
            this.weightCnt.Size = new System.Drawing.Size(110, 26);
            this.weightCnt.TabIndex = 19;
            this.weightCnt.Text = "Значение\r\n(вес, кол-во...)";
            // 
            // heightCnt
            // 
            this.heightCnt.Location = new System.Drawing.Point(15, 30);
            this.heightCnt.Name = "heightCnt";
            this.heightCnt.Size = new System.Drawing.Size(37, 13);
            this.heightCnt.TabIndex = 20;
            this.heightCnt.Text = "Высота";
            // 
            // widthCnt
            // 
            this.widthCnt.Location = new System.Drawing.Point(12, 56);
            this.widthCnt.Name = "widthCnt";
            this.widthCnt.Size = new System.Drawing.Size(40, 13);
            this.widthCnt.TabIndex = 21;
            this.widthCnt.Text = "Ширина";
            // 
            // lengthCnt
            // 
            this.lengthCnt.Location = new System.Drawing.Point(12, 85);
            this.lengthCnt.Name = "lengthCnt";
            this.lengthCnt.Size = new System.Drawing.Size(32, 13);
            this.lengthCnt.TabIndex = 22;
            this.lengthCnt.Text = "Длина";
            // 
            // saveBt
            // 
            this.saveBt.Location = new System.Drawing.Point(314, 189);
            this.saveBt.Name = "saveBt";
            this.saveBt.Size = new System.Drawing.Size(75, 23);
            this.saveBt.TabIndex = 7;
            this.saveBt.Text = "Сохранить";
            this.saveBt.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBt
            // 
            this.cancelBt.Location = new System.Drawing.Point(403, 189);
            this.cancelBt.Name = "cancelBt";
            this.cancelBt.Size = new System.Drawing.Size(75, 23);
            this.cancelBt.TabIndex = 8;
            this.cancelBt.Text = "Отмена";
            this.cancelBt.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // groupCnt
            // 
            this.groupCnt.Controls.Add(this.widthTBox);
            this.groupCnt.Controls.Add(this.heightTBox);
            this.groupCnt.Controls.Add(this.lengthTBox);
            this.groupCnt.Controls.Add(this.lengthCnt);
            this.groupCnt.Controls.Add(this.heightCnt);
            this.groupCnt.Controls.Add(this.widthCnt);
            this.groupCnt.Location = new System.Drawing.Point(12, 66);
            this.groupCnt.Name = "groupCnt";
            this.groupCnt.Size = new System.Drawing.Size(212, 120);
            this.groupCnt.TabIndex = 2;
            this.groupCnt.Text = "Размеры";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(338, 72);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 13);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "Ед.измерения";
            // 
            // unitEdit
            // 
            this.unitEdit.Location = new System.Drawing.Point(336, 91);
            this.unitEdit.Name = "unitEdit";
            this.unitEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::TVM_WMS.GUI.Properties.Resources.eraser16x16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Очистить", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::TVM_WMS.GUI.Properties.Resources.Add, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Добавить", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::TVM_WMS.GUI.Properties.Resources.Edit, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Редактировать", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::TVM_WMS.GUI.Properties.Resources.Delete, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Удалить", null, null, true)});
            this.unitEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitName", "Ед.изм.")});
            this.unitEdit.Size = new System.Drawing.Size(152, 22);
            this.unitEdit.TabIndex = 6;
            this.unitEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.unitEdit_ButtonClick);
            this.unitEdit.EditValueChanged += new System.EventHandler(this.unitEdit_EditValueChanged);
            // 
            // packingTypeEdit
            // 
            this.packingTypeEdit.Location = new System.Drawing.Point(12, 26);
            this.packingTypeEdit.Name = "packingTypeEdit";
            serializableAppearanceObject6.BorderColor = System.Drawing.Color.DimGray;
            serializableAppearanceObject6.Options.UseBorderColor = true;
            serializableAppearanceObject7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            serializableAppearanceObject7.Options.UseBorderColor = true;
            this.packingTypeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::TVM_WMS.GUI.Properties.Resources.eraser16x16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Очистить", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::TVM_WMS.GUI.Properties.Resources.Add, "", new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, serializableAppearanceObject9, "Добавить", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::TVM_WMS.GUI.Properties.Resources.Edit, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10, "Редактировать", null, null, true),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.BottomCenter, global::TVM_WMS.GUI.Properties.Resources.Delete, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11, "Удалить", null, null, true)});
            this.packingTypeEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PackingName", "Наименование")});
            this.packingTypeEdit.Size = new System.Drawing.Size(476, 22);
            this.packingTypeEdit.TabIndex = 1;
            this.packingTypeEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.packingTypeEdit_ButtonClick);
            this.packingTypeEdit.EditValueChanged += new System.EventHandler(this.packingTypeEdit_EditValueChanged);
            // 
            // MeasureEditFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 224);
            this.Controls.Add(this.packingTypeEdit);
            this.Controls.Add(this.unitEdit);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.groupCnt);
            this.Controls.Add(this.cancelBt);
            this.Controls.Add(this.saveBt);
            this.Controls.Add(this.weightCnt);
            this.Controls.Add(this.nameCnt);
            this.Controls.Add(this.weightTBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MeasureEditFm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Габариты";
            ((System.ComponentModel.ISupportInitialize)(this.heightTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lengthTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weightTBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupCnt)).EndInit();
            this.groupCnt.ResumeLayout(false);
            this.groupCnt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.unitEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packingTypeEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit heightTBox;
        private DevExpress.XtraEditors.TextEdit widthTBox;
        private DevExpress.XtraEditors.TextEdit lengthTBox;
        private DevExpress.XtraEditors.TextEdit weightTBox;
        private DevExpress.XtraEditors.LabelControl nameCnt;
        private DevExpress.XtraEditors.LabelControl heightCnt;
        private DevExpress.XtraEditors.LabelControl widthCnt;
        private DevExpress.XtraEditors.LabelControl lengthCnt;
        private DevExpress.XtraEditors.SimpleButton saveBt;
        private DevExpress.XtraEditors.SimpleButton cancelBt;
        private DevExpress.XtraEditors.GroupControl groupCnt;
        private DevExpress.XtraEditors.LabelControl weightCnt;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit unitEdit;
        private DevExpress.XtraEditors.LookUpEdit packingTypeEdit;
    }
}