using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public event Action onTriggerEnterEvent;
    public GameObject A;
    // Start is called before the first frame update
    void Start()
    {
        A.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ball"))
        {
            Debug.Log("트리거 발동");
            A.SetActive(false);
            onTriggerEnterEvent?.Invoke();
        }
    }
}
