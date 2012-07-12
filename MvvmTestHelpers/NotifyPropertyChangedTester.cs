using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvvmTestHelpers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T">A View Model implementing INotifyPropertyChanged</typeparam>
    public class NotifyPropertyChangedTester<T>
        where T : INotifyPropertyChanged
    {
        private readonly T _instance;
        private IEnumerable<PropertyInfo> _properties;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotifyPropertyChangedTester&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="instance">The instance.</param>
        public NotifyPropertyChangedTester(T instance)
        {
            _instance = instance;
            _properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        /// <summary>
        /// Excludes the properties by property name
        /// </summary>
        /// <param name="excludeProperties">The excluded property names</param>
        public void ExcludeProperties(IEnumerable<string> excludeProperties)
        {
            _properties = _properties.Where(prop => !excludeProperties.Contains(prop.Name));
        }

        /// <summary>
        /// Excludes the properties from the specified types
        /// </summary>
        /// <param name="excludeProperties">The excluded property types.</param>
        public void ExcludeProperties(IEnumerable<Type> excludeProperties)
        {
            _properties = _properties.Where(prop => excludeProperties.Contains(prop.PropertyType));
        }

        /// <summary>
        /// Tests the properties if the NotifyPropertyChanged event was triggerd when the value was set.
        /// </summary>
        public void Test()
        {
            foreach (var property in _properties)
            {
                var setter = property.GetSetMethod(false);
                var getter = property.GetGetMethod(false);

                if (setter == null) continue;

                var receivedEvents = new List<string>();

                PropertyChangedEventHandler propertyChanged =
                    (sender, args) => receivedEvents.Add(args.PropertyName);

                _instance.PropertyChanged += propertyChanged;

                object value = null;

                if (property.PropertyType.BaseType == typeof(ValueType))
                {
                    value = Activator.CreateInstance(property.PropertyType);
                }
                else if (property.PropertyType.BaseType == typeof(Enum))
                {
                    value = Enum.ToObject(property.PropertyType, 0);
                }

                setter.Invoke(_instance, new object[] { value });

                _instance.PropertyChanged -= propertyChanged;

                Assert.AreEqual(1, receivedEvents.Count);
                Assert.AreEqual(property.Name, receivedEvents.First());

                if (getter == null) continue;

                Assert.AreEqual(value, getter.Invoke(_instance, new object[] { }));
            }
        }
    }
}
