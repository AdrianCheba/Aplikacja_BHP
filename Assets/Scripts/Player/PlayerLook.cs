using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0;

    public float xSensitivity = 20f;
    public float ySensitivity = 15f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate((mouseX * Time.deltaTime) * xSensitivity * Vector3.up);
    }
}
