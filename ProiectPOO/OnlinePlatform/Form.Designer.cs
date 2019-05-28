namespace OnlinePlatform
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cFinalizare = new System.Windows.Forms.Button();
            this.cOutTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lvComanda = new System.Windows.Forms.ListView();
            this.ComandaDenumire = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cantitate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Categorie = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ComandaPret = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pInAddCommand = new System.Windows.Forms.Button();
            this.pInCantitate = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pOutPret = new System.Windows.Forms.TextBox();
            this.pOutGarantie = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pOutDataExp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pOutCategorie = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pOutDescriere = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pOutDenumire = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pInCategorie = new System.Windows.Forms.ComboBox();
            this.lvProduse = new System.Windows.Forms.ListView();
            this.Denumire = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Descriere = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pret = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.produseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comandaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProductPage = new System.Windows.Forms.GroupBox();
            this.CommandPage = new System.Windows.Forms.GroupBox();
            this.LoginPage = new System.Windows.Forms.GroupBox();
            this.loginPanel = new System.Windows.Forms.Panel();
            this.Username = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.Login = new System.Windows.Forms.Button();
            this.lUsername = new System.Windows.Forms.TextBox();
            this.lPassword = new System.Windows.Forms.TextBox();
            this.registerPanel = new System.Windows.Forms.Panel();
            this.rUsername = new System.Windows.Forms.TextBox();
            this.Register = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.rEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.rPassword = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.rPrenume = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.rNume = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pInCantitate)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.ProductPage.SuspendLayout();
            this.CommandPage.SuspendLayout();
            this.LoginPage.SuspendLayout();
            this.loginPanel.SuspendLayout();
            this.registerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cFinalizare
            // 
            this.cFinalizare.Location = new System.Drawing.Point(438, 75);
            this.cFinalizare.Name = "cFinalizare";
            this.cFinalizare.Size = new System.Drawing.Size(204, 45);
            this.cFinalizare.TabIndex = 3;
            this.cFinalizare.Text = "Finalizare Comanda";
            this.cFinalizare.UseVisualStyleBackColor = true;
            this.cFinalizare.Click += new System.EventHandler(this.cFinalizare_Click);
            // 
            // cOutTotal
            // 
            this.cOutTotal.Enabled = false;
            this.cOutTotal.Location = new System.Drawing.Point(523, 28);
            this.cOutTotal.Name = "cOutTotal";
            this.cOutTotal.Size = new System.Drawing.Size(119, 20);
            this.cOutTotal.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(435, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Total Comanda:";
            // 
            // lvComanda
            // 
            this.lvComanda.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ComandaDenumire,
            this.Cantitate,
            this.Categorie,
            this.ComandaPret});
            this.lvComanda.Location = new System.Drawing.Point(6, 19);
            this.lvComanda.Name = "lvComanda";
            this.lvComanda.Size = new System.Drawing.Size(404, 462);
            this.lvComanda.TabIndex = 0;
            this.lvComanda.UseCompatibleStateImageBehavior = false;
            this.lvComanda.View = System.Windows.Forms.View.Details;
            // 
            // ComandaDenumire
            // 
            this.ComandaDenumire.Text = "Denumire";
            this.ComandaDenumire.Width = 100;
            // 
            // Cantitate
            // 
            this.Cantitate.Text = "Cantitate";
            this.Cantitate.Width = 100;
            // 
            // Categorie
            // 
            this.Categorie.Text = "Categorie";
            this.Categorie.Width = 100;
            // 
            // ComandaPret
            // 
            this.ComandaPret.Text = "Pret/Unitate";
            this.ComandaPret.Width = 100;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(593, 241);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(246, 240);
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(592, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(247, 103);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(592, 132);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(247, 103);
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pInAddCommand);
            this.panel2.Controls.Add(this.pInCantitate);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(295, 241);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 88);
            this.panel2.TabIndex = 19;
            // 
            // pInAddCommand
            // 
            this.pInAddCommand.Location = new System.Drawing.Point(13, 39);
            this.pInAddCommand.Name = "pInAddCommand";
            this.pInAddCommand.Size = new System.Drawing.Size(186, 38);
            this.pInAddCommand.TabIndex = 18;
            this.pInAddCommand.Text = "Adauga la Comanda";
            this.pInAddCommand.UseVisualStyleBackColor = true;
            this.pInAddCommand.Click += new System.EventHandler(this.pInAddCommand_Click);
            // 
            // pInCantitate
            // 
            this.pInCantitate.Location = new System.Drawing.Point(88, 13);
            this.pInCantitate.Name = "pInCantitate";
            this.pInCantitate.Size = new System.Drawing.Size(111, 20);
            this.pInCantitate.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Cantitate";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pOutPret);
            this.panel1.Controls.Add(this.pOutGarantie);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pOutDataExp);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pOutCategorie);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pOutDescriere);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.pOutDenumire);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(295, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 207);
            this.panel1.TabIndex = 15;
            // 
            // pOutPret
            // 
            this.pOutPret.Enabled = false;
            this.pOutPret.Location = new System.Drawing.Point(88, 110);
            this.pOutPret.Name = "pOutPret";
            this.pOutPret.Size = new System.Drawing.Size(187, 20);
            this.pOutPret.TabIndex = 12;
            // 
            // pOutGarantie
            // 
            this.pOutGarantie.Enabled = false;
            this.pOutGarantie.Location = new System.Drawing.Point(88, 176);
            this.pOutGarantie.Name = "pOutGarantie";
            this.pOutGarantie.Size = new System.Drawing.Size(187, 20);
            this.pOutGarantie.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Denumire";
            // 
            // pOutDataExp
            // 
            this.pOutDataExp.Enabled = false;
            this.pOutDataExp.Location = new System.Drawing.Point(88, 143);
            this.pOutDataExp.Name = "pOutDataExp";
            this.pOutDataExp.Size = new System.Drawing.Size(187, 20);
            this.pOutDataExp.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descriere";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Categorie";
            // 
            // pOutCategorie
            // 
            this.pOutCategorie.Enabled = false;
            this.pOutCategorie.Location = new System.Drawing.Point(88, 77);
            this.pOutCategorie.Name = "pOutCategorie";
            this.pOutCategorie.Size = new System.Drawing.Size(187, 20);
            this.pOutCategorie.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Pret";
            // 
            // pOutDescriere
            // 
            this.pOutDescriere.Enabled = false;
            this.pOutDescriere.Location = new System.Drawing.Point(88, 44);
            this.pOutDescriere.Name = "pOutDescriere";
            this.pOutDescriere.Size = new System.Drawing.Size(187, 20);
            this.pOutDescriere.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Data Expirare";
            // 
            // pOutDenumire
            // 
            this.pOutDenumire.Enabled = false;
            this.pOutDenumire.Location = new System.Drawing.Point(88, 11);
            this.pOutDenumire.Name = "pOutDenumire";
            this.pOutDenumire.Size = new System.Drawing.Size(187, 20);
            this.pOutDenumire.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Garantie";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Categorie";
            // 
            // pInCategorie
            // 
            this.pInCategorie.FormattingEnabled = true;
            this.pInCategorie.Location = new System.Drawing.Point(64, 28);
            this.pInCategorie.Name = "pInCategorie";
            this.pInCategorie.Size = new System.Drawing.Size(206, 21);
            this.pInCategorie.TabIndex = 1;
            this.pInCategorie.SelectedIndexChanged += new System.EventHandler(this.pInCategorie_SelectedIndexChanged);
            // 
            // lvProduse
            // 
            this.lvProduse.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Denumire,
            this.Descriere,
            this.Pret});
            this.lvProduse.Location = new System.Drawing.Point(6, 55);
            this.lvProduse.Name = "lvProduse";
            this.lvProduse.Size = new System.Drawing.Size(264, 426);
            this.lvProduse.TabIndex = 0;
            this.lvProduse.UseCompatibleStateImageBehavior = false;
            this.lvProduse.View = System.Windows.Forms.View.Details;
            this.lvProduse.SelectedIndexChanged += new System.EventHandler(this.lvProduse_SelectedIndexChanged);
            // 
            // Denumire
            // 
            this.Denumire.Text = "Denumire";
            this.Denumire.Width = 100;
            // 
            // Descriere
            // 
            this.Descriere.Text = "Descriere";
            this.Descriere.Width = 100;
            // 
            // Pret
            // 
            this.Pret.Text = "Pret";
            // 
            // produseToolStripMenuItem
            // 
            this.produseToolStripMenuItem.Name = "produseToolStripMenuItem";
            this.produseToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.produseToolStripMenuItem.Text = "Produse";
            this.produseToolStripMenuItem.Click += new System.EventHandler(this.produseToolStripMenuItem_Click);
            // 
            // comandaToolStripMenuItem
            // 
            this.comandaToolStripMenuItem.Name = "comandaToolStripMenuItem";
            this.comandaToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.comandaToolStripMenuItem.Text = "Comanda";
            this.comandaToolStripMenuItem.Click += new System.EventHandler(this.comandaToolStripMenuItem_Click);
            // 
            // facturaToolStripMenuItem
            // 
            this.facturaToolStripMenuItem.Name = "facturaToolStripMenuItem";
            this.facturaToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.facturaToolStripMenuItem.Text = "Factura";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.loginToolStripMenuItem.Text = "Logout";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.produseToolStripMenuItem,
            this.comandaToolStripMenuItem,
            this.facturaToolStripMenuItem,
            this.loginToolStripMenuItem,
            this.registerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(870, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.registerToolStripMenuItem.Text = "Register";
            this.registerToolStripMenuItem.Click += new System.EventHandler(this.registerToolStripMenuItem_Click);
            // 
            // ProductPage
            // 
            this.ProductPage.Controls.Add(this.pictureBox2);
            this.ProductPage.Controls.Add(this.pictureBox1);
            this.ProductPage.Controls.Add(this.pictureBox3);
            this.ProductPage.Controls.Add(this.panel2);
            this.ProductPage.Controls.Add(this.panel1);
            this.ProductPage.Controls.Add(this.label1);
            this.ProductPage.Controls.Add(this.pInCategorie);
            this.ProductPage.Controls.Add(this.lvProduse);
            this.ProductPage.Location = new System.Drawing.Point(12, 27);
            this.ProductPage.Name = "ProductPage";
            this.ProductPage.Size = new System.Drawing.Size(846, 487);
            this.ProductPage.TabIndex = 1;
            this.ProductPage.TabStop = false;
            this.ProductPage.Text = "Produse";
            // 
            // CommandPage
            // 
            this.CommandPage.Controls.Add(this.cFinalizare);
            this.CommandPage.Controls.Add(this.cOutTotal);
            this.CommandPage.Controls.Add(this.label9);
            this.CommandPage.Controls.Add(this.lvComanda);
            this.CommandPage.Location = new System.Drawing.Point(6, 27);
            this.CommandPage.Name = "CommandPage";
            this.CommandPage.Size = new System.Drawing.Size(852, 487);
            this.CommandPage.TabIndex = 2;
            this.CommandPage.TabStop = false;
            this.CommandPage.Text = "Comanda";
            // 
            // LoginPage
            // 
            this.LoginPage.Controls.Add(this.loginPanel);
            this.LoginPage.Controls.Add(this.registerPanel);
            this.LoginPage.Location = new System.Drawing.Point(6, 27);
            this.LoginPage.Name = "LoginPage";
            this.LoginPage.Size = new System.Drawing.Size(852, 487);
            this.LoginPage.TabIndex = 4;
            this.LoginPage.TabStop = false;
            this.LoginPage.Text = "Login";
            // 
            // loginPanel
            // 
            this.loginPanel.Controls.Add(this.Username);
            this.loginPanel.Controls.Add(this.Password);
            this.loginPanel.Controls.Add(this.Login);
            this.loginPanel.Controls.Add(this.lUsername);
            this.loginPanel.Controls.Add(this.lPassword);
            this.loginPanel.Location = new System.Drawing.Point(279, 25);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(293, 146);
            this.loginPanel.TabIndex = 18;
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Location = new System.Drawing.Point(36, 30);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(55, 13);
            this.Username.TabIndex = 0;
            this.Username.Text = "Username";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(38, 63);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(53, 13);
            this.Password.TabIndex = 1;
            this.Password.Text = "Password";
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(95, 92);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(161, 23);
            this.Login.TabIndex = 4;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // lUsername
            // 
            this.lUsername.Location = new System.Drawing.Point(95, 27);
            this.lUsername.Name = "lUsername";
            this.lUsername.Size = new System.Drawing.Size(161, 20);
            this.lUsername.TabIndex = 2;
            // 
            // lPassword
            // 
            this.lPassword.Location = new System.Drawing.Point(95, 59);
            this.lPassword.Name = "lPassword";
            this.lPassword.Size = new System.Drawing.Size(161, 20);
            this.lPassword.TabIndex = 3;
            this.lPassword.UseSystemPasswordChar = true;
            // 
            // registerPanel
            // 
            this.registerPanel.Controls.Add(this.rUsername);
            this.registerPanel.Controls.Add(this.Register);
            this.registerPanel.Controls.Add(this.label10);
            this.registerPanel.Controls.Add(this.rEmail);
            this.registerPanel.Controls.Add(this.label11);
            this.registerPanel.Controls.Add(this.rPassword);
            this.registerPanel.Controls.Add(this.label12);
            this.registerPanel.Controls.Add(this.label13);
            this.registerPanel.Controls.Add(this.rPrenume);
            this.registerPanel.Controls.Add(this.label14);
            this.registerPanel.Controls.Add(this.rNume);
            this.registerPanel.Location = new System.Drawing.Point(279, 190);
            this.registerPanel.Name = "registerPanel";
            this.registerPanel.Size = new System.Drawing.Size(294, 267);
            this.registerPanel.TabIndex = 17;
            // 
            // rUsername
            // 
            this.rUsername.Location = new System.Drawing.Point(95, 96);
            this.rUsername.Name = "rUsername";
            this.rUsername.Size = new System.Drawing.Size(161, 20);
            this.rUsername.TabIndex = 13;
            // 
            // Register
            // 
            this.Register.Location = new System.Drawing.Point(95, 195);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(161, 28);
            this.Register.TabIndex = 16;
            this.Register.Text = "Register";
            this.Register.UseVisualStyleBackColor = true;
            this.Register.Click += new System.EventHandler(this.Register_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 5;
            this.label10.Text = "Nume";
            // 
            // rEmail
            // 
            this.rEmail.Location = new System.Drawing.Point(95, 158);
            this.rEmail.Name = "rEmail";
            this.rEmail.Size = new System.Drawing.Size(161, 20);
            this.rEmail.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(38, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Prenume";
            // 
            // rPassword
            // 
            this.rPassword.Location = new System.Drawing.Point(95, 127);
            this.rPassword.Name = "rPassword";
            this.rPassword.Size = new System.Drawing.Size(161, 20);
            this.rPassword.TabIndex = 14;
            this.rPassword.UseSystemPasswordChar = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(38, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Username";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(38, 130);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Password";
            // 
            // rPrenume
            // 
            this.rPrenume.Location = new System.Drawing.Point(95, 65);
            this.rPrenume.Name = "rPrenume";
            this.rPrenume.Size = new System.Drawing.Size(161, 20);
            this.rPrenume.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(38, 161);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Email";
            // 
            // rNume
            // 
            this.rNume.Location = new System.Drawing.Point(95, 34);
            this.rNume.Name = "rNume";
            this.rNume.Size = new System.Drawing.Size(161, 20);
            this.rNume.TabIndex = 11;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 526);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.ProductPage);
            this.Controls.Add(this.LoginPage);
            this.Controls.Add(this.CommandPage);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pInCantitate)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ProductPage.ResumeLayout(false);
            this.ProductPage.PerformLayout();
            this.CommandPage.ResumeLayout(false);
            this.CommandPage.PerformLayout();
            this.LoginPage.ResumeLayout(false);
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.registerPanel.ResumeLayout(false);
            this.registerPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvProduse;
        private System.Windows.Forms.ColumnHeader Denumire;
        private System.Windows.Forms.ColumnHeader Descriere;
        private System.Windows.Forms.ColumnHeader Pret;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox pInCategorie;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox pOutPret;
        private System.Windows.Forms.TextBox pOutGarantie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pOutDataExp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pOutCategorie;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox pOutDescriere;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox pOutDenumire;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button pInAddCommand;
        private System.Windows.Forms.NumericUpDown pInCantitate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button cFinalizare;
        private System.Windows.Forms.TextBox cOutTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListView lvComanda;
        private System.Windows.Forms.ColumnHeader ComandaDenumire;
        private System.Windows.Forms.ColumnHeader Cantitate;
        private System.Windows.Forms.ColumnHeader Categorie;
        private System.Windows.Forms.ColumnHeader ComandaPret;
        private System.Windows.Forms.ToolStripMenuItem produseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comandaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox ProductPage;
        private System.Windows.Forms.GroupBox CommandPage;
        private System.Windows.Forms.GroupBox LoginPage;
        private System.Windows.Forms.TextBox rEmail;
        private System.Windows.Forms.TextBox rPassword;
        private System.Windows.Forms.TextBox rUsername;
        private System.Windows.Forms.TextBox rPrenume;
        private System.Windows.Forms.TextBox rNume;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.TextBox lPassword;
        private System.Windows.Forms.TextBox lUsername;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Button Register;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Panel registerPanel;
    }
}

