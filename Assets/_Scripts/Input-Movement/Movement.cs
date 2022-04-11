using UnityEngine;

public class Movement : MonoBehaviour 
{
    // ToDo these ones are temporary
    [SerializeField] private float forwardSpeed = 5;
    [SerializeField] private float sidewaysSpeed = 4;

    // these ones are for touch control
    [SerializeField] private float smoothSpeed;
    private Vector3 newPosition;

    float zPosition;
    [SerializeField] bool isMoving;
    

    private void Start()
    {
        GameEvents.current.OnFightZoneTriggerEnter += stopMoving;
        GameEvents.current.OnFightZoneTriggerExit += startMoving;
        GameEvents.current.onStartGame += startMoving;
    }

    private void OnDestroy()
    {
        isMoving = false;
        GameEvents.current.OnFightZoneTriggerEnter -= stopMoving;
        GameEvents.current.OnFightZoneTriggerExit -= startMoving;
    }


    void FixedUpdate()
    {
        if (isMoving)
        {
            zPosition += Time.deltaTime * forwardSpeed;
            transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);
            
            if (Input.GetMouseButton(0)) {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit)) {
                    if (hit.point.x > LevelBoundary.leftSide && hit.point.x < LevelBoundary.rightSide) {
                        newPosition = new Vector3(hit.point.x, transform.position.y, zPosition);
                        transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed);
                    }
                }
            }

            // ToDo these ones are temporary
            if (Input.GetKey(KeyCode.A))
            {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * sidewaysSpeed);
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * sidewaysSpeed);
                }
            }
        }
    }

    void startMoving()
    {
        isMoving = true;
        AudioTree.Instance.playWalking();
    }

    void stopMoving()
    {
        isMoving = false;
        AudioTree.Instance.StopWalking();
    }
}
