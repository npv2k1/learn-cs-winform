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
        menuStrip.SuspendLayout();
        SuspendLayout();
        //
        // menuStrip
        //
        menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuCatalog, mnuMembers, mnuLoans });
        menuStrip.Location = new System.Drawing.Point(0, 0);
        menuStrip.Name = "menuStrip";
        menuStrip.Size = new System.Drawing.Size(784, 24);
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
        // MainForm
        //
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(784, 461);
        Controls.Add(menuStrip);
        MainMenuStrip = menuStrip;
        Name = "MainForm";
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Quản lý thư viện";
        menuStrip.ResumeLayout(false);
        menuStrip.PerformLayout();
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
}
