using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadResult()
    {
        SceneManager.LoadScene("Result");
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
