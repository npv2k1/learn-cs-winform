namespace QuanLyThuVien.Views;

partial class MainForm
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
        menuStrip = new System.Windows.Forms.MenuStrip();
        mnuCatalog = new System.Windows.Forms.ToolStripMenuItem();
        mnuBooks = new System.Windows.Forms.ToolStripMenuItem();
        mnuCategories = new System.Windows.Forms.ToolStripMenuItem();
        mnuAuthors = new System.Windows.Forms.ToolStripMenuItem();
        mnuPublishers = new System.Windows.Forms.ToolStripMenuItem();
        mnuMembers = new System.Windows.Forms.ToolStripMenuItem();
        mnuLoans = new System.Windows.Forms.ToolStripMenuItem();
        grpTotalTitles = new System.Windows.Forms.GroupBox();
        lblTotalTitles = new System.Windows.Forms.Label();
        grpTotalCopies = new System.Windows.Forms.GroupBox();
        lblTotalCopies = new System.Windows.Forms.Label();
        grpCopiesOnLoan = new System.Windows.Forms.GroupBox();
        lblCopiesOnLoan = new System.Windows.Forms.Label();
        grpActiveMembers = new System.Windows.Forms.GroupBox();
        lblActiveMembers = new System.Windows.Forms.Label();
        grpOpenLoans = new System.Windows.Forms.GroupBox();
        lblOpenLoans = new System.Windows.Forms.Label();
        grpOverdueLoans = new System.Windows.Forms.GroupBox();
        lblOverdueLoans = new System.Windows.Forms.Label();
        lblOverdue = new System.Windows.Forms.Label();
        dgvOverdue = new System.Windows.Forms.DataGridView();
        colLoanId = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colMemberName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colBookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colDueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colDaysLate = new System.Windows.Forms.DataGridViewTextBoxColumn();
        menuStrip.SuspendLayout();
        grpTotalTitles.SuspendLayout();
        grpTotalCopies.SuspendLayout();
        grpCopiesOnLoan.SuspendLayout();
        grpActiveMembers.SuspendLayout();
        grpOpenLoans.SuspendLayout();
        grpOverdueLoans.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvOverdue).BeginInit();
        SuspendLayout();
        //
        // menuStrip
        //
        menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuCatalog, mnuMembers, mnuLoans });
        menuStrip.Location = new System.Drawing.Point(0, 0);
        menuStrip.Name = "menuStrip";
        menuStrip.Size = new System.Drawing.Size(984, 24);
        menuStrip.TabIndex = 0;
        //
        // mnuCatalog
        //
        mnuCatalog.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuBooks, mnuCategories, mnuAuthors, mnuPublishers });
        mnuCatalog.Name = "mnuCatalog";
        mnuCatalog.Size = new System.Drawing.Size(120, 20);
        mnuCatalog.Text = "Danh mục";
        //
        // mnuBooks
        //
        mnuBooks.Name = "mnuBooks";
        mnuBooks.Size = new System.Drawing.Size(120, 20);
        mnuBooks.Text = "Sách";
        mnuBooks.Click += mnuBooks_Click;
        //
        // mnuCategories
        //
        mnuCategories.Name = "mnuCategories";
        mnuCategories.Size = new System.Drawing.Size(120, 20);
        mnuCategories.Text = "Thể loại";
        mnuCategories.Click += mnuCategories_Click;
        //
        // mnuAuthors
        //
        mnuAuthors.Name = "mnuAuthors";
        mnuAuthors.Size = new System.Drawing.Size(120, 20);
        mnuAuthors.Text = "Tác giả";
        mnuAuthors.Click += mnuAuthors_Click;
        //
        // mnuPublishers
        //
        mnuPublishers.Name = "mnuPublishers";
        mnuPublishers.Size = new System.Drawing.Size(120, 20);
        mnuPublishers.Text = "Nhà xuất bản";
        mnuPublishers.Click += mnuPublishers_Click;
        //
        // mnuMembers
        //
        mnuMembers.Name = "mnuMembers";
        mnuMembers.Size = new System.Drawing.Size(120, 20);
        mnuMembers.Text = "Độc giả";
        mnuMembers.Click += mnuMembers_Click;
        //
        // mnuLoans
        //
        mnuLoans.Name = "mnuLoans";
        mnuLoans.Size = new System.Drawing.Size(120, 20);
        mnuLoans.Text = "Mượn trả";
        mnuLoans.Click += mnuLoans_Click;
        //
        // grpTotalTitles
        //
        grpTotalTitles.Controls.Add(lblTotalTitles);
        grpTotalTitles.Location = new System.Drawing.Point(12, 36);
        grpTotalTitles.Name = "grpTotalTitles";
        grpTotalTitles.Size = new System.Drawing.Size(155, 84);
        grpTotalTitles.TabIndex = 1;
        grpTotalTitles.TabStop = false;
        grpTotalTitles.Text = "Đầu sách";
        //
        // lblTotalTitles
        //
        lblTotalTitles.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        lblTotalTitles.Location = new System.Drawing.Point(6, 23);
        lblTotalTitles.Name = "lblTotalTitles";
        lblTotalTitles.Size = new System.Drawing.Size(143, 50);
        lblTotalTitles.TabIndex = 0;
        lblTotalTitles.Text = "0";
        lblTotalTitles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // grpTotalCopies
        //
        grpTotalCopies.Controls.Add(lblTotalCopies);
        grpTotalCopies.Location = new System.Drawing.Point(173, 36);
        grpTotalCopies.Name = "grpTotalCopies";
        grpTotalCopies.Size = new System.Drawing.Size(155, 84);
        grpTotalCopies.TabIndex = 2;
        grpTotalCopies.TabStop = false;
        grpTotalCopies.Text = "Tổng số bản";
        //
        // lblTotalCopies
        //
        lblTotalCopies.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        lblTotalCopies.Location = new System.Drawing.Point(6, 23);
        lblTotalCopies.Name = "lblTotalCopies";
        lblTotalCopies.Size = new System.Drawing.Size(143, 50);
        lblTotalCopies.TabIndex = 0;
        lblTotalCopies.Text = "0";
        lblTotalCopies.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // grpCopiesOnLoan
        //
        grpCopiesOnLoan.Controls.Add(lblCopiesOnLoan);
        grpCopiesOnLoan.Location = new System.Drawing.Point(334, 36);
        grpCopiesOnLoan.Name = "grpCopiesOnLoan";
        grpCopiesOnLoan.Size = new System.Drawing.Size(155, 84);
        grpCopiesOnLoan.TabIndex = 3;
        grpCopiesOnLoan.TabStop = false;
        grpCopiesOnLoan.Text = "Đang cho mượn";
        //
        // lblCopiesOnLoan
        //
        lblCopiesOnLoan.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        lblCopiesOnLoan.Location = new System.Drawing.Point(6, 23);
        lblCopiesOnLoan.Name = "lblCopiesOnLoan";
        lblCopiesOnLoan.Size = new System.Drawing.Size(143, 50);
        lblCopiesOnLoan.TabIndex = 0;
        lblCopiesOnLoan.Text = "0";
        lblCopiesOnLoan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // grpActiveMembers
        //
        grpActiveMembers.Controls.Add(lblActiveMembers);
        grpActiveMembers.Location = new System.Drawing.Point(495, 36);
        grpActiveMembers.Name = "grpActiveMembers";
        grpActiveMembers.Size = new System.Drawing.Size(155, 84);
        grpActiveMembers.TabIndex = 4;
        grpActiveMembers.TabStop = false;
        grpActiveMembers.Text = "Độc giả hoạt động";
        //
        // lblActiveMembers
        //
        lblActiveMembers.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        lblActiveMembers.Location = new System.Drawing.Point(6, 23);
        lblActiveMembers.Name = "lblActiveMembers";
        lblActiveMembers.Size = new System.Drawing.Size(143, 50);
        lblActiveMembers.TabIndex = 0;
        lblActiveMembers.Text = "0";
        lblActiveMembers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // grpOpenLoans
        //
        grpOpenLoans.Controls.Add(lblOpenLoans);
        grpOpenLoans.Location = new System.Drawing.Point(656, 36);
        grpOpenLoans.Name = "grpOpenLoans";
        grpOpenLoans.Size = new System.Drawing.Size(155, 84);
        grpOpenLoans.TabIndex = 5;
        grpOpenLoans.TabStop = false;
        grpOpenLoans.Text = "Phiếu đang mượn";
        //
        // lblOpenLoans
        //
        lblOpenLoans.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        lblOpenLoans.Location = new System.Drawing.Point(6, 23);
        lblOpenLoans.Name = "lblOpenLoans";
        lblOpenLoans.Size = new System.Drawing.Size(143, 50);
        lblOpenLoans.TabIndex = 0;
        lblOpenLoans.Text = "0";
        lblOpenLoans.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // grpOverdueLoans
        //
        grpOverdueLoans.Controls.Add(lblOverdueLoans);
        grpOverdueLoans.Location = new System.Drawing.Point(817, 36);
        grpOverdueLoans.Name = "grpOverdueLoans";
        grpOverdueLoans.Size = new System.Drawing.Size(155, 84);
        grpOverdueLoans.TabIndex = 6;
        grpOverdueLoans.TabStop = false;
        grpOverdueLoans.Text = "Phiếu quá hạn";
        //
        // lblOverdueLoans
        //
        lblOverdueLoans.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        lblOverdueLoans.ForeColor = System.Drawing.Color.Firebrick;
        lblOverdueLoans.Location = new System.Drawing.Point(6, 23);
        lblOverdueLoans.Name = "lblOverdueLoans";
        lblOverdueLoans.Size = new System.Drawing.Size(143, 50);
        lblOverdueLoans.TabIndex = 0;
        lblOverdueLoans.Text = "0";
        lblOverdueLoans.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //
        // lblOverdue
        //
        lblOverdue.AutoSize = true;
        lblOverdue.Location = new System.Drawing.Point(12, 132);
        lblOverdue.Name = "lblOverdue";
        lblOverdue.Size = new System.Drawing.Size(120, 15);
        lblOverdue.TabIndex = 7;
        lblOverdue.Text = "Sách quá hạn chưa trả";
        //
        // dgvOverdue
        //
        dgvOverdue.AllowUserToAddRows = false;
        dgvOverdue.AllowUserToDeleteRows = false;
        dgvOverdue.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dgvOverdue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvOverdue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvOverdue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colLoanId, colMemberName, colBookTitle, colDueDate, colDaysLate });
        dgvOverdue.Location = new System.Drawing.Point(12, 152);
        dgvOverdue.MultiSelect = false;
        dgvOverdue.Name = "dgvOverdue";
        dgvOverdue.ReadOnly = true;
        dgvOverdue.RowHeadersVisible = false;
        dgvOverdue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvOverdue.Size = new System.Drawing.Size(960, 397);
        dgvOverdue.TabIndex = 8;
        //
        // colLoanId
        //
        colLoanId.DataPropertyName = "LoanId";
        colLoanId.HeaderText = "Số phiếu";
        colLoanId.Name = "colLoanId";
        colLoanId.ReadOnly = true;
        //
        // colMemberName
        //
        colMemberName.DataPropertyName = "MemberName";
        colMemberName.HeaderText = "Độc giả";
        colMemberName.Name = "colMemberName";
        colMemberName.ReadOnly = true;
        //
        // colBookTitle
        //
        colBookTitle.DataPropertyName = "BookTitle";
        colBookTitle.HeaderText = "Tên sách";
        colBookTitle.Name = "colBookTitle";
        colBookTitle.ReadOnly = true;
        //
        // colDueDate
        //
        colDueDate.DataPropertyName = "DueDate";
        colDueDate.HeaderText = "Hạn trả";
        colDueDate.Name = "colDueDate";
        colDueDate.ReadOnly = true;
        //
        // colDaysLate
        //
        colDaysLate.DataPropertyName = "DaysLate";
        colDaysLate.HeaderText = "Số ngày trễ";
        colDaysLate.Name = "colDaysLate";
        colDaysLate.ReadOnly = true;
        //
        // MainForm
        //
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(984, 561);
        Controls.Add(grpTotalTitles);
        Controls.Add(grpTotalCopies);
        Controls.Add(grpCopiesOnLoan);
        Controls.Add(grpActiveMembers);
        Controls.Add(grpOpenLoans);
        Controls.Add(grpOverdueLoans);
        Controls.Add(lblOverdue);
        Controls.Add(dgvOverdue);
        Controls.Add(menuStrip);
        MainMenuStrip = menuStrip;
        Name = "MainForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Quản lý thư viện";
        Load += MainForm_Load;
        menuStrip.ResumeLayout(false);
        menuStrip.PerformLayout();
        grpTotalTitles.ResumeLayout(false);
        grpTotalCopies.ResumeLayout(false);
        grpCopiesOnLoan.ResumeLayout(false);
        grpActiveMembers.ResumeLayout(false);
        grpOpenLoans.ResumeLayout(false);
        grpOverdueLoans.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvOverdue).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem mnuCatalog;
    private System.Windows.Forms.ToolStripMenuItem mnuBooks;
    private System.Windows.Forms.ToolStripMenuItem mnuCategories;
    private System.Windows.Forms.ToolStripMenuItem mnuAuthors;
    private System.Windows.Forms.ToolStripMenuItem mnuPublishers;
    private System.Windows.Forms.ToolStripMenuItem mnuMembers;
    private System.Windows.Forms.ToolStripMenuItem mnuLoans;
    private System.Windows.Forms.GroupBox grpTotalTitles;
    private System.Windows.Forms.Label lblTotalTitles;
    private System.Windows.Forms.GroupBox grpTotalCopies;
    private System.Windows.Forms.Label lblTotalCopies;
    private System.Windows.Forms.GroupBox grpCopiesOnLoan;
    private System.Windows.Forms.Label lblCopiesOnLoan;
    private System.Windows.Forms.GroupBox grpActiveMembers;
    private System.Windows.Forms.Label lblActiveMembers;
    private System.Windows.Forms.GroupBox grpOpenLoans;
    private System.Windows.Forms.Label lblOpenLoans;
    private System.Windows.Forms.GroupBox grpOverdueLoans;
    private System.Windows.Forms.Label lblOverdueLoans;
    private System.Windows.Forms.Label lblOverdue;
    private System.Windows.Forms.DataGridView dgvOverdue;
    private System.Windows.Forms.DataGridViewTextBoxColumn colLoanId;
    private System.Windows.Forms.DataGridViewTextBoxColumn colMemberName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colBookTitle;
    private System.Windows.Forms.DataGridViewTextBoxColumn colDueDate;
    private System.Windows.Forms.DataGridViewTextBoxColumn colDaysLate;
}
