using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanvasController : MonoBehaviour
{
    public EnemyCanvasView m_view;

    public void NoSign()
    {
        m_view.NoSign();
    }

    public void FollowingMode()
    {
        m_view.FollowingMode();
    }

    public void AttackMode()
    {
        m_view.AttackingMode();
    }
}
