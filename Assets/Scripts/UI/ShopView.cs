using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopView : MonoBehaviour
{
    public RectTransform m_ShopMenu;

    public void SetActiveShop(bool active)
    {
        m_ShopMenu.gameObject.SetActive(active);
    }
}
