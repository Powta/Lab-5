using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlane : MonoBehaviour
{
    Camera maincam;
    RaycastHit hitInfo;
    public Transform cubePrefab;
    public Transform capsulePreFab;
    public bool isCube;

    // Start is called before the first frame update
    private void Awake()
    {
        maincam = Camera.main;
        isCube = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = maincam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity))
            {
                Color c = new Color(Random.Range(0.5f, 1f), Random.Range(0.5f, 1f), Random.Range(0.5f, 1f));
                //CubePlacer.PlaceCube(hitInfo.point, c, cubePrefab);

                if(isCube)
                {
                    ICommand command = new PlaceCubeCommand(hitInfo.point, c, cubePrefab);
                    CommandInvoker.AddCopmmand(command);
                }

                else
                {
                    ICommand command = new PlaceCapsule(hitInfo.point, c, capsulePreFab);
                    CommandInvoker.AddCopmmand(command);
                }
            }
        }
        
    }

    public void TurnToCube()
    {
        isCube = true;
    }
    public void TurnToCapsule()
    {
        isCube = false;
    }
}
