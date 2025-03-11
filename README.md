# Trading Company Management System

A Windows Forms application built with C# and Entity Framework Core for managing a trading company's inventory, suppliers, customers, orders, and warehouse transfers.

---

## Features

- **Warehouse Management** - Add, update, and track warehouses and stock.
- **Item Management** - Define items and units of measurement.
- **Supplier & Customer Management** - Keep records of suppliers and customers.
- **Supply Orders** - Track supplier deliveries and add items to warehouses.
- **Customer Orders** - Process withdrawals and remove items from warehouses.
- **Warehouse Transfers** - Move stock between warehouses.
- **Reports** - Generate stock, order history, transfer, and expiration reports.

---

## Database Structure

The system follows a relational database design with the following key tables:

### **1. Warehouses**

Stores information about different warehouses.

- `WarehouseID` (Primary Key)
- `Name`
- `Address`
- `ResponsiblePerson`

### **2. Items**

Defines items available in the system.

- `ItemID` (Primary Key)
- `Name`
- `UnitOfMeasurement`

### **3. WarehouseItems** (Many-to-Many Between Warehouses and Items)

Tracks inventory in each warehouse.

- `WarehouseID` (Foreign Key)
- `ItemID` (Foreign Key)
- `Quantity`

### **4. Suppliers**

Stores supplier details.

- `SupplierID` (Primary Key)
- `Name`
- `Phone`
- `Mobile`
- `Fax`
- `Email`
- `Website`

### **5. Customers**

Stores customer details.

- `CustomerID` (Primary Key)
- `Name`
- `Phone`
- `Mobile`
- `Fax`
- `Email`
- `Website`

### **6. SupplyOrders**

Tracks supplier orders and the warehouses receiving them.

- `SupplyOrderID` (Primary Key)
- `WarehouseID` (Foreign Key)
- `SupplierID` (Foreign Key)
- `OrderDate`

### **7. SupplyOrderDetails** (Many-to-Many Between SupplyOrders and Items)

Tracks items and quantities in each supplier order.

- `SupplyOrderID` (Foreign Key)
- `ItemID` (Foreign Key)
- `Quantity`
- `ProductionDate`
- `ExpirationDate`

### **8. CustomerOrders**

Tracks customer withdrawals from warehouses.

- `CustomerOrderID` (Primary Key)
- `CustomerID` (Foreign Key)
- `WarehouseID` (Foreign Key)
- `OrderDate`

### **9. CustomerOrderDetails** (Many-to-Many Between CustomerOrders and Items)

Tracks items and quantities in customer orders.

- `CustomerOrderID` (Foreign Key)
- `ItemID` (Foreign Key)
- `Quantity`

### **10. TransferOrders**

Tracks stock transfers between warehouses.

- `TransferOrderID` (Primary Key)
- `SourceWarehouseID` (Foreign Key)
- `DestinationWarehouseID` (Foreign Key)
- `OrderDate`

### **11. TransferOrderDetails** (Many-to-Many Between TransferOrders and Items)

Tracks items and quantities in transfer orders.

- `TransferOrderID` (Foreign Key)
- `ItemID` (Foreign Key)
- `Quantity`
- `SupplierID` (Foreign Key)

---

## Installation and Setup

### **Prerequisites**

- .NET 6 or later
- SQL Server
- Entity Framework Core

## Usage

- Adding Warehouses - Navigate to the Warehouses tab, enter details, and click "Add."
- Managing Items - Define item names and units before assigning them to warehouses.
- Placing Supply Orders - Select a supplier and warehouse, add items, and save the order.
- Processing Customer Orders - Choose a customer, select warehouse stock, and complete the withdrawal.
- Transferring Items Between Warehouses - Select source and destination warehouses, add items, and finalize the transfer.
- Generating Reports - View current stock, order history, and expiring items under the Reports tab.
