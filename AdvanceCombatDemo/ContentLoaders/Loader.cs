using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceCombatDemo.ContentLoaders
{
    public abstract class Loader
    {
        public abstract void Load();

        protected List<T> LoadContent<T>() 
        {
            List<T> contents = new List<T>();

            Assembly assembly = typeof(Main).Assembly;

            List<Type> types = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(T))).ToList();

            foreach (Type type in types)
            {
                if (type.IsAbstract) continue;

                contents.Add((T)Activator.CreateInstance(type));
            }

            return contents;
        }
    }
}
