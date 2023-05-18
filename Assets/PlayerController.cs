using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(5, 30)] [SerializeField] private float speed = 10f;
    [SerializeField] private GrabTrigger grabTrigger;

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GrabBox();
        }
    }

    private bool isGrabbed;

    private void GrabBox()
    {
        if (isGrabbed)
        {
            StopGrabBox();
            isGrabbed = false;
        }
        else
        {
            StartGrabBox();
            isGrabbed = true;
        }
    }

    private void StartGrabBox()
    {
        if (grabTrigger.CanGrab)
        {
            grabTrigger.Box.transform.parent = this.gameObject.transform;
        }

        grabTrigger.Box.GetComponent<BoxBlockVisualiser>().SetBlockState(true);
    }

    private void StopGrabBox()
    {
        grabTrigger.Box.transform.parent = null;
        grabTrigger.Box.GetComponent<BoxBlockVisualiser>().SetBlockState(false);
    }

    private void Move()
    {
        Vector3 direction = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            direction.z = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction.z = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
        }

        direction = direction.normalized;

        transform.position += direction * (speed * Time.deltaTime);

        transform.LookAt(transform.position + new Vector3(-direction.z, 0, direction.x));
    }
}