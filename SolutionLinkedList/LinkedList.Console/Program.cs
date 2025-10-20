using LinkedList.Core;

var list = new SinglyLinkedList<string>();
var opc = string.Empty;
do
{
    opc = Menu();
    switch (opc)
    {
        case "0":
            Console.WriteLine("Bye.");
            break;

        case "1":
            Console.Write("Enter the value: ");
            list.InsertAtBeginning(Console.ReadLine()!);
            break;

        case "2":
            Console.Write("Enter the value: ");
            list.InsertAtEnd(Console.ReadLine()!);
            break;

        case "3":
            list.PrintList();
            break;

        default:
            Console.WriteLine("Invalid option");
            break;
    }
} while (opc != "0");

string Menu()
{
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine("1. Insert at beginning");
    Console.WriteLine("2. Insert at end");
    Console.WriteLine("3. Print the list");
    Console.WriteLine("0. Exit");
    Console.Write("Enter your option: ");
    return Console.ReadLine()!;
}