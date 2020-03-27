﻿using System;
using System.Linq;

namespace BlazorFramework.Factories
{
    public class WaitPostAction : Attribute
    {
        public int Value { get; set; }

        public WaitPostAction(int attributeValue)
        {
            Value = attributeValue;
        }
    }

    public static class AttributeExtensions
    {
        public static TValue GetAttributeValue<TAttribute, TValue>(this Type type, Func<TAttribute, TValue> valueSelector)
            where TAttribute : Attribute
        {
            var att = type.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;

            if (att != null)
            {
                return valueSelector(att);
            }

            return default(TValue);
        }
    }
}
