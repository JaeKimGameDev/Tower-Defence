using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float scrollSpeed = 5f;
    public float minYHeight= 10f;
    public float maxYHeight = 70f;
    public float maxXValue, maxZValue;
    public float minXValue, minZValue;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            if (transform.position.z <= maxZValue)
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            }
        }
        if (Input.GetKey("s"))
        {
            if (transform.position.z >= minZValue)
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            }                
        }
        if (Input.GetKey("d"))
        {
            if (transform.position.x <= maxXValue)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            }                
        }
        if (Input.GetKey("a"))
        {
            if (transform.position.x >= minXValue)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            }            
        }
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 500 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minYHeight, maxYHeight);

        transform.position = pos;
    }
}