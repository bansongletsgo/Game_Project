using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    static public CameraMove instance;
    public GameObject target; // 카메라 고정 대상
    public float moveSpeed; // 카메라 이동 속도
    private Vector3 targetPosition; // 대상의 현재 위치
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null){
           DontDestroyOnLoad(this.gameObject);
           instance = this; 
        }
        else{
            Destroy(this.gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target.gameObject != null){
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
