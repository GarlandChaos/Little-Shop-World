using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSW.Events;

public enum Direction
{
    Up,
    Down,
    Right,
    Left
}

public class DirectionIndicator : MonoBehaviour
{
    
    Direction currentDirection = Direction.Down;
	Direction lastDirection = Direction.Down;
	[SerializeField]
	GameEvent eventDirectionChanged = null;

	public Direction _CurrentDirection { get => currentDirection; }
	public Direction _LastDirection { get => lastDirection; }

    private void Update()
    {
		if(PauseManager.instance != null)
        {
			if (!PauseManager.instance._Paused)
				CheckForDirectionChange();
		}
    }

    void CheckForDirectionChange()
	{
		float x = Input.GetAxis("Horizontal");
		float y = Input.GetAxis("Vertical");

		if (x != 0)
		{
			if (x < 0) //left
				ChangeDirection(Direction.Left);
			else if (x > 0) //right
				ChangeDirection(Direction.Right);
		}
		else
		{
			if (y < 0) //down
				ChangeDirection(Direction.Down);
			else if (y > 0) //up
				ChangeDirection(Direction.Up);
		}
	}

	void ChangeDirection(Direction direction)
	{
		if (currentDirection != direction)
		{
			lastDirection = currentDirection;
			currentDirection = direction;
			eventDirectionChanged.Raise();
		}
	}
}