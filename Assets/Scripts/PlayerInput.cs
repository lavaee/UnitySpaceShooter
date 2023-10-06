using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] Joystick Inputjoystick;
    public Camera main;
    public ShipStats Stats;
    private float speed;
    bool Touch = true;

    void Start()
    {
        speed = Stats.MovementSpeed;

#if UNITY_EDITOR
        Touch = false;
#else
                Touch = true;
#endif
    }

    void Update()
    {
        Vector3 mousePosition = new Vector3();

        if (Touch)
        {
            if (Input.touchCount >= 1)
            {
                transform.position += new Vector3(Input.GetTouch(0).deltaPosition.x * Time.deltaTime * speed, Input.GetTouch(0).deltaPosition.y * Time.deltaTime * speed, 0);
            }
        }
        else
        {
            mousePosition = main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            transform.position = mousePosition;
        }
    }
}
