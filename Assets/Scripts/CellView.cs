using UnityEngine;
using UnityEngine.UI;
using System;

/// <summary>
/// Визуальное представление клетки 2048. Использует мировые координаты для позиционирования.
/// </summary>
public class CellView : MonoBehaviour
{
    [SerializeField] private Text valueText;

    private Cell cell;

    /// <summary>
    /// Инициализирует клетку, устанавливая мировую позицию и размер.
    /// </summary>
    /// <param name="cell">Логическая клетка.</param>
    /// <param name="worldPosition">Мировая позиция, полученная от фоновой ячейки.</param>
    /// <param name="cellSize">Размер клетки.</param>
    public void Init(Cell cell, Vector3 worldPosition, Vector2 cellSize)
    {
        this.cell = cell;
        RectTransform rect = GetComponent<RectTransform>();
        rect.position = worldPosition;

        UpdateValue(cell.Value);
        cell.OnValueChanged += UpdateValue;
    }


    private void UpdateValue(int newValue)
    {
        double displayedNumber = Math.Pow(2, newValue);
        valueText.text = displayedNumber.ToString();
    }
}