using System;
namespace Chess.Custom
{
	public class ChessPiece : Label
    {
        public static readonly BindableProperty IsWhiteProperty = BindableProperty.Create(nameof(IsWhite), typeof(bool), typeof(ChessPiece), default(bool));
        public static readonly BindableProperty CurrentPositionProperty = BindableProperty.Create(nameof(CurrentPosition), typeof(CurrentPosition), typeof(ChessPiece), default(CurrentPosition));
        public static readonly BindableProperty TypeProperty = BindableProperty.Create(nameof(ChessPieceType), typeof(ChessPieceType), typeof(ChessPieceType), default(ChessPieceType));

        public bool IsWhite
        {
            get => (bool)GetValue(IsWhiteProperty);
            set => SetValue(IsWhiteProperty, value);
        }

        public CurrentPosition CurrentPosition
        {
            get => (CurrentPosition)GetValue(CurrentPositionProperty);
            set => SetValue(CurrentPositionProperty, value);
        }

        public ChessPieceType ChessPieceType
        {
            get => (ChessPieceType)GetValue(TypeProperty);
            set => SetValue(TypeProperty, value);
        }


    }
    public class CurrentPosition
    {
        public int GridRow { get; set; } = 0;

        public int GridColumn { get; set; } = 0;
    }
}

