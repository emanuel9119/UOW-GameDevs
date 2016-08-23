using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Extensions
{
	public static class TransformGetAllChildren
	{
		public static IEnumerable<Transform> GetAllChildren(this Transform t)
		{
			LinkedList<Transform> childrenRemaining = new LinkedList<Transform>();
			childrenRemaining.AddLast(t);
			
			while(childrenRemaining.Count > 0)
			{
				var next = childrenRemaining.First;
				
				yield return next.Value;
				
				childrenRemaining.Remove(next);
				
				foreach(Transform v in next.Value)
				{
					childrenRemaining.AddLast(v);
				}
			}
		}
	}
}