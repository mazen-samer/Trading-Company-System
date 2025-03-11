using Trading_Company.Models;
namespace Trading_Company
{
    public partial class Form1 : Form
    {
        private List<SupplyOrderDetail> supplierOrderItems = new List<SupplyOrderDetail>();
        private List<CustomerOrderDetail> customerOrderItems = new List<CustomerOrderDetail>();
        private List<TransferOrderDetail> transferOrderItems = new List<TransferOrderDetail>();

        #region DB connection initialize and end based on form state.
        public Form1()
        {
            InitializeComponent();

            using (var context = new ApplicationDbContext())
            {
                context.Database.EnsureCreated();
            }
            LoadSupplierOrderWarehousesIntoComboBox();
            LoadSupplierOrderSupplierIntoComboBox();
            LoadSupplierOrderItemsIntoComboBox();
            LoadCustomerOrderWarehouseComboBox();
            LoadCustomerOrderCustomersComboBox();
            LoadCustomerOrderItemsComboBox();
            LoadTransferOrderItemsIntoComboBox();
            LoadTransferOrderSuppliersIntoComboBox();
            LoadTransferOrderWarehousesIntoComboBox();
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
                    LoadSupplierOrderWarehousesIntoComboBox();
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
        private void addItemBtn_Click(object sender, EventArgs e)
        {
            if (!AreItemsTabFieldsValid())
            {
                MessageBox.Show("Please enter missing fields!");
                return;
            }

            string name = itemNametxt.Text.Trim();
            string measurement = itemMeasurementTxt.Text.Trim();
            int selectedWarehouseID = Convert.ToInt32(supplierOrderWarehousesComboBox.SelectedValue);


            using (var context = new ApplicationDbContext())
            {
                var existingItem = context.Items.FirstOrDefault(i => i.Name == name && i.UnitOfMeasurement == measurement);

                if (existingItem == null)
                {
                    var newItem = new Item { Name = name, UnitOfMeasurement = measurement };
                    context.Items.Add(newItem);
                    context.SaveChanges();
                    MessageBox.Show("Item added successfully!");
                    LoadSupplierOrderItemsIntoComboBox();
                    LoadItemsAndWarehouseItems();

                }
            }

            ClearItemTabFields();
        }
        void LoadItemsAndWarehouseItems()
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
                    }).ToList();

