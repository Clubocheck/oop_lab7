namespace lab7
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            odjectSize_tb = new TrackBar();
            ctrlPush_cb = new CheckBox();
            plus_btn = new Button();
            minus_btn = new Button();
            delete_btn = new Button();
            selectAll_btn = new Button();
            unselectAll_btn = new Button();
            circle_btn = new Button();
            square_btn = new Button();
            triangle_btn = new Button();
            section_btn = new Button();
            color_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)odjectSize_tb).BeginInit();
            SuspendLayout();
            // 
            // odjectSize_tb
            // 
            odjectSize_tb.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            odjectSize_tb.Location = new Point(617, 27);
            odjectSize_tb.Maximum = 100;
            odjectSize_tb.Minimum = 10;
            odjectSize_tb.Name = "odjectSize_tb";
            odjectSize_tb.Size = new Size(130, 56);
            odjectSize_tb.SmallChange = 0;
            odjectSize_tb.TabIndex = 1;
            odjectSize_tb.TabStop = false;
            odjectSize_tb.TickFrequency = 5;
            odjectSize_tb.TickStyle = TickStyle.None;
            odjectSize_tb.Value = 10;
            odjectSize_tb.Scroll += odjectSize_tb_Scroll;
            // 
            // ctrlPush_cb
            // 
            ctrlPush_cb.AutoSize = true;
            ctrlPush_cb.Location = new Point(22, 137);
            ctrlPush_cb.Name = "ctrlPush_cb";
            ctrlPush_cb.Size = new Size(54, 24);
            ctrlPush_cb.TabIndex = 1;
            ctrlPush_cb.Text = "Ctrl";
            ctrlPush_cb.UseVisualStyleBackColor = true;
            ctrlPush_cb.CheckedChanged += ctrlPush_cb_CheckedChanged;
            // 
            // plus_btn
            // 
            plus_btn.Location = new Point(12, 99);
            plus_btn.Name = "plus_btn";
            plus_btn.Size = new Size(94, 29);
            plus_btn.TabIndex = 2;
            plus_btn.Text = "+";
            plus_btn.UseVisualStyleBackColor = true;
            plus_btn.Click += plus_btn_Click;
            // 
            // minus_btn
            // 
            minus_btn.Location = new Point(112, 99);
            minus_btn.Name = "minus_btn";
            minus_btn.Size = new Size(94, 29);
            minus_btn.TabIndex = 3;
            minus_btn.Text = "-";
            minus_btn.UseVisualStyleBackColor = true;
            minus_btn.Click += minus_btn_Click;
            // 
            // delete_btn
            // 
            delete_btn.Location = new Point(12, 54);
            delete_btn.Name = "delete_btn";
            delete_btn.Size = new Size(94, 29);
            delete_btn.TabIndex = 4;
            delete_btn.Text = "delete";
            delete_btn.UseVisualStyleBackColor = true;
            delete_btn.Click += delete_btn_Click;
            // 
            // selectAll_btn
            // 
            selectAll_btn.Location = new Point(12, 12);
            selectAll_btn.Name = "selectAll_btn";
            selectAll_btn.Size = new Size(94, 29);
            selectAll_btn.TabIndex = 5;
            selectAll_btn.Text = "select all";
            selectAll_btn.UseVisualStyleBackColor = true;
            selectAll_btn.Click += selectAll_btn_Click;
            // 
            // unselectAll_btn
            // 
            unselectAll_btn.Location = new Point(112, 12);
            unselectAll_btn.Name = "unselectAll_btn";
            unselectAll_btn.Size = new Size(94, 29);
            unselectAll_btn.TabIndex = 6;
            unselectAll_btn.Text = "unselect all";
            unselectAll_btn.UseVisualStyleBackColor = true;
            unselectAll_btn.Click += unselectAll_btn_Click;
            // 
            // circle_btn
            // 
            circle_btn.Location = new Point(11, 184);
            circle_btn.Name = "circle_btn";
            circle_btn.Size = new Size(94, 29);
            circle_btn.TabIndex = 7;
            circle_btn.Text = "circle";
            circle_btn.UseVisualStyleBackColor = true;
            circle_btn.Click += circle_btn_Click;
            // 
            // square_btn
            // 
            square_btn.Location = new Point(11, 234);
            square_btn.Name = "square_btn";
            square_btn.Size = new Size(94, 29);
            square_btn.TabIndex = 8;
            square_btn.Text = "square";
            square_btn.UseVisualStyleBackColor = true;
            square_btn.Click += square_btn_Click;
            // 
            // triangle_btn
            // 
            triangle_btn.Location = new Point(11, 282);
            triangle_btn.Name = "triangle_btn";
            triangle_btn.Size = new Size(94, 29);
            triangle_btn.TabIndex = 9;
            triangle_btn.Text = "triangle";
            triangle_btn.UseVisualStyleBackColor = true;
            triangle_btn.Click += triangle_btn_Click;
            // 
            // section_btn
            // 
            section_btn.Location = new Point(11, 330);
            section_btn.Name = "section_btn";
            section_btn.Size = new Size(94, 29);
            section_btn.TabIndex = 10;
            section_btn.Text = "section";
            section_btn.UseVisualStyleBackColor = true;
            section_btn.Click += section_btn_Click;
            // 
            // color_btn
            // 
            color_btn.Location = new Point(112, 54);
            color_btn.Name = "color_btn";
            color_btn.Size = new Size(94, 29);
            color_btn.TabIndex = 11;
            color_btn.Text = "color";
            color_btn.UseVisualStyleBackColor = true;
            color_btn.Click += color_btn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(color_btn);
            Controls.Add(section_btn);
            Controls.Add(triangle_btn);
            Controls.Add(square_btn);
            Controls.Add(circle_btn);
            Controls.Add(unselectAll_btn);
            Controls.Add(selectAll_btn);
            Controls.Add(delete_btn);
            Controls.Add(minus_btn);
            Controls.Add(plus_btn);
            Controls.Add(ctrlPush_cb);
            Controls.Add(odjectSize_tb);
            KeyPreview = true;
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Paint += Form1_Paint;
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            MouseClick += Form1_MouseClick;
            ((System.ComponentModel.ISupportInitialize)odjectSize_tb).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar odjectSize_tb;
        private CheckBox ctrlPush_cb;
        private Button plus_btn;
        private Button minus_btn;
        private Button delete_btn;
        private Button selectAll_btn;
        private Button unselectAll_btn;
        private Button circle_btn;
        private Button square_btn;
        private Button triangle_btn;
        private Button section_btn;
        private Button color_btn;
    }
}