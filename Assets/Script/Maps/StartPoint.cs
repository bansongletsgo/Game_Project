using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint; // 맵 이동후 시작 위치
    private CharacterMove thePlayer;
    private CameraMove theCamera;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindObjectOfType<CharacterMove>();
        theCamera = FindObjectOfType<CameraMove>();
        if(startPoint == thePlayer.currentMapName){
            theCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = this.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
