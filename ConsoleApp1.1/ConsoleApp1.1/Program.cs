// See https://aka.ms/new-console-template for more information
using ConsoleApp1._1.model;

Console.WriteLine("Bang tinh luong\n");

// Director director = new Director("MKT Director", 20000);

// Manager manager = new Manager("Product Manager", 10000);

// director.Display();


// List<Person> list = new List<Person>();

// list.Add(director);
// list.Add(manager);
// list.Add(new Employee("Java developer", 1000));
// list.Add(new Employee("NET developer", 2000));

/*int total = 0;
foreach (Person item in list)
{
    total += item.GetBonus();
    item.Display();
}

Console.WriteLine("Bonus: " + total);


Director director = new Director();
director.Input();

Employee employee = new Employee();
employee.Input();

Manager manager = new Manager();
manager.Input();



director.Display();
manager.Display();
employee.Display();*/




List<Person> people = new List<Person>(); // Danh sách để lưu trữ các đối tượng Person

bool exit = false;
while (!exit)
{
    Console.WriteLine("Select an option:");
    Console.WriteLine("1. Input");
    Console.WriteLine("2. Display All");
    Console.WriteLine("3. Exit");

    int choice;
    if (int.TryParse(Console.ReadLine(), out choice))
    {
        switch (choice)
        {
            case 1:
                bool inputExit = false;
                while (!inputExit)
                {
                    Console.WriteLine("Select a role:");
                    Console.WriteLine("1. Employee");
                    Console.WriteLine("2. Manager");
                    Console.WriteLine("3. Director");

                    int roleChoice;
                    if (int.TryParse(Console.ReadLine(), out roleChoice))
                    {
                        switch (roleChoice)
                        {
                            case 1:
                                Employee employee = new Employee();
                                employee.Input();
                                people.Add(employee); // Thêm đối tượng Employee vào danh sách
                                inputExit = true;
                                break;
                            case 2:
                                Manager manager = new Manager();
                                manager.Input();
                                people.Add(manager); // Thêm đối tượng Manager vào danh sách
                                inputExit = true;
                                break;
                            case 3:
                                Director director = new Director();
                                director.Input();
                                people.Add(director); // Thêm đối tượng Director vào danh sách
                                inputExit = true;
                                break;
                            default:
                                Console.WriteLine("Invalid role choice.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                }
                break;
            case 2:
                DisplayAll(people); // Hiển thị tất cả các đối tượng trong danh sách
                break;
            case 3:
                exit = true;
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid input.");
    }
}


static void DisplayAll(List<Person> people)
{
    Console.WriteLine("Name\t\tRole\t\tSalary");
    Console.WriteLine("--------------------------------------");
    int totalBonus = 0; // Biến để tích lũy tổng bonus
    foreach (var person in people)
    {
        person.Display(); // Gọi phương thức Display cho từng đối tượng trong danh sách
        totalBonus += person.GetBonus(); // Cộng bonus của mỗi đối tượng vào tổng bonus
    }
    Console.WriteLine("Total Bonus: $" + totalBonus);
}



