using UnityEngine;

namespace DuckHunting.Scripts
{
	public class GameManager : MonoBehaviour
	{
		public delegate void DuckDel();
		public static DuckDel OnSpawnDucks;
		public static DuckDel OnDuckShot;
		public static DuckDel OnDuckDeath;
		public static DuckDel OnDuckFlyAway;
		public static DuckDel OnDuckMiss;
		public static DuckDel OnGameOver;

		public GameObject flyAwaySky;
		public GameObject gameOver;
		Shooter shoot;

		// Use this for initialization
		void Start ()
		{
			GameObject shooter = GameObject.Find("Main Camera");
			shoot = shooter.GetComponent<Shooter>();

			GameManager.OnDuckMiss += FlyAwaySkyOn;
			GameManager.OnDuckFlyAway += FlyAwaySkyOff;
			GameManager.OnSpawnDucks += FlyAwaySkyOff;
			GameManager.OnGameOver += GameOverOn;
		}
		

		public void FlyAwaySkyOn()
		{
			flyAwaySky.SetActive (true);
		}

		public void FlyAwaySkyOff()
		{
			flyAwaySky.SetActive (false);
		}

		public void GameOverOn()
		{
			gameOver.SetActive (true);
		}
	}
}
