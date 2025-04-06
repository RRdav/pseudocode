namespace Assignment1
{
    partial class ToolCollection : IToolCollection
    {
        /// <summary>
        /// Storage for the referenced tools in the collection.
        /// </summary>
        private ITool[] mTools = null;

        /// <summary>
        /// Maximum number of tools that can be stored in the collection.
        /// </summary>
        private int mCapacity = 0;

        /// <summary>
        /// Public property that returns the total capacity of the collection.
        /// </summary>
        public int Capacity { get { return mCapacity; } }

        /// <summary>
        /// Property containing the current number of Tools in the collection.
        /// </summary>
        public int Number { get { return mTools.Length; } }

        /// <summary>
        /// Property for read-only access to the tools in the collection.
        /// </summary>
        public ITool[] Tools { get { return mTools; } }

        /// <summary>
        /// Creates a new tool collection with the specified capacity.
        /// The capacity is an upper bound for the number of tools that can be stored
        /// in the collection.
        /// </summary>
        /// <param name="capacity">Maximum number of tools in the collection</param>
        public ToolCollection(int capacity)
        {
            if (capacity < 1)
                throw new System.ArgumentOutOfRangeException("Capacity should be at least 1.");

            // Start with an empty array of no tools.
            mTools = new ITool[0];
            mCapacity = capacity;
        }

        public bool Add(ITool aTool)
        {
            if (IsFull())
            {
                Console.WriteLine("The tool collection is full.");
                return false;
            }

            if (aTool != null && !Search(aTool))
            {
                ITool[] newToolCollection = new ITool[mTools.Length + 1];
                for(int i = 0; i < mTools.Length; i++)
                {
                    newToolCollection[i] = mTools[i];
                }
                newToolCollection[newToolCollection.Length - 1] = aTool;
                mTools = newToolCollection;

                for (int i = 1; i < mTools.Length; i++)
                {
                    ITool key = mTools[i];
                    int left = 0;
                    int right = i - 1;
                    while (left <= right)
                    {
                        int mid = (left + right) / 2;
                        if (mTools[mid].Name.CompareTo(key.Name) < 0)
                        {
                            left = mid + 1;
                        }
                        else
                        {
                            right = mid - 1;
                        }
                    }
                    for (int j = i - 1; j >= left; j--)
                    {
                        mTools[j + 1] = mTools[j];
                    }
                    mTools[left] = key;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            mTools = new ITool[0];
        }

        public bool Delete(ITool aTool)
        {
            if(IsEmpty())
            {
                Console.WriteLine("The tool collection is empty.");
                return false;
            }

            if (aTool != null)
            {
                int left = 0;
                int right = mTools.Length - 1;
                int index = -1;

                while (left <= right)
                {
                    int mid = (left + right) / 2;
                    if (mTools[mid].Name.CompareTo(aTool.Name) == 0)
                    {
                        index = mid;
                        break;
                    }
                    else if (mTools[mid].Name.CompareTo(aTool.Name) < 0)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }

                if (index != -1)
                {
                    ITool[] newToolCollection = new ITool[mTools.Length - 1];
                    for (int i = 0, j = 0; i < mTools.Length; i++)
                    {
                        if (i != index)
                        {
                            newToolCollection[j++] = mTools[i];
                        }
                    }
                    mTools = newToolCollection;
                    return true;
                }
            }
            return false;
        }

        public bool IsEmpty()
        {
            if(mTools.Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFull()
        {
            if(mTools.Length == mCapacity)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Search(ITool aTool)
        {
            if (IsEmpty())
            {
                Console.WriteLine("The tool collection is empty.");
                return false;
            }
            if (aTool != null)
            {
                int left = 0;
                int right = mTools.Length - 1;
                while (left <= right)
                {
                    int mid = (left + right) / 2;
                    if (mTools[mid].Name.CompareTo(aTool.Name) == 0)
                    {
                        return true;
                    }
                    else if (mTools[mid].Name.CompareTo(aTool.Name) < 0)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                return false;
            } 
            else
            {
                return false;
            }
        }
    }
}
