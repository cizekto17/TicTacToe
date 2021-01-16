using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicTacToe
{
    class GameEnder
    {
        // DEFINE VARIABLES FOR CLASS GAME
        public string[,] gameField;
        private int winningCondition;
        private string lastPlayed = "";
        private int rowCount;
        private int columnCount;

        // CONSTRUCTOR FOR GAME
        // INSERT GAMEFIELD
        public GameEnder(string[,] tmpGameField, int tmpWinningCondition, int tmpRowCount, int tmpColumnCount)
        {
            gameField = tmpGameField;
            rowCount = tmpRowCount;
            columnCount = tmpColumnCount;
            winningCondition = tmpWinningCondition;
        }

        // FUNCTION CALLED FOR GAME END
        public bool CheckGameEnd(string tmpLastPlayed)
        {
            lastPlayed = tmpLastPlayed;
            bool gg = false;
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    System.Diagnostics.Debug.WriteLine(rowIndex.ToString()+" : "+columnIndex.ToString());
                    if (gameField[rowIndex,columnIndex] != "P")
                    {
                        // Check condition for winning
                        if (CheckVerticalWin(rowIndex, columnIndex) || CheckHorizontalWin(rowIndex, columnIndex) ||
                            CheckDiagonalWinAscending(rowIndex, columnIndex) || CheckDiagonalWinDescending(rowIndex, columnIndex))
                        {
                            // END GAME
                            // CALL END SCREEN
                            gg = true;
                        }
                    }
                }
            }
            return gg;
        }

        private bool CheckVerticalWin(int rowIndex, int columnIndex)
        {
            // Check if is possible
            if (columnCount - columnIndex >= winningCondition)
            {
                int inRow = 0;
                for (int startPoint = columnIndex; startPoint < columnIndex + winningCondition; startPoint++)
                {
                    if (gameField[rowIndex,startPoint] == lastPlayed)
                    {
                        inRow++;
                    }
                }
                if (inRow >= winningCondition)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool CheckHorizontalWin(int rowIndex, int columnIndex)
        {
            if (rowCount - rowIndex >= winningCondition)
            {
                int inColumn = 0;
                for (int startPoint = rowIndex; startPoint < rowIndex + winningCondition; startPoint++)
                {
                    if (gameField[startPoint,columnIndex] == lastPlayed)
                    {
                        inColumn++;
                    }
                }
                if (inColumn >= winningCondition)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool CheckDiagonalWinDescending(int rowIndex, int columnIndex)
        {
            if (rowCount - rowIndex >= winningCondition && columnCount - columnIndex >= winningCondition)
            {
                int inDiagonal = 0;
                for (int i = 0; i < winningCondition; i++)
                {
                    if (gameField[rowIndex + i,columnIndex + i] == lastPlayed)
                    {
                        inDiagonal++;
                    }
                }
                if (inDiagonal >= winningCondition)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool CheckDiagonalWinAscending(int rowIndex, int columnIndex)
        {
            if (rowIndex >= winningCondition - 1 && columnCount - columnIndex >= winningCondition)
            {
                int inDiagonal = 0;
                for (int i = 0; i < winningCondition; i++)
                {
                    if (gameField[rowIndex - i,columnIndex + i] == lastPlayed)
                    {
                        inDiagonal++;
                    }
                }
                if (inDiagonal >= winningCondition)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
