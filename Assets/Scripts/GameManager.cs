using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject sceneManager;
    GameObject[] redBlocks;
    GameObject[] greenBlocks;
    GameObject[] blueBlocks;
    GameObject[] yerrowBlocks;
    SceneManager scene;
    public int interval = 10;
    public int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        scene = sceneManager.GetComponent<SceneManager>();
    }

    public void TimeUp()
    {
        redBlocks = GameObject.FindGameObjectsWithTag("Red");
        greenBlocks = GameObject.FindGameObjectsWithTag("Green");
        blueBlocks = GameObject.FindGameObjectsWithTag("Blue");
        yerrowBlocks = GameObject.FindGameObjectsWithTag("Yerrow");

        foreach (var item in redBlocks)
        {
            item.GetComponent<MoveBlocks>().timeUp = true;
        }

        Debug.Log("Red : false");

        foreach (var item in greenBlocks)
        {
            item.GetComponent<MoveBlocks>().timeUp = true;
        }

        Debug.Log("Green : false");

        foreach (var item in blueBlocks)
        {
            item.GetComponent<MoveBlocks>().timeUp = true;
        }

        Debug.Log("Blue : false");

        foreach (var item in yerrowBlocks)
        {
            item.GetComponent<MoveBlocks>().timeUp = true;
        }

        Debug.Log("Yerrow : false");
    }
}
