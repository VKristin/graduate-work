using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Data;

//класс для хранения схем

namespace Diagrams
{
    [Serializable]
    [XmlInclude(typeof(EllipseBlock))]
    [XmlInclude(typeof(IfBlock))]
    [XmlInclude(typeof(IfWithoutElseBlock))]
    [XmlInclude(typeof(WhileBlock))]
    [XmlInclude(typeof(ForBlock))]
    [XmlInclude(typeof(DoWhileBlock))]
    public abstract class Block : ICloneable
    {
        public Block nextBlock;
        public SolidFigure figure;

        public Block(Block nextBlock, SolidFigure figure )
        {
            this.nextBlock = nextBlock;
            this.figure = figure;
        }
        public Block(Block b)
        {
            this.nextBlock = b.nextBlock;
            this.figure = b.figure;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public Block() { }
    }
    [Serializable]
    public class EllipseBlock : Block 
    {
        public EllipseBlock() { }
        public EllipseBlock(Block nextBlock,SolidFigure solidFigure) : base(nextBlock, solidFigure)
        {
            figure = solidFigure;
        }
        public EllipseBlock(Block b): base(b) { }
    }
    [Serializable]
    public class Condition : Block 
    {
        public Block trueBlock;

        public Condition() { }

        public Condition(Block nextBlock, Block trueBlock, SolidFigure figure): base(nextBlock, figure)
        {
            this.trueBlock = trueBlock;
        }
        public Condition(Block b) : base(b) { }

    }
    [Serializable]
    public class IfBlock : Condition
    {
        public byte condition; //номер условия
        public Block falseBlock;

        public IfBlock() { }
        public IfBlock(Block nextBlock, Block trueBlock, Block falseBlock, byte condition, ref SolidFigure solidFigure) : base(nextBlock, trueBlock, solidFigure)
        {
            this.trueBlock = trueBlock;
            figure = solidFigure;
            this.condition = condition;
            this.falseBlock = falseBlock;
        }
        public IfBlock(Block b) : base(b) { }

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
    [Serializable]
    public class ActionBlock : Block //блок действия
    {
        public byte action; //номер команды, которую необходимо выполнить

        public ActionBlock() { }
        public ActionBlock(Block nextBlock, byte action, ref SolidFigure solidFigure) : base(nextBlock, solidFigure)
        {
            this.action = action;
        }
        public ActionBlock(Block b) : base(b) { }

    }
    [Serializable]
    public class ProcedureBlock : Block //блок действия
    {
        public byte action; //номер команды, которую необходимо выполнить

        public ProcedureBlock() { }
        public ProcedureBlock(Block nextBlock, ref SolidFigure solidFigure) : base(nextBlock, solidFigure)
        {
        }
        public ProcedureBlock(Block b) : base(b) { }

    }
    [Serializable]
    public class WhileBlock : Condition //блок предусловия
    {
        public byte condition; //номер условия
        public byte num_cond;

        public WhileBlock() { }
        public WhileBlock(Block nextBlock, byte condition, byte num_cond, ref SolidFigure solidFigure, Block trueBlock) : base(nextBlock, trueBlock, solidFigure)
        {
            this.condition = condition;
            this.num_cond = num_cond;
            figure = solidFigure;
        }
        public WhileBlock(Block b) : base(b) { }

    }
    [Serializable]
    public class DoWhileBlock : Condition //блок постусловия
    {
        public byte condition; //номер условия
        public byte num_cond;

        public DoWhileBlock() { }
        public DoWhileBlock(Block nextBlock, byte condition, byte num_cond, ref SolidFigure solidFigure, Block trueBlock) : base(nextBlock, trueBlock, solidFigure)
        {
            this.num_cond = num_cond;
            this.trueBlock = trueBlock;
            this.condition = condition;
        }
        public DoWhileBlock(Block b) : base(b) { }

    }
    [Serializable]
    public class ForBlock : Condition //блок цикла с параметром
    {
        public int numOfRep; //количество повторов

        public ForBlock() { }
        public ForBlock(Block nextBlock, int numOfRep, ref SolidFigure solidFigure, Block trueBlock) : base(nextBlock, trueBlock, solidFigure)
        {
            this.numOfRep = numOfRep;
        }
        public ForBlock(Block b) : base(b) { }

    }
    [Serializable]
    public class IfWithoutElseBlock: Condition //блок условия без альтернативы
    {
        public byte condition; //номер условия
        public byte num_cond;

        public IfWithoutElseBlock() { }

        public IfWithoutElseBlock(Block nextBlock, byte condition, byte num_cond, ref SolidFigure solidFigure, Block trueBlock) : base(nextBlock, trueBlock, solidFigure)
        {
            this.num_cond = num_cond;
            this.condition = condition;
        }
        public IfWithoutElseBlock(Block b) : base(b) { }

    }
    /*public class SubroutineBlock: Block //блок с подпрограммой
    {

    }*/
}
