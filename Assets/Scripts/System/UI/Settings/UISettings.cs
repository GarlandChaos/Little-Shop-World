using System.Collections.Generic;
using UnityEngine;

namespace LSW.UI 
{
    [CreateAssetMenu(menuName = "Settings/UI Settings", fileName = "UI Settings")]
    public class UISettings : ScriptableObject
    {
        public List<GameObject> screensPrefabs =  new List<GameObject>();
    }
}
