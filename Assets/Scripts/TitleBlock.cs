using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBlock : MonoBehaviour
{
    [SerializeField] GameObject[] blocks;

    Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(-2.56f, 5.12f);

        for(int i = 0; i < 9; i++)
        {
            for(int j = 0; j < 5; j++)
            {
                int r = Random.Range(0, 4);
                Instantiate(blocks[r], pos, Quaternion.identity);
                pos.x += 1.28f;
                Debug.Log("Instantiated!");
            }
            pos.x = -2.56f;
            pos.y -= 1.28f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
