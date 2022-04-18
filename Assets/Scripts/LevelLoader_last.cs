using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader_last : MonoBehaviour
{
    private int nextSceneToLoad;

    void Start()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex - 5;
        DontDestroyOnLoad(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(nextSceneToLoad);
    }
}