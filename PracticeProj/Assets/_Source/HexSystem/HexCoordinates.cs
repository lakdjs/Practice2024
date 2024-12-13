using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCoordinates : MonoBehaviour
{
    private const float XOffset = 0;
    private const float YOffset = 0;
    private const float ZOffset = 0;
    public Vector3Int GetHexCoords()
            => offsetCoordinates;

    [Header("Offset coordinates")]
    [SerializeField] private Vector3Int offsetCoordinates;

    private void Awake()
    {
       SetCoords();
    }

    public void SetCoords()
    {
        offsetCoordinates = ConvertPositionToOffset(transform.position);
        //            Debug.Log(offsetCoordinates);
    }
    public static Vector3Int ConvertPositionToOffset(Vector3 position)
    {
        int x = Mathf.CeilToInt(position.x / XOffset);
        int y = Mathf.RoundToInt(position.y / YOffset);
        int z = Mathf.RoundToInt(position.z / ZOffset);
        return new Vector3Int(x, y, z);
    }
}
