using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBlocks : MonoBehaviour
{
    GameObject blockCreator;
    SetGame create;
    GameObject scoreText;
    Score score;
    GameObject manager;
    GameManager gameManager;

    int width = 5;
    int height = 5;

    private List<GameObject> deleteList;

    private bool isMoved = true;

    int currentScore;

    private void Start()
    {
        blockCreator = GameObject.Find("BlockCreator");
        scoreText = GameObject.Find("Score");
        manager = GameObject.Find("GameManager");
        create = blockCreator.GetComponent<SetGame>();
        score = scoreText.GetComponent<Score>();
        gameManager = manager.GetComponent<GameManager>();
        deleteList = new List<GameObject>();
    }

    public void CheckMatching()
    {
        gameManager.FreezeBlocks();

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height - 2; j++)
            {
                if (create.blockArray[i, j] != null && create.blockArray[i, j + 1] != null && create.blockArray[i, j + 2] != null)
                {
                    if (create.blockArray[i, j].tag == create.blockArray[i, j + 1].tag && create.blockArray[i, j].tag == create.blockArray[i, j + 2].tag)
                    {
                        create.blockArray[i, j].GetComponent<MoveBlocks>().isMatching = true;
                        create.blockArray[i, j + 1].GetComponent<MoveBlocks>().isMatching = true;
                        create.blockArray[i, j + 2].GetComponent<MoveBlocks>().isMatching = true;
                    }
                }
            }
        }

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width - 2; j++)
            {
                if (create.blockArray[j, i] != null && create.blockArray[j + 1, i] != null && create.blockArray[j + 2, i] != null)
                {
                    if (create.blockArray[j, i].tag == create.blockArray[j + 1, i].tag && create.blockArray[j, i].tag == create.blockArray[j + 2, i].tag)
                    {
                        create.blockArray[j, i].GetComponent<MoveBlocks>().isMatching = true;
                        create.blockArray[j + 1, i].GetComponent<MoveBlocks>().isMatching = true;
                        create.blockArray[j + 2, i].GetComponent<MoveBlocks>().isMatching = true;
                    }
                }
            }
        }

        foreach (var item in create.blockArray)
        {
            if (item != null)
            {
                if (item.GetComponent<MoveBlocks>().isMatching)
                {
                    deleteList.Add(item);
                }
            }
        }

        if (deleteList.Count > 0)
        {
            if (isMoved)
            {
                gameManager.currentScore = score.AddScore(gameManager.interval, gameManager.currentScore);
                score.ShowScore(gameManager.currentScore);
                gameManager.interval = 0;
                isMoved = false;
                Invoke("Delete", 0.3f);
            }
            else
            {
                Delete();
            }
        }
        else
        {
            isMoved = true;
            gameManager.MoveAgainBlocks();
        }
    }

    private void Delete()
    {
        foreach (var item in deleteList)
        {
            create.blockArray[(int)(item.transform.position.x / create.blockSize), (int)(item.transform.position.y / create.blockSize)] = null;
            Destroy(item);
            create.nextX = (int)(item.transform.position.x / create.blockSize);
            create.nextY = (int)(item.transform.position.y / create.blockSize);

            create.SpawnNewBlock();
        }

        deleteList.Clear();
        CheckMatching();
    }
}
