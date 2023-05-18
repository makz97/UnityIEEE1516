using UnityEngine;

public class GrabTrigger : MonoBehaviour
{
    public bool CanGrab { get; private set; }
    public GameObject Box { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Box")
        {
            CanGrab = true;
            Box = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Box")
        {
            CanGrab = true;
            Box = null;
        }
    }
}