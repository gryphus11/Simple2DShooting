using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDirectionMove : MonoBehaviour
{

    public float speed = 0.0f;
    public Vector2 direction = Vector2.zero;
    protected float _originalSpeed = 0.0f;

    // Use this for initialization
    void Start()
    {
        _originalSpeed = speed;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    public void Stop()
    {
        speed = 0.0f;
    }

    public void Resume()
    {
        speed = _originalSpeed;
    }
}
