namespace TVM_WMS.GUI
{
    partial class MainTabFm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTabFm));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.menuBarControl = new DevExpress.XtraNavBar.NavBarControl();
            this.receiptsMenu = new DevExpress.XtraNavBar.NavBarGroup();
            this.receiptNewItem = new DevExpress.XtraNavBar.NavBarItem();
            this.receiptsJournalItem = new DevExpress.XtraNavBar.NavBarItem();
            this.expendituresMenu = new DevExpress.XtraNavBar.NavBarGroup();
            this.requirementNewItem = new DevExpress.XtraNavBar.NavBarItem();
            this.expendituresJournalItem = new DevExpress.XtraNavBar.NavBarItem();
            this.wareHouseMenu = new DevExpress.XtraNavBar.NavBarGroup();
            this.receiptsAcceptanceItem = new DevExpress.XtraNavBar.NavBarItem();
            this.wareHouseMapItem = new DevExpress.XtraNavBar.NavBarItem();
            this.receiptsForKeepingItem = new DevExpress.XtraNavBar.NavBarItem();
            this.expenditureFromStorageItem = new DevExpress.XtraNavBar.NavBarItem();
            this.deficitItem = new DevExpress.XtraNavBar.NavBarItem();
            this.dictionaryMenu = new DevExpress.XtraNavBar.NavBarGroup();
            this.materialsItem = new DevExpress.XtraNavBar.NavBarItem();
            this.contractorsItem = new DevExpress.XtraNavBar.NavBarItem();
            this.measuresItem = new DevExpress.XtraNavBar.NavBarItem();
            this.unitsItem = new DevExpress.XtraNavBar.NavBarItem();
            this.usersItem = new DevExpress.XtraNavBar.NavBarItem();
            this.storageGroupsItem = new DevExpress.XtraNavBar.NavBarItem();
            this.personsItem = new DevExpress.XtraNavBar.NavBarItem();
            this.professionItem = new DevExpress.XtraNavBar.NavBarItem();
            this.alarmItem = new DevExpress.XtraNavBar.NavBarItem();
            this.settingsMenu = new DevExpress.XtraNavBar.NavBarGroup();
            this.settingsItem = new DevExpress.XtraNavBar.NavBarItem();
            this.testItem = new DevExpress.XtraNavBar.NavBarItem();
            this.userRolesItem = new DevExpress.XtraNavBar.NavBarItem();
            this.documentManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView2 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.zoneNamesItem = new DevExpress.XtraNavBar.NavBarItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuBarControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 583);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1399, 67);
            this.panelControl1.TabIndex = 0;
            // 
            // menuBarControl
            // 
            this.menuBarControl.ActiveGroup = this.receiptsMenu;
            this.menuBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuBarControl.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.receiptsMenu,
            this.expendituresMenu,
            this.wareHouseMenu,
            this.dictionaryMenu,
            this.settingsMenu});
            this.menuBarControl.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.receiptNewItem,
            this.requirementNewItem,
            this.receiptsAcceptanceItem,
            this.wareHouseMapItem,
            this.receiptsForKeepingItem,
            this.expenditureFromStorageItem,
            this.materialsItem,
            this.contractorsItem,
            this.measuresItem,
            this.unitsItem,
            this.usersItem,
            this.settingsItem,
            this.deficitItem,
            this.storageGroupsItem,
            this.receiptsJournalItem,
            this.expendituresJournalItem,
            this.testItem,
            this.userRolesItem,
            this.personsItem,
            this.professionItem,
            this.alarmItem,
            this.zoneNamesItem});
            this.menuBarControl.Location = new System.Drawing.Point(0, 0);
            this.menuBarControl.Name = "menuBarControl";
            this.menuBarControl.OptionsNavPane.ExpandedWidth = 242;
            this.menuBarControl.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.ExplorerBar;
            this.menuBarControl.Size = new System.Drawing.Size(242, 583);
            this.menuBarControl.TabIndex = 1;
            this.menuBarControl.View = new DevExpress.XtraNavBar.ViewInfo.AdvExplorerBarViewInfoRegistrator();
            this.menuBarControl.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.menuBarControl_LinkClicked);
            // 
            // receiptsMenu
            // 
            this.receiptsMenu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.receiptsMenu.Appearance.Options.UseFont = true;
            this.receiptsMenu.Caption = "Приход";
            this.receiptsMenu.Expanded = true;
            this.receiptsMenu.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.receiptsMenu.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.receiptNewItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.receiptsJournalItem)});
            this.receiptsMenu.Name = "receiptsMenu";
            // 
            // receiptNewItem
            // 
            this.receiptNewItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.receiptNewItem.Appearance.Options.UseFont = true;
            this.receiptNewItem.Caption = "Приходные документы";
            this.receiptNewItem.LargeImage = ((System.Drawing.Image)(resources.GetObject("receiptNewItem.LargeImage")));
            this.receiptNewItem.Name = "receiptNewItem";
            this.receiptNewItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("receiptNewItem.SmallImage")));
            // 
            // receiptsJournalItem
            // 
            this.receiptsJournalItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.receiptsJournalItem.Appearance.Options.UseFont = true;
            this.receiptsJournalItem.Caption = "Журнал прихода";
            this.receiptsJournalItem.Name = "receiptsJournalItem";
            this.receiptsJournalItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("receiptsJournalItem.SmallImage")));
            // 
            // expendituresMenu
            // 
            this.expendituresMenu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.expendituresMenu.Appearance.Options.UseFont = true;
            this.expendituresMenu.Caption = "Расход";
            this.expendituresMenu.Expanded = true;
            this.expendituresMenu.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsList;
            this.expendituresMenu.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.requirementNewItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.expendituresJournalItem)});
            this.expendituresMenu.Name = "expendituresMenu";
            // 
            // requirementNewItem
            // 
            this.requirementNewItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.requirementNewItem.Appearance.Options.UseFont = true;
            this.requirementNewItem.Caption = "Расходные документы";
            this.requirementNewItem.Name = "requirementNewItem";
            this.requirementNewItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("requirementNewItem.SmallImage")));
            // 
            // expendituresJournalItem
            // 
            this.expendituresJournalItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.expendituresJournalItem.Appearance.Options.UseFont = true;
            this.expendituresJournalItem.Caption = "Журнал расхода";
            this.expendituresJournalItem.Name = "expendituresJournalItem";
            this.expendituresJournalItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("expendituresJournalItem.SmallImage")));
            // 
            // wareHouseMenu
            // 
            this.wareHouseMenu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.wareHouseMenu.Appearance.Options.UseFont = true;
            this.wareHouseMenu.Caption = "Склад";
            this.wareHouseMenu.Expanded = true;
            this.wareHouseMenu.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsList;
            this.wareHouseMenu.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.receiptsAcceptanceItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.receiptsForKeepingItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.expenditureFromStorageItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.zoneNamesItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.wareHouseMapItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.deficitItem)});
            this.wareHouseMenu.Name = "wareHouseMenu";
            // 
            // receiptsAcceptanceItem
            // 
            this.receiptsAcceptanceItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.receiptsAcceptanceItem.Appearance.Options.UseFont = true;
            this.receiptsAcceptanceItem.Caption = "Зона приемки";
            this.receiptsAcceptanceItem.Name = "receiptsAcceptanceItem";
            this.receiptsAcceptanceItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("receiptsAcceptanceItem.SmallImage")));
            // 
            // wareHouseMapItem
            // 
            this.wareHouseMapItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.wareHouseMapItem.Appearance.Options.UseFont = true;
            this.wareHouseMapItem.Caption = "Загруженность склада";
            this.wareHouseMapItem.Name = "wareHouseMapItem";
            this.wareHouseMapItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("wareHouseMapItem.SmallImage")));
            // 
            // receiptsForKeepingItem
            // 
            this.receiptsForKeepingItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.receiptsForKeepingItem.Appearance.Options.UseFont = true;
            this.receiptsForKeepingItem.Caption = "Размещение на склад";
            this.receiptsForKeepingItem.Name = "receiptsForKeepingItem";
            this.receiptsForKeepingItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("receiptsForKeepingItem.SmallImage")));
            // 
            // expenditureFromStorageItem
            // 
            this.expenditureFromStorageItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.expenditureFromStorageItem.Appearance.Options.UseFont = true;
            this.expenditureFromStorageItem.Caption = "Списание со склада";
            this.expenditureFromStorageItem.Name = "expenditureFromStorageItem";
            this.expenditureFromStorageItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("expenditureFromStorageItem.SmallImage")));
            // 
            // deficitItem
            // 
            this.deficitItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.deficitItem.Appearance.Options.UseFont = true;
            this.deficitItem.Caption = "Расчет дефицита";
            this.deficitItem.Name = "deficitItem";
            this.deficitItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("deficitItem.SmallImage")));
            // 
            // dictionaryMenu
            // 
            this.dictionaryMenu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.dictionaryMenu.Appearance.Options.UseFont = true;
            this.dictionaryMenu.Appearance.Options.UseTextOptions = true;
            this.dictionaryMenu.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.dictionaryMenu.Caption = "Справочная информация";
            this.dictionaryMenu.Expanded = true;
            this.dictionaryMenu.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsList;
            this.dictionaryMenu.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.materialsItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.contractorsItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.measuresItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.unitsItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.usersItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.storageGroupsItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.personsItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.professionItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.alarmItem)});
            this.dictionaryMenu.Name = "dictionaryMenu";
            // 
            // materialsItem
            // 
            this.materialsItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.materialsItem.Appearance.Options.UseFont = true;
            this.materialsItem.Caption = "Номенклатура";
            this.materialsItem.Name = "materialsItem";
            this.materialsItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("materialsItem.SmallImage")));
            // 
            // contractorsItem
            // 
            this.contractorsItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.contractorsItem.Appearance.Options.UseFont = true;
            this.contractorsItem.Caption = "Контрагенты";
            this.contractorsItem.Name = "contractorsItem";
            this.contractorsItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("contractorsItem.SmallImage")));
            // 
            // measuresItem
            // 
            this.measuresItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.measuresItem.Appearance.Options.UseFont = true;
            this.measuresItem.Caption = "Габариты";
            this.measuresItem.Name = "measuresItem";
            this.measuresItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("measuresItem.SmallImage")));
            // 
            // unitsItem
            // 
            this.unitsItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.unitsItem.Appearance.Options.UseFont = true;
            this.unitsItem.Caption = "Ед. измерения";
            this.unitsItem.Name = "unitsItem";
            this.unitsItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("unitsItem.SmallImage")));
            // 
            // usersItem
            // 
            this.usersItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.usersItem.Appearance.Options.UseFont = true;
            this.usersItem.Caption = "Пользователи";
            this.usersItem.Name = "usersItem";
            this.usersItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("usersItem.SmallImage")));
            // 
            // storageGroupsItem
            // 
            this.storageGroupsItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.storageGroupsItem.Appearance.Options.UseFont = true;
            this.storageGroupsItem.Caption = "Складские группы";
            this.storageGroupsItem.Name = "storageGroupsItem";
            this.storageGroupsItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("storageGroupsItem.SmallImage")));
            // 
            // personsItem
            // 
            this.personsItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.personsItem.Appearance.Options.UseFont = true;
            this.personsItem.Caption = "Ответственные лица";
            this.personsItem.Name = "personsItem";
            this.personsItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("personsItem.SmallImage")));
            // 
            // professionItem
            // 
            this.professionItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.professionItem.Appearance.Options.UseFont = true;
            this.professionItem.Caption = "Профессии";
            this.professionItem.Name = "professionItem";
            this.professionItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("professionItem.SmallImage")));
            // 
            // alarmItem
            // 
            this.alarmItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.alarmItem.Appearance.Options.UseFont = true;
            this.alarmItem.Caption = "Коды ошибок";
            this.alarmItem.Name = "alarmItem";
            this.alarmItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("alarmItem.SmallImage")));
            // 
            // settingsMenu
            // 
            this.settingsMenu.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.settingsMenu.Appearance.Options.UseFont = true;
            this.settingsMenu.Caption = "Настройки";
            this.settingsMenu.Expanded = true;
            this.settingsMenu.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsList;
            this.settingsMenu.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.settingsItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.testItem),
            new DevExpress.XtraNavBar.NavBarItemLink(this.userRolesItem)});
            this.settingsMenu.Name = "settingsMenu";
            // 
            // settingsItem
            // 
            this.settingsItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.settingsItem.Appearance.Options.UseFont = true;
            this.settingsItem.Caption = "Настройки";
            this.settingsItem.Name = "settingsItem";
            this.settingsItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("settingsItem.SmallImage")));
            // 
            // testItem
            // 
            this.testItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.testItem.Appearance.Options.UseFont = true;
            this.testItem.Caption = "Тестирование";
            this.testItem.Name = "testItem";
            this.testItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("testItem.SmallImage")));
            // 
            // userRolesItem
            // 
            this.userRolesItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.userRolesItem.Appearance.Options.UseFont = true;
            this.userRolesItem.Caption = "Группы пользователей";
            this.userRolesItem.Name = "userRolesItem";
            this.userRolesItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("userRolesItem.SmallImage")));
            // 
            // documentManager
            // 
            this.documentManager.ContainerControl = this;
            this.documentManager.View = this.tabbedView2;
            this.documentManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView2});
            // 
            // tabbedView2
            // 
            this.tabbedView2.RootContainer.Element = null;
            // 
            // zoneNamesItem
            // 
            this.zoneNamesItem.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.zoneNamesItem.Appearance.Options.UseFont = true;
            this.zoneNamesItem.Caption = "Зоны хранения";
            this.zoneNamesItem.Name = "zoneNamesItem";
            this.zoneNamesItem.SmallImage = ((System.Drawing.Image)(resources.GetObject("zoneNamesItem.SmallImage")));
            // 
            // MainTabFm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 650);
            this.Controls.Add(this.menuBarControl);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainTabFm";
            this.Text = "WMS - автоматизированная система управления складом";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainTabFm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuBarControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraNavBar.NavBarControl menuBarControl;
        private DevExpress.XtraNavBar.NavBarGroup receiptsMenu;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView2;
        private DevExpress.XtraNavBar.NavBarItem receiptNewItem;
        private DevExpress.XtraNavBar.NavBarGroup expendituresMenu;
        private DevExpress.XtraNavBar.NavBarGroup wareHouseMenu;
        private DevExpress.XtraNavBar.NavBarItem requirementNewItem;
        private DevExpress.XtraNavBar.NavBarItem receiptsAcceptanceItem;
        private DevExpress.XtraNavBar.NavBarItem wareHouseMapItem;
        private DevExpress.XtraNavBar.NavBarItem receiptsForKeepingItem;
        private DevExpress.XtraNavBar.NavBarItem expenditureFromStorageItem;
        private DevExpress.XtraNavBar.NavBarGroup dictionaryMenu;
        private DevExpress.XtraNavBar.NavBarGroup settingsMenu;
        private DevExpress.XtraNavBar.NavBarItem materialsItem;
        private DevExpress.XtraNavBar.NavBarItem contractorsItem;
        private DevExpress.XtraNavBar.NavBarItem measuresItem;
        private DevExpress.XtraNavBar.NavBarItem unitsItem;
        private DevExpress.XtraNavBar.NavBarItem usersItem;
        private DevExpress.XtraNavBar.NavBarItem settingsItem;
        private DevExpress.XtraNavBar.NavBarItem deficitItem;
        private DevExpress.XtraNavBar.NavBarItem storageGroupsItem;
        private DevExpress.XtraNavBar.NavBarItem receiptsJournalItem;
        private DevExpress.XtraNavBar.NavBarItem expendituresJournalItem;
        private DevExpress.XtraNavBar.NavBarItem testItem;
        private DevExpress.XtraNavBar.NavBarItem userRolesItem;
        private DevExpress.XtraNavBar.NavBarItem personsItem;
        private DevExpress.XtraNavBar.NavBarItem professionItem;
        private DevExpress.XtraNavBar.NavBarItem alarmItem;
        private DevExpress.XtraNavBar.NavBarItem zoneNamesItem;
    }
}