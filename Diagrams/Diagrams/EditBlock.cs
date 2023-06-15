using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Diagrams
{
    public partial class EditBlock : Form
    {
        List<string> actions = new List<string>();
        List<string> directions = new List<string>();
        SolidFigure figure;
        Block block;
        DiagramBox db;

        public EditBlock(DiagramBox db, Block figure)
        {
            InitializeComponent();
            this.figure = figure.figure;
            this.db = db;
            block = figure;
            cbActions.DropDownStyle = ComboBoxStyle.DropDownList;

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.None;
            if (db.Diagram.figures[0] == figure.figure)
            {
                nudConditions.Visible = false;
                numActions.Visible = false;
                cbActions.Visible = false;
                cbDirection.Visible = false;
                lbAction.Text = "Название";
            }
            if (figure.figure.type == 2)
            {
                numActions.Visible = false;
                nudConditions.Visible = false;
                FillListActions();
                this.cbActions.Items.AddRange(actions.ToArray());
                this.cbDirection.Items.AddRange(directions.ToArray());
                cbDirection.SelectedIndex = 0;
                cbActions.SelectedIndex = 0;
            }
            if (figure.figure.type == 8)
            {
                nudConditions.Visible = false;
                cbActions.Visible = false;
                cbDirection.Visible = false;
                lbAction.Text = "Кол-во повторов";
            }
            if (figure.figure.type == 4)
            {
                numActions.Visible = false;
                lbAction.Text = "Есть место";
                numActions.Visible = false;
                FillListConditions();
                //this.cbDirection.Items.AddRange(directions.ToArray());
                cbDirection.Visible = false;
                this.cbActions.Items.AddRange(actions.ToArray());
                cbActions.SelectedIndex = 0;
                //cbDirection.SelectedIndex = 0;
            }
            if (figure.figure.type == 7)
            {
                lbAction.Text = "Подпрограмма";
                numActions.Visible = false;
                nudConditions.Visible = false;
                FillListProcedures();
                this.cbDirection.Items.AddRange(directions.ToArray());
                this.cbActions.Items.AddRange(actions.ToArray());
                cbDirection.Visible = false;
                if (actions.Count() != 0)
                    cbActions.SelectedIndex = 0;
            }
        }

        private void FillListActions()
        {
            actions.Add("Встать в левый нижний угол");
            actions.Add("Начертить");
            actions.Add("Переставить");

            directions.Add("→");
            directions.Add("←");
            directions.Add("↑");
            directions.Add("↓");
            directions.Add("↘");
            directions.Add("↗");
            directions.Add("↙");
            directions.Add("↖");
            /*actions.Add("Встать в левый нижний угол");
            actions.Add("Начертить вправо");
            actions.Add("Начертить влево");
            actions.Add("Начертить вверх");
            actions.Add("Начертить вниз");
            actions.Add("Начертить вправо вверх");
            actions.Add("Начертить вправо вниз");
            actions.Add("Начертить влево вверх");
            actions.Add("Начертить влево вниз");
            actions.Add("Переставить вправо");
            actions.Add("Переставить влево");
            actions.Add("Переставить вверх");
            actions.Add("Переставить вниз");
            actions.Add("Переставить вправо вверх");
            actions.Add("Переставить вправо вниз");
            actions.Add("Переставить влево вверх");
            actions.Add("Переставить влево вниз");*/
        }

        /*
                    case 0: figure.text = "→ " + nudConditions.Value.ToString(); break;
                    case 1: figure.text = "← " + nudConditions.Value.ToString(); break;
                    case 2: figure.text = "↑ " + nudConditions.Value.ToString(); break;
                    case 3: figure.text = "↓ " + nudConditions.Value.ToString(); break;
                    case 4: figure.text = "↘ " + nudConditions.Value.ToString(); break;
                    case 5: figure.text = "↗ " + nudConditions.Value.ToString(); break;
                    case 6: figure.text = "↙ " + nudConditions.Value.ToString(); break;
                    case 7: figure.text = "↖ " + nudConditions.Value.ToString(); break;*/

        private void FillListConditions()
        {
            actions.Add("→");
            actions.Add("←");
            actions.Add("↑");
            actions.Add("↓");
            actions.Add("↘");
            actions.Add("↗");
            actions.Add("↙");
            actions.Add("↖");
        }

        private void FillListProcedures()
        {
            string[] allfiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.drawerprocedure");
            foreach (string filename in allfiles)
            {
                actions.Add(Path.GetFileNameWithoutExtension(filename));
            }
        }

        private void Save()
        {
            if (figure.type == 2)
            {
                int idx = -1;   
                if (cbActions.SelectedIndex == 0)
                    figure.text = "Встать в ↙ угол";
                else
                    figure.text = cbActions.Text + " " + cbDirection.Text;
                switch (figure.text)
                {
                    case "Встать в ↙ угол": idx = 1; break;
                    case "Начертить →": idx = 2; break;
                    case "Начертить ←": idx = 3; break;
                    case "Начертить ↑": idx = 4; break;
                    case "Начертить ↓": idx = 5; break;
                    case "Начертить ↗": idx = 6; break;
                    case "Начертить ↘": idx = 7; break;
                    case "Начертить ↖": idx = 8; break;
                    case "Начертить ↙": idx = 9; break;
                    case "Переставить →": idx = 10; break;
                    case "Переставить ←": idx = 11; break;
                    case "Переставить ↑": idx = 12; break;
                    case "Переставить ↓": idx = 13; break;
                    case "Переставить ↗": idx = 14; break;
                    case "Переставить ↘": idx = 15; break;
                    case "Переставить ↖": idx = 16; break;
                    case "Переставить ↙": idx = 17; break;
                }
                (block as ActionBlock).action = Convert.ToByte(idx);
            }
            if (figure.type == 4)
            {
                switch (cbActions.SelectedIndex)
                {
                    case 0: figure.text = "→ " + nudConditions.Value.ToString(); break;
                    case 1: figure.text = "← " + nudConditions.Value.ToString(); break;
                    case 2: figure.text = "↑ " + nudConditions.Value.ToString(); break;
                    case 3: figure.text = "↓ " + nudConditions.Value.ToString(); break;
                    case 4: figure.text = "↘ " + nudConditions.Value.ToString(); break;
                    case 5: figure.text = "↗ " + nudConditions.Value.ToString(); break;
                    case 6: figure.text = "↙ " + nudConditions.Value.ToString(); break;
                    case 7: figure.text = "↖ " + nudConditions.Value.ToString(); break;
                }
                if (block is WhileBlock)
                {
                    (block as WhileBlock).condition = Convert.ToByte(cbActions.SelectedIndex + 1);
                    (block as WhileBlock).num_cond = Convert.ToByte(nudConditions.Value);
                }
                if (block is IfWithoutElseBlock)
                {
                    (block as IfWithoutElseBlock).condition = Convert.ToByte(cbActions.SelectedIndex + 1);
                    (block as IfWithoutElseBlock).num_cond = Convert.ToByte(nudConditions.Value);
                }
            }
            if (figure.type == 8)
            {
                figure.text = numActions.Value.ToString();
                (block as ForBlock).numOfRep = Convert.ToByte(numActions.Value);
            }
            if (figure.type == 7)
            {
                if (cbActions.Items.Count != 0)
                    figure.text = cbActions.Text.ToString();
            }
            this.Close();
            db.Invalidate();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditBlock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save();
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void cbActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (block is ActionBlock)
            {
                if (cbActions.SelectedIndex == 0)
                    cbDirection.Visible = false;
                else
                    cbDirection.Visible = true;
            }

        }
    }
}
