using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using static System.Single;
using Random = UnityEngine.Random;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private LevelData _levelData;
    [SerializeField] private Tile _tileTemplate;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private TileInventory _tileInventory;
    [SerializeField] private PlayerInput _playerInput;

    private void Start()
    {
        Create();
    }

    private void Create()
    {
        Transform tileLayer = null;
        string path = Application.dataPath + "/Levels/" + _levelData.TilePositionsPath + ".txt";
        var reader = new StreamReader(path);
        
        int tilesCount = int.Parse(reader.ReadLine() ?? throw new InvalidOperationException());
        var iconsOnTileCount = GetIconsOnTileCount(tilesCount, _levelData.TileIcons.Count);
        var iconsOnTiles = new List<IconsOnTile>();

        for (int i = 0; i < _levelData.TileIcons.Count; i++)
        {
            var tileIcon = new TileIcon(_levelData.TileIcons[i], (byte)i);
            var iconsOnTile = new IconsOnTile(tileIcon, iconsOnTileCount[i]);
            iconsOnTiles.Add(iconsOnTile);
        }
        
        while (reader.ReadLine() is { } line)
        {
            string[] positions = line.Split(" ");

            if (positions[0] == "l")
            {
                tileLayer = Instantiate(new GameObject(), _canvas.transform).transform;
                tileLayer.name = $"Layer {positions[1]}";
            }
            else
            {
                var tile = Instantiate(_tileTemplate, tileLayer);
                
                var tilePosition = new Vector3(Parse(positions[0]), Parse(positions[1]), 0f);
                tile.transform.position = tilePosition;

                int index = Random.Range(0, iconsOnTiles.Count);
                tile.Init(_playerInput, _tileInventory, iconsOnTiles[index].TileIcon);
                iconsOnTiles[index].DecreaseLeftTiles();
                
                if (iconsOnTiles[index].LeftTiles == 0)
                    iconsOnTiles.RemoveAt(index);
            }
        }
    }
    
    private List<int> GetIconsOnTileCount(int tilesCount, int spritesCount)
    {
        var result = new List<int>();
        
        int filledSpritesCount = 0;
        int currentCount = tilesCount / spritesCount;

        while (filledSpritesCount != spritesCount)
        {
            if (currentCount % 3 == 0)
            {
                result.Add(currentCount);
                filledSpritesCount++;
                tilesCount -= currentCount;
                        
                if (tilesCount != 0)
                    currentCount = tilesCount / (spritesCount - filledSpritesCount);
            }
            else
            {
                currentCount++;
            }
        }

        return result;
    }

    private struct IconsOnTile
    {
        public TileIcon TileIcon { get; }
        public int LeftTiles { get; private set; }

        public IconsOnTile(TileIcon tileIcon, int leftTiles)
        {
            TileIcon = tileIcon;
            LeftTiles = leftTiles;
        }

        public void DecreaseLeftTiles() => LeftTiles--;
    }
}
