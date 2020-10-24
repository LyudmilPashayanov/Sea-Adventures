using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerEnemyEyes : BaseEnemyEyes
{
    RaycastHit hit;
    public float m_RangeOfView = 10;
    public ViewType m_ViewType = ViewType.allAround;

    private void Start()
    {
        SetPairOfEyes(m_RangeOfView, m_ViewType);
    }

    public override bool CheckForPlayer()
    {
        Transform player = PlayerController_mobileJoystick.Instance.transform;
        if (Vector3.Distance(transform.position, player.position) < RangeOfView)
        {
            // check if there is a wall infornt of the player
            Debug.DrawLine(transform.position, player.position, Color.yellow);
            if (TargetInView(player))
            {
                return true;
            }
        }
        else
        {
            Debug.DrawLine(transform.position, player.position, Color.red);
        }
        return false;
    }

    public override bool TargetInView(Transform target)
    {
        return true;
    }
}
