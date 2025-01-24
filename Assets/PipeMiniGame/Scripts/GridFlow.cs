using Mohammad.Code;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

namespace PipeMiniGame
{
    public class GridFlow : MonoBehaviour
    {
        private AudioSource Win_AudioSource;
        private PipeRotator[] pipeRotators;
        [SerializeField] GameObject shouldentBeMiss1;
        [SerializeField] GameObject shouldentBeMiss2;
        private int DisableCall = 0;
        private GameObject persistentObject;

        public void DisablePersistentObject()
        {
            DisableCall++;
            if (DisableCall == 2)
            {
                persistentObject = GameObject.Find("GameSession");
                if (persistentObject != null)
                    persistentObject.SetActive(false);
            }
        }
        public void EnablePersistentObject()
        {
            if (persistentObject != null)
            {
                persistentObject.SetActive(true);
                persistentObject.GetComponent<LevelData>().BubbleLevel = true;
            }

            var sceneLoader = FindObjectsByType<SceneLoader>(FindObjectsSortMode.None)[0];
            sceneLoader.LoadSceneAsync("Level 1");
        }


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
            if (WinCheck() && shouldentBeMiss1.activeSelf && shouldentBeMiss2.activeSelf)
            {
                Win_AudioSource.Play();
                StartCoroutine(WaitForAudioToEnd());
            }
        }
        private IEnumerator WaitForAudioToEnd()
        {
            // Wait until the audio clip has finished playing
            while (Win_AudioSource.isPlaying)
            {
                yield return null; // Wait for the next frame
            }

            // Load the next scene after the audio has finished
            persistentObject.GetComponent<LevelData>().ToiletLevel = true;
            EnablePersistentObject();
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
