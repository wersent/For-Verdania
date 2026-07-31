using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Assets.Scripts.Features.GridSystem
{
    public interface IUiCoordinateConverter
    {
        Vector2 ToAnchoredPosition(Vector2 logicalPos);
    }

    public class CoordinateConverter : IUiCoordinateConverter
    {
        private readonly GridLayoutGroup _gridLG;

        public CoordinateConverter(GridLayoutGroup gridLG)
        {
            _gridLG = gridLG;
        }

        public Vector2 ToAnchoredPosition(Vector2 logicalPos)
        {
            if (_gridLG == null) return Vector2.zero;

            float cellWidth = _gridLG.cellSize.x;
            float cellHeight = _gridLG.cellSize.y;
            float spacingX = _gridLG.spacing.x;
            float spacingY = _gridLG.spacing.y;

            // математика расчета от верхнего левого угла (Top-Left)
            float pixelX = (logicalPos.x * (cellWidth + spacingX)) + (cellWidth / 2f);
            float pixelY = -(logicalPos.y * (cellHeight + spacingY)) - (cellHeight / 2f);

            pixelX += _gridLG.padding.left;
            pixelY -= _gridLG.padding.top;

            return new Vector2(pixelX, pixelY);
        }
    }
}
