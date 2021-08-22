using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlocks : MonoBehaviour
{
    [SerializeField] GameObject[] blocks;

    int width = 5;
    int height = 5;
    float blockSize = 1.28f;

    public GameObject[,] blockArray = new GameObject[5, 5];

    private List<GameObject> deleteList;

    int nextX;
    int nextY;

    // Start is called before the first frame update
    void Start()
    {
        deleteList = new List<GameObject>();
        Create();
    }

    private void Create()
    {
        for (int i = 0; i < width; i++)
        {
            if (i < width - 1)
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

        CheckMatchingSet();
    }

    private void CheckMatchingSet()
    {
        for(int i = 0; i < width; i++)
        {
            for(int j = 0; j < height - 2; j++)
            {
                if(blockArray[i, j + 2] != null)
                {
                    if (blockArray[i, j].tag == blockArray[i, j + 1].tag && blockArray[i, j].tag == blockArray[i, j + 2].tag)
                    {
                        blockArray[i, j].GetComponent<MoveBlocks>().isMatching = true;
                        blockArray[i, j + 1].GetComponent<MoveBlocks>().isMatching = true;
                        blockArray[i, j + 2].GetComponent<MoveBlocks>().isMatching = true;
                    }
                }
            }
        }

        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width - 2; j++)
            {
                if(blockArray[j + 2, i] != null)
                {
                    if (blockArray[j, i].tag == blockArray[j + 1, i].tag && blockArray[j, i].tag == blockArray[j + 2, i].tag)
                    {
                        blockArray[j, i].GetComponent<MoveBlocks>().isMatching = true;
                        blockArray[j + 1, i].GetComponent<MoveBlocks>().isMatching = true;
                        blockArray[j + 2, i].GetComponent<MoveBlocks>().isMatching = true;
                    }
                }
            }
        }

        foreach (var item in blockArray)
        {
            if(item != null)
            {
                if (item.GetComponent<MoveBlocks>().isMatching)
                {
                    deleteList.Add(item);
                }
            }
        }

        if(deleteList.Count > 0)
        {
            Delete();
        }
        else
        {
            Debug.Log("Game Start");
        }
    }

    private void Delete()
    {
        foreach (var item in deleteList)
        {
            blockArray[(int)(item.transform.position.x / blockSize), (int)(item.transform.position.y / blockSize)] = null;
            Destroy(item);
            nextX = (int)(item.transform.position.x / blockSize);
            nextY = (int)(item.transform.position.y / blockSize);

            SpawnNewBlock();
        }

        deleteList.Clear();
        CheckMatchingSet();
    }

    private void SpawnNewBlock()
    {
        int r = Random.Range(0, 4);
        var block = Instantiate(blocks[r]);
        block.transform.position = new Vector3(nextX * blockSize, nextY * blockSize);
        blockArray[nextX, nextY] = block;
    }
}
