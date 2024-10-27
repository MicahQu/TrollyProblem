using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public TrainMoveScript logic;
   
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Train").GetComponent<TrainMoveScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void flippinglever(){
        Debug.Log("Button clicked!");
        logic.FlipLever();
    }
}
