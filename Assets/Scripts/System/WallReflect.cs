using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallReflect : MonoBehaviour
{
    public enum Vertical
    {
        Up,
        Forward,
        Right
    }
    public Vertical direction;
    Vector3 vertical;
    // Start is called before the first frame update
    void Start()
    {
        switch (direction)
        {
            case Vertical.Up:
                vertical = Vector3.up;
                break;
            case Vertical.Forward:
                vertical = Vector3.forward;
                break;
            case Vertical.Right:
                vertical = Vector3.right;
                break;
            default:
                vertical= Vector3.up;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            BallBounce ball = collision.gameObject.GetComponent<BallBounce>();
            if (gameObject== GameManager.instanse.front)
            {
                ball.speed = ball.minSpeed;
                ball.GetComponent<MeshRenderer>().material.color = Color.white;
            }
            if (gameObject == GameManager.instanse.back)
            {
                ball.bounce = false;
            }
            GameManager.instanse.bounceManager.R_Tounch = false;
            GameManager.instanse.bounceManager.L_Tounch = false;
            Vector3 reflect = Vector3.Reflect(ball.directionVec, vertical).normalized;
            //직선 움직임 회피
            Vector3 limitVector(Vector3 standard)
            {
                Vector3 result = Vector3.zero;
                Vector3 standVec = standard;
                float dot = Vector3.Dot(reflect, standVec);
                Vector3 axisVec = Vector3.Cross(reflect, standVec);
                if (dot > 0.9f || dot < -0.9f)
                {
                    Vector3 a = Quaternion.AngleAxis(-(20 - Mathf.Acos(dot)), axisVec) * reflect;
                    Vector3 b = Quaternion.AngleAxis((20 - Mathf.Acos(dot)), axisVec) * reflect;
                    reflect = (reflect - a).magnitude < (reflect - b).magnitude ? a : b;

                    result = reflect;
                }
                return result;
            }

            Vector3 upCom = limitVector(Vector3.up);
            Vector3 rightCom = limitVector(Vector3.right);
            Vector3 forwardCom = limitVector(Vector3.forward);
            if (upCom != Vector3.zero)
            {
                reflect = upCom;
            }
            else if (forwardCom != Vector3.zero)
            {
                reflect = forwardCom;
            }
            else if (rightCom != Vector3.zero)
            {
                reflect = rightCom;
            }
            ball.directionVec = reflect;
        }
    }
}
