namespace QuanLyThuVien.Views;

partial class LoanCreateForm
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
        lblMember = new System.Windows.Forms.Label();
        cboMember = new System.Windows.Forms.ComboBox();
        lblDueDate = new System.Windows.Forms.Label();
        dtpDueDate = new System.Windows.Forms.DateTimePicker();
        lblBooks = new System.Windows.Forms.Label();
        clbBooks = new System.Windows.Forms.CheckedListBox();
        btnSave = new System.Windows.Forms.Button();
        btnCancel = new System.Windows.Forms.Button();
        SuspendLayout();
        //
        // lblMember
        //
        lblMember.AutoSize = true;
        lblMember.Location = new System.Drawing.Point(12, 15);
        lblMember.Name = "lblMember";
        lblMember.Size = new System.Drawing.Size(80, 15);
        lblMember.TabIndex = 0;
        lblMember.Text = "Độc giả";
        //
        // cboMember
        //
        cboMember.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        cboMember.Location = new System.Drawing.Point(90, 12);
        cboMember.Name = "cboMember";
        cboMember.Size = new System.Drawing.Size(402, 23);
        cboMember.TabIndex = 1;
        cboMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cboMember.FormattingEnabled = true;
        //
        // lblDueDate
        //
        lblDueDate.AutoSize = true;
        lblDueDate.Location = new System.Drawing.Point(12, 44);
        lblDueDate.Name = "lblDueDate";
        lblDueDate.Size = new System.Drawing.Size(80, 15);
        lblDueDate.TabIndex = 2;
        lblDueDate.Text = "Hạn trả";
        //
        // dtpDueDate
        //
        dtpDueDate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        dtpDueDate.Location = new System.Drawing.Point(90, 41);
        dtpDueDate.Name = "dtpDueDate";
        dtpDueDate.Size = new System.Drawing.Size(402, 23);
        dtpDueDate.TabIndex = 3;
        dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        //
        // lblBooks
        //
        lblBooks.AutoSize = true;
        lblBooks.Location = new System.Drawing.Point(12, 73);
        lblBooks.Name = "lblBooks";
        lblBooks.Size = new System.Drawing.Size(80, 15);
        lblBooks.TabIndex = 4;
        lblBooks.Text = "Sách";
        //
        // clbBooks
        //
        clbBooks.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        clbBooks.Location = new System.Drawing.Point(90, 70);
        clbBooks.Name = "clbBooks";
        clbBooks.Size = new System.Drawing.Size(402, 324);
        clbBooks.TabIndex = 5;
        clbBooks.CheckOnClick = true;
        clbBooks.FormattingEnabled = true;
        //
        // btnSave
        //
        btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        btnSave.Location = new System.Drawing.Point(306, 404);
        btnSave.Name = "btnSave";
        btnSave.Size = new System.Drawing.Size(90, 25);
        btnSave.TabIndex = 6;
        btnSave.Text = "Lưu";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        //
        // btnCancel
        //
        btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
        btnCancel.Location = new System.Drawing.Point(402, 404);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new System.Drawing.Size(90, 25);
        btnCancel.TabIndex = 7;
        btnCancel.Text = "Hủy";
        btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        btnCancel.UseVisualStyleBackColor = true;
        //
        // LoanCreateForm
        //
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(504, 441);
        CancelButton = btnCancel;
        Controls.Add(lblMember);
        Controls.Add(cboMember);
        Controls.Add(lblDueDate);
        Controls.Add(dtpDueDate);
        Controls.Add(lblBooks);
        Controls.Add(clbBooks);
        Controls.Add(btnSave);
        Controls.Add(btnCancel);
        Name = "LoanCreateForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        Text = "Tạo phiếu mượn";
        Load += LoanCreateForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private System.Windows.Forms.Label lblMember;
    private System.Windows.Forms.ComboBox cboMember;
    private System.Windows.Forms.Label lblDueDate;
    private System.Windows.Forms.DateTimePicker dtpDueDate;
    private System.Windows.Forms.Label lblBooks;
    private System.Windows.Forms.CheckedListBox clbBooks;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCancel;
}
