using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Program
{
    public class DatabaseObject
    {
        string Name;
        int Amount;
        int ID;
       public DatabaseObject(string N, int A, int I)
        {
            Name = N;
            Amount = A;
            ID = I;
        }
        public string GetName()
        {
            return Name;
        }
        public int GetAmount()
        {
            return Amount;
        }
        public int GetID()
        {
            return ID;
        }
    }
    public class TDatabase
    {
        private List<DatabaseObject> Inventory;
        public TDatabase()
        {
            Inventory = new List<DatabaseObject>();
        }
        public DatabaseObject GetElement(int index)
        {
            return Inventory[index];
        }
        public void AddObject(string N, int A, int I)
        {
            Inventory.Add( new DatabaseObject(N, A, I));
        }
        public void RemoveObject(int index)
        {
            Inventory.RemoveAt(index);
        }
        public int FindIndexName(string N)
        {
            int i = 0;
            while(Inventory[i].GetName() != N)
            {
                i++;
            }
            return i;
        }
        public int Size()
        {
            return Inventory.Count();
        }
    }
}
