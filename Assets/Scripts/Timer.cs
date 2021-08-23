using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float maxTime;
    [SerializeField] GameObject gameManager;
    GameManager gManager;
    public float currentTime;

    Slider timer;

    // Start is called before the first frame update
    void Start()
    {
        gManager = gameManager.GetComponent<GameManager>();
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
                gManager.FreezeBlocks();
                break;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}
