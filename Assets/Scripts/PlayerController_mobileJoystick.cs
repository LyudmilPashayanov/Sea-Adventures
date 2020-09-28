using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_mobileJoystick : MonoBehaviour
{

    public float m_ForwardSpeed = 10f;
    public RectTransform m_Circle;
    public RectTransform m_OuterCircle;
    public Vector3 m_InitialPosition;
    public Vector3 m_MovementDirection;
    public Vector2 m_circlePos;
    public bool m_StartMovement;
    public Transform m_ship;
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            m_InitialPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            m_Circle.transform.position = Input.mousePosition;
            m_OuterCircle.transform.position = Input.mousePosition;
            m_circlePos = Input.mousePosition;
            m_Circle.gameObject.SetActive(true);
            m_OuterCircle.gameObject.SetActive(true);
        }
        if (Input.GetMouseButton(0))
        {
            m_StartMovement = true;
            m_MovementDirection = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            Debug.Log("m_MovementDirection: " + m_MovementDirection);
        }
        else
        {
            m_StartMovement = false;
        }
    }

    private void FixedUpdate()
    {
        if (m_StartMovement)
        {
            Vector3 offset = m_InitialPosition - m_MovementDirection;
            Vector3 direction = Vector3.ClampMagnitude(offset, 1.0f);
            Move(direction);
            m_Circle.transform.position = new Vector2(m_circlePos.x + direction.x*150, m_circlePos.y + direction.y*150);
        }
        else
        {
            m_Circle.gameObject.SetActive(false);
            m_OuterCircle.gameObject.SetActive(false);
        }

    }
    void Move(Vector3 direction)
    {
        Vector3 movement = new Vector3(direction.x, 0, direction.y );
        m_ship.localRotation = Quaternion.LookRotation(movement * Time.deltaTime);
        transform.Translate(movement * m_ForwardSpeed* Time.deltaTime);
    }
}
