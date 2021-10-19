using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCapsule : ICommand
{
    Vector3 position;
    Color color;
    Transform capsule;

    public PlaceCapsule(Vector3 position, Color color, Transform capsule)
    {
        this.position = position;
        this.color = color;
        this.capsule = capsule;
    }

    public void Execute()
    {
        CubePlacer.PlaceCube(position, color, capsule);
    }

    public void Undo()
    {
        CubePlacer.RemoveCube(position, color);
    }
}


