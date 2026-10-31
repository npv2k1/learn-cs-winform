namespace QuanLyThuVien.Views;

partial class BookForm
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
        dgvBooks = new System.Windows.Forms.DataGridView();
        grpDetails = new System.Windows.Forms.GroupBox();
        lblTitle = new System.Windows.Forms.Label();
        txtTitle = new System.Windows.Forms.TextBox();
        lblIsbn = new System.Windows.Forms.Label();
        txtIsbn = new System.Windows.Forms.TextBox();
        lblCategory = new System.Windows.Forms.Label();
        cboCategory = new System.Windows.Forms.ComboBox();
        lblPublisher = new System.Windows.Forms.Label();
        cboPublisher = new System.Windows.Forms.ComboBox();
        lblPublishedYear = new System.Windows.Forms.Label();
        nudPublishedYear = new System.Windows.Forms.NumericUpDown();
        lblTotalCopies = new System.Windows.Forms.Label();
        nudTotalCopies = new System.Windows.Forms.NumericUpDown();
        lblAuthors = new System.Windows.Forms.Label();
        clbAuthors = new System.Windows.Forms.CheckedListBox();
        btnNew = new System.Windows.Forms.Button();
        btnSave = new System.Windows.Forms.Button();
        btnDelete = new System.Windows.Forms.Button();
        colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colAuthorNames = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colCategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colPublisherName = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colAvailableCopies = new System.Windows.Forms.DataGridViewTextBoxColumn();
        colTotalCopies = new System.Windows.Forms.DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudPublishedYear).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudTotalCopies).BeginInit();
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
        // dgvBooks
        //
        dgvBooks.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dgvBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { colTitle, colAuthorNames, colCategoryName, colPublisherName, colAvailableCopies, colTotalCopies });
        dgvBooks.Location = new System.Drawing.Point(12, 43);
        dgvBooks.Name = "dgvBooks";
        dgvBooks.Size = new System.Drawing.Size(556, 506);
        dgvBooks.TabIndex = 2;
        dgvBooks.AllowUserToAddRows = false;
        dgvBooks.AllowUserToDeleteRows = false;
        dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvBooks.MultiSelect = false;
        dgvBooks.ReadOnly = true;
        dgvBooks.RowHeadersVisible = false;
        dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        dgvBooks.SelectionChanged += dgvBooks_SelectionChanged;
        //
        // grpDetails
        //
        grpDetails.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        grpDetails.Controls.Add(lblTitle);
        grpDetails.Controls.Add(txtTitle);
        grpDetails.Controls.Add(lblIsbn);
        grpDetails.Controls.Add(txtIsbn);
        grpDetails.Controls.Add(lblCategory);
        grpDetails.Controls.Add(cboCategory);
        grpDetails.Controls.Add(lblPublisher);
        grpDetails.Controls.Add(cboPublisher);
        grpDetails.Controls.Add(lblPublishedYear);
        grpDetails.Controls.Add(nudPublishedYear);
        grpDetails.Controls.Add(lblTotalCopies);
        grpDetails.Controls.Add(nudTotalCopies);
        grpDetails.Controls.Add(lblAuthors);
        grpDetails.Controls.Add(clbAuthors);
        grpDetails.Location = new System.Drawing.Point(580, 12);
        grpDetails.Name = "grpDetails";
        grpDetails.Size = new System.Drawing.Size(392, 504);
        grpDetails.TabIndex = 3;
        grpDetails.Text = "Thông tin";
        //
        // lblTitle
        //
        lblTitle.AutoSize = true;
        lblTitle.Location = new System.Drawing.Point(12, 29);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new System.Drawing.Size(80, 15);
        lblTitle.TabIndex = 4;
        lblTitle.Text = "Tên sách";
        //
        // txtTitle
        //
        txtTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtTitle.Location = new System.Drawing.Point(110, 26);
        txtTitle.Name = "txtTitle";
        txtTitle.Size = new System.Drawing.Size(266, 23);
        txtTitle.TabIndex = 5;
        //
        // lblIsbn
        //
        lblIsbn.AutoSize = true;
        lblIsbn.Location = new System.Drawing.Point(12, 61);
        lblIsbn.Name = "lblIsbn";
        lblIsbn.Size = new System.Drawing.Size(80, 15);
        lblIsbn.TabIndex = 6;
        lblIsbn.Text = "ISBN";
        //
        // txtIsbn
        //
        txtIsbn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        txtIsbn.Location = new System.Drawing.Point(110, 58);
        txtIsbn.Name = "txtIsbn";
        txtIsbn.Size = new System.Drawing.Size(266, 23);
        txtIsbn.TabIndex = 7;
        //
        // lblCategory
        //
        lblCategory.AutoSize = true;
        lblCategory.Location = new System.Drawing.Point(12, 93);
        lblCategory.Name = "lblCategory";
        lblCategory.Size = new System.Drawing.Size(80, 15);
        lblCategory.TabIndex = 8;
        lblCategory.Text = "Thể loại";
        //
        // cboCategory
        //
        cboCategory.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        cboCategory.Location = new System.Drawing.Point(110, 90);
        cboCategory.Name = "cboCategory";
        cboCategory.Size = new System.Drawing.Size(266, 23);
        cboCategory.TabIndex = 9;
        cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboCategory.FormattingEnabled = true;
        //
        // lblPublisher
        //
        lblPublisher.AutoSize = true;
        lblPublisher.Location = new System.Drawing.Point(12, 125);
        lblPublisher.Name = "lblPublisher";
        lblPublisher.Size = new System.Drawing.Size(80, 15);
        lblPublisher.TabIndex = 10;
        lblPublisher.Text = "Nhà xuất bản";
        //
        // cboPublisher
        //
        cboPublisher.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        cboPublisher.Location = new System.Drawing.Point(110, 122);
        cboPublisher.Name = "cboPublisher";
        cboPublisher.Size = new System.Drawing.Size(266, 23);
        cboPublisher.TabIndex = 11;
        cboPublisher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboPublisher.FormattingEnabled = true;
        //
        // lblPublishedYear
        //
        lblPublishedYear.AutoSize = true;
        lblPublishedYear.Location = new System.Drawing.Point(12, 157);
        lblPublishedYear.Name = "lblPublishedYear";
        lblPublishedYear.Size = new System.Drawing.Size(80, 15);
        lblPublishedYear.TabIndex = 12;
        lblPublishedYear.Text = "Năm xuất bản";
        //
        // nudPublishedYear
        //
        nudPublishedYear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        nudPublishedYear.Location = new System.Drawing.Point(110, 154);
        nudPublishedYear.Name = "nudPublishedYear";
        nudPublishedYear.Size = new System.Drawing.Size(266, 23);
        nudPublishedYear.TabIndex = 13;
        nudPublishedYear.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        //
        // lblTotalCopies
        //
        lblTotalCopies.AutoSize = true;
        lblTotalCopies.Location = new System.Drawing.Point(12, 189);
        lblTotalCopies.Name = "lblTotalCopies";
        lblTotalCopies.Size = new System.Drawing.Size(80, 15);
        lblTotalCopies.TabIndex = 14;
        lblTotalCopies.Text = "Tổng số bản";
        //
        // nudTotalCopies
        //
        nudTotalCopies.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        nudTotalCopies.Location = new System.Drawing.Point(110, 186);
        nudTotalCopies.Name = "nudTotalCopies";
        nudTotalCopies.Size = new System.Drawing.Size(266, 23);
        nudTotalCopies.TabIndex = 15;
        nudTotalCopies.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        //
        // lblAuthors
        //
        lblAuthors.AutoSize = true;
        lblAuthors.Location = new System.Drawing.Point(12, 221);
        lblAuthors.Name = "lblAuthors";
        lblAuthors.Size = new System.Drawing.Size(80, 15);
        lblAuthors.TabIndex = 16;
        lblAuthors.Text = "Tác giả";
        //
        // clbAuthors
        //
        clbAuthors.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        clbAuthors.Location = new System.Drawing.Point(110, 218);
        clbAuthors.Name = "clbAuthors";
        clbAuthors.Size = new System.Drawing.Size(266, 130);
        clbAuthors.TabIndex = 17;
        clbAuthors.CheckOnClick = true;
        clbAuthors.FormattingEnabled = true;
        //
        // btnNew
        //
        btnNew.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        btnNew.Location = new System.Drawing.Point(580, 524);
        btnNew.Name = "btnNew";
        btnNew.Size = new System.Drawing.Size(90, 25);
        btnNew.TabIndex = 18;
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
        btnSave.TabIndex = 19;
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
        btnDelete.TabIndex = 20;
        btnDelete.Text = "Xóa";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        //
        // colTitle
        //
        colTitle.DataPropertyName = "Title";
        colTitle.HeaderText = "Tên sách";
        colTitle.Name = "colTitle";
        colTitle.ReadOnly = true;
        //
        // colAuthorNames
        //
        colAuthorNames.DataPropertyName = "AuthorNames";
        colAuthorNames.HeaderText = "Tác giả";
        colAuthorNames.Name = "colAuthorNames";
        colAuthorNames.ReadOnly = true;
        //
        // colCategoryName
        //
        colCategoryName.DataPropertyName = "CategoryName";
        colCategoryName.HeaderText = "Thể loại";
        colCategoryName.Name = "colCategoryName";
        colCategoryName.ReadOnly = true;
        //
        // colPublisherName
        //
        colPublisherName.DataPropertyName = "PublisherName";
        colPublisherName.HeaderText = "Nhà xuất bản";
        colPublisherName.Name = "colPublisherName";
        colPublisherName.ReadOnly = true;
        //
        // colAvailableCopies
        //
        colAvailableCopies.DataPropertyName = "AvailableCopies";
        colAvailableCopies.HeaderText = "Còn lại";
        colAvailableCopies.Name = "colAvailableCopies";
        colAvailableCopies.ReadOnly = true;
        //
        // colTotalCopies
        //
        colTotalCopies.DataPropertyName = "TotalCopies";
        colTotalCopies.HeaderText = "Tổng số";
        colTotalCopies.Name = "colTotalCopies";
        colTotalCopies.ReadOnly = true;
        //
        // BookForm
        //
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(984, 561);
        Controls.Add(txtSearch);
        Controls.Add(btnSearch);
        Controls.Add(dgvBooks);
        Controls.Add(grpDetails);
        Controls.Add(btnNew);
        Controls.Add(btnSave);
        Controls.Add(btnDelete);
        Name = "BookForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Sách";
        Load += BookForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudPublishedYear).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudTotalCopies).EndInit();
        grpDetails.ResumeLayout(false);
        grpDetails.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.DataGridView dgvBooks;
    private System.Windows.Forms.GroupBox grpDetails;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.TextBox txtTitle;
    private System.Windows.Forms.Label lblIsbn;
    private System.Windows.Forms.TextBox txtIsbn;
    private System.Windows.Forms.Label lblCategory;
    private System.Windows.Forms.ComboBox cboCategory;
    private System.Windows.Forms.Label lblPublisher;
    private System.Windows.Forms.ComboBox cboPublisher;
    private System.Windows.Forms.Label lblPublishedYear;
    private System.Windows.Forms.NumericUpDown nudPublishedYear;
    private System.Windows.Forms.Label lblTotalCopies;
    private System.Windows.Forms.NumericUpDown nudTotalCopies;
    private System.Windows.Forms.Label lblAuthors;
    private System.Windows.Forms.CheckedListBox clbAuthors;
    private System.Windows.Forms.Button btnNew;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
    private System.Windows.Forms.DataGridViewTextBoxColumn colAuthorNames;
    private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colPublisherName;
    private System.Windows.Forms.DataGridViewTextBoxColumn colAvailableCopies;
    private System.Windows.Forms.DataGridViewTextBoxColumn colTotalCopies;
}
