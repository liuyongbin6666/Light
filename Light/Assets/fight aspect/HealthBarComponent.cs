using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class HealthBarComponent : MonoBehaviour
{
    public float content;//����������Ҳ������Ѫ��
    public float Maxcontent;
    public Image hp_Main;
    public float hurtSpeed = 0.005f;
    public float healSpeed = 0.006f;
    public float hurt_duration = 2f;
    public float heal_duration = 2f;
    [SerializeField, LabelText("��ǰ���������")] SliderType st;
    public void Init(float hp)
    {
        Maxcontent = hp;
        content = Maxcontent;
    }
    public virtual void GetHit(float t)//
    {
        content = content - t;
    }
    public virtual void GetHeal(float t)
    {
        content = content + t;
    }
    public void UpdateContent()
    {
        CheckContent();
        hp_Main.fillAmount = content / Maxcontent;
    }
    void CheckContent()
    {
        if (content < 0)
        {
            content = 0;
        }
        if(content>Maxcontent)
        {
            content = Maxcontent;
        }
    }
    public void GetHealSlowly(float s=0.006f/*sΪÿ��ֵΪhealSpeed��ʱ�����ӵ�Ѫ��*/)//������Ѫ
    {
        StartCoroutine(Healing(s));
    }
    public virtual IEnumerator Healing(float s)
    {
        float startTime = Time.time;
        while (Time.time < heal_duration)
        {
            content += s;
            UpdateContent();
            yield return new WaitForSeconds(healSpeed);
        }
    }
    public void GetPoison(float s= 0.005f/*sΪÿ��ֵΪhurtSpeed��ʱ����ٵ�Ѫ��*/)//������Ѫ���ж�
    {
        StartCoroutine(Poisoning(s));
    }
    public virtual IEnumerator Poisoning(float s)
    {
        float startTime = Time.time;
        while(Time.time<hurt_duration)
        {
            content -= s;
            UpdateContent();
            yield return new WaitForSeconds(hurtSpeed);
        }
    }
}
enum SliderType
{
    [SerializeField,LabelText("Ѫ��")]hp,
    [SerializeField, LabelText("����")] mana
}