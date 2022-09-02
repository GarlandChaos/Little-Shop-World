using UnityEngine;

namespace LSW.UI
{
    public class SpecialLayer : ALayer<ISpecialController>
    {
        public override void SaySize()
        {
            Debug.Log("Panel layer size is: " + screens.Count);
            base.SaySize();
        }
    }
}
