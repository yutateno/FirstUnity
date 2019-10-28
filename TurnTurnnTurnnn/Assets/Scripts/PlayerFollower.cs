using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{

    public GameObject player;       // プレイヤー
    Vector3 offset;     // カメラとプレイヤーとの差
    Vector3 cameraArea;

    // Start is called before the first frame update
    void Start()
    {
        offset.x = this.transform.position.x;
        offset.y = this.transform.position.y - player.transform.position.y;
        offset.z = this.transform.position.z - player.transform.position.z;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        cameraArea.x = offset.x;
        cameraArea.y = player.transform.position.y + offset.y;
        cameraArea.z = player.transform.position.z + offset.z;
        this.transform.position = cameraArea;
    }
}
