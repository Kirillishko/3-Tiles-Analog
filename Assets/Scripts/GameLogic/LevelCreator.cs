using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private LevelData _levelData;
    [SerializeField] private TileInventory _tileInventory;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Tile _tileTemplate;

    private void Create()
    {
        string line;
        string path = Application.dataPath + "/Levels/" + _levelData.TilePositionsPath + ".exe";
        var reader = new StreamReader(path);
        
        while ((line = reader.ReadLine()) != null)
        {
            string[] positions = line.Split(" ");

            if (positions[0] == "l")
            {

            }
        }
    }
}
