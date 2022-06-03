using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    [SerializeField]
    private float trainSpeed;

    [SerializeField]
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.z > 220)
        {
            transform.Translate(0, -trainSpeed * Time.deltaTime, 0);
        }
    }
}
