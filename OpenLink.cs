using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OpenLink : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed primary button.");
            Application.OpenURL("https://www.irishcentral.com/roots/history/how-the-irish-changed-the-traffic-laws-in-tipperary-hill-syracuse");
        }
    }
}
