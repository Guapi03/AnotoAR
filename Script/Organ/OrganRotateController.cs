using UnityEngine;

public class OrganRotateController : MonoBehaviour
{
    public float rotateSpeed = 0.3f;

    private Transform currentOrgan;

    void Update()
    {
        if (!OrganFocusManager.Instance.IsFocused())
            return;

        currentOrgan =
            OrganFocusManager.Instance.GetCurrentTransform();

        if (currentOrgan == null)
            return;

#if UNITY_EDITOR

        if (Input.GetMouseButton(0))
        {
            float deltaX =
                Input.GetAxis("Mouse X");

            float deltaY =
                Input.GetAxis("Mouse Y");

            currentOrgan.Rotate(
                Camera.main.transform.up,
                -deltaX * rotateSpeed * 100f,
                Space.World);

            currentOrgan.Rotate(
                Camera.main.transform.right,
                deltaY * rotateSpeed * 100f,
                Space.World);
        }

#else

        if (Input.touchCount == 1)
        {
            Touch touch =
                Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float deltaX =
                    touch.deltaPosition.x;

                float deltaY =
                    touch.deltaPosition.y;

                currentOrgan.Rotate(
                    Camera.main.transform.up,
                    -deltaX * rotateSpeed,
                    Space.World);

                currentOrgan.Rotate(
                    Camera.main.transform.right,
                    deltaY * rotateSpeed,
                    Space.World);
            }
        }

#endif
    }
}