using UnityEngine;

namespace PipeMiniGame
{
    public class GridFlow : MonoBehaviour
    {
        private AudioSource Win_AudioSource;
        private PipeRotator[] pipeRotators;
        private void Start()
        {
            // Get all PipeRotator components from the children of this GameObject
            pipeRotators = GetComponentsInChildren<PipeRotator>();
            Win_AudioSource = GetComponent<AudioSource>();
            // Optional: Log the number of found PipeRotators
            Debug.Log($"Found {pipeRotators.Length} PipeRotators in children of {gameObject.name}.");
        }
        public void WinPipe()
        {
            if (WinCheck())
            {
                Win_AudioSource.Play();
            }
            else
                Debug.Log("No");
        }

        private bool WinCheck()
        {
            foreach (PipeRotator pipeRotator in pipeRotators)
            {
                if (pipeRotator != null)
                {
                    if (!pipeRotator.isCorrect || !pipeRotator.isCorrectPlace)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
