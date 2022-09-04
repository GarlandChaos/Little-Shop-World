using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BodyType
{
    Torso,
    ArmRight,
    ArmLeft,
    LegRight,
    LegLeft,
    FootRight,
    FootLeft,
    HandRight,
    HandLeft,
    Head
}

[CreateAssetMenu(menuName = "Game Data/Body Part", fileName = "Body Part")]
public class BodyPart : ScriptableObject
{
    [SerializeField]
    BodyType bodyType = BodyType.Torso;
    [SerializeField]
    Sprite spriteUp = null;
    [SerializeField]
    Sprite spriteDown = null;
    [SerializeField]
    Sprite spriteLeft = null;
    [SerializeField]
    Sprite spriteRight = null;
    [SerializeField]
    bool flippedSprite = false;

    public BodyType _BodyType { get => bodyType; }
    public Sprite _SpriteUp { get => spriteUp; }
    public Sprite _SpriteDown { get => spriteDown; }
    public Sprite _SpriteLeft { get => spriteLeft; }
    public Sprite _SpriteRight { get => spriteRight; }
    public bool _FlippedSprite { get => flippedSprite; }
}