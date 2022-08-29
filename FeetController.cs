using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetController : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        this.Player = GameObject.Find("PinkMan");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.Player.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y, playerPos.z);
    }
}
