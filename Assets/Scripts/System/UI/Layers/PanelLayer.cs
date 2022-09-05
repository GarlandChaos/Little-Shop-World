using UnityEngine;

namespace LSW.UI
{
    public class PanelLayer : ALayer<IPanelController>
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
