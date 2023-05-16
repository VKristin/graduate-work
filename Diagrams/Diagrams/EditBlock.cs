﻿using System;
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
                lbAction.Text = "Название";
            }
            if (figure.figure.type == 2)
            {
                numActions.Visible = false;
                nudConditions.Visible = false;
                FillListActions();
                this.cbActions.Items.AddRange(actions.ToArray());
                cbActions.SelectedIndex = 0;
            }
            if (figure.figure.type == 8)
            {
                nudConditions.Visible = false;
                cbActions.Visible = false;
                lbAction.Text = "Кол-во повторов";
            }
            if (figure.figure.type == 4)
            {
                numActions.Visible = false;
                lbAction.Text = "Есть место";
                numActions.Visible = false;
                FillListConditions();
                this.cbActions.Items.AddRange(actions.ToArray());
                cbActions.SelectedIndex = 0;
            }
            if (figure.figure.type == 7)
            {
                lbAction.Text = "Подпрограмма";
                numActions.Visible = false;
                nudConditions.Visible = false;
                FillListProcedures();
                this.cbActions.Items.AddRange(actions.ToArray());
                if (actions.Count() != 0)
                    cbActions.SelectedIndex = 0;
            }
        }

        private void FillListActions()
        {
            actions.Add("Встать в левый нижний угол");
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
            actions.Add("Переставить влево вниз");
        }

        private void FillListConditions()
        {
            actions.Add("Вправо");
            actions.Add("Влево");
            actions.Add("Вверх");
            actions.Add("Вниз");
            actions.Add("Вправо вниз");
            actions.Add("Вправо вверх");
            actions.Add("Влево вниз");
            actions.Add("Влево вверх");
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
                switch (cbActions.SelectedIndex)
                {
                    case 0: figure.text = "Встать в ↙ угол"; break;
                    case 1: figure.text = "Начертить →"; break;
                    case 2: figure.text = "Начертить ←"; break;
                    case 3: figure.text = "Начертить ↑"; break;
                    case 4: figure.text = "Начертить ↓"; break;
                    case 5: figure.text = "Начертить ↗"; break;
                    case 6: figure.text = "Начертить ↘"; break;
                    case 7: figure.text = "Начертить ↖"; break;
                    case 8: figure.text = "Начертить ↙"; break;
                    case 9: figure.text = "Переставить →"; break;
                    case 10: figure.text = "Переставить ←"; break;
                    case 11: figure.text = "Переставить ↑"; break;
                    case 12: figure.text = "Переставить ↓"; break;
                    case 13: figure.text = "Переставить ↗"; break;
                    case 14: figure.text = "Переставить ↘"; break;
                    case 15: figure.text = "Переставить ↖"; break;
                    case 16: figure.text = "Переставить ↙"; break;
                }
                (block as ActionBlock).action = Convert.ToByte(cbActions.SelectedIndex + 1);
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
    }
}
