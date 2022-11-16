using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileInventory : MonoBehaviour
{
    [SerializeField] private RectTransform[] _tilesPositions;
    private const int CountEqualTiles = 3;

    private int _currentTileCount = 0;

    [SerializeField] private List<Tile> _tiles = new();


    public void AddTile(Tile tile) => _tiles.Add(tile);

    public bool TryGetFreePosition(Tile otherTile, out Vector3 position)
    {
        position = Vector3.zero;
        
        if (_tiles.Count >= _tilesPositions.Length)
            return false;

        bool isFound = false;
        int otherTileIndex = 0;
        
        for (int i = 0; i < _tiles.Count; i++)
        {
            if (isFound == false)
            {
                if (_tiles[i].Equals(otherTile) == false)
                    continue;
                
                if (_tiles[i + 1].Equals(otherTile) == false)
                {
                    position = _tilesPositions[i + 1].position;
                    otherTileIndex = i;
                }
                else
                {
                    position = _tilesPositions[i + 2].position;
                    otherTileIndex = i;
                    i++;
                }
                
                isFound = true;
            }
            else
            {
                _tiles[i].Move(_tilesPositions[i + 1].position, false);
            }
        }

        if (isFound)
        {
            _tiles.Insert(otherTileIndex, otherTile);
            return true;
        }

        position = _tilesPositions[_tiles.Count].position;
        _tiles.Add(otherTile);
        return true;
    }

    public void TryFindEqualTiles()
    {
        _currentTileCount++;
        
        foreach (var tile in _tiles)
        {
            int count = 0;
            var tiles = new Tile[3];
            
            foreach (var otherTile in _tiles)
                if (otherTile.Equals(tile))
                {
                    tiles[count] = otherTile;
                    count++;
                }

            if (count == CountEqualTiles)
            {
                DestroyEqualTiles(tiles);
                break;
            }
        }
    }

    private void DestroyEqualTiles(IEnumerable<Tile> tiles)
    {
        foreach (var tile in tiles)
        {
            _currentTileCount--;
            
            tile.Destroy();
            _tiles.Remove(tile);
        }
    }
}
