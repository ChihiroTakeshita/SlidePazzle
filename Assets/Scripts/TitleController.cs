using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    [SerializeField] GameObject title;
    [SerializeField] GameObject rule;
    [SerializeField] GameObject scenemanager;
    SceneChange manager;
    bool isRule = false;

    private void Start()
    {
        manager = scenemanager.GetComponent<SceneChange>();
    }

    private void OnMouseDown()
    {
        if(!isRule)
        {
            title.SetActive(false);
            rule.SetActive(true);
            isRule = true;
        }
        else
        {
            manager.LoadGame();
        }
    }
}
