using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;

public class LevelFormSaver : MonoBehaviour
{
    private const string Folder = "/Levels/";
    private const string Extension = ".txt";
    
    [SerializeField] private string _fileName;
    [SerializeField] private TileLayer[] _layers;
    
    [ContextMenu("SaveLevel")]
    public void SaveLevel()
    {
        string path = Application.dataPath + Folder + _fileName + Extension;
        var writer = new StreamWriter(path);

        for (int i = 0; i < _layers.Length; i++)
        {
            writer.WriteLine($"l {i + 1}");
            var layer = _layers[i];

            foreach (var tile in layer.GetComponentsInChildren<Tile>())
            {
                var position = tile.transform.position;
                writer.WriteLine($"{position.x} {position.y}");
            }
        }

        writer.Close();
    }
}
