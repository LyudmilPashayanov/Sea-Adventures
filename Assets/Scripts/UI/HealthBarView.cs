using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarView : MonoBehaviour
{
    public Slider m_HpSlider;

    private void LateUpdate()
    {
        m_HpSlider.transform.LookAt(transform.position + Camera.main.transform.forward);
    }
    public void ReduceHp(int amount)
    {
        m_HpSlider.value -= amount;
    }
}
