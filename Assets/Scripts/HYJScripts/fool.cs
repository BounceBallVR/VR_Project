using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fool : MonoBehaviour
{
    public int GameDamage; // 게임 데미지
    public Text damage; // 데미지를 표시할 UI Text
    public GameObject targetPrefab; // 타겟 프리팹
    private GameObject[] targetInstance; // 생성된 타겟 인스턴스
    public target tr; // target 스크립트를 가진 오브젝트에 대한 참조
    private bool BallTrue;
   

    void Start()
    {
        
        BallTrue = true;
        targetInstance = new GameObject[9];
        damage.text = GameDamage.ToString(); // 초기 데미지 값을 UI에 표시

        // Start 메서드에서 이벤트 등록
       
        
    }

    void Update()
    {
        if (BallTrue) 
        { 
            int result = Random.Range(0, 9);
            Debug.Log(result);
            switch (result)
            {
                case 0:
                    targetInstance[0] = Instantiate(targetPrefab, new Vector3(3f, -3f, 1f), Quaternion.identity);
                    BallTrue = false;
                    break;
                case 1:
                    targetInstance[1] = Instantiate(targetPrefab, new Vector3(0f, -3f, 1f), Quaternion.identity);
                    BallTrue = false;
                    break;
                case 2:
                    targetInstance[2] = Instantiate(targetPrefab, new Vector3(-3f, -3f, 1f), Quaternion.identity);
                    BallTrue = false;
                    break;
                case 3:
                    targetInstance[3] = Instantiate(targetPrefab, new Vector3(3f, 0f, 1f), Quaternion.identity);
                    BallTrue = false;
                    break;
                case 4:
                    targetInstance[4] = Instantiate(targetPrefab, new Vector3(0f, 0f, 1f), Quaternion.identity);
                    BallTrue = false;
                    break;
                case 5:
                    targetInstance[5] = Instantiate(targetPrefab, new Vector3(-3f, 0f, 1f), Quaternion.identity);
                    BallTrue = false;
                    break;
                case 6:
                    targetInstance[6] = Instantiate(targetPrefab, new Vector3(3f, 3f, 1f), Quaternion.identity);
                    BallTrue = false;
                    break;
                case 7:
                    targetInstance[7] = Instantiate(targetPrefab, new Vector3(0f, 3f, 1f), Quaternion.identity);
                    BallTrue = false;
                    break;
                case 8:
                    targetInstance[8] = Instantiate(targetPrefab, new Vector3(-3f, 3f, 1f), Quaternion.identity);
                    BallTrue = false;
                    break;
            }
            tr = targetInstance[result].GetComponent<target>();
            tr.onTriggerEnterEvent += success; // 타겟 스크립트의 이벤트에 success 메서드를 등록
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            GameDamage += 10; // 충돌한 오브젝트가 "ball" 태그를 가진 경우 데미지를 10 증가
            damage.text = GameDamage.ToString(); // UI에 증가된 데미지 값을 표시
        }
    }

    // 이벤트 핸들러: 타겟 스크립트의 트리거 발동 시 호출됨
    public void success()
    {
        Debug.Log("이벤트 발동");
        GameDamage += 50; // 트리거 발동 시 데미지를 50 증가
        damage.text = GameDamage.ToString(); // UI에 증가된 데미지 값을 표시
        StartCoroutine(GmaeStop());
    }
    IEnumerator GmaeStop()
    { 
        yield return new WaitForSeconds(5.0f);
        BallTrue = true;
    }
}
