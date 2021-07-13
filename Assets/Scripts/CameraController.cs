using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Misc.Input.BuildActions BuildInput => GM.Ins.InputManager.Build;

    public float speed = 10;
    private Vector2 orbit;
    public float rotSpeed = 20;

    private void Update(){
        var look = BuildInput.Look.ReadValue<Vector2>();
        orbit += look * (Time.deltaTime * rotSpeed);
        var rot = Quaternion.Euler(-orbit.y, orbit.x, 0);

        var move = BuildInput.Move.ReadValue<Vector2>();
        var fly = BuildInput.Fly.ReadValue<float>();
        var velocity = new Vector3(move.x, fly, move.y) * speed;
        velocity = transform.TransformVector(velocity);
        var pos = transform.position + velocity * Time.deltaTime;

        transform.SetPositionAndRotation(pos, rot);
    }
}