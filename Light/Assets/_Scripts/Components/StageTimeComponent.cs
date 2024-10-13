using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class StageTimeComponent :CountdownComponent
{
    [SerializeField,LabelText("��������")] int pulseTimes;
    [SerializeField,LabelText("�ؿ�ʱ��")] float duration;

    protected override int PulseTimes => pulseTimes;

    protected override float Duration => duration;
}
