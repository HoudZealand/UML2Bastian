using PizzaLib.Interfaces;
using PizzaLib.Models;
using PizzaLib.Services;
using PizzaLib.Exceptions;

CustomerRepository cRepo = new CustomerRepository();

Customer c1 = new Customer("Lars Olivarius", "0847592", "vej 3, 4000 Roskilde");
c1.ClubMember = true;
cRepo.AddCustomer(c1);

MenuItemRepository mRepo = new MenuItemRepository();

MenuItem m1 = new MenuItem("Roma", 99.95, "tomat, skinke, bacon, æg", MenuType.PIZZECLASSICHE);
mRepo.AddMenuItem(m1);

cRepo.PrintAllCustomers();
Console.WriteLine();
mRepo.PrintAllMenuItems();
Console.WriteLine();

Console.WriteLine("---Get Members Test---");
List<ICustomer> members = cRepo.GetMembers();
foreach(ICustomer i in members)
{
    Console.WriteLine(i.ToString());
}
Console.WriteLine();

Console.WriteLine("---Get Customers By Area Test---");
List<ICustomer> cByArea = cRepo.GetByArea("Roskilde");
foreach(ICustomer i in cByArea)
{
    Console.WriteLine(i.ToString());
}
Console.WriteLine();

Console.WriteLine("---Get Items By Type Test---");
List<IMenuItem> pizzeClassische = mRepo.GetItemsByType(MenuType.PIZZECLASSICHE);
foreach(IMenuItem i in pizzeClassische)
{
    Console.WriteLine(i.ToString());
}
Console.WriteLine();

Console.WriteLine("---Get Most Expensive Item By Type Test---");
IMenuItem expensivePizzeClassische = mRepo.GetMostExpensiveByType(MenuType.PIZZECLASSICHE);
Console.WriteLine(expensivePizzeClassische.ToString());
Console.WriteLine();

Console.WriteLine("---Get Sorted Menu Test---");
mRepo.PrintSortedMenu();

Console.WriteLine();
Console.WriteLine("---Exceptions test---");
try
{
    VIPCustomer vip1 = new VIPCustomer("vip test", "2847936", "moon", 60);
}catch(InvalidDiscountException e)
{
    Console.WriteLine($"InvalidDiscountException: {e.Message}");
}

Console.WriteLine();
Console.WriteLine("---Company Singleton Test---");
CompanyInfo company = CompanyInfo.Instance;
company.Name = "john pizza";
company.CVR = "87634901";
company.VAT = 7.5;
company.ClubDiscount = 5;

Console.WriteLine(company.ToString());

Console.WriteLine();
Console.WriteLine("---Get All Items in Price Range (95-97) Test---");
List<IMenuItem> itemsInRange = mRepo.GetItemsInPriceRange(95.0, 97.0);
foreach(IMenuItem m in itemsInRange)
{
    Console.WriteLine(m.ToString());
}

Console.WriteLine();
Console.WriteLine("---Update Customer Test---");
Customer c2 = new Customer("Hans-Henrik Høybye", "7524890", "et sted i hillerød");
Console.WriteLine("c1: " + c1.ToString());
Console.WriteLine("c2: " + c2.ToString());
Console.WriteLine("-Updating c1-");
c1.UpdateCustomer(c2);
Console.WriteLine("c1: " + c1.ToString());

Console.WriteLine();
Console.WriteLine("---Update Menu Item Test---");
MenuItem m2 = new MenuItem("item", 395.95, "mystisk!", MenuType.SANDWICHES);
Console.WriteLine("m1: " + m1.ToString());
Console.WriteLine("m2: " + m2.ToString());
Console.WriteLine("-Updating m1-");
m1.UpdateItem(m2);
Console.WriteLine("m1: " + m1.ToString());