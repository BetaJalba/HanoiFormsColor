namespace BelGiocoHanoi
{
    partial class FormHanoi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DATGRDVIEW = new DataGridView();
            TXTNUM = new NumericUpDown();
            LBLNUM = new Label();
            BTNCALC = new Button();
            BTNNEXTMOVE = new Button();
            BTNPREVMOVE = new Button();
            ((System.ComponentModel.ISupportInitialize)DATGRDVIEW).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TXTNUM).BeginInit();
            SuspendLayout();
            // 
            // DATGRDVIEW
            // 
            DATGRDVIEW.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DATGRDVIEW.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DATGRDVIEW.Location = new Point(182, 72);
            DATGRDVIEW.Name = "DATGRDVIEW";
            DATGRDVIEW.RowHeadersWidth = 51;
            DATGRDVIEW.Size = new Size(419, 303);
            DATGRDVIEW.TabIndex = 0;
            DATGRDVIEW.CellContentClick += DATGRDVIEW_CellContentClick;
            DATGRDVIEW.SelectionChanged += DATGRDVIEW_SelectionChanged;
            // 
            // TXTNUM
            // 
            TXTNUM.Location = new Point(12, 188);
            TXTNUM.Name = "TXTNUM";
            TXTNUM.Size = new Size(150, 27);
            TXTNUM.TabIndex = 1;
            // 
            // LBLNUM
            // 
            LBLNUM.AutoSize = true;
            LBLNUM.Location = new Point(12, 165);
            LBLNUM.Name = "LBLNUM";
            LBLNUM.Size = new Size(108, 20);
            LBLNUM.TabIndex = 2;
            LBLNUM.Text = "Numero dischi:";
            // 
            // BTNCALC
            // 
            BTNCALC.Location = new Point(12, 235);
            BTNCALC.Name = "BTNCALC";
            BTNCALC.Size = new Size(150, 55);
            BTNCALC.TabIndex = 3;
            BTNCALC.Text = "LET'S DUEL!!!";
            BTNCALC.UseVisualStyleBackColor = true;
            BTNCALC.Click += BTNCALC_Click;
            // 
            // BTNNEXTMOVE
            // 
            BTNNEXTMOVE.Location = new Point(628, 170);
            BTNNEXTMOVE.Name = "BTNNEXTMOVE";
            BTNNEXTMOVE.Size = new Size(150, 60);
            BTNNEXTMOVE.TabIndex = 4;
            BTNNEXTMOVE.Text = "PROSSIMA MOSSA";
            BTNNEXTMOVE.UseVisualStyleBackColor = true;
            BTNNEXTMOVE.Click += BTNNEXTMOVE_Click;
            // 
            // BTNPREVMOVE
            // 
            BTNPREVMOVE.Location = new Point(628, 236);
            BTNPREVMOVE.Name = "BTNPREVMOVE";
            BTNPREVMOVE.Size = new Size(150, 60);
            BTNPREVMOVE.TabIndex = 5;
            BTNPREVMOVE.Text = "MOSSA PRECEDENTE";
            BTNPREVMOVE.UseVisualStyleBackColor = true;
            BTNPREVMOVE.Click += BTNPREVMOVE_Click;
            // 
            // FormHanoi
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BTNPREVMOVE);
            Controls.Add(BTNNEXTMOVE);
            Controls.Add(BTNCALC);
            Controls.Add(LBLNUM);
            Controls.Add(TXTNUM);
            Controls.Add(DATGRDVIEW);
            Name = "FormHanoi";
            Text = "FormHanoi";
            Load += FormHanoi_Load;
            ((System.ComponentModel.ISupportInitialize)DATGRDVIEW).EndInit();
            ((System.ComponentModel.ISupportInitialize)TXTNUM).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DATGRDVIEW;
        private NumericUpDown TXTNUM;
        private Label LBLNUM;
        private Button BTNCALC;
        private Button BTNNEXTMOVE;
        private Button BTNPREVMOVE;
    }
}