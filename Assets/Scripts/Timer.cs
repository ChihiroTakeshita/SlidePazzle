using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float maxTime;
    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject text;
    GameManager gManager;
    GameObject scenemanager;
    SceneChange manager;
    Text timeUp;
    public float currentTime;

    Slider timer;

    // Start is called before the first frame update
    void Start()
    {
        scenemanager = GameObject.FindGameObjectWithTag("SceneManager");
        manager = scenemanager.GetComponent<SceneChange>();
        gManager = gameManager.GetComponent<GameManager>();
        timeUp = text.GetComponent<Text>();
        currentTime = maxTime;
        timer = GetComponent<Slider>();
        timer.maxValue = maxTime;
        timer.value = maxTime;
        StartCoroutine("Time");
    }

    IEnumerator Time()
    {
        while(true)
        {
            timer.value = currentTime;
            currentTime -= 0.1f;

            if(currentTime < 0)
            {
                timeUp.text = "TIME UP!";
                gManager.FreezeBlocks();
                //Invoke("ToResult", 0.5f);
                break;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    void ToResult()
    {
        manager.LoadResult();
    }
}
