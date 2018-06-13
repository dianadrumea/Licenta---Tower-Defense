using UnityEngine;

public class CameraController : MonoBehaviour {

    public float panBorderThickness = 10f;
    public float panSpeed = 5f;
    public float scrollSpeed = 3f;
    public float rotationSpeed = 3f;

    public float minY = 1f;
    public float maxY = 15f;

    public float minRot = 21f;
    public float maxRot = 79f;

    private bool doMove = true;

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            doMove = !doMove;

        if (!doMove)
            return;

        /* Because camera has a -90 degree rotation:
            -If d is pressed or if the mouse position is in the right side of the screen, it will move forward
            -If a is pressed or if the mouse position is in the left side of the screen, it will move backwards
            -If s is pressed or if the mouse position is in the lower side of the screen, it will move right
            -If w is pressed or if the mouse position is in the upper side of the screen, it will move left   
         */
        if (Input.GetKey("d")) //|| Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a")) //|| Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s")) //|| Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("w")) //|| Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= scroll * 100 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;

        float eulerAngX = transform.eulerAngles.x;
        eulerAngX -= scroll * rotationSpeed * 1000 * Time.deltaTime;
        eulerAngX = Mathf.Clamp(eulerAngX, minRot, maxRot);
        transform.rotation = Quaternion.Euler(eulerAngX, -90, 0);
    }
}
