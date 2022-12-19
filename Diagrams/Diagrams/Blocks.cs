using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//класс для хранения схем

namespace Diagrams
{
    public abstract class Block
    {
        public Block nextBlock;
        public SolidFigure figure;

        public Block(Block nextBlock, SolidFigure figure )
        {
            this.nextBlock = nextBlock;
            this.figure = figure;
        }
    }
    public class EllipseBlock : Block 
    {
        public EllipseBlock(Block nextBlock,SolidFigure solidFigure) : base(nextBlock, solidFigure)
        {
            figure = solidFigure;
        }
    }
    public class IfBlock : Block
    {
        Block trueBlock;
        Block falseBlock;

        public IfBlock(Block nextBlock, Block trueBlock, Block falseBlock, SolidFigure solidFigure) : base(nextBlock, solidFigure)
        {
            this.trueBlock = trueBlock;
            figure = solidFigure;
            this.falseBlock = falseBlock;
        }
    }
    /// 1 - встать в левый нижний угол
    /// 2 - начертить вправо
    /// 3 - начертить влево
    /// 4 - начертить вверх
    /// 5 - начертить вниз
    /// 6 - начертить вправо вверх
    /// 7 - начертить вправо вверх
    /// 8 - начертить влево вверх
    /// 9 - начертить влево вниз
    /// 10 - переставить вправо
    /// 11 - переставить влево
    /// 12 - переставить вверх
    /// 13 - переставить вниз
    /// 14 - переставить вправо вверх
    /// 15 - переставить вправо вниз
    /// 16 - переставить влево вверх
    /// 17 - переставить влево вниз
    public class ActionBlock : Block //блок действия
    {
        byte action; //номер команды, которую необходимо выполнить
        public ActionBlock(Block nextBlock, byte action, SolidFigure solidFigure) : base(nextBlock, solidFigure)
        {
            this.action = action;
        }
    }
    public class WhileBlock : Block //блок предусловия
    {
        byte condition; //номер условия
        Block trueBlock;
        public WhileBlock(Block nextBlock, byte condition, SolidFigure solidFigure, Block trueBlock) : base(nextBlock, solidFigure)
        {
            this.condition = condition;
            figure = solidFigure;
        }
    }
    public class DoWhileBlock : Block //блок постусловия
    {
        byte condition; //номер условия
        Block trueBlock;
        public DoWhileBlock(Block nextBlock, byte condition, SolidFigure solidFigure, Block trueBlock) : base(nextBlock, solidFigure)
        {
            this.condition = condition;
        }
    }
    public class ForBlock : Block //блок цикла с параметром
    {
        int numOfRep; //количество повторов
        Block trueBlock;
        public ForBlock(Block nextBlock, int numOfRep, SolidFigure solidFigure, Block trueBlock) : base(nextBlock, solidFigure)
        {
            this.numOfRep = numOfRep;
        }
    }
    public class IfWithoutElseBlock: Block //блок условия без альтернативы
    {
        byte condition; //номер условия
        Block trueBlock;
        public IfWithoutElseBlock(Block nextBlock, byte condition, SolidFigure solidFigure, Block trueBlock) : base(nextBlock, solidFigure)
        {
            this.condition = condition;
        }
    }
    /*public class SubroutineBlock: Block //блок с подпрограммой
    {

    }*/
}
