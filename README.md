# CapstoneBackend

Hi team,

This is the updated API with new requirements so far.

Note:
1. Before running this API just run this Scaffold command and then try running the API.

Scaffold-DbContext "Server=5400-TI11982\MSSQLSERVER1;Database=ShoppingCapstoneDB ;Trusted_Connection=True;" 
Microsoft.EntityFrameworkCore.SqlServer -ContextDir DataContexts -Context DemoTokenContexts -OutputDir DataContexts -Force

2. Change the server name in appsettings.Development.json file

Modification Timeline:
15-12-2021 11:00 AM: Modified CartController
15-12-2021 12:34 PM: Updated Cart Controller.
  Note:
  Ignore CartTablesController and every controller required for Cart Table will be available in CartController only.
15-12-2021 12:34 PM: Modified SellerController as per vivek Requirement.
15-12-2021 12:34 PM: Upadted OrderController with GetOrderDetailsByBuyerId and DeleteOrder methods.
