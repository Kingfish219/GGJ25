using UnityEngine;

namespace Mohammad.Code
{
    public class BoxHandler : MonoBehaviour
    {
        [SerializeField] private GameObject Box;
        public void OnMouseDown()
        {
            if (Box != null) 
                Box.SetActive(true);
        }

        public void buxFalse()
        {
            if (Box != null)
                Box.SetActive(false);
        }
    }
}