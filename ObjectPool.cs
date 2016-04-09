using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;


namespace KBEngine
{
	/// <summary>
	/// 简单的对象池
	/// </summary>
	/// <typeparam name="T">对象类型</typeparam>
	public class ObjectPool<T> where T : new()
	{
		private static LinkedList<T> _objects = new LinkedList<T>();

		public static T getObject()
		{
			lock (_objects)
			{
				if (_objects.First != null)
				{
					T v = _objects.First.Value;
					_objects.RemoveFirst();
					return v;
				}
				else
				{
					return new T();
				}
			}
		}

		public static void putObject(T item)
		{
			lock (_objects)
			{
				_objects.AddLast(item);
			}
		}
	}

}
