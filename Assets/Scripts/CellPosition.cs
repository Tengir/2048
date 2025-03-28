using UnityEngine;

/// <summary>
/// Компонент, назначаемый на пустую ячейку фона.
/// Хранит координаты в сетке и флаг, указывающий, занята ли данная ячейка.
/// </summary>
public class CellPosition : MonoBehaviour
{
    [SerializeField]
    private int gridX;
    [SerializeField]
    private int gridY;

    /// <summary>
    /// Координата по X в сетке (от 0 до fieldSize-1).
    /// </summary>
    public int GridX { get => gridX; set => gridX = value; }

    /// <summary>
    /// Координата по Y в сетке (от 0 до fieldSize-1).
    /// </summary>
    public int GridY { get => gridY; set => gridY = value; }

    /// <summary>
    /// Флаг, показывающий, занята ли эта ячейка.
    /// </summary>
    public bool IsOccupied { get; set; }

    /// <summary>
    /// Возвращает локальную позицию ячейки (anchoredPosition) из RectTransform.
    /// </summary>
    /// <returns>Локальная позиция в пикселях.</returns>
    public Vector2 GetLocalPosition()
    {
        RectTransform rect = GetComponent<RectTransform>();
        return rect.anchoredPosition;
    }
}