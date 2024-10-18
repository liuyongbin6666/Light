using System;
using System.Collections;
using System.Collections.Generic;
using GMVC.Core;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class PlotComponentBase : MonoInitializer
{

    public PlotManager PlotManager => Game.PlotManager;
    [LabelText("故事")]public StorySo story;
    [LabelText("情节"),ValueDropdown(nameof(GetPlots)),OnValueChanged(nameof(ChangeName))]public string plotName;
    IEnumerable<string> GetPlots() => story?.GetPlotNames() ?? new []{ "请设置剧情" };
    void ChangeName() => name = "情节_" + plotName;
    public override void Initialization()
    {
        PlotManager.RegComponent(this);
        if (story.IsAutoBegin(plotName))
        {
            if (!gameObject.activeSelf) throw new InvalidOperationException($"{name}:自动开启情节必须保证控件是活跃状态！");
            StartCoroutine(BeginRoutine());

            IEnumerator BeginRoutine()
            {
                yield return new WaitForSeconds(0.1f);
                Begin();
            }
        }
    }
    /// <summary>
    /// 开始情节，初始化并扩展控件逻辑
    /// </summary>
    public abstract void Begin();
    /// <summary>
    /// 结束情节，并触发下一个情节
    /// </summary>
    public void Finalization() => PlotManager.TriggerNext(this);
}