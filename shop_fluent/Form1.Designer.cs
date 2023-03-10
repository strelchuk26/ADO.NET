namespace shop_fluent
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.shopsListBox = new System.Windows.Forms.ListBox();
			this.showProductsButton = new System.Windows.Forms.Button();
			this.shopItemsListBox = new System.Windows.Forms.ListBox();
			this.showWorkersButton = new System.Windows.Forms.Button();
			this.refreshShopListButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// shopsListBox
			// 
			this.shopsListBox.FormattingEnabled = true;
			this.shopsListBox.ItemHeight = 15;
			this.shopsListBox.Location = new System.Drawing.Point(-1, 102);
			this.shopsListBox.Name = "shopsListBox";
			this.shopsListBox.Size = new System.Drawing.Size(242, 484);
			this.shopsListBox.TabIndex = 0;
			this.shopsListBox.SelectedIndexChanged += new System.EventHandler(this.shopsListBox_SelectedIndexChanged);
			// 
			// showProductsButton
			// 
			this.showProductsButton.Location = new System.Drawing.Point(266, 28);
			this.showProductsButton.Name = "showProductsButton";
			this.showProductsButton.Size = new System.Drawing.Size(127, 51);
			this.showProductsButton.TabIndex = 1;
			this.showProductsButton.Text = "PRODUCTS";
			this.showProductsButton.UseVisualStyleBackColor = true;
			this.showProductsButton.Click += new System.EventHandler(this.showProductsButton_Click);
			// 
			// shopItemsListBox
			// 
			this.shopItemsListBox.FormattingEnabled = true;
			this.shopItemsListBox.ItemHeight = 15;
			this.shopItemsListBox.Location = new System.Drawing.Point(266, 102);
			this.shopItemsListBox.Name = "shopItemsListBox";
			this.shopItemsListBox.Size = new System.Drawing.Size(667, 484);
			this.shopItemsListBox.TabIndex = 2;
			// 
			// showWorkersButton
			// 
			this.showWorkersButton.Location = new System.Drawing.Point(428, 28);
			this.showWorkersButton.Name = "showWorkersButton";
			this.showWorkersButton.Size = new System.Drawing.Size(127, 51);
			this.showWorkersButton.TabIndex = 3;
			this.showWorkersButton.Text = "WORKERS";
			this.showWorkersButton.UseVisualStyleBackColor = true;
			this.showWorkersButton.Click += new System.EventHandler(this.showWorkersButton_Click);
			// 
			// refreshShopListButton
			// 
			this.refreshShopListButton.Location = new System.Drawing.Point(56, 28);
			this.refreshShopListButton.Name = "refreshShopListButton";
			this.refreshShopListButton.Size = new System.Drawing.Size(127, 51);
			this.refreshShopListButton.TabIndex = 4;
			this.refreshShopListButton.Text = "REFRESH";
			this.refreshShopListButton.UseVisualStyleBackColor = true;
			this.refreshShopListButton.Click += new System.EventHandler(this.refreshShopListButton_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(931, 583);
			this.Controls.Add(this.refreshShopListButton);
			this.Controls.Add(this.showWorkersButton);
			this.Controls.Add(this.shopItemsListBox);
			this.Controls.Add(this.showProductsButton);
			this.Controls.Add(this.shopsListBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private ListBox shopsListBox;
		private Button showProductsButton;
		private ListBox shopItemsListBox;
		private Button showWorkersButton;
		private Button refreshShopListButton;
	}
}