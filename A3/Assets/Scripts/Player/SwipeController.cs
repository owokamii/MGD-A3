using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public PlayerController playerController;
    private Vector3 startPos, endPos;
    private bool isSwipping;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isSwipping = true;
            startPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0) && isSwipping)
        {
            isSwipping = false;
            endPos = Input.mousePosition;
            DetectDirection();
        }
    }

    void DetectDirection()
    {
        float swipeDistanceX = Mathf.Abs(endPos.x - startPos.x);
        float swipeDistanceY = Mathf.Abs(endPos.y - startPos.y);

        if(!playerController.isJumping)
        {
            if (swipeDistanceX > swipeDistanceY)
            {
                if (startPos.x > endPos.x)
                {
                    playerController.MoveLeft();
                    FindObjectOfType<AudioManager>().PlaySFX("Move");
                }
                else
                {
                    playerController.MoveRight();
                    FindObjectOfType<AudioManager>().PlaySFX("Move");
                }
            }
            else
            {
                if (startPos.y < endPos.y)
                {
                    playerController.Jump();
                    FindObjectOfType<AudioManager>().PlaySFX("Jump");
                }
            }
        }
        else
        {
            if (startPos.y > endPos.y)
            {
                playerController.Land();
                FindObjectOfType<AudioManager>().PlaySFX("Move");
            }
        }

        startPos = endPos = Vector3.zero;
    }
}