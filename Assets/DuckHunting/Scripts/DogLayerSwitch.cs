using UnityEngine;

namespace DuckHunting.Scripts
{
    public class DogLayerSwitch : MonoBehaviour
    {
        public int sortingOrder = 0;
        private SpriteRenderer sprite;

        //void Start () {}

        //void Update () {}

        void SwitchLayerBack()
        {
            sprite = GetComponent<SpriteRenderer>();
            sprite.sortingLayerName = "Dog";
        }

    }
}
