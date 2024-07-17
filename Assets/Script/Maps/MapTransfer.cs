using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapTransfer : MonoBehaviour
{
    public string transferMapName; //이동할 맵의 이름
    public Transform target;
    private CharacterMove thePlayer;
    private CameraMove theCamera;
    // Start is called before the first frame update
    void Start()
    {
        theCamera = FindObjectOfType<CameraMove>();
        thePlayer = FindObjectOfType<CharacterMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player"){
            thePlayer.currentMapName = transferMapName;
            //SceneManager.LoadScene(transferMapName);
            theCamera.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, theCamera.transform.position.z);
            thePlayer.transform.position = target.transform.position;
        }
    }
}
