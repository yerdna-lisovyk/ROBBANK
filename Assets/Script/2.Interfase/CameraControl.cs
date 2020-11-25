
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Vector2 startPos;
    [SerializeField] private Camera cam;
    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            startPos = cam.ScreenToWorldPoint(Input.mousePosition);
        else if(Input.GetMouseButton(0))
            {
            float pos = cam.ScreenToWorldPoint(Input.mousePosition).x-startPos.x;
            transform.position = new Vector3(transform.position.x - pos, transform.position.y, transform.position.z);
        }

    }

}
