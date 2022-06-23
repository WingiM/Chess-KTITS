using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Chess.Core;
using Chess.Core.Figures;

namespace Chess.WPFApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly Style BlackStyle;
        private static readonly Style WhiteStyle;
        private static readonly Color BlackColor;
        private static readonly Color WhiteColor;

        private readonly ChessBoard _board;
        private Piece _currentPiece;

        static MainWindow()
        {
            BlackColor = Color.FromRgb(181, 73, 1);
            WhiteColor = Color.FromRgb(231, 172, 113);

            var baseStyle = new Style();
            baseStyle.Setters.Add(new Setter
            {
                Property = HorizontalContentAlignmentProperty,
                Value = HorizontalAlignment.Center
            });
            baseStyle.Setters.Add(new Setter
            {
                Property = VerticalContentAlignmentProperty,
                Value = VerticalAlignment.Center
            });

            BlackStyle = new Style { BasedOn = baseStyle };
            BlackStyle.Setters.Add(new Setter
            {
                Property = BackgroundProperty,
                Value = new SolidColorBrush(BlackColor)
            });
            BlackStyle.Setters.Add(new Setter
            {
                Property = ForegroundProperty,
                Value = new SolidColorBrush(WhiteColor)
            });
            BlackStyle.Setters.Add(new Setter
            {
                Property = BorderBrushProperty,
                Value = new SolidColorBrush(WhiteColor)
            });

            WhiteStyle = new Style { BasedOn = baseStyle };
            WhiteStyle.Setters.Add(new Setter
            {
                Property = BackgroundProperty,
                Value = new SolidColorBrush(WhiteColor)
            });
            WhiteStyle.Setters.Add(new Setter
            {
                Property = ForegroundProperty,
                Value = new SolidColorBrush(BlackColor)
            });
            WhiteStyle.Setters.Add(new Setter
            {
                Property = BorderBrushProperty,
                Value = new SolidColorBrush(BlackColor)
            });
        }

        public MainWindow()
        {
            InitializeComponent();
            _board = new ChessBoard(true);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    CreateGridCell(j, i);
                }
            }

            LoadBoard();
        }

        private void LoadBoard()
        {
            ResetBoard();
            foreach (var piece in _board)
            {
                (int col, int row) = piece.NumericCoordinates;
                var cell = GetCellByCoordinates(col, row);
                var uri = ChessGrid
                    .Resources[$"{piece.Color}{piece.GetType().Name}Uri"];
                cell!.Content = uri is null
                    ? $"{piece.Color}{piece.FigureName}"
                    : new Image
                    {
                        Source = new BitmapImage(new Uri(uri.ToString()))
                    };
            }
        }

        private void ResetBoard()
        {
            foreach (ChessCell cell in ChessGrid.Children)
            {
                cell.Content = "";
                cell.Background = GetCellDefaultBackground(cell.Col, cell.Row);
                cell.Foreground =
                    GetCellDefaultBackground(cell.Col + 1, cell.Row);
                cell.BorderThickness = new Thickness(0);
                cell.Style = GetCellDefaultStyle(cell.Col, cell.Row);
            }
        }

        private void CreateGridCell(int col, int row)
        {
            var cell = new ChessCell(col, row)
            {
                Style = GetCellDefaultStyle(col, row)
            };
            cell.MouseDown += ChessCell_MouseDown;
            Grid.SetRow(cell, row);
            Grid.SetColumn(cell, col);
            ChessGrid.Children.Add(cell);
        }

        private void ChessCell_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChessCell cell = sender as ChessCell;

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (_currentPiece is null)
                {
                    _currentPiece = _board.GetPieceOnCell(cell.Col, cell.Row);
                    PaintCellsToMove();
                }
                else
                {
                    if (_board.MovePiece(_currentPiece, cell.Col, cell.Row))
                    {
                        _currentPiece = null;
                        LoadBoard();
                    }
                }
            }
            else if (e.RightButton == MouseButtonState.Pressed)
            {
                _board.RemovePiece(cell.Col, cell.Row);
                LoadBoard();
            }
        }

        private Style GetCellDefaultStyle(int col, int row)
        {
            if ((col + row) % 2 == 0)
                return WhiteStyle;
            return BlackStyle;
        }

        private SolidColorBrush GetCellDefaultBackground(int col, int row)
        {
            if ((col + row) % 2 == 0)
                return new SolidColorBrush(WhiteColor);
            return new SolidColorBrush(BlackColor);
        }

        private ChessCell GetCellByCoordinates(int col, int row)
        {
            return ChessGrid.Children
                .Cast<ChessCell>()
                .First(c => c.Col == col && c.Row == row);
        }

        private void PaintCellsToMove()
        {
            if (_currentPiece is null)
                return;

            foreach (ChessCell cell in ChessGrid.Children)
            {
                if (_board.CanPieceMove(_currentPiece, cell.Col, cell.Row))
                {
                    cell.Background = new SolidColorBrush(Colors.Gold);
                    cell.Foreground = new SolidColorBrush(Colors.Black);
                    cell.BorderBrush = new SolidColorBrush(Colors.Black);
                    cell.BorderThickness = new Thickness(2);
                }
            }
        }

        private void btn_AddFigure_Click(object sender, RoutedEventArgs e)
        {
            TeamColor color = Combo_ColorSelection.Text == "Black"
                ? TeamColor.Black
                : TeamColor.White;
            var figureName = Combo_FigureSelection.Text;

            try
            {
                _board.AddPiece(color, figureName, textBox_Coordinates.Text);
                LoadBoard();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}