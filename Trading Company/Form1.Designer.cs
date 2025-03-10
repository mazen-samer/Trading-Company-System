namespace Trading_Company
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            warehousesPage = new TabPage();
            loadWarehousesBtn = new Button();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            updateWarehouseBtn = new Button();
            addWarehouseBtn = new Button();
            warehousePersonTxt = new TextBox();
            warehouseAddressTxt = new TextBox();
            warehouseNameTxt = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            itemsPage = new TabPage();
            label12 = new Label();
            addItemBtn = new Button();
            label11 = new Label();
            loadItemsAndWarehouseItemsBtn = new Button();
            warehouseItemsDataGrid = new DataGridView();
            itemsDataGrid = new DataGridView();
            expirationDatePicker = new DateTimePicker();
            label10 = new Label();
            label9 = new Label();
            productionDatePicker = new DateTimePicker();
            itemQuantityTxt = new TextBox();
            label8 = new Label();
            label7 = new Label();
            warehouseItemsComboBox = new ComboBox();
            itemMeasurementTxt = new TextBox();
            itemNametxt = new TextBox();
            label6 = new Label();
            label5 = new Label();
            supplierPage = new TabPage();
            label20 = new Label();
            loadSuppliersBtn = new Button();
            label19 = new Label();
            updateSupplierBtn = new Button();
            addSupplierBtn = new Button();
            suppliersDataGrid = new DataGridView();
            supplierNameTxt = new TextBox();
            supplierPhoneTxt = new TextBox();
            supplierFaxTxt = new TextBox();
            supplierMobileTxt = new TextBox();
            supplierEmailTxt = new TextBox();
            supplierWebsiteTxt = new TextBox();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            customerPage = new TabPage();
            label27 = new Label();
            loadCustomersBtn = new Button();
            customerDataGrid = new DataGridView();
            updateCustomerBtn = new Button();
            addCustomerBtn = new Button();
            customerWebsiteTxt = new TextBox();
            customerEmailTxt = new TextBox();
            customerMobileTxt = new TextBox();
            customerFaxTxt = new TextBox();
            customerPhoneTxt = new TextBox();
            customerNameTxt = new TextBox();
            label26 = new Label();
            label25 = new Label();
            label24 = new Label();
            label23 = new Label();
            label22 = new Label();
            label21 = new Label();
            tabControl1.SuspendLayout();
            warehousesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            itemsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)warehouseItemsDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)itemsDataGrid).BeginInit();
            supplierPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)suppliersDataGrid).BeginInit();
            customerPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)customerDataGrid).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(warehousesPage);
            tabControl1.Controls.Add(itemsPage);
            tabControl1.Controls.Add(supplierPage);
            tabControl1.Controls.Add(customerPage);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1155, 619);
            tabControl1.TabIndex = 0;
            // 
            // warehousesPage
            // 
            warehousesPage.Controls.Add(loadWarehousesBtn);
            warehousesPage.Controls.Add(label4);
            warehousesPage.Controls.Add(dataGridView1);
            warehousesPage.Controls.Add(updateWarehouseBtn);
            warehousesPage.Controls.Add(addWarehouseBtn);
            warehousesPage.Controls.Add(warehousePersonTxt);
            warehousesPage.Controls.Add(warehouseAddressTxt);
            warehousesPage.Controls.Add(warehouseNameTxt);
            warehousesPage.Controls.Add(label3);
            warehousesPage.Controls.Add(label2);
            warehousesPage.Controls.Add(label1);
            warehousesPage.Location = new Point(4, 29);
            warehousesPage.Name = "warehousesPage";
            warehousesPage.Padding = new Padding(3);
            warehousesPage.Size = new Size(1147, 586);
            warehousesPage.TabIndex = 0;
            warehousesPage.Text = "Warehouses";
            warehousesPage.UseVisualStyleBackColor = true;
            // 
            // loadWarehousesBtn
            // 
            loadWarehousesBtn.Location = new Point(730, 511);
            loadWarehousesBtn.Name = "loadWarehousesBtn";
            loadWarehousesBtn.Size = new Size(163, 29);
            loadWarehousesBtn.TabIndex = 10;
            loadWarehousesBtn.Text = "Load Warehouses";
            loadWarehousesBtn.UseVisualStyleBackColor = true;
            loadWarehousesBtn.Click += loadWarehousesBtn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(741, 46);
            label4.Name = "label4";
            label4.Size = new Size(140, 20);
            label4.TabIndex = 9;
            label4.Text = "Current Warehouses";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(502, 69);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(618, 436);
            dataGridView1.TabIndex = 8;
            // 
            // updateWarehouseBtn
            // 
            updateWarehouseBtn.Location = new Point(292, 390);
            updateWarehouseBtn.Name = "updateWarehouseBtn";
            updateWarehouseBtn.Size = new Size(94, 29);
            updateWarehouseBtn.TabIndex = 7;
            updateWarehouseBtn.Text = "Update";
            updateWarehouseBtn.UseVisualStyleBackColor = true;
            updateWarehouseBtn.Click += updateWarehouseBtn_Click;
            // 
            // addWarehouseBtn
            // 
            addWarehouseBtn.Location = new Point(48, 390);
            addWarehouseBtn.Name = "addWarehouseBtn";
            addWarehouseBtn.Size = new Size(94, 29);
            addWarehouseBtn.TabIndex = 6;
            addWarehouseBtn.Text = "Add";
            addWarehouseBtn.UseVisualStyleBackColor = true;
            addWarehouseBtn.Click += addWarehouseBtn_Click;
            // 
            // warehousePersonTxt
            // 
            warehousePersonTxt.Location = new Point(222, 292);
            warehousePersonTxt.Name = "warehousePersonTxt";
            warehousePersonTxt.Size = new Size(199, 27);
            warehousePersonTxt.TabIndex = 5;
            // 
            // warehouseAddressTxt
            // 
            warehouseAddressTxt.Location = new Point(222, 229);
            warehouseAddressTxt.Name = "warehouseAddressTxt";
            warehouseAddressTxt.Size = new Size(199, 27);
            warehouseAddressTxt.TabIndex = 4;
            // 
            // warehouseNameTxt
            // 
            warehouseNameTxt.Location = new Point(222, 168);
            warehouseNameTxt.Name = "warehouseNameTxt";
            warehouseNameTxt.Size = new Size(199, 27);
            warehouseNameTxt.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 295);
            label3.Name = "label3";
            label3.Size = new Size(183, 20);
            label3.TabIndex = 2;
            label3.Text = "Responsible Person Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 232);
            label2.Name = "label2";
            label2.Size = new Size(142, 20);
            label2.TabIndex = 1;
            label2.Text = "Warehouse Address:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 171);
            label1.Name = "label1";
            label1.Size = new Size(129, 20);
            label1.TabIndex = 0;
            label1.Text = "Warehouse Name:";
            // 
            // itemsPage
            // 
            itemsPage.Controls.Add(label12);
            itemsPage.Controls.Add(addItemBtn);
            itemsPage.Controls.Add(label11);
            itemsPage.Controls.Add(loadItemsAndWarehouseItemsBtn);
            itemsPage.Controls.Add(warehouseItemsDataGrid);
            itemsPage.Controls.Add(itemsDataGrid);
            itemsPage.Controls.Add(expirationDatePicker);
            itemsPage.Controls.Add(label10);
            itemsPage.Controls.Add(label9);
            itemsPage.Controls.Add(productionDatePicker);
            itemsPage.Controls.Add(itemQuantityTxt);
            itemsPage.Controls.Add(label8);
            itemsPage.Controls.Add(label7);
            itemsPage.Controls.Add(warehouseItemsComboBox);
            itemsPage.Controls.Add(itemMeasurementTxt);
            itemsPage.Controls.Add(itemNametxt);
            itemsPage.Controls.Add(label6);
            itemsPage.Controls.Add(label5);
            itemsPage.Location = new Point(4, 29);
            itemsPage.Name = "itemsPage";
            itemsPage.Padding = new Padding(3);
            itemsPage.Size = new Size(1147, 586);
            itemsPage.TabIndex = 1;
            itemsPage.Text = "Items";
            itemsPage.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(57, 551);
            label12.Name = "label12";
            label12.Size = new Size(603, 20);
            label12.TabIndex = 17;
            label12.Text = "* You can update the item's quantity if you entered the same name and measurement unit.";
            // 
            // addItemBtn
            // 
            addItemBtn.Location = new Point(249, 507);
            addItemBtn.Name = "addItemBtn";
            addItemBtn.Size = new Size(94, 29);
            addItemBtn.TabIndex = 16;
            addItemBtn.Text = "Add";
            addItemBtn.UseVisualStyleBackColor = true;
            addItemBtn.Click += addItemBtn_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(726, 62);
            label11.Name = "label11";
            label11.Size = new Size(191, 20);
            label11.TabIndex = 15;
            label11.Text = "Items and Warehouse Items";
            // 
            // loadItemsAndWarehouseItemsBtn
            // 
            loadItemsAndWarehouseItemsBtn.Location = new Point(774, 507);
            loadItemsAndWarehouseItemsBtn.Name = "loadItemsAndWarehouseItemsBtn";
            loadItemsAndWarehouseItemsBtn.Size = new Size(94, 29);
            loadItemsAndWarehouseItemsBtn.TabIndex = 14;
            loadItemsAndWarehouseItemsBtn.Text = "Load Items";
            loadItemsAndWarehouseItemsBtn.UseVisualStyleBackColor = true;
            loadItemsAndWarehouseItemsBtn.Click += loadItemsAndWarehouseItemsBtn_Click;
            // 
            // warehouseItemsDataGrid
            // 
            warehouseItemsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            warehouseItemsDataGrid.Location = new Point(573, 313);
            warehouseItemsDataGrid.Name = "warehouseItemsDataGrid";
            warehouseItemsDataGrid.RowHeadersWidth = 51;
            warehouseItemsDataGrid.Size = new Size(497, 188);
            warehouseItemsDataGrid.TabIndex = 13;
            // 
            // itemsDataGrid
            // 
            itemsDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            itemsDataGrid.Location = new Point(573, 85);
            itemsDataGrid.Name = "itemsDataGrid";
            itemsDataGrid.RowHeadersWidth = 51;
            itemsDataGrid.Size = new Size(497, 188);
            itemsDataGrid.TabIndex = 12;
            // 
            // expirationDatePicker
            // 
            expirationDatePicker.Location = new Point(249, 443);
            expirationDatePicker.Name = "expirationDatePicker";
            expirationDatePicker.Size = new Size(250, 27);
            expirationDatePicker.TabIndex = 11;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(110, 445);
            label10.Name = "label10";
            label10.Size = new Size(115, 20);
            label10.TabIndex = 10;
            label10.Text = "Expiration Date:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(105, 380);
            label9.Name = "label9";
            label9.Size = new Size(120, 20);
            label9.TabIndex = 9;
            label9.Text = "Production Date:";
            // 
            // productionDatePicker
            // 
            productionDatePicker.Location = new Point(249, 378);
            productionDatePicker.Name = "productionDatePicker";
            productionDatePicker.Size = new Size(250, 27);
            productionDatePicker.TabIndex = 8;
            // 
            // itemQuantityTxt
            // 
            itemQuantityTxt.Location = new Point(249, 313);
            itemQuantityTxt.Name = "itemQuantityTxt";
            itemQuantityTxt.Size = new Size(250, 27);
            itemQuantityTxt.TabIndex = 7;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(157, 315);
            label8.Name = "label8";
            label8.Size = new Size(68, 20);
            label8.TabIndex = 6;
            label8.Text = "Quantity:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(96, 250);
            label7.Name = "label7";
            label7.Size = new Size(129, 20);
            label7.TabIndex = 5;
            label7.Text = "Select Warehouse:";
            // 
            // warehouseItemsComboBox
            // 
            warehouseItemsComboBox.FormattingEnabled = true;
            warehouseItemsComboBox.Items.AddRange(new object[] { "ahmed", "mazen" });
            warehouseItemsComboBox.Location = new Point(249, 247);
            warehouseItemsComboBox.Name = "warehouseItemsComboBox";
            warehouseItemsComboBox.Size = new Size(250, 28);
            warehouseItemsComboBox.TabIndex = 4;
            // 
            // itemMeasurementTxt
            // 
            itemMeasurementTxt.Location = new Point(249, 182);
            itemMeasurementTxt.Name = "itemMeasurementTxt";
            itemMeasurementTxt.Size = new Size(250, 27);
            itemMeasurementTxt.TabIndex = 3;
            // 
            // itemNametxt
            // 
            itemNametxt.Location = new Point(249, 117);
            itemNametxt.Name = "itemNametxt";
            itemNametxt.Size = new Size(250, 27);
            itemNametxt.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(33, 185);
            label6.Name = "label6";
            label6.Size = new Size(192, 20);
            label6.TabIndex = 1;
            label6.Text = "Item's unit of measurement:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(139, 120);
            label5.Name = "label5";
            label5.Size = new Size(86, 20);
            label5.TabIndex = 0;
            label5.Text = "Item Name:";
            // 
            // supplierPage
            // 
            supplierPage.Controls.Add(label20);
            supplierPage.Controls.Add(loadSuppliersBtn);
            supplierPage.Controls.Add(label19);
            supplierPage.Controls.Add(updateSupplierBtn);
            supplierPage.Controls.Add(addSupplierBtn);
            supplierPage.Controls.Add(suppliersDataGrid);
            supplierPage.Controls.Add(supplierNameTxt);
            supplierPage.Controls.Add(supplierPhoneTxt);
            supplierPage.Controls.Add(supplierFaxTxt);
            supplierPage.Controls.Add(supplierMobileTxt);
            supplierPage.Controls.Add(supplierEmailTxt);
            supplierPage.Controls.Add(supplierWebsiteTxt);
            supplierPage.Controls.Add(label18);
            supplierPage.Controls.Add(label17);
            supplierPage.Controls.Add(label16);
            supplierPage.Controls.Add(label15);
            supplierPage.Controls.Add(label14);
            supplierPage.Controls.Add(label13);
            supplierPage.Location = new Point(4, 29);
            supplierPage.Name = "supplierPage";
            supplierPage.Size = new Size(1147, 586);
            supplierPage.TabIndex = 2;
            supplierPage.Text = "Supplier";
            supplierPage.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(183, 502);
            label20.Name = "label20";
            label20.Size = new Size(429, 20);
            label20.TabIndex = 17;
            label20.Text = "*You can update the supplier by providing his name and phone!";
            // 
            // loadSuppliersBtn
            // 
            loadSuppliersBtn.Location = new Point(745, 493);
            loadSuppliersBtn.Name = "loadSuppliersBtn";
            loadSuppliersBtn.Size = new Size(94, 29);
            loadSuppliersBtn.TabIndex = 16;
            loadSuppliersBtn.Text = "Load";
            loadSuppliersBtn.UseVisualStyleBackColor = true;
            loadSuppliersBtn.Click += loadSuppliersBtn_Click;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(731, 64);
            label19.Name = "label19";
            label19.Size = new Size(122, 20);
            label19.TabIndex = 15;
            label19.Text = "Current Suppliers";
            // 
            // updateSupplierBtn
            // 
            updateSupplierBtn.Location = new Point(250, 451);
            updateSupplierBtn.Name = "updateSupplierBtn";
            updateSupplierBtn.Size = new Size(94, 29);
            updateSupplierBtn.TabIndex = 14;
            updateSupplierBtn.Text = "Update";
            updateSupplierBtn.UseVisualStyleBackColor = true;
            updateSupplierBtn.Click += updateSupplierBtn_Click;
            // 
            // addSupplierBtn
            // 
            addSupplierBtn.Location = new Point(113, 451);
            addSupplierBtn.Name = "addSupplierBtn";
            addSupplierBtn.Size = new Size(94, 29);
            addSupplierBtn.TabIndex = 13;
            addSupplierBtn.Text = "Add";
            addSupplierBtn.UseVisualStyleBackColor = true;
            addSupplierBtn.Click += addSupplierBtn_Click;
            // 
            // suppliersDataGrid
            // 
            suppliersDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            suppliersDataGrid.Location = new Point(469, 94);
            suppliersDataGrid.Name = "suppliersDataGrid";
            suppliersDataGrid.RowHeadersWidth = 51;
            suppliersDataGrid.Size = new Size(647, 383);
            suppliersDataGrid.TabIndex = 12;
            // 
            // supplierNameTxt
            // 
            supplierNameTxt.Location = new Point(183, 107);
            supplierNameTxt.Name = "supplierNameTxt";
            supplierNameTxt.Size = new Size(193, 27);
            supplierNameTxt.TabIndex = 11;
            // 
            // supplierPhoneTxt
            // 
            supplierPhoneTxt.Location = new Point(183, 160);
            supplierPhoneTxt.Name = "supplierPhoneTxt";
            supplierPhoneTxt.Size = new Size(193, 27);
            supplierPhoneTxt.TabIndex = 10;
            // 
            // supplierFaxTxt
            // 
            supplierFaxTxt.Location = new Point(183, 213);
            supplierFaxTxt.Name = "supplierFaxTxt";
            supplierFaxTxt.Size = new Size(193, 27);
            supplierFaxTxt.TabIndex = 9;
            // 
            // supplierMobileTxt
            // 
            supplierMobileTxt.Location = new Point(183, 266);
            supplierMobileTxt.Name = "supplierMobileTxt";
            supplierMobileTxt.Size = new Size(193, 27);
            supplierMobileTxt.TabIndex = 8;
            // 
            // supplierEmailTxt
            // 
            supplierEmailTxt.Location = new Point(183, 319);
            supplierEmailTxt.Name = "supplierEmailTxt";
            supplierEmailTxt.Size = new Size(193, 27);
            supplierEmailTxt.TabIndex = 7;
            // 
            // supplierWebsiteTxt
            // 
            supplierWebsiteTxt.Location = new Point(183, 372);
            supplierWebsiteTxt.Name = "supplierWebsiteTxt";
            supplierWebsiteTxt.Size = new Size(193, 27);
            supplierWebsiteTxt.TabIndex = 6;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(83, 375);
            label18.Name = "label18";
            label18.Size = new Size(65, 20);
            label18.TabIndex = 5;
            label18.Text = "Website:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(99, 322);
            label17.Name = "label17";
            label17.Size = new Size(49, 20);
            label17.TabIndex = 4;
            label17.Text = "Email:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(89, 269);
            label16.Name = "label16";
            label16.Size = new Size(59, 20);
            label16.TabIndex = 3;
            label16.Text = "Mobile:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(115, 216);
            label15.Name = "label15";
            label15.Size = new Size(33, 20);
            label15.TabIndex = 2;
            label15.Text = "Fax:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(95, 163);
            label14.Name = "label14";
            label14.Size = new Size(53, 20);
            label14.TabIndex = 1;
            label14.Text = "Phone:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(96, 110);
            label13.Name = "label13";
            label13.Size = new Size(52, 20);
            label13.TabIndex = 0;
            label13.Text = "Name:";
            // 
            // customerPage
            // 
            customerPage.Controls.Add(label27);
            customerPage.Controls.Add(loadCustomersBtn);
            customerPage.Controls.Add(customerDataGrid);
            customerPage.Controls.Add(updateCustomerBtn);
            customerPage.Controls.Add(addCustomerBtn);
            customerPage.Controls.Add(customerWebsiteTxt);
            customerPage.Controls.Add(customerEmailTxt);
            customerPage.Controls.Add(customerMobileTxt);
            customerPage.Controls.Add(customerFaxTxt);
            customerPage.Controls.Add(customerPhoneTxt);
            customerPage.Controls.Add(customerNameTxt);
            customerPage.Controls.Add(label26);
            customerPage.Controls.Add(label25);
            customerPage.Controls.Add(label24);
            customerPage.Controls.Add(label23);
            customerPage.Controls.Add(label22);
            customerPage.Controls.Add(label21);
            customerPage.Location = new Point(4, 29);
            customerPage.Name = "customerPage";
            customerPage.Size = new Size(1147, 586);
            customerPage.TabIndex = 3;
            customerPage.Text = "Customer";
            customerPage.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(816, 78);
            label27.Name = "label27";
            label27.Size = new Size(58, 20);
            label27.TabIndex = 16;
            label27.Text = "label27";
            // 
            // loadCustomersBtn
            // 
            loadCustomersBtn.Location = new Point(807, 492);
            loadCustomersBtn.Name = "loadCustomersBtn";
            loadCustomersBtn.Size = new Size(94, 29);
            loadCustomersBtn.TabIndex = 15;
            loadCustomersBtn.Text = "button3";
            loadCustomersBtn.UseVisualStyleBackColor = true;
            loadCustomersBtn.Click += loadCustomersBtn_Click;
            // 
            // customerDataGrid
            // 
            customerDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customerDataGrid.Location = new Point(571, 101);
            customerDataGrid.Name = "customerDataGrid";
            customerDataGrid.RowHeadersWidth = 51;
            customerDataGrid.Size = new Size(544, 385);
            customerDataGrid.TabIndex = 14;
            // 
            // updateCustomerBtn
            // 
            updateCustomerBtn.Location = new Point(301, 453);
            updateCustomerBtn.Name = "updateCustomerBtn";
            updateCustomerBtn.Size = new Size(94, 29);
            updateCustomerBtn.TabIndex = 13;
            updateCustomerBtn.Text = "Update";
            updateCustomerBtn.UseVisualStyleBackColor = true;
            updateCustomerBtn.Click += updateCustomerBtn_Click;
            // 
            // addCustomerBtn
            // 
            addCustomerBtn.Location = new Point(154, 453);
            addCustomerBtn.Name = "addCustomerBtn";
            addCustomerBtn.Size = new Size(94, 29);
            addCustomerBtn.TabIndex = 12;
            addCustomerBtn.Text = "Add";
            addCustomerBtn.UseVisualStyleBackColor = true;
            addCustomerBtn.Click += addCustomerBtn_Click;
            // 
            // customerWebsiteTxt
            // 
            customerWebsiteTxt.Location = new Point(194, 370);
            customerWebsiteTxt.Name = "customerWebsiteTxt";
            customerWebsiteTxt.Size = new Size(233, 27);
            customerWebsiteTxt.TabIndex = 11;
            // 
            // customerEmailTxt
            // 
            customerEmailTxt.Location = new Point(194, 317);
            customerEmailTxt.Name = "customerEmailTxt";
            customerEmailTxt.Size = new Size(233, 27);
            customerEmailTxt.TabIndex = 10;
            // 
            // customerMobileTxt
            // 
            customerMobileTxt.Location = new Point(194, 264);
            customerMobileTxt.Name = "customerMobileTxt";
            customerMobileTxt.Size = new Size(233, 27);
            customerMobileTxt.TabIndex = 9;
            // 
            // customerFaxTxt
            // 
            customerFaxTxt.Location = new Point(194, 211);
            customerFaxTxt.Name = "customerFaxTxt";
            customerFaxTxt.Size = new Size(233, 27);
            customerFaxTxt.TabIndex = 8;
            // 
            // customerPhoneTxt
            // 
            customerPhoneTxt.Location = new Point(194, 158);
            customerPhoneTxt.Name = "customerPhoneTxt";
            customerPhoneTxt.Size = new Size(233, 27);
            customerPhoneTxt.TabIndex = 7;
            // 
            // customerNameTxt
            // 
            customerNameTxt.Location = new Point(194, 105);
            customerNameTxt.Name = "customerNameTxt";
            customerNameTxt.Size = new Size(233, 27);
            customerNameTxt.TabIndex = 6;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(100, 373);
            label26.Name = "label26";
            label26.Size = new Size(65, 20);
            label26.TabIndex = 5;
            label26.Text = "Website:";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(116, 320);
            label25.Name = "label25";
            label25.Size = new Size(49, 20);
            label25.TabIndex = 4;
            label25.Text = "Email:";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(106, 267);
            label24.Name = "label24";
            label24.Size = new Size(59, 20);
            label24.TabIndex = 3;
            label24.Text = "Mobile:";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(132, 214);
            label23.Name = "label23";
            label23.Size = new Size(33, 20);
            label23.TabIndex = 2;
            label23.Text = "Fax:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(112, 161);
            label22.Name = "label22";
            label22.Size = new Size(53, 20);
            label22.TabIndex = 1;
            label22.Text = "Phone:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(113, 108);
            label21.Name = "label21";
            label21.Size = new Size(52, 20);
            label21.TabIndex = 0;
            label21.Text = "Name:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1179, 643);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            warehousesPage.ResumeLayout(false);
            warehousesPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            itemsPage.ResumeLayout(false);
            itemsPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)warehouseItemsDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)itemsDataGrid).EndInit();
            supplierPage.ResumeLayout(false);
            supplierPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)suppliersDataGrid).EndInit();
            customerPage.ResumeLayout(false);
            customerPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)customerDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage warehousesPage;
        private TabPage itemsPage;
        private TabPage supplierPage;
        private TabPage customerPage;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button updateWarehouseBtn;
        private Button addWarehouseBtn;
        private TextBox warehousePersonTxt;
        private TextBox warehouseAddressTxt;
        private TextBox warehouseNameTxt;
        private DataGridView dataGridView1;
        private Button loadWarehousesBtn;
        private Label label4;
        private Label label6;
        private Label label5;
        private ComboBox warehouseItemsComboBox;
        private TextBox itemMeasurementTxt;
        private TextBox itemNametxt;
        private Label label7;
        private DateTimePicker expirationDatePicker;
        private Label label10;
        private Label label9;
        private DateTimePicker productionDatePicker;
        private TextBox itemQuantityTxt;
        private Label label8;
        private DataGridView warehouseItemsDataGrid;
        private DataGridView itemsDataGrid;
        private Label label11;
        private Button loadItemsAndWarehouseItemsBtn;
        private Button addItemBtn;
        private Label label12;
        private Label label13;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label label14;
        private Button updateSupplierBtn;
        private Button addSupplierBtn;
        private DataGridView suppliersDataGrid;
        private TextBox supplierNameTxt;
        private TextBox supplierPhoneTxt;
        private TextBox supplierFaxTxt;
        private TextBox supplierMobileTxt;
        private TextBox supplierEmailTxt;
        private TextBox supplierWebsiteTxt;
        private Button loadSuppliersBtn;
        private Label label19;
        private Label label20;
        private Label label26;
        private Label label25;
        private Label label24;
        private Label label23;
        private Label label22;
        private Label label21;
        private TextBox customerWebsiteTxt;
        private TextBox customerEmailTxt;
        private TextBox customerMobileTxt;
        private TextBox customerFaxTxt;
        private TextBox customerPhoneTxt;
        private TextBox customerNameTxt;
        private DataGridView customerDataGrid;
        private Button updateCustomerBtn;
        private Button addCustomerBtn;
        private Label label27;
        private Button loadCustomersBtn;
    }
}
