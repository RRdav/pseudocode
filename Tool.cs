using System.ComponentModel.Design;

namespace Assignment1
{
    public partial class Tool : ITool
    {
        /// <summary>
        /// Represents the name of the tool. This string must non-empty.
        /// </summary>
        private string mName;

        /// <summary>
        /// Array containing the current borrowers for the tool.
        /// There is no specific requirement for the ordering of borrower names, but there should
        /// never be any duplicate names in the array.
        /// </summary>
        private string[] mBorrowers;

        /// <summary>
        /// Private field containing the maximum number of borrowers.
        /// </summary>
        private int mQuantity;

        /// <summary>
        /// Represents the name of the tool. This string must non-empty.
        /// </summary>
        public string Name { get { return mName; } }

        /// <summary>
        /// Represents the quantity of tools that are tracked by this object.
        /// If there were 10 hammers available, then Quantity would return 10 regardless of
        /// how many were currently being borrowed.
        /// </summary>
        public int Quantity { get { return mQuantity; } }

        /// <summary>
        /// Array containing the current borrowers for the tool.
        /// There is no specific requirement for the ordering of borrower names, but there should
        /// never be any duplicate names in the array.
        /// </summary>
        public string[] Borrowers { get { return mBorrowers; } }

        /// <summary>
        /// Property containing the current number of borrowers of the tool.
        /// </summary>
        public int AvailableQuantity { get { return mQuantity - mBorrowers.Length; } }

        /// <summary>
        /// Creates a new tool that tracks borrowers, and can be added to a collection.
        /// </summary>
        /// <param name="name">Name of this tool, must be non-empty otherwise ArgumentException is thrown</param>
        /// <param name="quantity">Quantity to make available to borrowers, must be greater than or equal
        /// to 1, otherwise ArgumentOutOfRangeException should be thrown.</param>
        public Tool(string name, int quantity)
        {
            if (name == null || name.Length == 0)
                throw new System.ArgumentException("name must not be a null or empty string");

            if (quantity < 1)
                throw new System.ArgumentOutOfRangeException("Quantity must be at least 1");

            mName = name;
            mBorrowers = new string[0];
            mQuantity = quantity;
        }

        public bool IncreaseQuantity(int num)
        {
            if(num > 0)
            {
                mQuantity += num;
                return true;
            }
            return false;
        }

        public bool DecreaseQuantity(int num)
        {
            if(num > 0 && num <= AvailableQuantity)
            {
                mQuantity -= num;
                return true;
            }
            return false;
        }

        public bool AddBorrower(string aBorrower)
        {
            if(AvailableQuantity > 0 && aBorrower != null && aBorrower != "" && !SearchBorrower(aBorrower)) {
                int OldAvailableQuantity = AvailableQuantity;
                string[] oldBorrowers = mBorrowers;
                string[] newBorrowers = new string[mBorrowers.Length + 1];
                Console.WriteLine("===============================");
                Console.WriteLine("Old Borrowers Available QTY: " + AvailableQuantity);
                Console.WriteLine("===============================");
                for (int i = 0; i < oldBorrowers.Length; i++)
                {
                    newBorrowers[i] = oldBorrowers[i];
                }
                newBorrowers[newBorrowers.Length-1] = aBorrower;
                mBorrowers = newBorrowers;
                Console.WriteLine("===============================");
                Console.WriteLine("Borrower added: " + aBorrower);
                Console.WriteLine("Available Quantity Changed: " + AvailableQuantity);
                Console.WriteLine("===============================");
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteBorrower(string aBorrower)
        {
            if (aBorrower != null && aBorrower != "" && SearchBorrower(aBorrower))
            {
                // Find the index of the borrower to be removed
                int index = -1;
                for (int i = 0; i < mBorrowers.Length; i++)
                {
                    if (mBorrowers[i] == aBorrower)
                    {
                        index = i;
                        Console.WriteLine($"Found Borrower to delete : {mBorrowers[i]}");
                        break;
                    }
                }

                // If the borrower is found, remove them from the array
                if (index != -1)
                {
                    string[] newBorrowers = new string[mBorrowers.Length - 1];

                    // Copy the elements before the index
                    for (int i = 0; i < index; i++)
                    {
                        newBorrowers[i] = mBorrowers[i];
                    }

                    // Copy the elements after the index
                    for (int i = index; i < newBorrowers.Length; i++)
                    {
                        newBorrowers[i] = mBorrowers[i + 1];
                    }

                    mBorrowers = newBorrowers;
                    return true;
                }
                else
                {
                    Console.WriteLine($"Can't find and delete borrower: {aBorrower}");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Can't delete anything lol");
                return false;
            }
        }



        public bool SearchBorrower(string aBorrower)
        {
            if (aBorrower != null && aBorrower != "") {
                for (int i = 0; i < mBorrowers.Length; i++) {
                    if (mBorrowers[i] == aBorrower)
                        return true;
                }
                return false;
            }
            else {
                return false;
            }
        }
    }
}