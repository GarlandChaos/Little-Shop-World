using UnityEngine;

namespace LSW.Gameplay
{
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
            if (PauseManager.instance != null)
            {
                if (!PauseManager.instance._Paused)
                    CheckConditions();
            }
        }

        void CheckConditions()
        {
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
}