using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombNote : MonoBehaviour
{
    public GameObject RedBomb;
    public GameObject BlueBomb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Transform bombPos = other.gameObject.transform;
            float ballSpeed = other.gameObject.GetComponent<BallBounce>().speed;

            if (other.gameObject.layer == LayerMask.NameToLayer("BombNote"))
            {
               
                //ÀÌÆåÆ® »ý¼º
                var hitInstance = Instantiate(BlueBomb, bombPos.position, Quaternion.identity);
                hitInstance.transform.LookAt(GameManager.instanse.cameraManager.Oculus_Camera.transform.position);

                //Destroy hit effects depending on particle Duration time
                var hitPs = hitInstance.GetComponent<ParticleSystem>();
                if (hitPs != null)
                {
                    Destroy(hitInstance, hitPs.main.duration);
                }
                else
                {
                    var hitPsParts = hitInstance.transform.GetChild(0).GetComponent<ParticleSystem>();
                    Destroy(hitInstance, hitPsParts.main.duration);
                }
                
                if (ballSpeed / 5f<=30)
                {
                    GameManager.instanse.Score+=ballSpeed/5f;
                }
                else
                {
                    GameManager.instanse.Score+=30;
                }
            }
            Destroy(other.gameObject);
        }
    }
}
