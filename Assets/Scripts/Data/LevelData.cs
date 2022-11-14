using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data", fileName = "Icons")]
public class LevelData : ScriptableObject
{
    [SerializeField] private Sprite _backgroundIcon;
    [SerializeField] private List<Sprite> _tileIcons;
    [SerializeField] private AudioClip _clip;
    
    public List<Sprite> TileIcons => _tileIcons;
    public Sprite BackgroundIcon => _backgroundIcon;
    public AudioClip Clip => _clip;
}
