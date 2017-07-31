﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

/// 
/// 1.泛型
/// 2.反射
/// 3.抽象类
/// 4.命名空间
/// 
namespace QFramework
{
    public abstract class QSingleton<T> where T : QSingleton<T>
    {
        protected static T instance = null;

        protected QSingleton()
        {
        }

        public static T Instance()
        {
            if (instance == null)
            {
                ConstructorInfo[] ctors = typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                ConstructorInfo ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
                if (ctor == null)
                    throw new Exception("Non-public ctor() not found!");
                instance = ctor.Invoke(null) as T;
            }
            return instance;
        }
    }
}