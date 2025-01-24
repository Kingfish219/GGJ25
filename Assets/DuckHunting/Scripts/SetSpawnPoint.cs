using System;
using UnityEngine;

namespace DuckHunting.Scripts
{
	public class SetSpawnPoint : MonoBehaviour 
	{
		public static Action<Transform> PassSpawnPointTransform;

		void Start () 
		{
			if (PassSpawnPointTransform != null)
				PassSpawnPointTransform (transform);
		}

	}
}