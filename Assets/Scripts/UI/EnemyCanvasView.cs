using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCanvasView : MonoBehaviour
{
    public RectTransform m_WarningSign;
    public Sprite m_FollowingImage;
    public Sprite m_AttackingImage;

    public void NoSign()
    {
        m_WarningSign.gameObject.SetActive(false);
    }

    public void FollowingMode()
    {
        m_WarningSign.gameObject.SetActive(true);
        m_WarningSign.GetComponent<Image>().sprite = m_FollowingImage;
    }

    public void AttackingMode()
    {
        m_WarningSign.gameObject.SetActive(true);
        m_WarningSign.GetComponent<Image>().sprite = m_AttackingImage;
    }
}
