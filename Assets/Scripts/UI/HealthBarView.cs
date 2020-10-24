using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{
    public Slider m_HpSlider;
    public bool followCamera;
    private void LateUpdate()
    {
        if(followCamera)
            m_HpSlider.transform.LookAt(transform.position + Camera.main.transform.forward);
    }

    public void ReduceHp(int amount)
    {
        m_HpSlider.value -= amount;
    }
}
