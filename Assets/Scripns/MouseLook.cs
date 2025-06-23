using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    
    [SerializeField, Tooltip("Скорость вращения по горизонтальной плоскости")]
    private float sensitivityHor = 9.0f;
    [SerializeField, Tooltip("Скорость вращения по вертикальной плоскости")]
    private float sensitivityVert = 9.0f;

    [SerializeField, Tooltip("Угол поворота по вертикали минимум")]
    private float minimumVert = -45.0f;
    [SerializeField, Tooltip("Угол поворота по вертикали Максимум")]
    private float maximumVert = 45.0f;
    
    private float verticalRot = 0;


    void Start()
    {
        
    }

      void Update()
    {
        if(axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY)
        {
            verticalRot -= Input.GetAxis("Mouse Y") * sensitivityVert;
            verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

            float horizontalRot = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
        else
        {

        }
    }
}
