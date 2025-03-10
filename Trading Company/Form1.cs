using Trading_Company.Models;
namespace Trading_Company
{
    public partial class Form1 : Form
    {
        private readonly ApplicationDbContext context;
        #region DB connection initialize and end based on form state.
        public Form1()
        {
            InitializeComponent();

            using (var context = new ApplicationDbContext())
            {
                context.Database.EnsureCreated();
            }
            LoadWarehousesIntoComboBox();
        }

        #endregion

        #region Warehouse Tab
        private void addWarehouseBtn_Click(object sender, EventArgs e)
        {
            if (!AreWarehouseTabFieldsValid())
            {
                MessageBox.Show("Please enter missing fields!");
                return;
            }

            try
            {
                using (var context = new ApplicationDbContext())
                {
                    string name = warehouseNameTxt.Text.Trim();
                    string address = warehouseAddressTxt.Text.Trim();
                    string responsiblePerson = warehousePersonTxt.Text.Trim();

                    bool exists = context.Warehouses.Any(w => w.Name == name);
                    if (exists)
                    {
                        MessageBox.Show("A warehouse with the same name and address already exists!");
                        return;
                    }

                    var warehouse = new Warehouse
                    {
                        Name = name,
                        Address = address,
                        ResponsiblePerson = responsiblePerson
                    };

                    context.Warehouses.Add(warehouse);
                    context.SaveChanges();
                    MessageBox.Show("Warehouse added successfully!");
                    LoadWarehousesIntoComboBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            ClearWarehouseTabFields();
        }

        private bool AreWarehouseTabFieldsValid()
        {
            return !string.IsNullOrWhiteSpace(warehouseNameTxt.Text) &&
                   !string.IsNullOrWhiteSpace(warehouseAddressTxt.Text) &&
                   !string.IsNullOrWhiteSpace(warehousePersonTxt.Text);
        }

        private void ClearWarehouseTabFields()
        {
            warehouseNameTxt.Text = "";
            warehouseAddressTxt.Text = "";
            warehousePersonTxt.Text = "";
        }



        private void loadWarehousesBtn_Click(object sender, EventArgs e)
        {
            LoadWarehouses();
        }

        private void updateWarehouseBtn_Click(object sender, EventArgs e)
        {
            string name = warehouseNameTxt.Text.Trim();
            string address = warehouseAddressTxt.Text.Trim();
            string responsiblePerson = warehousePersonTxt.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter a name to update!");
                return;
            }

            using (var context = new ApplicationDbContext())
            {
                var warehouse = context.Warehouses.FirstOrDefault(w => w.Name == name);

                if (warehouse == null)
                {
                    MessageBox.Show("Warehouse not found!");
                    return;
                }

                if (!string.IsNullOrWhiteSpace(address))
                {
                    warehouse.Address = address;
                }

                if (!string.IsNullOrWhiteSpace(responsiblePerson))
                {
                    warehouse.ResponsiblePerson = responsiblePerson;
                }

                context.SaveChanges();
                MessageBox.Show("Warehouse updated successfully!");
            }

            LoadWarehouses();
        }

        void LoadWarehouses()
        {
            using (var context = new ApplicationDbContext())
            {
                var warehouses = context.Warehouses
                    .Select(w => new
                    {
                        ID = w.WarehouseID,
                        Name = w.Name,
                        Address = w.Address,
                        Responsible_Person = w.ResponsiblePerson
                    })
                    .ToList();

                dataGridView1.DataSource = warehouses;
            }
        }

        #endregion

        #region Items Tab
        void LoadWarehousesIntoComboBox()
        {
            using (var context = new ApplicationDbContext())
            {
                var warehouses = context.Warehouses
                    .Select(w => new { w.WarehouseID, w.Name })
                    .ToList();

                warehouseItemsComboBox.DataSource = warehouses;
                warehouseItemsComboBox.DisplayMember = "Name";
                warehouseItemsComboBox.ValueMember = "WarehouseID";
            }
        }
        private void addItemBtn_Click(object sender, EventArgs e)
        {
            if (!AreItemsTabFieldsValid())
            {
                MessageBox.Show("Please enter missing fields!");
                return;
            }

            string name = itemNametxt.Text.Trim();
            string measurement = itemMeasurementTxt.Text.Trim();
            int selectedWarehouseID = Convert.ToInt32(warehouseItemsComboBox.SelectedValue);
            int quantity = Convert.ToInt32(itemQuantityTxt.Text);
            DateTime productionDate = productionDatePicker.Value;
            DateTime expirationDate = expirationDatePicker.Value;

            using (var context = new ApplicationDbContext())
            {
                var existingItem = context.Items.FirstOrDefault(i => i.Name == name && i.UnitOfMeasurement == measurement);

                if (existingItem == null)
                {
                    var newItem = new Item { Name = name, UnitOfMeasurement = measurement };
                    context.Items.Add(newItem);
                    context.SaveChanges();  // Save to generate `ItemID`
                    existingItem = newItem;  // Now we can use `existingItem.ItemID`
                }

                var warehouseItem = context.WarehouseItems.FirstOrDefault(wi => wi.WarehouseID == selectedWarehouseID && wi.ItemID == existingItem.ItemID);

                if (warehouseItem == null)
                {
                    warehouseItem = new WarehouseItem
                    {
                        WarehouseID = selectedWarehouseID,
                        ItemID = existingItem.ItemID,
                        Quantity = quantity,
                        ExpirationDate = expirationDate,
                        ProductionDate = productionDate
                    };
                    context.WarehouseItems.Add(warehouseItem);
                    MessageBox.Show("Item added to warehouse successfully!");
                }
                else
                {
                    // If the item is already in the warehouse, update the quantity
                    warehouseItem.Quantity += quantity;
                    MessageBox.Show("Item updated to warehouse successfully!");
                }

                context.SaveChanges();
            }

            ClearItemTabFields();
        }


        bool AreItemsTabFieldsValid()
        {
            return (!string.IsNullOrEmpty(itemNametxt.Text) &&
                    !string.IsNullOrEmpty(itemMeasurementTxt.Text) &&
                    warehouseItemsComboBox.SelectedValue != null &&
                    !string.IsNullOrEmpty(itemQuantityTxt.Text));
        }

        void ClearItemTabFields()
        {
            itemNametxt.Text = "";
            itemMeasurementTxt.Text = "";
            itemQuantityTxt.Text = "";
        }

        private void loadItemsAndWarehouseItemsBtn_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                var items = context.Items
                    .Select(i =>
                    new
                    {
                        ID = i.ItemID,
                        Name = i.Name,
                        Measurement_Unit = i.UnitOfMeasurement
                    }).ToList();
                itemsDataGrid.DataSource = items;

                var warehouseItems = context.WarehouseItems
                    .Select(wi => new
                    {
                        ItemID = wi.ItemID,
                        ItemName = wi.Item.Name,
                        WarehouseID = wi.WarehouseID,
                        WarehouseName = wi.Warehouse.Name,
                        Quantity = wi.Quantity,
                        Production_Date = wi.ProductionDate,
                        Expiration_Date = wi.ExpirationDate,
                    }).ToList();

                warehouseItemsDataGrid.DataSource = warehouseItems;
            }
        }
        #endregion

