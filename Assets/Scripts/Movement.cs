using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 5;
    [SerializeField] private float sidewaysSpeed = 4;

    float zPosition;
    bool isMoving;

    private void Start()
    {
        isMoving = true;
        GameEvents.current.OnFightZoneTriggerEnter += stopMoving;
        GameEvents.current.OnFightZoneTriggerExit += startMoving;
    }

    private void OnDestroy()
    {
        isMoving = false;
        GameEvents.current.OnFightZoneTriggerEnter -= stopMoving;
        GameEvents.current.OnFightZoneTriggerExit -= startMoving;
    }


    void FixedUpdate()
    {

        // . . left = 1, right = 2, forward = 0
        // going left means 1, going right means 2, going forward is 0.

        zPosition += Time.deltaTime * forwardSpeed;
        if (isMoving)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);
            if (Input.touchCount > 0)
            {
                var touch = Input.GetTouch(0);
                if (touch.position.x < Screen.width / 2)
                {
                    if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                    {

                        transform.Translate(Vector3.left * Time.deltaTime * sidewaysSpeed);

                    }
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                    {

                        transform.Translate(Vector3.right * Time.deltaTime * sidewaysSpeed);
                    }
                }
                else
                {

                }
            }

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

    void stopMoving()
    {
        isMoving = false;
    }

    void startMoving()
    {
        isMoving = true;
    }
}
