using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public Vector3 directionVec;
    public float speed;
    public float minSpeed;

    public float subject=1;

    public bool bounce;
    // Start is called before the first frame update
    void Start()
    {
        bounce = false;
        minSpeed = speed;
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

        ////유저에게 날라갈때
        //RaycastHit rayHit;
        //Ray ray = new Ray(transform.position, directionVec);
        //if (Physics.Raycast(ray, out rayHit, LayerMask.GetMask("Wall")) && !bounce)
        //{
        //    if (rayHit.collider.gameObject == GameManager.instanse.back)
        //    {
        //        bounce = true;
        //        Vector3 hitObjPos = rayHit.collider.gameObject.transform.position;
        //        Vector3 point = hitObjPos;
        //        point.x = hitObjPos.x - ((hitObjPos.x - rayHit.point.x) / subject);
        //        point.y = hitObjPos.y - ((hitObjPos.y - rayHit.point.y) / subject);
        //        directionVec = (point - transform.position).normalized;
        //    }
        //}
    }
}
