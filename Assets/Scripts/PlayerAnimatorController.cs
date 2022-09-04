using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField]
    Animator animatorPlayer = null;
    static int hashStop = Animator.StringToHash("Stop");
    static int hashWalkUpDown = Animator.StringToHash("WalkUpDown");
    static int hashWalkLeftRight = Animator.StringToHash("WalkLeftRight");
    [SerializeField]
    BodyPartsModifier bodyPartsModifier = null;

    void Update()
    {
        bool horizontalKeyPressed = (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow));
        bool verticalKeyPressed = (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow));

        bool horizontalKeyReleased = (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow));
        bool verticalKeyReleased = (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow));

        bool horizontalKeyHeldDown = (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow));
        bool verticalKeyHeldDown = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow));

        if (!horizontalKeyHeldDown && !verticalKeyHeldDown)
        {
            animatorPlayer.SetTrigger(hashStop);
            Debug.Log("Triggered Stop");
        }
        else if (bodyPartsModifier.currentDirection == Direction.Left || bodyPartsModifier.currentDirection == Direction.Right)
        {
            animatorPlayer.SetTrigger(hashWalkLeftRight);
            Debug.Log("Triggered WalkLeftRight");
        }
        else if (bodyPartsModifier.currentDirection == Direction.Up || bodyPartsModifier.currentDirection == Direction.Down)
        {
            animatorPlayer.SetTrigger(hashWalkUpDown);
            Debug.Log("Triggered WalkUpDown");
        }
    }
}