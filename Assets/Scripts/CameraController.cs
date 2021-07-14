using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 10;
    private Vector2 orbit;
    public float rotSpeed = 20;

    private float fly = 0;
    private Vector3 mouse = Vector3.zero;

    void Start(){
        mouse = Input.mousePosition;
    }
    private void Update(){
        var move = new Vector2();
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

        var look = Input.mousePosition - mouse;
        orbit += (Vector2)look * (rotSpeed);
        var rot = Quaternion.Euler(-orbit.y, orbit.x, 0);

        if (Input.GetKey(KeyCode.E))
        {
            fly = 1;
        }else if(Input.GetKey(KeyCode.Q))
        {
            fly = -1;
        }
        else
        {
            fly = 0;
        }
        var velocity = new Vector3(move.x, fly, move.y) * speed;
        velocity = transform.TransformVector(velocity);
        var pos = transform.position + velocity * Time.deltaTime;

        transform.SetPositionAndRotation(pos, rot);

        mouse = Input.mousePosition;
    }
}