                warehouseItemsDataGrid.DataSource = warehouseItems;
            }
        }

        bool AreItemsTabFieldsValid()
        {
            return (!string.IsNullOrEmpty(itemNametxt.Text) &&
                    !string.IsNullOrEmpty(itemMeasurementTxt.Text));
        }

        void ClearItemTabFields()
        {
            itemNametxt.Text = "";
            itemMeasurementTxt.Text = "";
        }

        private void loadItemsAndWarehouseItemsBtn_Click(object sender, EventArgs e)
        {
            LoadItemsAndWarehouseItems();
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
                    LoadSupplierOrderSupplierIntoComboBox();
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

        #region Supplier Order Tab

        private void clearSupplierOrderList_Click(object sender, EventArgs e)
        {
            supplierOrderItems.Clear();
            supplierOrderItemsListBox.Items.Clear();
        }
        void LoadSupplierOrderWarehousesIntoComboBox()
        {
            using (var context = new ApplicationDbContext())
            {
                var warehouses = context.Warehouses
                    .Select(w => new { w.WarehouseID, w.Name })
                    .ToList();

                supplierOrderWarehousesComboBox.DataSource = warehouses;
                supplierOrderWarehousesComboBox.DisplayMember = "Name";
                supplierOrderWarehousesComboBox.ValueMember = "WarehouseID";
            }
        }
        void LoadSupplierOrderSupplierIntoComboBox()
        {
            using (var context = new ApplicationDbContext())
            {
                var suppliers = context.Suppliers
                    .Select(s => new { s.SupplierID, s.Name })
                    .ToList();
                supplierOrderSupplierComboBox.DataSource = suppliers;
                supplierOrderSupplierComboBox.DisplayMember = "Name";
                supplierOrderSupplierComboBox.ValueMember = "SupplierID";

            }
        }
        void LoadSupplierOrderItemsIntoComboBox()
        {
            using (var context = new ApplicationDbContext())
            {
                var items = context.Items
                    .Select(s => new { s.ItemID, s.Name })
                    .ToList();
                supplierOrderItemsComboBox.DataSource = items;
                supplierOrderItemsComboBox.DisplayMember = "Name";
                supplierOrderItemsComboBox.ValueMember = "ItemID";

            }
        }
        private void addItemToSupplierOrderBtn_Click(object sender, EventArgs e)
        {
            if (!AreSupplierOrderItemFieldsValid())
            {
                MessageBox.Show("Please fill in all item details!");
                return;
            }

            int itemId = Convert.ToInt32(supplierOrderItemsComboBox.SelectedValue);
            string itemName = supplierOrderItemsComboBox.Text;
            int quantity = Convert.ToInt32(supplierOrderItemQuantityTxt.Text);
            DateTime productionDate = supplierOrderProdDate.Value;
            DateTime expirationDate = supplierOrderExpDate.Value;

            var newItem = new SupplyOrderDetail
            {
                ItemID = itemId,
                Quantity = quantity,
                ProductionDate = productionDate,
                ExpirationDate = expirationDate
            };

            supplierOrderItems.Add(newItem);

            supplierOrderItemsListBox.Items.Add($"{itemName} | {quantity} pcs");

            MessageBox.Show("Item added to order!");
        }
        private bool AreSupplierOrderItemFieldsValid()
        {
            if (supplierOrderItemsComboBox.SelectedValue == null)
                return false;

            if (string.IsNullOrWhiteSpace(supplierOrderItemQuantityTxt.Text) ||
                !int.TryParse(supplierOrderItemQuantityTxt.Text, out _))
                return false;

            if (supplierOrderProdDate.Value >= supplierOrderExpDate.Value)
                return false;

            return true;
        }

        private void supplierOrderAddBtn_Click(object sender, EventArgs e)
        {
            if (supplierOrderItems.Count == 0)
            {
                MessageBox.Show("No items in the order! Add items first.");
                return;
            }

            int supplierId = Convert.ToInt32(supplierOrderSupplierComboBox.SelectedValue);
            int warehouseId = Convert.ToInt32(supplierOrderWarehousesComboBox.SelectedValue);

            using (var context = new ApplicationDbContext())
            {
                var newOrder = new SupplyOrder
                {
                    SupplierID = supplierId,
                    WarehouseID = warehouseId,
                    OrderDate = DateTime.Now
                };

                context.SupplyOrders.Add(newOrder);
                context.SaveChanges();  // Save to generate `SupplyOrderID`

                foreach (var item in supplierOrderItems)
                {
                    item.SupplyOrderID = newOrder.SupplyOrderID;
                    context.SupplyOrderDetails.Add(item);

                    var warehouseItem = context.WarehouseItems
                        .FirstOrDefault(wi => wi.WarehouseID == warehouseId && wi.ItemID == item.ItemID);

                    if (warehouseItem == null)
                    {
                        warehouseItem = new WarehouseItem
                        {
                            WarehouseID = warehouseId,
                            ItemID = item.ItemID,
                            Quantity = item.Quantity
                        };
                        context.WarehouseItems.Add(warehouseItem);
                    }
                    else
                    {
                        warehouseItem.Quantity += item.Quantity;
                    }
                }

                context.SaveChanges();
                LoadSupplierOrderData();
            }

            MessageBox.Show("Order saved successfully, and warehouse stock updated!");

            supplierOrderItems.Clear();
            supplierOrderItemsListBox.Items.Clear();
        }
        private void loadSupplierOrderData_Click(object sender, EventArgs e)
        {
            LoadSupplierOrderData();
        }

        void LoadSupplierOrderData()
        {
            using (var context = new ApplicationDbContext())
            {
                var orders = context.SupplyOrders
                    .Select(o => new
                    {
                        OrderID = o.SupplyOrderID,
                        OrderDate = o.OrderDate,
                        SupplierName = o.Supplier.Name,
                        WarehouseName = o.Warehouse.Name
                    })
                    .ToList();

                supplierOrdersDataGridView.DataSource = orders;

                var orderDetails = context.SupplyOrderDetails
            .Select(d => new
            {
                OrderID = d.SupplyOrderID,
                ItemName = d.Item.Name,
                Quantity = d.Quantity,
                ProductionDate = d.ProductionDate,
                ExpirationDate = d.ExpirationDate
            })
            .ToList();

                supplierOrderDetailsDataGridView.DataSource = orderDetails;
            }
        }
        #endregion

        #region Customer Order Tab

        private void clearCustomerOrderList_Click(object sender, EventArgs e)
        {
            customerOrderItems.Clear();
            customerOrderItemsListBox.Items.Clear();
        }
        private void addItemToCustomerOrderBtn_Click(object sender, EventArgs e)
        {
            if (!AreCustomerOrderItemFieldsValid())
            {
                MessageBox.Show("Please fill in all item details!");
                return;
            }

            int itemId = Convert.ToInt32(customerOrderItemsComboBox.SelectedValue);
            string itemName = customerOrderItemsComboBox.Text;
            int quantity = Convert.ToInt32(customerOrderItemQuantityTxt.Text);

            var newItem = new CustomerOrderDetail
            {
                ItemID = itemId,
                Quantity = quantity
            };

            customerOrderItems.Add(newItem);
            customerOrderItemsListBox.Items.Add($"{itemName} | {quantity} pcs");

            MessageBox.Show("Item added to order!");
        }
        private bool AreCustomerOrderItemFieldsValid()
        {
            if (customerOrderItemsComboBox.SelectedValue == null)
                return false;

            if (string.IsNullOrWhiteSpace(customerOrderItemQuantityTxt.Text) ||
                !int.TryParse(customerOrderItemQuantityTxt.Text, out int quantity) ||
                quantity <= 0)
                return false;

            return true;
        }
        void LoadCustomerOrderWarehouseComboBox()
        {
            using (var context = new ApplicationDbContext())
            {
                var warehouses = context.Warehouses
                .Select(w => new { w.WarehouseID, w.Name })
                .ToList();

                customerOrderWarehousesComboBox.DataSource = new List<object>(warehouses);
                customerOrderWarehousesComboBox.DisplayMember = "Name";
                customerOrderWarehousesComboBox.ValueMember = "WarehouseID";
            }
        }
        void LoadCustomerOrderCustomersComboBox()
        {
            using (var context = new ApplicationDbContext())
            {
                var customers = context.Customers
                .Select(c => new { c.CustomerID, c.Name })
                .ToList();

                customerOrderCustomerComboBox.DataSource = customers;
                customerOrderCustomerComboBox.DisplayMember = "Name";
                customerOrderCustomerComboBox.ValueMember = "CustomerID";
            }
        }

        void LoadCustomerOrderItemsComboBox()
        {
            using (var context = new ApplicationDbContext())
            {
                var items = context.Items
                .Select(i => new { i.ItemID, i.Name })
                .ToList();

                customerOrderItemsComboBox.DataSource = items;
                customerOrderItemsComboBox.DisplayMember = "Name";
                customerOrderItemsComboBox.ValueMember = "ItemID";
            }
        }

        private void saveCustomerOrderBtn_Click(object sender, EventArgs e)
        {
            if (customerOrderItems.Count == 0)
            {
                MessageBox.Show("No items in the order! Add items first.");
                return;
            }

            int customerId = Convert.ToInt32(customerOrderCustomerComboBox.SelectedValue);
            int warehouseId = Convert.ToInt32(customerOrderWarehousesComboBox.SelectedValue);

            using (var context = new ApplicationDbContext())
            {
                // ✅ Don't set WithdrawalOrderID manually; let EF handle it
                var newOrder = new CustomerOrder
                {
                    CustomerID = customerId,
                    WarehouseID = warehouseId,
                    OrderDate = DateTime.Now
                };

                context.WithdrawalOrders.Add(newOrder);
                context.SaveChanges();

                foreach (var item in customerOrderItems)
                {
                    item.WithdrawalOrderID = newOrder.WithdrawalOrderID;
                    context.WithdrawalOrderDetails.Add(item);

                    var warehouseItem = context.WarehouseItems
                        .FirstOrDefault(wi => wi.WarehouseID == warehouseId && wi.ItemID == item.ItemID);

                    if (warehouseItem == null || warehouseItem.Quantity < item.Quantity)
                    {
                        MessageBox.Show($"Not enough stock for {item.ItemID}!");
                        return;
                    }

                    warehouseItem.Quantity -= item.Quantity;
                }

                context.SaveChanges();
                LoadCustomerOrders();
            }

            MessageBox.Show("Customer order saved, and warehouse stock updated!");

            customerOrderItems.Clear();
            customerOrderItemsListBox.Items.Clear();
        }


        private void loadCustomerOrderData_Click(object sender, EventArgs e)
        {
            LoadCustomerOrders();
        }

        void LoadCustomerOrders()
        {
            using (var context = new ApplicationDbContext())
            {
                var orders = context.WithdrawalOrders
                    .Select(o => new
                    {
                        OrderID = o.WithdrawalOrderID,
                        OrderDate = o.OrderDate,
                        CustomerName = o.Customer.Name,
                        WarehouseName = o.Warehouse.Name
                    })
                    .ToList();

                customerOrdersDataGridView.DataSource = orders;

                var orderDetails = context.WithdrawalOrderDetails
                    .Select(d => new
                    {
                        OrderID = d.WithdrawalOrderID,
                        ItemName = d.Item.Name,
                        Quantity = d.Quantity
                    })
                    .ToList();

                customerOrderDetailsDataGridView.DataSource = orderDetails;
            }
        }




        #endregion

        #region Transfer Order Tab

        private void clearTransferOrderList_Click(object sender, EventArgs e)
        {
            transferOrderItems.Clear();
            transferOrderItemsListBox.Items.Clear();
        }
        private void addItemToTransferOrderBtn_Click(object sender, EventArgs e)
        {
            if (!AreTransferOrderItemFieldsValid())
            {
                MessageBox.Show("Please fill in all item details!");
                return;
            }

            int itemId = Convert.ToInt32(transferOrderItemsComboBox.SelectedValue);
            string itemName = transferOrderItemsComboBox.Text;
            int quantity = Convert.ToInt32(transferOrderItemQuantityTxt.Text);
            int supplierId = Convert.ToInt32(transferOrderSupplierComboBox.SelectedValue);

            var newItem = new TransferOrderDetail
            {
                ItemID = itemId,
                Quantity = quantity,
                SupplierID = supplierId
            };

            transferOrderItems.Add(newItem);
            transferOrderItemsListBox.Items.Add($"{itemName} | {quantity} pcs | Supplier: {transferOrderSupplierComboBox.Text}");

            MessageBox.Show("Item added to transfer order!");
        }
        private bool AreTransferOrderItemFieldsValid()
        {
            if (transferOrderItemsComboBox.SelectedValue == null)
                return false;

            if (transferOrderSourceWarehouseComboBox.SelectedValue == null ||
                transferOrderDestinationWarehouseComboBox.SelectedValue == null)
                return false;

            if (transferOrderSourceWarehouseComboBox.SelectedValue == transferOrderDestinationWarehouseComboBox.SelectedValue)
                return false;

            if (string.IsNullOrWhiteSpace(transferOrderItemQuantityTxt.Text) ||
                !int.TryParse(transferOrderItemQuantityTxt.Text, out int quantity) ||
                quantity <= 0)
                return false;

            return true;
        }

        private void saveTransferOrderBtn_Click(object sender, EventArgs e)
        {
            if (transferOrderItems.Count == 0)
            {
                MessageBox.Show("No items in the transfer order! Add items first.");
                return;
            }

            int sourceWarehouseId = Convert.ToInt32(transferOrderSourceWarehouseComboBox.SelectedValue);
            int destinationWarehouseId = Convert.ToInt32(transferOrderDestinationWarehouseComboBox.SelectedValue);

            if (sourceWarehouseId == destinationWarehouseId)
            {
                MessageBox.Show("Source and destination warehouses must be different!");
                return;
            }

            using (var context = new ApplicationDbContext())
            {
                var newOrder = new TransferOrder
                {
                    SourceWarehouseID = sourceWarehouseId,
                    DestinationWarehouseID = destinationWarehouseId,
                    OrderDate = DateTime.Now
                };

                context.TransferOrders.Add(newOrder);
                context.SaveChanges();  // Save to generate `TransferOrderID`

                foreach (var item in transferOrderItems)
                {
                    item.TransferOrderID = newOrder.TransferOrderID;
                    context.TransferOrderDetails.Add(item);

                    // Check if the item exists in the source warehouse
                    var sourceItem = context.WarehouseItems
                        .FirstOrDefault(wi => wi.WarehouseID == sourceWarehouseId && wi.ItemID == item.ItemID);

                    if (sourceItem == null || sourceItem.Quantity < item.Quantity)
                    {
                        MessageBox.Show($"Not enough stock in source warehouse for {item.ItemID}!");
                        return;
                    }

                    // Reduce stock from the source warehouse
                    sourceItem.Quantity -= item.Quantity;

                    // Add stock to the destination warehouse
                    var destinationItem = context.WarehouseItems
                        .FirstOrDefault(wi => wi.WarehouseID == destinationWarehouseId && wi.ItemID == item.ItemID);

                    if (destinationItem == null)
                    {
                        destinationItem = new WarehouseItem
                        {
                            WarehouseID = destinationWarehouseId,
                            ItemID = item.ItemID,
                            Quantity = item.Quantity
                        };
                        context.WarehouseItems.Add(destinationItem);
                    }
                    else
                    {
                        destinationItem.Quantity += item.Quantity;
                    }
                }

                context.SaveChanges();
                LoadTransferOrders();
            }

            MessageBox.Show("Transfer order saved, and warehouse stock updated!");

            transferOrderItems.Clear();
            transferOrderItemsListBox.Items.Clear();
        }
        void LoadTransferOrders()
        {
            using (var context = new ApplicationDbContext())
            {
                var orders = context.TransferOrders
                    .Select(o => new
                    {
                        OrderID = o.TransferOrderID,
                        OrderDate = o.OrderDate,
                        SourceWarehouse = o.SourceWarehouse.Name,
                        DestinationWarehouse = o.DestinationWarehouse.Name
                    })
                    .ToList();

                transferOrdersDataGridView.DataSource = orders;

                var orderDetails = context.TransferOrderDetails
                    .Select(d => new
                    {
                        OrderID = d.TransferOrderID,
                        ItemName = d.Item.Name,
                        Quantity = d.Quantity,
                        SupplierName = d.Supplier.Name
                    })
                    .ToList();

                transferOrderDetailsDataGridView.DataSource = orderDetails;
            }
        }

        void LoadTransferOrderWarehousesIntoComboBox()
        {
            using (var context = new ApplicationDbContext())
            {
                var warehouses = context.Warehouses
                    .Select(w => new { w.WarehouseID, w.Name })
                    .ToList();

                transferOrderSourceWarehouseComboBox.DataSource = new List<object>(warehouses);
                transferOrderSourceWarehouseComboBox.DisplayMember = "Name";
                transferOrderSourceWarehouseComboBox.ValueMember = "WarehouseID";

                transferOrderDestinationWarehouseComboBox.DataSource = new List<object>(warehouses);
                transferOrderDestinationWarehouseComboBox.DisplayMember = "Name";
                transferOrderDestinationWarehouseComboBox.ValueMember = "WarehouseID";
            }
        }

        void LoadTransferOrderSuppliersIntoComboBox()
        {
            using (var context = new ApplicationDbContext())
            {
                var suppliers = context.Suppliers
                    .Select(s => new { s.SupplierID, s.Name })
                    .ToList();

                transferOrderSupplierComboBox.DataSource = suppliers;
                transferOrderSupplierComboBox.DisplayMember = "Name";
                transferOrderSupplierComboBox.ValueMember = "SupplierID";
            }
        }

        void LoadTransferOrderItemsIntoComboBox()
        {
            using (var context = new ApplicationDbContext())
            {
                var items = context.Items
                    .Select(i => new { i.ItemID, i.Name })
                    .ToList();

                transferOrderItemsComboBox.DataSource = items;
                transferOrderItemsComboBox.DisplayMember = "Name";
                transferOrderItemsComboBox.ValueMember = "ItemID";
            }
        }

        private void loadTransferOrderData_Click(object sender, EventArgs e)
        {
            LoadTransferOrders();
        }
        #endregion

    }
}