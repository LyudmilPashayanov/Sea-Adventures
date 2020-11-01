using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerEnemyMovement : BaseEnemyMovement
{
    public bool move;
    private Vector3 goToPosition;
    private void Update()
    {
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, goToPosition, m_MovementSpeed * Time.deltaTime);
            transform.LookAt(goToPosition);
            if(Vector3.Distance(transform.position, goToPosition) <= 2)
            {
                move = false;
            }
        }
    }
    public override void MoveTo(Vector3 position)
    {
        goToPosition = position;
        move = true;
    }

    public override void StopMoving()
    {
        move = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            other.gameObject.GetComponent<WallTrap>().DestroyTrap();
        }
    }

}
