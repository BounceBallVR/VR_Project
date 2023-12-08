using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombNote : MonoBehaviour
{
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
            Vector3 pos = other.gameObject.transform.position;
            //ÀÌÆåÆ® »ý¼º
            GameObject effect;
            if(other.gameObject.layer == LayerMask.NameToLayer("BombNote"))
            {
                GameManager.instanse.Score++;
            }
            Destroy(other.gameObject);
        }
    }
}
