using System.Collections.Generic;
using UnityEngine;

namespace LSW
{
    [CreateAssetMenu(menuName = "Data Containers/Body Part List", fileName = "Body Part List")]
    public class BodyPartList : ScriptableObject
    {
        [SerializeField]
        List<BodyPart> bodyPartList = new List<BodyPart>();

        public List<BodyPart> _BodyPartList { get => bodyPartList; }
    }
}