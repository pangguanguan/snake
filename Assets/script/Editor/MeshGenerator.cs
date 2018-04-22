﻿using UnityEngine;
using UnityEditor;

public class MeshGenerator {

    [MenuItem("Utility/MeshGenerator/Ground")]
    static void GenerateGround()
    {
        var mesh = new Mesh();

        mesh.vertices = new Vector3[]
        {
            new Vector3(-0.5f, 0, 0.5f),
            new Vector3(0.5f, 0, 0.5f),
            new Vector3(0.5f, 0, -0.5f),
            new Vector3(-0.5f, 0, -0.5f)
        };

        mesh.uv = new Vector2[]
        {
            new Vector2(0, 1),
            new Vector2(1, 1),
            new Vector2(1, 0),
            new Vector2(0, 0)
        };

        mesh.triangles = new int[] { 0, 1, 2, 0, 2, 3 };

        var path = EditorUtility.SaveFilePanelInProject(
            "Save Mesh in Assets",
            "GroundMesh.asset",
            "asset",
            "Please enter a file name to save the Mesh to ");

        if (path != "")
        {
            AssetDatabase.CreateAsset(mesh, path);
            AssetDatabase.SaveAssets();
        }
    }

    [MenuItem("Utility/MeshGenerator/Snake")]
    static void GenerateSnake()
    {
        var verts = new Vector3[]
        {
            new Vector3(-2, 0, 2),
            new Vector3(2, 0, 2),
            new Vector3(2, 0, -2),
            new Vector3(-2, 0, -2),
            new Vector3(-1, 1, 1),
            new Vector3(1, 1, 1),
            new Vector3(1, 1, -1),
            new Vector3(-1, 1, -1),
            new Vector3(-1, -1, 1),
            new Vector3(1, -1, 1),
            new Vector3(1, -1, -1),
            new Vector3(-1, -1, -1)
        };

        var vertTris = new int[]
        {
            0, 1, 4, 4, 1, 5,
            1, 2, 5, 5, 2, 6,
            2, 3, 6, 6, 3, 7,
            3, 0, 7, 7, 0, 4,
            4, 5, 7, 7, 5, 6,
            3, 2, 11, 11, 2, 10,
            2, 1, 10, 10, 1, 9,
            1, 0, 9, 9, 0, 8,
            0, 3, 8, 8, 3, 11,
            11, 10, 8, 8, 10, 9
        };

        var uvs = new Vector2[]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(1, 1),
            new Vector2(0, 1)
        };

        var uvTris = new int[]
        {
            0, 1, 3, 3, 1, 2,
            0, 1, 3, 3, 1, 2,
            0, 1, 3, 3, 1, 2,
            0, 1, 3, 3, 1, 2,
            0, 1, 3, 3, 1, 2,
            0, 1, 3, 3, 1, 2,
            0, 1, 3, 3, 1, 2,
            0, 1, 3, 3, 1, 2,
            0, 1, 3, 3, 1, 2,
            0, 1, 3, 3, 1, 2
        };

        int num = vertTris.Length;

        var meshVerts = new Vector3[num];
        var meshUvs = new Vector2[num];
        var meshTris = new int[num];

        for (int i = 0; i < num; i++)
        {
            meshVerts[i] = verts[vertTris[i]];
            meshUvs[i] = uvs[uvTris[i]];
            meshTris[i] = i;
        }

        var mesh = new Mesh();

        mesh.vertices = meshVerts;
        mesh.uv = meshUvs;
        mesh.triangles = meshTris;

        var path = EditorUtility.SaveFilePanelInProject(
            "Save Mesh in Assets",
            "SnakeMesh.asset",
            "asset",
            "Please enter a file name to save the Mesh to ");

        if (path != "")
        {
            AssetDatabase.CreateAsset(mesh, path);
            AssetDatabase.SaveAssets();
        }
    }
}
