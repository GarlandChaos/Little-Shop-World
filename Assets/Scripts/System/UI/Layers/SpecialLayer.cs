using UnityEngine;

namespace LSW.UI
{
    public class SpecialLayer : ALayer<ISpecialController>
    {
        public override void SaySize()
        {
#if UNITY_EDITOR
            Debug.Log("Panel layer size is: " + screens.Count);
#endif
            base.SaySize();
        }
    }
}