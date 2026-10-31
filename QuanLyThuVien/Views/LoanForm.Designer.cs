namespace QuanLyThuVien.Views;

partial class LoanForm
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
        btnCreateLoan = new System.Windows.Forms.Button();
        dgvLoans = new System.Windows.Forms.DataGridView();
        lblItems = new System.Windows.Forms.Label();
        btnReturn = new System.Windows.Forms.Button();
        dgvItems = new System.Windows.Forms.DataGridView();
        colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colMemberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colLoanDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colDueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colBookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colReturnedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colFineAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvLoans).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
        SuspendLayout();
        //
        // txtSearch
        //
        txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtSearch.Location = new System.Drawing.Point(12, 12);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new System.Drawing.Size(640, 23);
        txtSearch.TabIndex = 0;
        txtSearch.PlaceholderText = "Nhập tên hoặc mã thẻ độc giả";
        //
        // btnSearch
        //
        btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        btnSearch.Location = new System.Drawing.Point(658, 11);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new System.Drawing.Size(80, 25);
        btnSearch.TabIndex = 1;
        btnSearch.Text = "Tìm";
        btnSearch.UseVisualStyleBackColor = true;
        btnSearch.Click += btnSearch_Click;
        //
        // btnCreateLoan
        //
        btnCreateLoan.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        btnCreateLoan.Location = new System.Drawing.Point(744, 11);
        btnCreateLoan.Name = "btnCreateLoan";
        btnCreateLoan.Size = new System.Drawing.Size(228, 25);
        btnCreateLoan.TabIndex = 2;
        btnCreateLoan.Text = "Tạo phiếu mượn";
        btnCreateLoan.UseVisualStyleBackColor = true;
        btnCreateLoan.Click += btnCreateLoan_Click;
        //
        // dgvLoans
        //
        dgvLoans.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dgvLoans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colId, colMemberName, colLoanDate, colDueDate, colStatus });
        dgvLoans.Location = new System.Drawing.Point(12, 43);
        dgvLoans.Name = "dgvLoans";
        dgvLoans.Size = new System.Drawing.Size(960, 280);
        dgvLoans.TabIndex = 3;
        dgvLoans.AllowUserToAddRows = false;
        dgvLoans.AllowUserToDeleteRows = false;
        dgvLoans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvLoans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvLoans.MultiSelect = false;
        dgvLoans.ReadOnly = true;
        dgvLoans.RowHeadersVisible = false;
        dgvLoans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvLoans.SelectionChanged += dgvLoans_SelectionChanged;
        //
        // lblItems
        //
        lblItems.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
        lblItems.AutoSize = true;
        lblItems.Location = new System.Drawing.Point(12, 336);
        lblItems.Name = "lblItems";
        lblItems.Size = new System.Drawing.Size(80, 15);
        lblItems.TabIndex = 4;
        lblItems.Text = "Sách trong phiếu";
        //
        // btnReturn
        //
        btnReturn.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        btnReturn.Location = new System.Drawing.Point(832, 331);
        btnReturn.Name = "btnReturn";
        btnReturn.Size = new System.Drawing.Size(140, 25);
        btnReturn.TabIndex = 5;
        btnReturn.Text = "Trả sách đã chọn";
        btnReturn.UseVisualStyleBackColor = true;
        btnReturn.Click += btnReturn_Click;
        //
        // dgvItems
        //
        dgvItems.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colBookTitle, colReturnedDate, colFineAmount });
        dgvItems.Location = new System.Drawing.Point(12, 361);
        dgvItems.Name = "dgvItems";
        dgvItems.Size = new System.Drawing.Size(960, 238);
        dgvItems.TabIndex = 6;
        dgvItems.AllowUserToAddRows = false;
        dgvItems.AllowUserToDeleteRows = false;
        dgvItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvItems.MultiSelect = false;
        dgvItems.ReadOnly = true;
        dgvItems.RowHeadersVisible = false;
        dgvItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        //
        // colId
        //
        colId.DataPropertyName = "Id";
        colId.HeaderText = "Số phiếu";
        colId.Name = "colId";
        colId.ReadOnly = true;
        //
        // colMemberName
        //
        colMemberName.DataPropertyName = "MemberName";
        colMemberName.HeaderText = "Độc giả";
        colMemberName.Name = "colMemberName";
        colMemberName.ReadOnly = true;
        //
        // colLoanDate
        //
        colLoanDate.DataPropertyName = "LoanDate";
        colLoanDate.HeaderText = "Ngày mượn";
        colLoanDate.Name = "colLoanDate";
        colLoanDate.ReadOnly = true;
        //
        // colDueDate
        //
        colDueDate.DataPropertyName = "DueDate";
        colDueDate.HeaderText = "Hạn trả";
        colDueDate.Name = "colDueDate";
        colDueDate.ReadOnly = true;
        //
        // colStatus
        //
        colStatus.DataPropertyName = "Status";
        colStatus.HeaderText = "Trạng thái";
        colStatus.Name = "colStatus";
        colStatus.ReadOnly = true;
        //
        // colBookTitle
        //
        colBookTitle.DataPropertyName = "BookTitle";
        colBookTitle.HeaderText = "Tên sách";
        colBookTitle.Name = "colBookTitle";
        colBookTitle.ReadOnly = true;
        //
        // colReturnedDate
        //
        colReturnedDate.DataPropertyName = "ReturnedDate";
        colReturnedDate.HeaderText = "Ngày trả";
        colReturnedDate.Name = "colReturnedDate";
        colReturnedDate.ReadOnly = true;
        //
        // colFineAmount
        //
        colFineAmount.DataPropertyName = "FineAmount";
        colFineAmount.HeaderText = "Tiền phạt";
        colFineAmount.Name = "colFineAmount";
        colFineAmount.ReadOnly = true;
        //
        // LoanForm
        //
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(984, 611);
        Controls.Add(txtSearch);
        Controls.Add(btnSearch);
        Controls.Add(btnCreateLoan);
        Controls.Add(dgvLoans);
        Controls.Add(lblItems);
        Controls.Add(btnReturn);
        Controls.Add(dgvItems);
        Name = "LoanForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Mượn trả sách";
        Load += LoanForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvLoans).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.Button btnCreateLoan;
    private System.Windows.Forms.DataGridView dgvLoans;
    private System.Windows.Forms.Label lblItems;
    private System.Windows.Forms.Button btnReturn;
    private System.Windows.Forms.DataGridView dgvItems;
    private System.Windows.Forms.DataGridViewTextBoxColumn colId;
    private System.Windows.Forms.DataGridViewTextBoxColumn colMemberName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colLoanDate;
    private System.Windows.Forms.DataGridViewTextBoxColumn colDueDate;
    private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    private System.Windows.Forms.DataGridViewTextBoxColumn colBookTitle;
    private System.Windows.Forms.DataGridViewTextBoxColumn colReturnedDate;
    private System.Windows.Forms.DataGridViewTextBoxColumn colFineAmount;
}
