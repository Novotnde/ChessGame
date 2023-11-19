
using Chess.Custom;
using Chess.ViewModel;

namespace Chess;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new ChessBoardViewModel();
    }

    private Point startPosition;

    private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {
        var label = (Label)sender;
        
        switch (e.StatusType)
        {
            case GestureStatus.Started:
                // Capture the start position of the drag
                Console.WriteLine(e.TotalX);
                Console.WriteLine(e.TotalY);

                if (label.Parent is ChessSquareGrid chessSquareGrid)
                {
                    Console.WriteLine(chessSquareGrid.ID);
                    Console.WriteLine(chessSquareGrid.SquareName);
                }

                startPosition = new Point(label.TranslationX, label.TranslationY);
                break;

            case GestureStatus.Running:
                // Update label translation for the drag
                label.TranslationX = e.TotalX;
                label.TranslationY = e.TotalY;
                break;

            case GestureStatus.Completed:
                // Use the start position for calculating the grid position
                MoveLabelToNewPosition(label, label.TranslationX, label.TranslationY, startPosition);
                break;
        }
    }

    private void MoveLabelToNewPosition(Label label, double x, double y, Point startPosition)
    {
        var currentParent = (Grid)label.Parent;
        currentParent.Children.Remove(label);

        var (newRow, newColumn) = CalculateGridPosition(x, y, startPosition);

        string cellName = $"cell{newRow}{newColumn}"; 

        var cell = this.FindByName<Grid>(cellName);
        if (cell == null)
        {
            return;
        }

        cell.Children.Add(label);

        label.TranslationX = 0;
        label.TranslationY = 0;
    }

    private (int row, int column) CalculateGridPosition(double translationX, double translationY, Point startPosition)
    {
        int cellSize = 100; 

        double adjustedTranslationX = translationX + startPosition.X;
        double adjustedTranslationY = translationY + startPosition.Y;

        int newRow = (int)Math.Floor(adjustedTranslationY / cellSize);
        int newColumn = (int)Math.Floor(adjustedTranslationX / cellSize);

        newRow = Math.Max(0, Math.Min(newRow, mainGrid.RowDefinitions.Count - 1));
        newColumn = Math.Max(0, Math.Min(newColumn, mainGrid.ColumnDefinitions.Count - 1));

        return (newRow, newColumn);
    }


}