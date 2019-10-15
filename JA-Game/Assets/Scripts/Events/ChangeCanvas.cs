using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCanvas : MonoBehaviour {
    public GameObject canvas1, canvas2;
	
	// Update is called once per frame
    public void swapCanvas()
    {
        if (canvas1.activeSelf)
        {
            canvas1.SetActive(false);
            canvas2.SetActive(true);
        }
        else if (canvas2.activeSelf)
        {
            canvas1.SetActive(true);
            canvas2.SetActive(false);
        }
    }
}
