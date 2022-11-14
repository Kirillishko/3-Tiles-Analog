using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileInventory : MonoBehaviour
{
    [SerializeField] private RectTransform[] _positions;
    private const int CountEqualTiles = 3;

    private int _currentTileCount = 0;

    private List<Tile> _tiles = new();

    public Vector3 GetNextPosition => _positions[_currentTileCount].position;

    public void AddTile(Tile tile) => _tiles.Add(tile);

    public void TryFindEqualTiles()
    {
        Debug.Log("TryFindEqualTiles");
        
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
