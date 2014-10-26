using System;
using System.Collections;
using System.Collections.Generic;

namespace DecisionTheory.Core.DesignPatterns
{
    /// <summary>
    /// Design Pattern: Abstract Factory
    /// <para>This class represents an abstract factory. It holds singletons for each used class types</para>
    /// </summary>
    public class AbstractFactory<T> : IEnumerable<T>
    {
        private IDictionary<Type, T> instances;

        /// <summary>
        /// Default constructor for an abstract factory instance, makes type-instance mapping
        /// </summary>
        public AbstractFactory()
        {
            instances = new Dictionary<Type, T>();
        }
        
        /// <summary>
        /// Factory makes singleton instances for incoming class types
        /// </summary>
        /// <typeparam name="E">incoming class type</typeparam>
        /// <returns>singleton for incoming class</returns>
        public T getInstance<E>() where E : T, new()
        {
            Type type = typeof(E);
            if (!instances.ContainsKey(type))
                instances[type] = new E();
            return instances[type];
        }

        /// <summary>
        /// This method has been implemented for IEnumerable interface supporting
        /// </summary>
        /// <returns>enumerator for instances</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return instances.Values.GetEnumerator();
        }

        /// <summary>
        /// This method has been implemented for IEnumerable interface supporting
        /// </summary>
        /// <returns>enumerator for instances</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return instances.Values.GetEnumerator();
        }
    }
}
