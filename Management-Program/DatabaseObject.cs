//Name: DatabaseObject.cs
//Purpose: Declares and implements both the DatabaseObject and TDatabase classes
//Author: Brayden Faulkner
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Program
{
    public class DatabaseObject
    {
        //This is the class that holds each indivual object in the database
        string Name;
        int Amount;
        string ID;
       public DatabaseObject(string N, int A, string I)
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
        public string GetID()
        {
            return ID;
        }
    }
    public class TDatabase
    {
        //Stores the list of DatabaseObjects and hold the functions that work on them
        private List<DatabaseObject> Inventory;
        public TDatabase()
        {
            Inventory = new List<DatabaseObject>();
        }
        public DatabaseObject GetElement(int index)
        {
            return Inventory[index];
        }
        public void AddObject(string N, int A, string I)
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
        public bool Repetition(string Name, string ID)
        {
            for(int i = 0; i < Size(); i++)
            {
                if(Name == GetElement(i).GetName())
                {
                    return true;
                }
                if(ID == GetElement(i).GetID())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
