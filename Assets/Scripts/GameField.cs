using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Компонент игрового поля 2048, который отвечает за создание игровых клеток.
/// Фоновые ячейки остаются в backgroundContainer, а игровые клетки создаются в activeCellsContainer,
/// используя мировые координаты для точного размещения.
/// </summary>
public class GameField : MonoBehaviour
{
    [SerializeField] private CellView cellPrefab;
    [SerializeField] private Transform backgroundContainer;
    [SerializeField] private Transform activeCellsContainer;
    [SerializeField] private Vector2 cellSize;

    private List<CellPosition> allPositions = new List<CellPosition>();
    
    // Отдельное поле для генератора случайных чисел.
    private System.Random _random = new System.Random();

    private void Awake()
    {
        allPositions = backgroundContainer.GetComponentsInChildren<CellPosition>().ToList();
    }

    private void Start()
    {
        Canvas.ForceUpdateCanvases();
        CreateCell();
        CreateCell();
    }

    public void CreateCell()
    {
        List<CellPosition> freePositions = allPositions.FindAll(pos => !pos.IsOccupied);
        if (freePositions.Count == 0)
        {
            Debug.Log("Нет свободных позиций для создания клетки!");
            return;
        }
        
        // Используем отдельный генератор для выбора индекса
        int index = _random.Next(0, freePositions.Count);
        CellPosition chosenPos = freePositions[index];

        chosenPos.IsOccupied = true;

        int value = _random.NextDouble() < 0.9 ? 1 : 2;
        Cell cell = new Cell(value);

        CellView view = Instantiate(cellPrefab, activeCellsContainer);
        Vector3 worldPos = chosenPos.transform.position;
        view.Init(cell, worldPos, cellSize);

        Debug.Log($"Cell create at index={index}, value={value}, world_pos={worldPos}");
    }
}

