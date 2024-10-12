using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class JoyStick : MonoBehaviour
{
    public float mRadius = 0f;
    public RectTransform joyStick;
    public RectTransform handle;
    public Vector3 mousePosition,dragPosition;
    //playerͨ����ȡdir��ֵ���ƶ�
    public Vector3 dir;

    public bool IsDrag;
    public Vector3 pos;
    private void Awake()
    {
        
    }
    protected void Start()
    {
        joyStick = transform.GetChild(0).GetComponent<RectTransform>();
        handle = transform.GetChild(0).GetChild(0).GetComponent<RectTransform>();
        mRadius = (joyStick.transform as RectTransform).sizeDelta.x * 0.45f;
    }
    public void Update()
    {
        //���
        if (Input.GetMouseButtonDown(0))
        {
            
            mousePosition = Input.mousePosition;
            joyStick.transform.position = mousePosition;
            joyStick.gameObject.SetActive(true);
            IsDrag = true;
            return;
        }
        //̧��
        if (Input.GetMouseButtonUp(0))
        {
            IsDrag = false;
            handle.localPosition = Vector3.zero;
            dir = Vector3.zero;
            joyStick.gameObject.SetActive(false);
        }
        //��ק
        if (Input.GetMouseButton(0))
        {
            if(IsDrag)
            {
                dragPosition = Input.mousePosition;
                pos = dragPosition - mousePosition;
                if(pos.magnitude>mRadius)
                {
                    pos = pos.normalized*mRadius;
                    
                }
                handle.localPosition = pos;
                dir = pos.normalized;
            }
        }
    }

}
