﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11Exercises_PeopleCollection
{
    class People : DictionaryBase, ICloneable
    {
        public void Add(Person newPerson)
        {
            Dictionary.Add(newPerson.Name, newPerson);
        }

        public void Remove(string name)
        {
            Dictionary.Remove(name);
        }

        public Person this[string name] //indexer
        {
            get { return (Person)Dictionary[name]; }
            set { Dictionary[name] = value; }
        }

        public Person[] GetOldest()
        {
            Person oldestPerson = null;
            People oldestPeople = new People();
            Person currentPerson;
            foreach (DictionaryEntry p in Dictionary)
            {
                currentPerson = p.Value as Person;
                if (oldestPerson == null)
                {
                    oldestPerson = currentPerson;
                    oldestPeople.Add(currentPerson);
                }
                else
                {
                    if (currentPerson > oldestPerson)
                    {
                        oldestPeople.Clear();
                        oldestPeople.Add(currentPerson);
                        oldestPerson = currentPerson;
                    }
                    else
                    {
                        if (currentPerson >= oldestPerson) oldestPeople.Add(currentPerson); //had to use >= operator because == override was not implemented.
                    }
                }
            }
            Person[] oldestPeopleArray = new Person[oldestPeople.Count];
            int copyIndex = 0;
            foreach (DictionaryEntry p in oldestPeople)
            {
                oldestPeopleArray[copyIndex] = p.Value as Person;
                copyIndex++;
            }
            return oldestPeopleArray;
        }

        public object Clone() //implement deep copying
        {
            People clonedPeople = new People();
            Person currentPerson, newPerson;
            foreach(DictionaryEntry p in Dictionary)
            {
                currentPerson = p.Value as Person;
                newPerson = new Person();
                newPerson.Name = currentPerson.Name;
                newPerson.Age = currentPerson.Age;
                clonedPeople.Add(newPerson);
            }
            return clonedPeople;
        }

        public IEnumerable Ages //Age iterator
        {
            get
            {
                foreach (object person in Dictionary.Values)
                {
                    yield return (person as Person).Age;
                }
            }
        }
    }
}
