using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlocks : MonoBehaviour
{
    Vector3 offsetUp = new Vector3(0, 0.65f);
    Vector3 offsetDown = new Vector3(0, -0.65f);
    Vector3 offsetRight = new Vector3(0.65f, 0);
    Vector3 offsetLeft = new Vector3(-0.65f, 0);

    public bool isMatching = false;

    private void OnMouseDown()
    {
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position + offsetUp, Vector2.up, 0.3f);
        if (!hitUp)
        {
            transform.position += new Vector3(0, 1.28f);
        }

        RaycastHit2D hitDown = Physics2D.Raycast(transform.position + offsetDown, Vector2.down, 0.3f);
        if (!hitDown)
        {
            transform.position += new Vector3(0, -1.28f);
        }

        RaycastHit2D hitRight = Physics2D.Raycast(transform.position + offsetRight, Vector2.right, 0.3f);
        if (!hitRight)
        {
            transform.position += new Vector3(1.28f, 0);
        }

        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position + offsetLeft, Vector2.left, 0.3f);
        if (!hitLeft)
        {
            transform.position += new Vector3(-1.28f, 0);
        }
    }
}
