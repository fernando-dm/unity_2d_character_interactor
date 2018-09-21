using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    private Vector3 offset;
    public float smoothing = 5f;

    public Transform target;

    // Use this for initialization
    private void Start()
    {
        offset = transform.position - target.position;
    }
    //private void Update()
    //{
    //    FixedUpdate();
    //}

    // Update is called once per frame
    private void FixedUpdate()
    {
        var targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}