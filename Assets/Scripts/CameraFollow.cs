using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private float trialDistance;
    private Vector3 offSet;
    private float cameraDelay;

    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        offSet = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        
        //Vector3 followPosition = target.position - transform.position;
        //followPosition.y += offSet;
        //transform.position += (followPosition - transform.position) * cameraDelay;
        //transform.LookAt(followPosition);
        //followPosition.y += offSet;

        //transform.position += (followPosition - transform.position) * cameraDelay;

        //transform.LookAt(target.position);
    }

    private void LateUpdate()
    {
        if (!isDead)
        {
            Vector3 newPosition = target.transform.position + offSet;
            newPosition.y = 10.0f;
            newPosition.x = 0;
            transform.position = newPosition;

            //isDead = false;

        }
        //else
        //{
        //    onDeath();
        //}
       
    }

    public void onDeath()
    {
        isDead = true;
    }
}
