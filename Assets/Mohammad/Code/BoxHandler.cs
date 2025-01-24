using UnityEngine;

namespace Mohammad.Code
{
    public class BoxHandler : MonoBehaviour
    {
        [SerializeField] private GameObject Box;
        private GameObject persistentObject;
        private bool isValidBox = true;
        public void OnMouseDown()
        {
            persistentObject = GameObject.Find("GameSession");
            if (persistentObject != null)
                isValidBox = persistentObject.GetComponent<LevelData>().BubbleLevel;
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