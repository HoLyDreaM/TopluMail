namespace TopluMail
{
  partial class frmAyar
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
      this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
      this.sll = new System.Windows.Forms.CheckBox();
      this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
      this.btnSina = new DevExpress.XtraEditors.SimpleButton();
      this.txtSifre = new System.Windows.Forms.TextBox();
      this.txtKullanici = new System.Windows.Forms.TextBox();
      this.txtPort = new System.Windows.Forms.TextBox();
      this.txtSunucu = new System.Windows.Forms.TextBox();
      this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
      this.groupControl1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupControl1
      // 
      this.groupControl1.Controls.Add(this.sll);
      this.groupControl1.Controls.Add(this.btnKaydet);
      this.groupControl1.Controls.Add(this.btnSina);
      this.groupControl1.Controls.Add(this.txtSifre);
      this.groupControl1.Controls.Add(this.txtKullanici);
      this.groupControl1.Controls.Add(this.txtPort);
      this.groupControl1.Controls.Add(this.txtSunucu);
      this.groupControl1.Controls.Add(this.labelControl5);
      this.groupControl1.Controls.Add(this.labelControl3);
      this.groupControl1.Controls.Add(this.labelControl2);
      this.groupControl1.Controls.Add(this.labelControl1);
      this.groupControl1.Location = new System.Drawing.Point(3, 4);
      this.groupControl1.Name = "groupControl1";
      this.groupControl1.Size = new System.Drawing.Size(352, 360);
      this.groupControl1.TabIndex = 0;
      // 
      // sll
      // 
      this.sll.AutoSize = true;
      this.sll.Location = new System.Drawing.Point(171, 149);
      this.sll.Name = "sll";
      this.sll.Size = new System.Drawing.Size(43, 17);
      this.sll.TabIndex = 11;
      this.sll.Text = "SSL";
      this.sll.UseVisualStyleBackColor = true;
      // 
      // btnKaydet
      // 
      this.btnKaydet.Location = new System.Drawing.Point(5, 333);
      this.btnKaydet.Name = "btnKaydet";
      this.btnKaydet.Size = new System.Drawing.Size(342, 23);
      this.btnKaydet.TabIndex = 10;
      this.btnKaydet.Text = "Kaydet";
      this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
      // 
      // btnSina
      // 
      this.btnSina.Location = new System.Drawing.Point(170, 170);
      this.btnSina.Name = "btnSina";
      this.btnSina.Size = new System.Drawing.Size(176, 23);
      this.btnSina.TabIndex = 9;
      this.btnSina.Text = "Hesap Ayarlarını Sına";
      this.btnSina.Click += new System.EventHandler(this.btnSina_Click);
      // 
      // txtSifre
      // 
      this.txtSifre.Location = new System.Drawing.Point(171, 122);
      this.txtSifre.Name = "txtSifre";
      this.txtSifre.PasswordChar = '?';
      this.txtSifre.Size = new System.Drawing.Size(176, 21);
      this.txtSifre.TabIndex = 8;
      // 
      // txtKullanici
      // 
      this.txtKullanici.Location = new System.Drawing.Point(171, 92);
      this.txtKullanici.Name = "txtKullanici";
      this.txtKullanici.Size = new System.Drawing.Size(176, 21);
      this.txtKullanici.TabIndex = 7;
      // 
      // txtPort
      // 
      this.txtPort.Location = new System.Drawing.Point(171, 64);
      this.txtPort.Name = "txtPort";
      this.txtPort.Size = new System.Drawing.Size(49, 21);
      this.txtPort.TabIndex = 6;
      // 
      // txtSunucu
      // 
      this.txtSunucu.Location = new System.Drawing.Point(171, 36);
      this.txtSunucu.Name = "txtSunucu";
      this.txtSunucu.Size = new System.Drawing.Size(176, 21);
      this.txtSunucu.TabIndex = 5;
      // 
      // labelControl5
      // 
      this.labelControl5.Appearance.Font = new System.Drawing.Font("Garamond", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.labelControl5.Location = new System.Drawing.Point(46, 67);
      this.labelControl5.Name = "labelControl5";
      this.labelControl5.Size = new System.Drawing.Size(115, 13);
      this.labelControl5.TabIndex = 4;
      this.labelControl5.Text = "Giden Sunucu Portu :";
      // 
      // labelControl3
      // 
      this.labelControl3.Appearance.Font = new System.Drawing.Font("Garamond", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.labelControl3.Location = new System.Drawing.Point(128, 126);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new System.Drawing.Size(31, 13);
      this.labelControl3.TabIndex = 2;
      this.labelControl3.Text = "Şifre :";
      // 
      // labelControl2
      // 
      this.labelControl2.Appearance.Font = new System.Drawing.Font("Garamond", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.labelControl2.Location = new System.Drawing.Point(83, 96);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(78, 13);
      this.labelControl2.TabIndex = 1;
      this.labelControl2.Text = "Kullanıcı Adı :";
      // 
      // labelControl1
      // 
      this.labelControl1.Appearance.Font = new System.Drawing.Font("Garamond", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
      this.labelControl1.Location = new System.Drawing.Point(5, 38);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(156, 13);
      this.labelControl1.TabIndex = 0;
      this.labelControl1.Text = "Giden Posta Sunucu(SMTP) :";
      // 
      // frmAyar
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(358, 369);
      this.Controls.Add(this.groupControl1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "frmAyar";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "SMTP Ayarları";
      this.Load += new System.EventHandler(this.frmAyar_Load);
      ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
      this.groupControl1.ResumeLayout(false);
      this.groupControl1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.GroupControl groupControl1;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.LabelControl labelControl3;
    private DevExpress.XtraEditors.LabelControl labelControl5;
    private System.Windows.Forms.TextBox txtSunucu;
    private System.Windows.Forms.TextBox txtPort;
    private System.Windows.Forms.TextBox txtKullanici;
    private System.Windows.Forms.TextBox txtSifre;
    private DevExpress.XtraEditors.SimpleButton btnSina;
    private DevExpress.XtraEditors.SimpleButton btnKaydet;
    private System.Windows.Forms.CheckBox sll;
  }
}