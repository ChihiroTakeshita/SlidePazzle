using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーン遷移用
/// </summary>

public class SceneManager : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// ゲーム画面を読み込みます。
    /// </summary>
    public void LoadGame()
    {

    }

    /// <summary>
    /// リザルト画面を読み込みます。
    /// </summary>
    public void LoadResult()
    {

    }

    /// <summary>
    /// タイトル画面を読み込みます。
    /// </summary>
    public void LoadTitle()
    {

    }
}
