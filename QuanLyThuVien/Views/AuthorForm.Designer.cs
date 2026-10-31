namespace QuanLyThuVien.Views;

partial class AuthorForm
{
    /// <summary>Biến bắt buộc của Designer.</summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>Giải phóng các tài nguyên đang dùng.</summary>
    /// <param name="disposing"><see langword="true"/> nếu cần giải phóng cả tài nguyên managed.</param>
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
    /// Phương thức bắt buộc của Designer, không sửa nội dung bằng code editor.
    /// </summary>
    private void InitializeComponent()
    {
        txtSearch = new System.Windows.Forms.TextBox();
        btnSearch = new System.Windows.Forms.Button();
        dgvAuthors = new System.Windows.Forms.DataGridView();
        grpDetails = new System.Windows.Forms.GroupBox();
        lblFullName = new System.Windows.Forms.Label();
        txtFullName = new System.Windows.Forms.TextBox();
        lblBirthYear = new System.Windows.Forms.Label();
        nudBirthYear = new System.Windows.Forms.NumericUpDown();
        lblBiography = new System.Windows.Forms.Label();
        txtBiography = new System.Windows.Forms.TextBox();
        btnNew = new System.Windows.Forms.Button();
        btnSave = new System.Windows.Forms.Button();
        btnDelete = new System.Windows.Forms.Button();
        colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colBirthYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvAuthors).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudBirthYear).BeginInit();
        grpDetails.SuspendLayout();
        SuspendLayout();
        //
        // txtSearch
        //
        txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtSearch.Location = new System.Drawing.Point(12, 12);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new System.Drawing.Size(470, 23);
        txtSearch.TabIndex = 0;
        txtSearch.PlaceholderText = "Nhập từ khóa tìm kiếm";
        //
        // btnSearch
        //
        btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        btnSearch.Location = new System.Drawing.Point(488, 11);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new System.Drawing.Size(80, 25);
        btnSearch.TabIndex = 1;
        btnSearch.Text = "Tìm";
        btnSearch.UseVisualStyleBackColor = true;
        btnSearch.Click += btnSearch_Click;
        //
        // dgvAuthors
        //
        dgvAuthors.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dgvAuthors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colFullName, colBirthYear });
        dgvAuthors.Location = new System.Drawing.Point(12, 43);
        dgvAuthors.Name = "dgvAuthors";
        dgvAuthors.Size = new System.Drawing.Size(556, 506);
        dgvAuthors.TabIndex = 2;
        dgvAuthors.AllowUserToAddRows = false;
        dgvAuthors.AllowUserToDeleteRows = false;
        dgvAuthors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvAuthors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvAuthors.MultiSelect = false;
        dgvAuthors.ReadOnly = true;
        dgvAuthors.RowHeadersVisible = false;
        dgvAuthors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvAuthors.SelectionChanged += dgvAuthors_SelectionChanged;
        //
        // grpDetails
        //
        grpDetails.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        grpDetails.Controls.Add(lblFullName);
        grpDetails.Controls.Add(txtFullName);
        grpDetails.Controls.Add(lblBirthYear);
        grpDetails.Controls.Add(nudBirthYear);
        grpDetails.Controls.Add(lblBiography);
        grpDetails.Controls.Add(txtBiography);
        grpDetails.Location = new System.Drawing.Point(580, 12);
        grpDetails.Name = "grpDetails";
        grpDetails.Size = new System.Drawing.Size(392, 504);
        grpDetails.TabIndex = 3;
        grpDetails.Text = "Thông tin";
        //
        // lblFullName
        //
        lblFullName.AutoSize = true;
        lblFullName.Location = new System.Drawing.Point(12, 29);
        lblFullName.Name = "lblFullName";
        lblFullName.Size = new System.Drawing.Size(80, 15);
        lblFullName.TabIndex = 4;
        lblFullName.Text = "Họ tên";
        //
        // txtFullName
        //
        txtFullName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtFullName.Location = new System.Drawing.Point(110, 26);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new System.Drawing.Size(266, 23);
        txtFullName.TabIndex = 5;
        //
        // lblBirthYear
        //
        lblBirthYear.AutoSize = true;
        lblBirthYear.Location = new System.Drawing.Point(12, 61);
        lblBirthYear.Name = "lblBirthYear";
        lblBirthYear.Size = new System.Drawing.Size(80, 15);
        lblBirthYear.TabIndex = 6;
        lblBirthYear.Text = "Năm sinh";
        //
        // nudBirthYear
        //
        nudBirthYear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        nudBirthYear.Location = new System.Drawing.Point(110, 58);
        nudBirthYear.Name = "nudBirthYear";
        nudBirthYear.Size = new System.Drawing.Size(266, 23);
        nudBirthYear.TabIndex = 7;
        nudBirthYear.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        //
        // lblBiography
        //
        lblBiography.AutoSize = true;
        lblBiography.Location = new System.Drawing.Point(12, 93);
        lblBiography.Name = "lblBiography";
        lblBiography.Size = new System.Drawing.Size(80, 15);
        lblBiography.TabIndex = 8;
        lblBiography.Text = "Tiểu sử";
        //
        // txtBiography
        //
        txtBiography.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtBiography.Location = new System.Drawing.Point(110, 90);
        txtBiography.Name = "txtBiography";
        txtBiography.Size = new System.Drawing.Size(266, 120);
        txtBiography.TabIndex = 9;
        txtBiography.Multiline = true;
        txtBiography.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        //
        // btnNew
        //
        btnNew.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        btnNew.Location = new System.Drawing.Point(580, 524);
        btnNew.Name = "btnNew";
        btnNew.Size = new System.Drawing.Size(90, 25);
        btnNew.TabIndex = 10;
        btnNew.Text = "Thêm mới";
        btnNew.UseVisualStyleBackColor = true;
        btnNew.Click += btnNew_Click;
        //
        // btnSave
        //
        btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        btnSave.Location = new System.Drawing.Point(676, 524);
        btnSave.Name = "btnSave";
        btnSave.Size = new System.Drawing.Size(90, 25);
        btnSave.TabIndex = 11;
        btnSave.Text = "Lưu";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        //
        // btnDelete
        //
        btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        btnDelete.Location = new System.Drawing.Point(772, 524);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new System.Drawing.Size(90, 25);
        btnDelete.TabIndex = 12;
        btnDelete.Text = "Xóa";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        //
        // colFullName
        //
        colFullName.DataPropertyName = "FullName";
        colFullName.HeaderText = "Họ tên";
        colFullName.Name = "colFullName";
        colFullName.ReadOnly = true;
        //
        // colBirthYear
        //
        colBirthYear.DataPropertyName = "BirthYear";
        colBirthYear.HeaderText = "Năm sinh";
        colBirthYear.Name = "colBirthYear";
        colBirthYear.ReadOnly = true;
        //
        // AuthorForm
        //
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(984, 561);
        Controls.Add(txtSearch);
        Controls.Add(btnSearch);
        Controls.Add(dgvAuthors);
        Controls.Add(grpDetails);
        Controls.Add(btnNew);
        Controls.Add(btnSave);
        Controls.Add(btnDelete);
        Name = "AuthorForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Tác giả";
        Load += AuthorForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvAuthors).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudBirthYear).EndInit();
        grpDetails.ResumeLayout(false);
        grpDetails.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.DataGridView dgvAuthors;
    private System.Windows.Forms.GroupBox grpDetails;
    private System.Windows.Forms.Label lblFullName;
    private System.Windows.Forms.TextBox txtFullName;
    private System.Windows.Forms.Label lblBirthYear;
    private System.Windows.Forms.NumericUpDown nudBirthYear;
    private System.Windows.Forms.Label lblBiography;
    private System.Windows.Forms.TextBox txtBiography;
    private System.Windows.Forms.Button btnNew;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colBirthYear;
}
