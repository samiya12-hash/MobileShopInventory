namespace MobileShopInventory
{
    class Program
    {
        static List<Phone> inventory = new List<Phone>();
        static List<SalesRecord> salesList = new List<SalesRecord>();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n===== Mobile Shop Inventory =====");
                Console.WriteLine("1. Add Phone");
                Console.WriteLine("2. View Inventory");
                Console.WriteLine("3. Search Phone");
                Console.WriteLine("4. Update Stock");
                Console.WriteLine("5. Delete Phone");
                Console.WriteLine("6. Sell Phone");
                Console.WriteLine("7. View Sales Records");
                Console.WriteLine("8. Exit");
                Console.Write("Select an option: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1: AddPhone(); break;
                        case 2: ViewInventory(); break;
                        case 3: SearchPhone(); break;
                        case 4: UpdateStock(); break;
                        case 5: DeletePhone(); break;
                        case 6: SellPhone(); break;
                        case 7: ViewSales(); break;
                        case 8: running = false; break;
                        default: Console.WriteLine("Invalid choice!"); break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number!");
                }
                static void AddPhone()
                {
                    try
                    {
                        Console.WriteLine("\n--- Add Phone ---");
                        Console.WriteLine("1. Smartphone");
                        Console.WriteLine("2. Gaming Phone");
                        Console.Write("Select type: ");
                        int type = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Brand: ");
                        string brand = Console.ReadLine()!;

                        Console.Write("Enter Model: ");
                        string model = Console.ReadLine()!;

                        Console.Write("Enter Storage (e.g. 128GB): ");
                        string storage = Console.ReadLine()!;

                        Console.Write("Enter Price (BDT): ");
                        double price = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter Stock Quantity: ");
                        int stock = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Camera MP: ");
                        int camera = Convert.ToInt32(Console.ReadLine());

                        if (type == 1)
                        {
                            inventory.Add(new SmartPhone(brand, model, storage, price, stock, camera));
                            Console.WriteLine("Smartphone added successfully!");
                        }
                        else if (type == 2)
                        {
                            Console.Write("Enter Refresh Rate (Hz): ");
                            int refreshRate = Convert.ToInt32(Console.ReadLine());
                            inventory.Add(new GamingPhone(brand, model, storage, price, stock, camera, refreshRate));
                            Console.WriteLine("Gaming Phone added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Invalid phone type!");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input! Please enter correct values.");
                    }

                }
                static void ViewInventory()
                {
                    Console.WriteLine("\n--- Inventory List ---");

                    if (inventory.Count == 0)
                    {
                        Console.WriteLine("No phones in inventory!");
                        return;
                    }

                    foreach (Phone phone in inventory)
                    {
                        phone.DisplayInfo(); // Polymorphism in action
                    }
                }
                static void SearchPhone()
                {
                    Console.Write("\nEnter Model to search: ");
                    string model = Console.ReadLine()!;

                    Phone found = inventory.Find(p => p.Model.ToLower() == model.ToLower());

                    if (found != null)
                    {
                        Console.WriteLine("\n--- Phone Found ---");
                        found.DisplayInfo();
                    }
                    else
                    {
                        Console.WriteLine("Phone not found!");
                    }
                }
                static void UpdateStock()
                {
                    try
                    {
                        Console.Write("\nEnter Model to update stock: ");
                        string model = Console.ReadLine();

                        Phone found = inventory.Find(p => p.Model.ToLower() == model.ToLower());

                        if (found != null)
                        {
                            Console.Write("Enter new Stock quantity: ");
                            int newStock = Convert.ToInt32(Console.ReadLine());

                            if (newStock < 0)
                            {
                                Console.WriteLine("Stock cannot be negative!");
                                return;
                            }

                            found.Stock = newStock;
                            Console.WriteLine("Stock updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Phone not found!");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                static void DeletePhone()
                {
                    Console.Write("\nEnter Model to delete: ");
                    string model = Console.ReadLine();

                    Phone found = inventory.Find(p => p.Model.ToLower() == model.ToLower());

                    if (found != null)
                    {
                        inventory.Remove(found);
                        Console.WriteLine("Phone deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Phone not found!");
                    }
                }
                static void SellPhone()
                {
                    try
                    {
                        Console.Write("\nEnter Model to sell: ");
                        string model = Console.ReadLine();

                        Phone found = inventory.Find(p => p.Model.ToLower() == model.ToLower());

                        if (found != null)
                        {
                            Console.Write("Enter Customer Name: ");
                            string customerName = Console.ReadLine()!;

                            Console.Write("Enter Quantity to sell: ");
                            int quantity = Convert.ToInt32(Console.ReadLine()!);

                            if (quantity <= 0)
                            {
                                Console.WriteLine("Quantity must be greater than zero!");
                                return;
                            }

                            if (quantity > found.Stock)
                            {
                                Console.WriteLine($"Insufficient stock! Only {found.Stock} available.");
                                return;
                            }

                            found.Stock -= quantity;
                            double totalPrice = found.Price * quantity;

                            SalesRecord record = new SalesRecord(customerName, found.Model, quantity, totalPrice);
                            salesList.Add(record);

                            Console.WriteLine("Sale completed successfully!");
                            record.ShowSale();
                        }
                        else
                        {
                            Console.WriteLine("Phone not found!");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                static void ViewSales()
                {
                    Console.WriteLine("\n--- Sales Records ---");

                    if (salesList.Count == 0)
                    {
                        Console.WriteLine("No sales records found!");
                        return;
                    }

                    foreach (SalesRecord record in salesList)
                    {
                        record.ShowSale();
                    }
                }
            }
        }
    }
}