using UnityEngine;
using UnityEngine.Events;

namespace Components
{
    /// <summary>
    /// 自动发射在视野内的组件，用于在视野内发射光线等效果。
    /// </summary>
    public class VisionActiveComponent : MonoBehaviour
    {
        [SerializeField] SpriteRenderer renderer;
        public readonly UnityEvent OnActiveEvent = new();
        // 用于设置材质中布尔值的方法
        public void SetActive(bool value)
        {
            MaterialEmit(value);
            OnActiveEvent.Invoke();
        }
        public void MaterialEmit(bool value)
        {
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();
            renderer.GetPropertyBlock(mpb);
            mpb.SetFloat("_IsEmit", value ? 1.0f : 0.0f);
            renderer.SetPropertyBlock(mpb);
        }
    }
}