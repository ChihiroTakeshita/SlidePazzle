using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAlpha : MonoBehaviour
{
    Text text;

    float alpha;
    [SerializeField] float ratio;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        alpha = 0;
        StartCoroutine(ChangeAlpha());
    }

    IEnumerator ChangeAlpha()
    {
        while(true)
        {
            text.color = new Color(0f, 0f, 0f, alpha);
            alpha += ratio;
            if (alpha > 1 || alpha < 0)
            {
                ratio *= -1;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
