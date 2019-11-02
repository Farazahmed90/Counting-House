namespace BankManagementSystem
{
    partial class viewForm
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
            this.empDataGridView = new System.Windows.Forms.DataGridView();
            this.updateButton = new System.Windows.Forms.Button();
            this.DelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.empDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // empDataGridView
            // 
            this.empDataGridView.AllowUserToAddRows = false;
            this.empDataGridView.AllowUserToDeleteRows = false;
            this.empDataGridView.AllowUserToResizeRows = false;
            this.empDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.empDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.empDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.empDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.empDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.empDataGridView.Location = new System.Drawing.Point(0, 39);
            this.empDataGridView.Name = "empDataGridView";
            this.empDataGridView.ReadOnly = true;
            this.empDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.empDataGridView.RowHeadersVisible = false;
            this.empDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.empDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.empDataGridView.Size = new System.Drawing.Size(722, 363);
            this.empDataGridView.TabIndex = 0;
            this.empDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.empDataGridView_CellClick);
            this.empDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.empDataGridView_CellDoubleClick);
            // 
            // updateButton
            // 
            this.updateButton.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.updateButton.Location = new System.Drawing.Point(490, 408);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(105, 31);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // DelButton
            // 
            this.DelButton.Font = new System.Drawing.Font("Century Gothic", 11.25F);
            this.DelButton.Location = new System.Drawing.Point(607, 408);
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size(105, 31);
            this.DelButton.TabIndex = 4;
            this.DelButton.Text = "Delete";
            this.DelButton.UseVisualStyleBackColor = true;
            this.DelButton.Click += new System.EventHandler(this.DelButton_Click);
            // 
            // viewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 451);
            this.Controls.Add(this.DelButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.empDataGridView);
            this.Name = "viewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SBl Employees";
            ((System.ComponentModel.ISupportInitialize)(this.empDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView empDataGridView;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button DelButton;
    }
}