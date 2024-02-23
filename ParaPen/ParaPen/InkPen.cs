using ParaPen.EventArgs;
using ParaPen.Models.Interfaces;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using static ParaPen.MyInkCanvasMethods;

namespace ParaPen;

public class InkPen : IInkPen
{
    public event EventHandler<PositionEventArgs> PenPositionChanged;
    public event EventHandler OnDispose;


    private Point curCords = new(0, 0);
    public Point CurCords
    {
        get => curCords;
        set
        {
            if (curCords != value)
            {
                PenPositionChanged?.Invoke(this, new PositionEventArgs(curCords, value));
                curCords = value;
            }
        }
    }

    public DrawingAttributes DrawingAttributes { get; init; }

    private readonly InkCanvas _inkCanvas;


    public InkPen(InkCanvas inkCanvas, DrawingAttributes drawingAttributes, IUserViewMover userViewMover)
    {
        _inkCanvas = inkCanvas;
        DrawingAttributes = drawingAttributes;

        userViewMover.UserViewOffsetChanged += MovePen;
    }

    // note : возможно, стоит использовать другие методы для реализации "удаления" объекта
    public void Dispose()
    {
        OnDispose?.Invoke(this, System.EventArgs.Empty);
        //throw new NotImplementedException();
    }


    public void DrawLine(Vector relativeOffset)
    {
        Point toPoint = CurCords + relativeOffset;

        Stroke line = GetStrokeLine(CurCords, toPoint, DrawingAttributes);
        CurCords = toPoint;
        _inkCanvas.Strokes.Add(line);
    }

    /// <summary>
    /// Изменяет местоположение `InkPen` на поле при `UserViewOffsetChanged`
    /// </summary>
    private void MovePen(object? sender, OffsetEventArgs e)
    {
        CurCords += e.Offset;
    }
}
