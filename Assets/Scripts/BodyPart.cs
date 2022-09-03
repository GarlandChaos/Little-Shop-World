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
    FootLeft
}

[CreateAssetMenu(menuName = "Game Data/Body Part", fileName = "Body Part")]
public class BodyPart : ScriptableObject
{
    [SerializeField]
    BodyType bodyType = BodyType.Torso;
    [SerializeField]
    Sprite sprite = null;
    [SerializeField]
    bool flippedSprite = false;

    public BodyType _BodyType { get => bodyType; }
    public Sprite _Sprite { get => sprite; }
    public bool _FlippedSprite { get => flippedSprite; }
}