using UnityEngine;
using UnityEngine.SceneManagement;

namespace LSW
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance = null;
        int startSceneIndex = 1;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);
        }

        private void Start()
        {
            LoadScene(startSceneIndex);
        }

        private void LoadScene(int index)
        {
            int current = SceneManager.GetActiveScene().buildIndex;
            if (index != current)
                SceneManager.LoadScene(index, LoadSceneMode.Additive);
            if (index > startSceneIndex)
                SceneManager.UnloadSceneAsync(current);
        }
    }
}