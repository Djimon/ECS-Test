using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(ExtrudeMeshfromPolygon2D))]
public class ExtrudeMeshfromPolygon2DEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ExtrudeMeshfromPolygon2D myScript = (ExtrudeMeshfromPolygon2D)target;
        if (GUILayout.Button("Generate Mesh"))
        {
            myScript.GenerateMesh();
        }
    }
}
