using System;
namespace Chess.Custom
{
	public class ChessSquareGrid : Grid
    {
        public static readonly BindableProperty IDProperty = BindableProperty.Create(nameof(ID), typeof(int), typeof(ChessSquareGrid), default(int));
        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(SquareName), typeof(string), typeof(ChessSquareGrid), default(string));

        public int ID
        {
            get => (int)GetValue(IDProperty);
            set => SetValue(IDProperty, value);
        }

        public string SquareName
        {
            get => (string)GetValue(NameProperty);
            set => SetValue(NameProperty, value);
        }
    }
}

