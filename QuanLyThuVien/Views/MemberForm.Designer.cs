namespace QuanLyThuVien.Views;

partial class MemberForm
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
        dgvMembers = new System.Windows.Forms.DataGridView();
        grpDetails = new System.Windows.Forms.GroupBox();
        lblMemberCode = new System.Windows.Forms.Label();
        txtMemberCode = new System.Windows.Forms.TextBox();
        lblFullName = new System.Windows.Forms.Label();
        txtFullName = new System.Windows.Forms.TextBox();
        lblPhone = new System.Windows.Forms.Label();
        txtPhone = new System.Windows.Forms.TextBox();
        lblEmail = new System.Windows.Forms.Label();
        txtEmail = new System.Windows.Forms.TextBox();
        lblAddress = new System.Windows.Forms.Label();
        txtAddress = new System.Windows.Forms.TextBox();
        lblJoinedDate = new System.Windows.Forms.Label();
        dtpJoinedDate = new System.Windows.Forms.DateTimePicker();
        lblExpiryDate = new System.Windows.Forms.Label();
        dtpExpiryDate = new System.Windows.Forms.DateTimePicker();
        lblIsActive = new System.Windows.Forms.Label();
        chkIsActive = new System.Windows.Forms.CheckBox();
        btnNew = new System.Windows.Forms.Button();
        btnSave = new System.Windows.Forms.Button();
        btnDelete = new System.Windows.Forms.Button();
        colMemberCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colExpiryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
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
        // dgvMembers
        //
        dgvMembers.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dgvMembers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colMemberCode, colFullName, colPhone, colExpiryDate });
        dgvMembers.Location = new System.Drawing.Point(12, 43);
        dgvMembers.Name = "dgvMembers";
        dgvMembers.Size = new System.Drawing.Size(556, 506);
        dgvMembers.TabIndex = 2;
        dgvMembers.AllowUserToAddRows = false;
        dgvMembers.AllowUserToDeleteRows = false;
        dgvMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvMembers.MultiSelect = false;
        dgvMembers.ReadOnly = true;
        dgvMembers.RowHeadersVisible = false;
        dgvMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvMembers.SelectionChanged += dgvMembers_SelectionChanged;
        //
        // grpDetails
        //
        grpDetails.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        grpDetails.Controls.Add(lblMemberCode);
        grpDetails.Controls.Add(txtMemberCode);
        grpDetails.Controls.Add(lblFullName);
        grpDetails.Controls.Add(txtFullName);
        grpDetails.Controls.Add(lblPhone);
        grpDetails.Controls.Add(txtPhone);
        grpDetails.Controls.Add(lblEmail);
        grpDetails.Controls.Add(txtEmail);
        grpDetails.Controls.Add(lblAddress);
        grpDetails.Controls.Add(txtAddress);
        grpDetails.Controls.Add(lblJoinedDate);
        grpDetails.Controls.Add(dtpJoinedDate);
        grpDetails.Controls.Add(lblExpiryDate);
        grpDetails.Controls.Add(dtpExpiryDate);
        grpDetails.Controls.Add(lblIsActive);
        grpDetails.Controls.Add(chkIsActive);
        grpDetails.Location = new System.Drawing.Point(580, 12);
        grpDetails.Name = "grpDetails";
        grpDetails.Size = new System.Drawing.Size(392, 504);
        grpDetails.TabIndex = 3;
        grpDetails.Text = "Thông tin";
        //
        // lblMemberCode
        //
        lblMemberCode.AutoSize = true;
        lblMemberCode.Location = new System.Drawing.Point(12, 29);
        lblMemberCode.Name = "lblMemberCode";
        lblMemberCode.Size = new System.Drawing.Size(80, 15);
        lblMemberCode.TabIndex = 4;
        lblMemberCode.Text = "Mã thẻ";
        //
        // txtMemberCode
        //
        txtMemberCode.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtMemberCode.Location = new System.Drawing.Point(110, 26);
        txtMemberCode.Name = "txtMemberCode";
        txtMemberCode.Size = new System.Drawing.Size(266, 23);
        txtMemberCode.TabIndex = 5;
        //
        // lblFullName
        //
        lblFullName.AutoSize = true;
        lblFullName.Location = new System.Drawing.Point(12, 61);
        lblFullName.Name = "lblFullName";
        lblFullName.Size = new System.Drawing.Size(80, 15);
        lblFullName.TabIndex = 6;
        lblFullName.Text = "Họ tên";
        //
        // txtFullName
        //
        txtFullName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtFullName.Location = new System.Drawing.Point(110, 58);
        txtFullName.Name = "txtFullName";
        txtFullName.Size = new System.Drawing.Size(266, 23);
        txtFullName.TabIndex = 7;
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
        // lblEmail
        //
        lblEmail.AutoSize = true;
        lblEmail.Location = new System.Drawing.Point(12, 125);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new System.Drawing.Size(80, 15);
        lblEmail.TabIndex = 10;
        lblEmail.Text = "Email";
        //
        // txtEmail
        //
        txtEmail.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtEmail.Location = new System.Drawing.Point(110, 122);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new System.Drawing.Size(266, 23);
        txtEmail.TabIndex = 11;
        //
        // lblAddress
        //
        lblAddress.AutoSize = true;
        lblAddress.Location = new System.Drawing.Point(12, 157);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new System.Drawing.Size(80, 15);
        lblAddress.TabIndex = 12;
        lblAddress.Text = "Địa chỉ";
        //
        // txtAddress
        //
        txtAddress.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtAddress.Location = new System.Drawing.Point(110, 154);
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new System.Drawing.Size(266, 23);
        txtAddress.TabIndex = 13;
        //
        // lblJoinedDate
        //
        lblJoinedDate.AutoSize = true;
        lblJoinedDate.Location = new System.Drawing.Point(12, 189);
        lblJoinedDate.Name = "lblJoinedDate";
        lblJoinedDate.Size = new System.Drawing.Size(80, 15);
        lblJoinedDate.TabIndex = 14;
        lblJoinedDate.Text = "Ngày cấp thẻ";
        //
        // dtpJoinedDate
        //
        dtpJoinedDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dtpJoinedDate.Location = new System.Drawing.Point(110, 186);
        dtpJoinedDate.Name = "dtpJoinedDate";
        dtpJoinedDate.Size = new System.Drawing.Size(266, 23);
        dtpJoinedDate.TabIndex = 15;
        dtpJoinedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        //
        // lblExpiryDate
        //
        lblExpiryDate.AutoSize = true;
        lblExpiryDate.Location = new System.Drawing.Point(12, 221);
        lblExpiryDate.Name = "lblExpiryDate";
        lblExpiryDate.Size = new System.Drawing.Size(80, 15);
        lblExpiryDate.TabIndex = 16;
        lblExpiryDate.Text = "Ngày hết hạn";
        //
        // dtpExpiryDate
        //
        dtpExpiryDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dtpExpiryDate.Location = new System.Drawing.Point(110, 218);
        dtpExpiryDate.Name = "dtpExpiryDate";
        dtpExpiryDate.Size = new System.Drawing.Size(266, 23);
        dtpExpiryDate.TabIndex = 17;
        dtpExpiryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        //
        // lblIsActive
        //
        lblIsActive.AutoSize = true;
        lblIsActive.Location = new System.Drawing.Point(12, 253);
        lblIsActive.Name = "lblIsActive";
        lblIsActive.Size = new System.Drawing.Size(80, 15);
        lblIsActive.TabIndex = 18;
        lblIsActive.Text = "Trạng thái";
        //
        // chkIsActive
        //
        chkIsActive.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        chkIsActive.Location = new System.Drawing.Point(110, 250);
        chkIsActive.Name = "chkIsActive";
        chkIsActive.Size = new System.Drawing.Size(266, 23);
        chkIsActive.TabIndex = 19;
        chkIsActive.Text = "Đang hoạt động";
        chkIsActive.UseVisualStyleBackColor = true;
        //
        // btnNew
        //
        btnNew.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        btnNew.Location = new System.Drawing.Point(580, 524);
        btnNew.Name = "btnNew";
        btnNew.Size = new System.Drawing.Size(90, 25);
        btnNew.TabIndex = 20;
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
        btnSave.TabIndex = 21;
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
        btnDelete.TabIndex = 22;
        btnDelete.Text = "Xóa";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        //
        // colMemberCode
        //
        colMemberCode.DataPropertyName = "MemberCode";
        colMemberCode.HeaderText = "Mã thẻ";
        colMemberCode.Name = "colMemberCode";
        colMemberCode.ReadOnly = true;
        //
        // colFullName
        //
        colFullName.DataPropertyName = "FullName";
        colFullName.HeaderText = "Họ tên";
        colFullName.Name = "colFullName";
        colFullName.ReadOnly = true;
        //
        // colPhone
        //
        colPhone.DataPropertyName = "Phone";
        colPhone.HeaderText = "Điện thoại";
        colPhone.Name = "colPhone";
        colPhone.ReadOnly = true;
        //
        // colExpiryDate
        //
        colExpiryDate.DataPropertyName = "ExpiryDate";
        colExpiryDate.HeaderText = "Hết hạn";
        colExpiryDate.Name = "colExpiryDate";
        colExpiryDate.ReadOnly = true;
        //
        // MemberForm
        //
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(984, 561);
        Controls.Add(txtSearch);
        Controls.Add(btnSearch);
        Controls.Add(dgvMembers);
        Controls.Add(grpDetails);
        Controls.Add(btnNew);
        Controls.Add(btnSave);
        Controls.Add(btnDelete);
        Name = "MemberForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Độc giả";
        Load += MemberForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
        grpDetails.ResumeLayout(false);
        grpDetails.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.DataGridView dgvMembers;
    private System.Windows.Forms.GroupBox grpDetails;
    private System.Windows.Forms.Label lblMemberCode;
    private System.Windows.Forms.TextBox txtMemberCode;
    private System.Windows.Forms.Label lblFullName;
    private System.Windows.Forms.TextBox txtFullName;
    private System.Windows.Forms.Label lblPhone;
    private System.Windows.Forms.TextBox txtPhone;
    private System.Windows.Forms.Label lblEmail;
    private System.Windows.Forms.TextBox txtEmail;
    private System.Windows.Forms.Label lblAddress;
    private System.Windows.Forms.TextBox txtAddress;
    private System.Windows.Forms.Label lblJoinedDate;
    private System.Windows.Forms.DateTimePicker dtpJoinedDate;
    private System.Windows.Forms.Label lblExpiryDate;
    private System.Windows.Forms.DateTimePicker dtpExpiryDate;
    private System.Windows.Forms.Label lblIsActive;
    private System.Windows.Forms.CheckBox chkIsActive;
    private System.Windows.Forms.Button btnNew;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.DataGridViewTextBoxColumn colMemberCode;
    private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
    private System.Windows.Forms.DataGridViewTextBoxColumn colExpiryDate;
}
