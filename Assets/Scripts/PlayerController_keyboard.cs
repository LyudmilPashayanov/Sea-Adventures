using UnityEngine;

public class PlayerController_keyboard : MonoBehaviour
{
    public float m_ForwardSpeed = 0.4f;
    public float m_BackwardsSpeed = 0.2f;
    public float m_RotationSpeed=1.5f;
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * m_ForwardSpeed, Space.Self);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * m_BackwardsSpeed, Space.Self);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * m_RotationSpeed, Space.Self);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * m_RotationSpeed, Space.Self);
        }
    }
}
