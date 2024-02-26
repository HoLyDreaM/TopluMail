namespace TopluMail
{
    using DevExpress.XtraEditors;
    using iniOku;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using System.Windows.Forms;

    public class frmAyar : XtraForm
    {
        private SimpleButton btnKaydet;
        private SimpleButton btnSina;
        private IContainer components = null;
        private GroupControl groupControl1;
        private iniOku.iniOku iniOku = new iniOku.iniOku(Application.StartupPath + @"\Ayarlar.ini");
        private LabelControl labelControl1;
        private LabelControl labelControl2;
        private LabelControl labelControl3;
        private LabelControl labelControl5;
        private CheckBox sll;
        private TextBox txtKullanici;
        private TextBox txtPort;
        private TextBox txtSifre;
        private TextBox txtSunucu;

        public frmAyar()
        {
            this.InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            this.iniOku.IniWriteValue("Ayarlar", "Sunucu", this.txtSunucu.Text);
            this.iniOku.IniWriteValue("Ayarlar", "Port", this.txtPort.Text);
            this.iniOku.IniWriteValue("Ayarlar", "Kullanici", this.txtKullanici.Text);
            this.iniOku.IniWriteValue("Ayarlar", "Sll", this.sll.Checked.ToString());
            this.iniOku.IniWriteValue("Ayarlar", "Pw", Sifrele(this.txtSifre.Text));
        }

        private void btnSina_Click(object sender, EventArgs e)
        {
            SmtpClient mailGonderici = new SmtpClient(this.txtSunucu.Text) {
                Credentials = new NetworkCredential(this.txtKullanici.Text, this.txtSifre.Text),
                Port = Convert.ToInt32(this.txtPort.Text),
                EnableSsl = this.sll.Checked
            };
            MailMessage Mail = new MailMessage(this.txtKullanici.Text, this.txtKullanici.Text, "Sınama Maili", "Sınama Maili") {
                Subject = "Sınama Maili"
            };
            try
            {
                mailGonderici.Send(Mail);
                MessageBox.Show("Sınama Başarılı");
            }
            catch (SmtpException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public static string Coz(string cozVeri)
        {
            byte[] cozByteDizi = Convert.FromBase64String(cozVeri);
            return Encoding.ASCII.GetString(cozByteDizi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmAyar_Load(object sender, EventArgs e)
        {
            this.txtSunucu.Text = this.iniOku.IniReadValue("Ayarlar", "Sunucu");
            this.txtPort.Text = this.iniOku.IniReadValue("Ayarlar", "Port");
            this.txtKullanici.Text = this.iniOku.IniReadValue("Ayarlar", "Kullanici");
            this.txtSifre.Text = Coz(this.iniOku.IniReadValue("Ayarlar", "Pw"));
            this.sll.Checked = Convert.ToBoolean(this.iniOku.IniReadValue("Ayarlar", "sll"));
        }

        private void InitializeComponent()
        {
            this.groupControl1 = new GroupControl();
            this.sll = new CheckBox();
            this.btnKaydet = new SimpleButton();
            this.btnSina = new SimpleButton();
            this.txtSifre = new TextBox();
            this.txtKullanici = new TextBox();
            this.txtPort = new TextBox();
            this.txtSunucu = new TextBox();
            this.labelControl5 = new LabelControl();
            this.labelControl3 = new LabelControl();
            this.labelControl2 = new LabelControl();
            this.labelControl1 = new LabelControl();
            this.groupControl1.BeginInit();
            this.groupControl1.SuspendLayout();
            base.SuspendLayout();
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
            this.groupControl1.Location = new Point(3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new Size(0x160, 360);
            this.groupControl1.TabIndex = 0;
            this.sll.AutoSize = true;
            this.sll.Location = new Point(0xab, 0x95);
            this.sll.Name = "sll";
            this.sll.Size = new Size(0x2b, 0x11);
            this.sll.TabIndex = 11;
            this.sll.Text = "SSL";
            this.sll.UseVisualStyleBackColor = true;
            this.btnKaydet.Location = new Point(5, 0x14d);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new Size(0x156, 0x17);
            this.btnKaydet.TabIndex = 10;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new EventHandler(this.btnKaydet_Click);
            this.btnSina.Location = new Point(170, 170);
            this.btnSina.Name = "btnSina";
            this.btnSina.Size = new Size(0xb0, 0x17);
            this.btnSina.TabIndex = 9;
            this.btnSina.Text = "Hesap Ayarlarını Sına";
            this.btnSina.Click += new EventHandler(this.btnSina_Click);
            this.txtSifre.Location = new Point(0xab, 0x7a);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '?';
            this.txtSifre.Size = new Size(0xb0, 0x15);
            this.txtSifre.TabIndex = 8;
            this.txtKullanici.Location = new Point(0xab, 0x5c);
            this.txtKullanici.Name = "txtKullanici";
            this.txtKullanici.Size = new Size(0xb0, 0x15);
            this.txtKullanici.TabIndex = 7;
            this.txtPort.Location = new Point(0xab, 0x40);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new Size(0x31, 0x15);
            this.txtPort.TabIndex = 6;
            this.txtSunucu.Location = new Point(0xab, 0x24);
            this.txtSunucu.Name = "txtSunucu";
            this.txtSunucu.Size = new Size(0xb0, 0x15);
            this.txtSunucu.TabIndex = 5;
            this.labelControl5.Appearance.Font = new Font("Garamond", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl5.Location = new Point(0x2e, 0x43);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new Size(0x73, 13);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Giden Sunucu Portu :";
            this.labelControl3.Appearance.Font = new Font("Garamond", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl3.Location = new Point(0x80, 0x7e);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new Size(0x1f, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Şifre :";
            this.labelControl2.Appearance.Font = new Font("Garamond", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl2.Location = new Point(0x53, 0x60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new Size(0x4e, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Kullanıcı Adı :";
            this.labelControl1.Appearance.Font = new Font("Garamond", 9f, FontStyle.Bold, GraphicsUnit.Point, 0xa2);
            this.labelControl1.Location = new Point(5, 0x26);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new Size(0x9c, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Giden Posta Sunucu(SMTP) :";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x166, 0x171);
            base.Controls.Add(this.groupControl1);
            base.FormBorderStyle = FormBorderStyle.FixedDialog;
            base.Name = "frmAyar";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "SMTP Ayarları";
            base.Load += new EventHandler(this.frmAyar_Load);
            this.groupControl1.EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            base.ResumeLayout(false);
        }

        public static string Sifrele(string veri)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(veri));
        }
    }
}

