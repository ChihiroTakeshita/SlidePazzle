using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocks : MonoBehaviour
{
    Vector3 offsetUp = new Vector3(0, 0.65f);
    Vector3 offsetDown = new Vector3(0, -0.65f);
    Vector3 offsetRight = new Vector3(0.65f, 0);
    Vector3 offsetLeft = new Vector3(-0.65f, 0);

    GameObject blockCreator;
    SetGame create;
    DeleteBlocks deleteBlocks;
    GameObject manager;
    GameManager gameManager;
    AudioSource audioSource;
    [SerializeField] AudioClip clip;

    public bool isMatching = false;

    public bool cantMove = false;

    public int[] coodinate;

    private void Start()
    {
        blockCreator = GameObject.Find("BlockCreator");
        manager = GameObject.Find("GameManager");
        gameManager = manager.GetComponent<GameManager>();
        create = blockCreator.GetComponent<SetGame>();
        deleteBlocks = GetComponent<DeleteBlocks>();
        audioSource = GetComponent<AudioSource>();

        coodinate = new int[] {(int)(transform.position.x / create.blockSize), (int)(transform.position.y / create.blockSize)};
    }

    private void OnMouseDown()
    {
        if (!cantMove)
        {
            gameManager.interval += 1;

            RaycastHit2D hitUp = Physics2D.Raycast(transform.position + offsetUp, Vector2.up, 0.3f);
            if (!hitUp)
            {
                var x = (int)(transform.position.x / create.blockSize);
                var y = (int)(transform.position.y / create.blockSize);
                create.blockArray[x, y + 1] = this.gameObject;
                create.blockArray[x, y] = null;
                coodinate[0] = x;
                coodinate[1] = y + 1;
                transform.position += new Vector3(0, 1.28f);
                audioSource.PlayOneShot(clip);
            }

            RaycastHit2D hitDown = Physics2D.Raycast(transform.position + offsetDown, Vector2.down, 0.3f);
            if (!hitDown)
            {
                var x = (int)(transform.position.x / create.blockSize);
                var y = (int)(transform.position.y / create.blockSize);
                create.blockArray[x, y - 1] = this.gameObject;
                create.blockArray[x, y] = null;
                coodinate[0] = x;
                coodinate[1] = y - 1;
                transform.position += new Vector3(0, -1.28f);
                audioSource.PlayOneShot(clip);
            }

            RaycastHit2D hitRight = Physics2D.Raycast(transform.position + offsetRight, Vector2.right, 0.3f);
            if (!hitRight)
            {
                var x = (int)(transform.position.x / create.blockSize);
                var y = (int)(transform.position.y / create.blockSize);
                create.blockArray[x + 1, y] = this.gameObject;
                create.blockArray[x, y] = null;
                coodinate[0] = x + 1;
                coodinate[1] = y;
                transform.position += new Vector3(1.28f, 0);
                audioSource.PlayOneShot(clip);
            }

            RaycastHit2D hitLeft = Physics2D.Raycast(transform.position + offsetLeft, Vector2.left, 0.3f);
            if (!hitLeft)
            {
                var x = (int)(transform.position.x / create.blockSize);
                var y = (int)(transform.position.y / create.blockSize);
                create.blockArray[x - 1, y] = this.gameObject;
                create.blockArray[x, y] = null;
                coodinate[0] = x - 1;
                coodinate[1] = y;
                transform.position += new Vector3(-1.28f, 0);
                audioSource.PlayOneShot(clip);
            }

            deleteBlocks.CheckMatching();
        }
    }
}
