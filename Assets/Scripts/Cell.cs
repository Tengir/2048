using System;

/// <summary>
/// Логическая клетка для игры 2048.
/// Хранит значение клетки, где 1 соответствует числу 2, 2 – числу 4 и т.д.
/// </summary>
public class Cell
{
    /// <summary>
    /// Событие, вызываемое при изменении значения клетки.
    /// </summary>
    public event Action<int> OnValueChanged;

    private int value;

    /// <summary>
    /// Значение клетки (степень двойки).
    /// При изменении вызывается событие OnValueChanged.
    /// </summary>
    public int Value
    {
        get => value;
        set
        {
            if (this.value != value)
            {
                this.value = value;
                OnValueChanged?.Invoke(this.value);
            }
        }
    }

    /// <summary>
    /// Конструктор клетки.
    /// </summary>
    /// <param name="value">Начальное значение клетки (степень двойки).</param>
    public Cell(int value)
    {
        this.value = value;
    }
}