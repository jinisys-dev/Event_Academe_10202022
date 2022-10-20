using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

//added by Genny - Apr. 25, 2008
namespace Jinisys.Hotel.BusinessSharedClasses
{
    public class GenericList<T> : List<T>
    {
        public void AddItem(T item)
        {
            this.Add(item);
        }
        public int IndexOf(T obj)
        {
            return this.IndexOf(obj);
        }
    }
}
