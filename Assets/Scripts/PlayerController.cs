using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float turnSpeed = 1;

    private bool swordActiveFrames = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = new Vector3(0f, (Input.GetAxis("Turning") * turnSpeed * Time.deltaTime), 0f);
        transform.Rotate(rotation);

        if(swordActiveFrames)
            Debug.Log("Hitframes!");
    }

    void Hit(int activation)
    {
        if (activation == 1)
            swordActiveFrames = true;
        else
            swordActiveFrames = false;
    }
}
