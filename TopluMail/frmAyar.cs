using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Net;
using System.Net.Mail;
namespace TopluMail
{
  public partial class frmAyar : DevExpress.XtraEditors.XtraForm
  {
    public frmAyar()
    {
      InitializeComponent();
    }
    iniOku.iniOku iniOku = new iniOku.iniOku(Application.StartupPath +"\\Ayarlar.ini");

    public static string Coz(string cozVeri)
    {
      byte[] cozByteDizi = System.Convert.FromBase64String(cozVeri);
      string orjinalVeri = System.Text.ASCIIEncoding.ASCII.GetString(cozByteDizi);
      return orjinalVeri;
    }

    public static string Sifrele(string veri)
    {
      byte[] veriByteDizisi = System.Text.ASCIIEncoding.ASCII.GetBytes(veri);
      string sifrelenmisVeri = System.Convert.ToBase64String(veriByteDizisi);
      return sifrelenmisVeri;
    }
    private void frmAyar_Load(object sender, EventArgs e)
    {
      txtSunucu.Text = iniOku.IniReadValue("Ayarlar","Sunucu");
      txtPort.Text = iniOku.IniReadValue("Ayarlar","Port");
      txtKullanici.Text = iniOku.IniReadValue("Ayarlar","Kullanici");
      txtSifre.Text=Coz(iniOku.IniReadValue("Ayarlar","Pw"));
      sll.Checked = Convert.ToBoolean(iniOku.IniReadValue("Ayarlar", "sll"));
    }

    private void btnKaydet_Click(object sender, EventArgs e)
    {
      iniOku.IniWriteValue("Ayarlar","Sunucu",txtSunucu.Text);
      iniOku.IniWriteValue("Ayarlar","Port",txtPort.Text);
      iniOku.IniWriteValue("Ayarlar","Kullanici", txtKullanici.Text);
      iniOku.IniWriteValue("Ayarlar","Sll",sll.Checked.ToString());
      iniOku.IniWriteValue("Ayarlar","Pw", Sifrele(txtSifre.Text));
    }

    private void btnSina_Click(object sender, EventArgs e)
    {
      SmtpClient mailGonderici = new SmtpClient(txtSunucu.Text);
      mailGonderici.Credentials = new NetworkCredential(txtKullanici.Text,txtSifre.Text);
      mailGonderici.Port = Convert.ToInt32(txtPort.Text);
      mailGonderici.EnableSsl = sll.Checked;

      MailMessage Mail = new MailMessage(txtKullanici.Text, txtKullanici.Text, "Sınama Maili", "Sınama Maili");
      Mail.Subject = "Sınama Maili";

   
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
  }
}