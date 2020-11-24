using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Models
{
    class Stack<T>
    {
        private List<T> items = new List<T>();

        public bool IsEmpty => items.Count == 0;


        public void Add(T item)
        {
            items.Add(item);
        }

        public T PickUp()
        {
            if (!IsEmpty)
            {
                var item = items.LastOrDefault();
                items.Remove(item);
                return item;
            }
            else
            {
                
                throw new NullReferenceException("Стек пуст");
            }

        }

        public T Look()
        {
            if (!IsEmpty)
            {
                return items.LastOrDefault();
            }
            else
            {
                throw new NullReferenceException("Стек пуст");
            }

        }

        public void Delete()
        {
            if (!IsEmpty)
            {
                var item = items.LastOrDefault();
                items.Remove(item);
            }
            else
            {
                throw new NullReferenceException("Стек пуст");
            }

        }
    }
}
