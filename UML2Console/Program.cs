using PizzaLib.Interfaces;
using PizzaLib.Models;
using PizzaLib.Services;

CustomerRepository cRepo = new CustomerRepository();

Customer c1 = new Customer("Lars Olivarius", "0847592", "vej 3!");
c1.ClubMember = true;
cRepo.AddCustomer(c1);

MenuItemRepository mRepo = new MenuItemRepository();

MenuItem m1 = new MenuItem("Roma", 99.95, "tomat, skinke, bacon, æg", MenuType.PIZZECLASSSICHE);
mRepo.AddMenuItem(m1);

cRepo.PrintAllCustomers();
mRepo.PrintAllMenuItems();

List<ICustomer> members = cRepo.GetMembers();
