using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolvingController : MonoBehaviour
{
    public MeshRenderer ObjectMesh;                           //������ Cube�� ����ϰ� �־ ��� 
    public SkinnedMeshRenderer SkinnedMeshRenderer;     //ĳ���� or Ŀ���� ������Ʈ ����Ҷ�

    public float dissolveRate = 0.0125f;
    public float refreshRate = 0.025f;

    public Material[] ObjectMeshs;                      //�������� Material �� ��� �ϴ� ��� 

    // Start is called before the first frame update
    void Start()
    {
        if(ObjectMesh != null)
        {
            ObjectMeshs = ObjectMesh.materials;             //������ �ִ� ���׸��� ����Ʈ�� �ִ´�. 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            StartCoroutine(CoDissolve());
        }
        
    }

    IEnumerator CoDissolve()
    {
        if(ObjectMeshs.Length > 0)
        {
            float counter = 0;

            while (ObjectMeshs[0].GetFloat("_DissolveAmount") < 1)
            {
                counter += dissolveRate;
                for(int i = 0; i < ObjectMeshs.Length; i++)
                {
                    ObjectMeshs[i].SetFloat("_DissolveAmount", counter);
                }

                yield return new WaitForSeconds(refreshRate);
            }
        }
    }
}
