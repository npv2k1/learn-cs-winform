namespace QuanLyThuVien.Views;

partial class PublisherForm
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
        dgvPublishers = new System.Windows.Forms.DataGridView();
        grpDetails = new System.Windows.Forms.GroupBox();
        lblName = new System.Windows.Forms.Label();
        txtName = new System.Windows.Forms.TextBox();
        lblAddress = new System.Windows.Forms.Label();
        txtAddress = new System.Windows.Forms.TextBox();
        lblPhone = new System.Windows.Forms.Label();
        txtPhone = new System.Windows.Forms.TextBox();
        btnNew = new System.Windows.Forms.Button();
        btnSave = new System.Windows.Forms.Button();
        btnDelete = new System.Windows.Forms.Button();
        colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvPublishers).BeginInit();
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
        // dgvPublishers
        //
        dgvPublishers.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dgvPublishers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colName, colAddress, colPhone });
        dgvPublishers.Location = new System.Drawing.Point(12, 43);
        dgvPublishers.Name = "dgvPublishers";
        dgvPublishers.Size = new System.Drawing.Size(556, 506);
        dgvPublishers.TabIndex = 2;
        dgvPublishers.AllowUserToAddRows = false;
        dgvPublishers.AllowUserToDeleteRows = false;
        dgvPublishers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvPublishers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvPublishers.MultiSelect = false;
        dgvPublishers.ReadOnly = true;
        dgvPublishers.RowHeadersVisible = false;
        dgvPublishers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvPublishers.SelectionChanged += dgvPublishers_SelectionChanged;
        //
        // grpDetails
        //
        grpDetails.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        grpDetails.Controls.Add(lblName);
        grpDetails.Controls.Add(txtName);
        grpDetails.Controls.Add(lblAddress);
        grpDetails.Controls.Add(txtAddress);
        grpDetails.Controls.Add(lblPhone);
        grpDetails.Controls.Add(txtPhone);
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
        lblName.Text = "Tên";
        //
        // txtName
        //
        txtName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtName.Location = new System.Drawing.Point(110, 26);
        txtName.Name = "txtName";
        txtName.Size = new System.Drawing.Size(266, 23);
        txtName.TabIndex = 5;
        //
        // lblAddress
        //
        lblAddress.AutoSize = true;
        lblAddress.Location = new System.Drawing.Point(12, 61);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new System.Drawing.Size(80, 15);
        lblAddress.TabIndex = 6;
        lblAddress.Text = "Địa chỉ";
        //
        // txtAddress
        //
        txtAddress.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtAddress.Location = new System.Drawing.Point(110, 58);
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new System.Drawing.Size(266, 23);
        txtAddress.TabIndex = 7;
        //
        // lblPhone
        //
        lblPhone.AutoSize = true;
        lblPhone.Location = new System.Drawing.Point(12, 93);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new System.Drawing.Size(80, 15);
        lblPhone.TabIndex = 8;
        lblPhone.Text = "Điện thoại";
        //
        // txtPhone
        //
        txtPhone.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtPhone.Location = new System.Drawing.Point(110, 90);
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new System.Drawing.Size(266, 23);
        txtPhone.TabIndex = 9;
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
        // colName
        //
        colName.DataPropertyName = "Name";
        colName.HeaderText = "Tên nhà xuất bản";
        colName.Name = "colName";
        colName.ReadOnly = true;
        //
        // colAddress
        //
        colAddress.DataPropertyName = "Address";
        colAddress.HeaderText = "Địa chỉ";
        colAddress.Name = "colAddress";
        colAddress.ReadOnly = true;
        //
        // colPhone
        //
        colPhone.DataPropertyName = "Phone";
        colPhone.HeaderText = "Điện thoại";
        colPhone.Name = "colPhone";
        colPhone.ReadOnly = true;
        //
        // PublisherForm
        //
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(984, 561);
        Controls.Add(txtSearch);
        Controls.Add(btnSearch);
        Controls.Add(dgvPublishers);
        Controls.Add(grpDetails);
        Controls.Add(btnNew);
        Controls.Add(btnSave);
        Controls.Add(btnDelete);
        Name = "PublisherForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Nhà xuất bản";
        Load += PublisherForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvPublishers).EndInit();
        grpDetails.ResumeLayout(false);
        grpDetails.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.DataGridView dgvPublishers;
    private System.Windows.Forms.GroupBox grpDetails;
    private System.Windows.Forms.Label lblName;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label lblAddress;
    private System.Windows.Forms.TextBox txtAddress;
    private System.Windows.Forms.Label lblPhone;
    private System.Windows.Forms.TextBox txtPhone;
    private System.Windows.Forms.Button btnNew;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.DataGridViewTextBoxColumn colName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
}
