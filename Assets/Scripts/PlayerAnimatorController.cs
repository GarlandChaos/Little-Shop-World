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
    DirectionIndicator directionIndicator = null;

    void Update()
    {
        if(PauseManager.instance != null)
        {
            if (!PauseManager.instance._Paused)
                CheckConditions();
        }
    }

    void CheckConditions()
    {
        bool horizontalKeyPressed = (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow));
        bool verticalKeyPressed = (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow));

        bool horizontalKeyReleased = (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow));
        bool verticalKeyReleased = (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow));

        bool horizontalKeyHeldDown = (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow));
        bool verticalKeyHeldDown = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow));

        if (!horizontalKeyHeldDown && !verticalKeyHeldDown)
            animatorPlayer.SetTrigger(hashStop);
        else if (directionIndicator._CurrentDirection == Direction.Left || directionIndicator._CurrentDirection == Direction.Right)
            animatorPlayer.SetTrigger(hashWalkLeftRight);
        else if (directionIndicator._CurrentDirection == Direction.Up || directionIndicator._CurrentDirection == Direction.Down)
            animatorPlayer.SetTrigger(hashWalkUpDown);
    }
}