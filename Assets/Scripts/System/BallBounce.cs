using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public Vector3 directionVec;
    public float speed;
    public float Minspeed;

    public float subject=1;

    bool bounce;
    // Start is called before the first frame update
    void Start()
    {
        bounce = false;
        Minspeed = speed;
        directionVec = -Vector3.forward;
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
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            bounce = true;
            if (collision.gameObject.GetInstanceID()==GameManager.instanse.front.GetInstanceID())
            {
                speed = Minspeed;
            }
            GameManager.instanse.bounceManager.R_Tounch = false;
            GameManager.instanse.bounceManager.L_Tounch = false;
            GetComponent<MeshRenderer>().material.color = Color.white;
            Vector3 reflect = Vector3.Reflect(directionVec, collision.gameObject.transform.up).normalized;

            //직선 움직임 회피
            Vector3 limitVector(Vector3 standard)
            {
                Vector3 result = Vector3.zero;
                Vector3 standVec = standard;
                float dot = Vector3.Dot(reflect, standVec);
                Vector3 axisVec = Vector3.Cross(reflect, standVec);
                if (dot > 0.9f || dot<-0.9f)
                {
                    Vector3 a = Quaternion.AngleAxis(-(20 - Mathf.Acos(dot)), axisVec) * reflect;
                    Vector3 b = Quaternion.AngleAxis((20 - Mathf.Acos(dot)), axisVec) * reflect;
                    reflect = (reflect - a).magnitude < (reflect - b).magnitude ? a : b;

                    result = reflect;
                }
                return result;
            }

            Vector3 upCom       = limitVector(Vector3.up);
            Vector3 rightCom    = limitVector(Vector3.right);
            Vector3 forwardCom  = limitVector(Vector3.forward);
            if (upCom != Vector3.zero)
            {
                reflect = upCom;
            } else if (forwardCom != Vector3.zero)
            {
                reflect = forwardCom;
            } else if (rightCom != Vector3.zero)
            {
                reflect = rightCom;
            }
            //유저에게 날라갈때
            RaycastHit rayHit;
            Ray ray = new Ray();
            ray = new Ray(transform.position, reflect);

            if (Physics.Raycast(ray, out rayHit, LayerMask.GetMask("Wall")))
            {
                if (rayHit.collider.gameObject.GetInstanceID() == GameManager.instanse.back.GetInstanceID())
                {
                    Vector3 hitObjPos = rayHit.collider.gameObject.transform.position;
                    Vector3 point = hitObjPos;
                    point.x = hitObjPos.x - ((hitObjPos.x - rayHit.point.x) / subject);
                    point.y = hitObjPos.y - ((hitObjPos.y - rayHit.point.y) / subject);
                    reflect = (point - transform.position).normalized;

                    GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
            directionVec = reflect;
        }
    }
}
