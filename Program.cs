using Assignment1;

class Program
{
    static void Main(string[] args)
    {
        //// Create a new tool
        //Tool hammer = new Tool("Hammer", 10);

        //// Display tool information
        //Console.WriteLine($"Tool Name: {hammer.Name}");
        //Console.WriteLine($"Total Quantity: {hammer.Quantity}");
        //Console.WriteLine($"Available Quantity: {hammer.AvailableQuantity}");

        //// Add a borrower
        //hammer.AddBorrower("John Doe");
        //hammer.AddBorrower("RR David");
        //hammer.AddBorrower("Kwame Asante");


        //// Display updated available quantity
        //Console.WriteLine($"Available Quantity after borrowing: {hammer.AvailableQuantity}");

        //Console.WriteLine("Borrowers: " + string.Join(", ", hammer.Borrowers));


        //// Search for a borrower
        //bool found = hammer.SearchBorrower("John Doe");
        //Console.WriteLine($"Borrower found: {found}");

        //// Delete a borrower
        //bool deleted = hammer.DeleteBorrower("John Doe");
        //Console.WriteLine($"Borrower deleted: {deleted}");

        //// Display updated available quantity
        //Console.WriteLine($"Available Quantity after returning: {hammer.AvailableQuantity}");

        //Testing Increment and Decrement methods
        Tool screwdriver = new Tool("Screwdriver", 5);
        Console.WriteLine($"Current Amount of tools: {screwdriver.Quantity}");
        screwdriver.IncreaseQuantity(5);
        Console.WriteLine($"Current Amount of tools: {screwdriver.Quantity}");
        screwdriver.DecreaseQuantity(5);
        Console.WriteLine($"Current Amount of tools: {screwdriver.Quantity}");
        Console.ReadLine();
    }
}