        #region Supplier Tab
        private void addSupplierBtn_Click(object sender, EventArgs e)
        {
            if (!AreSupplierTabFieldsValid())
            {
                MessageBox.Show("Please enter missing fields!");
                return;
            }
            string name = supplierNameTxt.Text;
            string phone = supplierPhoneTxt.Text;
            string mobile = supplierMobileTxt.Text;
            string fax = supplierFaxTxt.Text;
            string email = supplierEmailTxt.Text;
            string website = supplierWebsiteTxt.Text;

            using (var context = new ApplicationDbContext())
            {
                var existingSupplier = context.Suppliers.FirstOrDefault(s => s.Name == name && s.Phone == phone);
                if (existingSupplier == null)
                {
                    context.Suppliers.Add(new Supplier()
                    {
                        Name = name,
                        Phone = phone,
                        Mobile = mobile,
                        Fax = fax,
                        Email = email,
                        Website = website,
                    });
                    context.SaveChanges();
                    MessageBox.Show("Supplier added successfully!");
                    LoadSuppliers();
                }
                else
                {
                    MessageBox.Show("Supplier already exists!");
                }
            }
            ClearSupplierTabFields();
        }

        private void updateSupplierBtn_Click(object sender, EventArgs e)
        {
            string name = supplierNameTxt.Text.Trim();
            string phone = supplierPhoneTxt.Text.Trim();
            string fax = supplierFaxTxt.Text.Trim();
            string mobile = supplierMobileTxt.Text.Trim();
            string email = supplierEmailTxt.Text.Trim();
            string website = supplierWebsiteTxt.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Please enter a name and a phone to find the supplier you want to update!");
                return;
            }
            using (var context = new ApplicationDbContext())
            {
                var supplierToBeUpdated = context.Suppliers.FirstOrDefault(s => s.Name == name && s.Phone == phone);
                if (supplierToBeUpdated != null)
                {
                    if (!string.IsNullOrEmpty(fax))
                    {
                        supplierToBeUpdated.Fax = fax;
                    }
                    if (!string.IsNullOrEmpty(mobile))
                    {
                        supplierToBeUpdated.Mobile = mobile;
                    }
                    if (!string.IsNullOrEmpty(email))
                    {
                        supplierToBeUpdated.Email = email;
                    }
                    if (!string.IsNullOrEmpty(website))
                    {
                        supplierToBeUpdated.Website = website;
                    }
                    context.SaveChanges();
                    MessageBox.Show("Supplier updated successfully!");
                    LoadSuppliers();
                }
                else
                {
                    MessageBox.Show("No supplier was found with this name or phone!");
                }
            }
        }


        bool AreSupplierTabFieldsValid()
        {
            return (!string.IsNullOrEmpty(supplierNameTxt.Text) &&
                    !string.IsNullOrEmpty(supplierPhoneTxt.Text) &&
                    !string.IsNullOrEmpty(supplierMobileTxt.Text) &&
                    !string.IsNullOrEmpty(supplierFaxTxt.Text) &&
                    !string.IsNullOrEmpty(supplierEmailTxt.Text) &&
                    !string.IsNullOrEmpty(supplierWebsiteTxt.Text));
        }
        void ClearSupplierTabFields()
        {
            supplierNameTxt.Text = "";
            supplierPhoneTxt.Text = "";
            supplierMobileTxt.Text = "";
            supplierFaxTxt.Text = "";
            supplierEmailTxt.Text = "";
            supplierWebsiteTxt.Text = "";
        }
        private void loadSuppliersBtn_Click(object sender, EventArgs e)
        {
            LoadSuppliers();
        }

        void LoadSuppliers()
        {
            using (var context = new ApplicationDbContext())
            {
                var suppliers = context.Suppliers
                    .Select(s => new
                    {
                        ID = s.SupplierID,
                        Name = s.Name,
                        Phone = s.Phone,
                        Mobile = s.Mobile,
                        Fax = s.Fax,
                        Email = s.Email,
                        Website = s.Website,
                    }).ToList();
                suppliersDataGrid.DataSource = suppliers;
            }
        }
        #endregion

        #region Customer Tab
        private void addCustomerBtn_Click(object sender, EventArgs e)
        {
            if (!AreCustomerTabFieldsValid())
            {
                MessageBox.Show("Please enter missing fields");
                return;
            }

            string name = customerNameTxt.Text;
            string phone = customerPhoneTxt.Text;
            string mobile = customerMobileTxt.Text;
            string fax = customerFaxTxt.Text;
            string email = customerEmailTxt.Text;
            string website = customerWebsiteTxt.Text;
            using (var context = new ApplicationDbContext())
            {
                context.Customers.Add(new Customer()
                {
                    Name = name,
                    Phone = phone,
                    Mobile = mobile,
                    Fax = fax,
                    Email = email,
                    Website = website,
                });
                context.SaveChanges();
                MessageBox.Show("Customer is added successfully");
                LoadCustomers();
            }
            ClearCustomerTabFields();
        }

        private void updateCustomerBtn_Click(object sender, EventArgs e)
        {
            string name = customerNameTxt.Text;
            string phone = customerPhoneTxt.Text;
            string mobile = customerMobileTxt.Text;
            string fax = customerFaxTxt.Text;
            string email = customerEmailTxt.Text;
            string website = customerWebsiteTxt.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Please enter name and phone of the customer you want to update");
                return;
            }
            using (var context = new ApplicationDbContext())
            {
                var customerToBeUpdated = context.Customers.FirstOrDefault(c => c.Name == name && c.Phone == phone);
                if (customerToBeUpdated != null)
                {
                    if (!string.IsNullOrEmpty(fax))
                    {
                        customerToBeUpdated.Fax = fax;
                    }
                    if (!string.IsNullOrEmpty(mobile))
                    {
                        customerToBeUpdated.Mobile = mobile;
                    }
                    if (!string.IsNullOrEmpty(email))
                    {
                        customerToBeUpdated.Email = email;
                    }
                    if (!string.IsNullOrEmpty(website))
                    {
                        customerToBeUpdated.Website = website;
                    }
                    context.SaveChanges();
                    MessageBox.Show("Customer updated successfully!");
                    LoadCustomers();
                    ClearCustomerTabFields();
                }
                else
                {
                    MessageBox.Show("No customer was found with this name or phone!");
                }
            }
        }

        bool AreCustomerTabFieldsValid()
        {
            return (!string.IsNullOrEmpty(customerNameTxt.Text) &&
                    !string.IsNullOrEmpty(customerPhoneTxt.Text) &&
                    !string.IsNullOrEmpty(customerMobileTxt.Text) &&
                    !string.IsNullOrEmpty(customerFaxTxt.Text) &&
                    !string.IsNullOrEmpty(customerEmailTxt.Text) &&
                    !string.IsNullOrEmpty(customerWebsiteTxt.Text));
        }
        void ClearCustomerTabFields()
        {
            customerNameTxt.Text = "";
            customerPhoneTxt.Text = "";
            customerMobileTxt.Text = "";
            customerFaxTxt.Text = "";
            customerEmailTxt.Text = "";
            customerWebsiteTxt.Text = "";
        }

        private void loadCustomersBtn_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        void LoadCustomers()
        {
            using (var context = new ApplicationDbContext())
            {
                var customers = context.Customers
                    .Select(s => new
                    {
                        ID = s.CustomerID,
                        Name = s.Name,
                        Phone = s.Phone,
                        Mobile = s.Mobile,
                        Fax = s.Fax,
                        Email = s.Email,
                        Website = s.Website,
                    }).ToList();
                customerDataGrid.DataSource = customers;
            }
        }

        #endregion
    }
}
