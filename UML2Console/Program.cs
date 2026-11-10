using PizzaLib.Interfaces;
using PizzaLib.Models;
using PizzaLib.Services;

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
Console.WriteLine("---TryParse Enum Test---");
if(!Enum.TryParse(Console.ReadLine(), out MenuType menuTypeTest))
{
    Console.WriteLine("big loss :(");
}
Console.WriteLine(menuTypeTest);