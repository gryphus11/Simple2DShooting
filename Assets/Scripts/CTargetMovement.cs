using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTargetMovement : CMoveBullet
{

    public Transform target = null;

    private Vector3 _originTargetPos = Vector3.zero;

    public void Init(Transform target)
    {
        if (target != null)
        {
            this.target = target;
            _originTargetPos = target.position;
            direction = _originTargetPos - transform.position;
        }
        else
        {
            //Destroy(gameObject);
            CObjectPool.current.PoolObject(gameObject);
        }
    }


    // Update is called once per frame
    protected override void Update()
    {

        if (target == null)
        {
            transform.Translate(direction.normalized * speed * Time.deltaTime);
            return;
        }

        direction = target.position - transform.position;

        float angle = Vector2.Angle(transform.up, direction.normalized);

        Vector3 cross = Vector3.Cross(transform.up, direction.normalized);

        if (cross.z < 0)
        {
            angle = 360 - angle;
        }

        transform.Rotate(0.0f, 0.0f, angle);

        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }
}
