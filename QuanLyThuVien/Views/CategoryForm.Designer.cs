namespace QuanLyThuVien.Views;

partial class CategoryForm
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
        dgvCategories = new System.Windows.Forms.DataGridView();
        grpDetails = new System.Windows.Forms.GroupBox();
        lblName = new System.Windows.Forms.Label();
        txtName = new System.Windows.Forms.TextBox();
        lblDescription = new System.Windows.Forms.Label();
        txtDescription = new System.Windows.Forms.TextBox();
        btnNew = new System.Windows.Forms.Button();
        btnSave = new System.Windows.Forms.Button();
        btnDelete = new System.Windows.Forms.Button();
        colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();
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
        // dgvCategories
        //
        dgvCategories.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dgvCategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colName, colDescription });
        dgvCategories.Location = new System.Drawing.Point(12, 43);
        dgvCategories.Name = "dgvCategories";
        dgvCategories.Size = new System.Drawing.Size(556, 506);
        dgvCategories.TabIndex = 2;
        dgvCategories.AllowUserToAddRows = false;
        dgvCategories.AllowUserToDeleteRows = false;
        dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvCategories.MultiSelect = false;
        dgvCategories.ReadOnly = true;
        dgvCategories.RowHeadersVisible = false;
        dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvCategories.SelectionChanged += dgvCategories_SelectionChanged;
        //
        // grpDetails
        //
        grpDetails.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        grpDetails.Controls.Add(lblName);
        grpDetails.Controls.Add(txtName);
        grpDetails.Controls.Add(lblDescription);
        grpDetails.Controls.Add(txtDescription);
        grpDetails.Location = new System.Drawing.Point(580, 12);
        grpDetails.Name = "grpDetails";
        grpDetails.Size = new System.Drawing.Size(392, 504);
        grpDetails.TabIndex = 3;
        grpDetails.Text = "Thông tin";
        //
        // lblName
        //
        lblName.AutoSize = true;
        lblName.Location = new System.Drawing.Point(12, 29);
        lblName.Name = "lblName";
        lblName.Size = new System.Drawing.Size(80, 15);
        lblName.TabIndex = 4;
        lblName.Text = "Tên thể loại";
        //
        // txtName
        //
        txtName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtName.Location = new System.Drawing.Point(110, 26);
        txtName.Name = "txtName";
        txtName.Size = new System.Drawing.Size(266, 23);
        txtName.TabIndex = 5;
        //
        // lblDescription
        //
        lblDescription.AutoSize = true;
        lblDescription.Location = new System.Drawing.Point(12, 61);
        lblDescription.Name = "lblDescription";
        lblDescription.Size = new System.Drawing.Size(80, 15);
        lblDescription.TabIndex = 6;
        lblDescription.Text = "Mô tả";
        //
        // txtDescription
        //
        txtDescription.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtDescription.Location = new System.Drawing.Point(110, 58);
        txtDescription.Name = "txtDescription";
        txtDescription.Size = new System.Drawing.Size(266, 90);
        txtDescription.TabIndex = 7;
        txtDescription.Multiline = true;
        txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        //
        // btnNew
        //
        btnNew.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        btnNew.Location = new System.Drawing.Point(580, 524);
        btnNew.Name = "btnNew";
        btnNew.Size = new System.Drawing.Size(90, 25);
        btnNew.TabIndex = 8;
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
        btnSave.TabIndex = 9;
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
        btnDelete.TabIndex = 10;
        btnDelete.Text = "Xóa";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        //
        // colName
        //
        colName.DataPropertyName = "Name";
        colName.HeaderText = "Tên thể loại";
        colName.Name = "colName";
        colName.ReadOnly = true;
        //
        // colDescription
        //
        colDescription.DataPropertyName = "Description";
        colDescription.HeaderText = "Mô tả";
        colDescription.Name = "colDescription";
        colDescription.ReadOnly = true;
        //
        // CategoryForm
        //
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(984, 561);
        Controls.Add(txtSearch);
        Controls.Add(btnSearch);
        Controls.Add(dgvCategories);
        Controls.Add(grpDetails);
        Controls.Add(btnNew);
        Controls.Add(btnSave);
        Controls.Add(btnDelete);
        Name = "CategoryForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Thể loại";
        Load += CategoryForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();
        grpDetails.ResumeLayout(false);
        grpDetails.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.DataGridView dgvCategories;
    private System.Windows.Forms.GroupBox grpDetails;
    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label lblDescription;
    private System.Windows.Forms.TextBox txtDescription;
    private System.Windows.Forms.Button btnNew;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.DataGridViewTextBoxColumn colName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
}
