using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public Vector3 directionVec;
    public float speed;

    bool returnPly;
    // Start is called before the first frame update
    void Start()
    {
        directionVec = -Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //기본 이동
        transform.Translate(directionVec.normalized * speed * Time.fixedDeltaTime);

        //z, xy 구분 이동
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            returnPly = false;
            Vector3 reflect = Vector3.Reflect(directionVec, collision.gameObject.transform.up).normalized;

            Vector3 standVec = Vector3.up;
            float dot = Vector3.Dot(reflect, standVec);
            Vector3 axisVec = Vector3.Cross(reflect, standVec);
            if (axisVec == Vector3.zero)
                axisVec = Vector3.right;
            if (dot > 0.9f)
            {
                Vector3 a = Quaternion.AngleAxis(-(20 - Mathf.Acos(dot)), axisVec) * reflect;
                Vector3 b = Quaternion.AngleAxis((20 - Mathf.Acos(dot)), axisVec) * reflect;
                reflect =(reflect-a).magnitude<(reflect-b).magnitude?a:b;

                directionVec = reflect;
                return;
            }

            standVec = Vector3.right;
            dot = Vector3.Dot(reflect, standVec);
            axisVec = Vector3.Cross(reflect, standVec);
            if (axisVec == Vector3.zero)
                axisVec = Vector3.up;
            if (dot > 0.9f)
            {
                Vector3 a = Quaternion.AngleAxis(-(20 - Mathf.Acos(dot)), axisVec) * reflect;
                Vector3 b = Quaternion.AngleAxis((20 - Mathf.Acos(dot)), axisVec) * reflect;
                reflect = (reflect - a).magnitude < (reflect - b).magnitude ? a : b;

                directionVec = reflect;
                return;
            }

            standVec = Vector3.forward;
            dot = Vector3.Dot(reflect, standVec);
            axisVec = Vector3.Cross(reflect, standVec);
            if (axisVec == Vector3.zero)
                axisVec = Vector3.up;
            if (dot > 0.9f)
            {
                Vector3 a = Quaternion.AngleAxis(-(20 - Mathf.Acos(dot)), axisVec) * reflect;
                Vector3 b = Quaternion.AngleAxis((20 - Mathf.Acos(dot)), axisVec) * reflect;
                reflect = (reflect - a).magnitude < (reflect - b).magnitude ? a : b;

                directionVec = reflect;
                return;
            }

            directionVec = reflect;
        }
    }
}
