using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList2
{
    public class MyList<T>
    {
        public T[] items;
        public T[] tempArray;
        int count;
        int cap;
        public int Count {get { return count; } }

        public MyList()
        {
            cap = 4;
            count = 0;
            items = new T[cap];

        }


        public void Add(T item)
        {
            CheckIfCapped();
            items[count] = item;
            count++;
        }

        public void CheckIfCapped()
        {
            if (count == cap - 1)
            {
                cap += 4;
                StoreData();
                CreateNewArray();
                TransferData();
            }
        }
        public void StoreData()
        {
            tempArray = new T[count];
            for(int i = 0; i < count; i++)
            {
                tempArray[i] = items[i];
            }
        }
        public void TransferData()
        {
            for (int i = 0; i < tempArray.Count(); i++)
            {
                items[i] = tempArray[i];
            }
           
        }
        public void CreateNewArray()
        {
            items = new T[cap];
        }

        public void Remove(int index)
        {
            while (count - 1 > index)
            {
                items[index] = items[index + 1];
                index++;
            }
                count--;
            
        }

        public T this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
            }
        }
    }
}
