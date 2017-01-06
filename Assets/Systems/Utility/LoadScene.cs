using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Systems.Utility.SceneManagment
{
    [RequireComponent(typeof(SceneFader))]
    public class LoadScene : MonoBehaviour
    {
        public float timer = 3f;
        public bool useTimer = false;
        public string SceneToLoad;

        void Awake()
        {
            if (useTimer)
            {
                Load(SceneToLoad);
            }
        }

        public void Load(string scene)
        {
            Time.timeScale = 1.0f;
            StartCoroutine("DisplayNextLevel", scene);
        }

        /// <summary>
        /// DisplayNextLevel waits for fading to finish then
        /// loads the scene in "SceneToLoad"
        /// </summary>
        IEnumerator DisplayNextLevel(string scene)
        {
            if (useTimer)
            {
                yield return new WaitForSeconds(timer);
            }
            float fadeTime = GetComponent<SceneFader>().BeginFade(1);
            yield return new WaitForSeconds(fadeTime);
            SceneManager.LoadScene(scene);
        }
    }
}