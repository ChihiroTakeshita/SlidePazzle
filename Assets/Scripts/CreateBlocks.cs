using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlocks : MonoBehaviour
{
    [SerializeField] GameObject[] blocks;

    int width = 5;
    int height = 5;
    float blockSize = 1.28f;

    GameObject[,] blockArray = new GameObject[5, 5];

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < width; i++)
        {
            if(i < width - 1)
            {
                for (int j = 0; j < height; j++)
                {
                    int r = Random.Range(0, 4);
                    var block = Instantiate(blocks[r]);
                    block.transform.position = new Vector3(blockSize * i, blockSize * j);
                    blockArray[i, j] = block;
                }
            }
            else
            {
                for (int j = 0; j < height - 1; j++)
                {
                    int r = Random.Range(0, 4);
                    var block = Instantiate(blocks[r]);
                    block.transform.position = new Vector3(blockSize * i, blockSize * j);
                    blockArray[i, j] = block;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
