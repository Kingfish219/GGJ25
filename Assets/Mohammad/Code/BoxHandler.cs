using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Mohammad.Code
{
    public class BoxHandler : MonoBehaviour
    {
        public GameObject BOB;
        [SerializeField] private GameObject Box;
        private GameObject persistentObject;
        private bool isValidBox = true;
        private void Start()
        {
            Debug.Log(LevelData.BubbleLevel); 
            if (LevelData.BubbleLevel)
            {
                Vector3 randomPosition = new Vector3(Random.Range(0f, 0f), Random.Range(-10f, 10f), 0f);
                Quaternion rotation = Quaternion.identity; // No rotation

                Instantiate(BOB, randomPosition, rotation);
            }
        }
        public void OnMouseDown()
        {
            persistentObject = GameObject.Find("GameSession");
            if (persistentObject != null)
                isValidBox = LevelData.BubbleLevel;
            if (Box != null && !isValidBox) 
                Box.SetActive(true);
        }

        public void buxFalse()
        {
            if (Box != null)
                Box.SetActive(false);
        }
    }
}