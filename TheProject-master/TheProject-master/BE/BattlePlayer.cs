using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Utilities;

namespace BE
{
    public class BattlePlayer
    {
        public String Name { get; set; }
       
        [XmlIgnore]
        public bool?[,] Board { get; private set; }
        [XmlArray("Board")]
        public bool?[] BoardDto
        {
            get { return Board.Flatten(); }
            set { Board = value.Expand(10); }
        }

        [XmlIgnore]
        public bool?[,] OpponentBoard { get; private set; }
        [XmlArray("OpponentBoard")]
        public bool?[] OpponentBoardDto
        {
            get { return OpponentBoard.Flatten(); }
            set { OpponentBoard = value.Expand(10); }
        }

        public void fire(int i, int j)
        {
            if (OpponentBoard[i, j] == null)
            {
                //ask opponent 
                //in real play we get "hit" value from opponent
                //bool missed = false;
                bool hit = true;
                if (hit)
                {
                    OpponentBoard[i, j] = true;
                }
                else
                {
                    OpponentBoard[i, j] = false;
                }
            }
            //add more logic here
        }
        public void putShips()
        {
            //TO DO
        }
        public BattlePlayer()
        {
            Board = new bool?[10, 10];
            OpponentBoard = new bool?[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Board[i, j] = null;
                    OpponentBoard[i, j] = null;
                }
            }
        }
        public bool? this[int i, int j]
        {
            get { return Board[i, j]; }
            set { Board[i, j] = value; }
        }

        public override string ToString()
        {
            String result = "";
            result += String.Format("Player Name: {0}\n", Name);
            result += "Board: \n";
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    switch (Board[i,j])
                    {
                        case true:
                            result += "X ";
                            break;
                        case false:
                            result += "- ";
                            break;
                        case null:
                            result += "  ";
                            break;
                        default:
                            break;
                    }
                }
                result += "\n";
            }
            result += "OpponentBoard: \n";
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    switch (OpponentBoard[i, j])
                    {
                        case true:
                            result += "X ";
                            break;
                        case false:
                            result += "- ";
                            break;
                        case null:
                            result += "  ";
                            break;
                        default:
                            break;
                    }
                }
                result += "\n";
            }
            return result;

        }

    }
}
