using LinkedList.Core;

var list = new DoublyLinkedList<string>(); 
string option;

do
{
    option = Menu();
    switch (option)
    {
        case "1":
            Console.Write("Enter a value: ");
            var value = Console.ReadLine()!;
            list.AddInOrder(value);
            break;

        case "2":
            list.DisplayForward();
            break;

        case "3":
            list.DisplayBackward();
            break;

        case "4":
            list.SortDescending();
            break;

        case "5":
            list.FindMode();
            break;

        case "6":
            list.DisplayGraph();
            break;

        case "7":
            Console.Write("Enter a value to check: ");
            var v = Console.ReadLine()!;
            Console.WriteLine(list.Exists(v) ? "Exists." : "Does not exist.");
            break;

        case "8":
            Console.Write("Enter a value to remove (one): ");
            list.RemoveOne(Console.ReadLine()!);
            break;

        case "9":
            Console.Write("Enter a value to remove (all): ");
            list.RemoveAll(Console.ReadLine()!);
            break;

        case "0":
            Console.WriteLine("Bye!");
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
} while (option != "0");

string Menu()
{
    Console.WriteLine("\n===== DOUBLY LINKED LIST MENU =====");
    Console.WriteLine("1. Add (ascending order)");
    Console.WriteLine("2. Show forward");
    Console.WriteLine("3. Show backward");
    Console.WriteLine("4. Sort descending");
    Console.WriteLine("5. Show mode(s)");
    Console.WriteLine("6. Show graph");
    Console.WriteLine("7. Check existence");
    Console.WriteLine("8. Remove one occurrence");
    Console.WriteLine("9. Remove all occurrences");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");
    return Console.ReadLine()!;
}
