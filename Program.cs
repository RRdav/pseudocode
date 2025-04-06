using Assignment1;

class Program
{
    static void Main(string[] args)
    {
        // Create a new tool
        Tool hammer = new Tool("Hammer", 10);

        // Display tool information
        Console.WriteLine($"Tool Name: {hammer.Name}");
        Console.WriteLine($"Total Quantity: {hammer.Quantity}");
        Console.WriteLine($"Available Quantity: {hammer.AvailableQuantity}");

        // Add a borrower
        bool added = hammer.AddBorrower("John Doe");
        Console.WriteLine($"Borrower added: {added}");

        // Display updated available quantity
        Console.WriteLine($"Available Quantity after borrowing: {hammer.AvailableQuantity}");

        // Search for a borrower
        bool found = hammer.SearchBorrower("John Doe");
        Console.WriteLine($"Borrower found: {found}");

        // Delete a borrower
        bool deleted = hammer.DeleteBorrower("John Doe");
        Console.WriteLine($"Borrower deleted: {deleted}");

        // Display updated available quantity
        Console.WriteLine($"Available Quantity after returning: {hammer.AvailableQuantity}");
        Console.ReadLine();
    }
}