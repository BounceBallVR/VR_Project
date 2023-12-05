using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fool : MonoBehaviour
{
    public int GameDamage; // ���� ������
    public Text damage; // �������� ǥ���� UI Text
    public GameObject targetPrefab; // Ÿ�� ������
    private GameObject[] targetInstance; // ������ Ÿ�� �ν��Ͻ�
    public target tr; // target ��ũ��Ʈ�� ���� ������Ʈ�� ���� ����
    private bool BallTrue;
   

    void Start()
    {
        
        BallTrue = true;
        targetInstance = new GameObject[9];
        damage.text = GameDamage.ToString(); // �ʱ� ������ ���� UI�� ǥ��

        // Start �޼��忡�� �̺�Ʈ ���
       
        
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
            tr.onTriggerEnterEvent += success; // Ÿ�� ��ũ��Ʈ�� �̺�Ʈ�� success �޼��带 ���
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            GameDamage += 10; // �浹�� ������Ʈ�� "ball" �±׸� ���� ��� �������� 10 ����
            damage.text = GameDamage.ToString(); // UI�� ������ ������ ���� ǥ��
        }
    }

    // �̺�Ʈ �ڵ鷯: Ÿ�� ��ũ��Ʈ�� Ʈ���� �ߵ� �� ȣ���
    public void success()
    {
        Debug.Log("�̺�Ʈ �ߵ�");
        GameDamage += 50; // Ʈ���� �ߵ� �� �������� 50 ����
        damage.text = GameDamage.ToString(); // UI�� ������ ������ ���� ǥ��
        StartCoroutine(GmaeStop());
    }
    IEnumerator GmaeStop()
    { 
        yield return new WaitForSeconds(5.0f);
        BallTrue = true;
    }
}
