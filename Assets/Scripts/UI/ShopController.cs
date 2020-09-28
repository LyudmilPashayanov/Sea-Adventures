using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public ShopView m_view;

    public void SetShopOff()
    {
        m_view.SetActiveShop(false);
    }

    public void SetShopActive()
    {
        m_view.SetActiveShop(true);
    }
}
