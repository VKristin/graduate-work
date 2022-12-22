﻿using System;
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
        public byte condition; //номер условия
        public Block trueBlock;
        public Block falseBlock;

        public IfBlock(Block nextBlock, Block trueBlock, Block falseBlock, ref SolidFigure solidFigure) : base(nextBlock, solidFigure)
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
    /// 7 - начертить вправо вниз
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
        public byte action; //номер команды, которую необходимо выполнить
        public ActionBlock(Block nextBlock, byte action, ref SolidFigure solidFigure) : base(nextBlock, solidFigure)
        {
            this.action = action;
        }
    }
    public class WhileBlock : Block //блок предусловия
    {
        public byte condition; //номер условия
        public byte num_cond;
        public Block trueBlock;
        public WhileBlock(Block nextBlock, byte condition, byte num_cond, ref SolidFigure solidFigure, Block trueBlock) : base(nextBlock, solidFigure)
        {
            this.condition = condition;
            this.num_cond = num_cond;
            figure = solidFigure;
        }
    }
    public class DoWhileBlock : Block //блок постусловия
    {
        public byte condition; //номер условия
        public byte num_cond;
        public Block trueBlock;
        public DoWhileBlock(Block nextBlock, byte condition, byte num_cond, ref SolidFigure solidFigure, Block trueBlock) : base(nextBlock, solidFigure)
        {
            this.num_cond = num_cond;
            this.condition = condition;
        }
    }
    public class ForBlock : Block //блок цикла с параметром
    {
        public int numOfRep; //количество повторов
        public Block trueBlock;
        public ForBlock(Block nextBlock, int numOfRep, ref SolidFigure solidFigure, Block trueBlock) : base(nextBlock, solidFigure)
        {
            this.numOfRep = numOfRep;
        }
    }
    public class IfWithoutElseBlock: Block //блок условия без альтернативы
    {
        public byte condition; //номер условия
        public byte num_cond;
        public Block trueBlock;

        public IfWithoutElseBlock(Block nextBlock, byte condition, byte num_cond, ref SolidFigure solidFigure, Block trueBlock) : base(nextBlock, solidFigure)
        {
            this.num_cond = num_cond;
            this.condition = condition;
        }
    }
    /*public class SubroutineBlock: Block //блок с подпрограммой
    {

    }*/
}
