using System;
using code.scripts.tilemap.managers;
using code.scripts.tilemap.utilities;
using UnityEngine;

namespace code.scripts.tilemap {
    public class GridVisualiser : MonoBehaviour {
        [SerializeField, Range(0, 3)] private int range;
        
        private void Update() {
            Visualise.HexagonsInRange(GridManager.hovered_cell, range, Color.cyan);
            Visualise.Hexagon(GridManager.hovered_cell, Color.blue);
        }
    }
}