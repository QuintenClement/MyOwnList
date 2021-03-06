﻿using System;
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
        public static MyList<T> operator+ (MyList<T> list1, MyList<T> list2)
        {
            MyList<T> list = new MyList<T>();
            for (int i = 0; i < list1.count; i++)
            {
                list.Add(list1[i]);
            }
            for (int j = 0; j < list2.count; j++)
            {
                list.Add(list2[j]);
            }
            return list;
        }
        public static MyList<T> operator- (MyList<T> list1, MyList<T> list2)
        {
            for (int i = 0; i < list1.count; i++)
            {
                for (int j = 0; j < list2.count; j++)
                {
                    if (list1[i].Equals(list2[j]))
                    {
                        list1.Remove(i);
                    }
                }
            }
            return list1;
        }
        public override string ToString()
        {
            string NewString = "";
            for (int i = 0; i < count; i++)
            {
                items[i].ToString();
                NewString += items[i];
            }
            return NewString;
        }
    }
}
