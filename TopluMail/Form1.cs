using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Helpers;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
namespace WindowsApplication1
{
  
  public partial class Form1 : XtraForm
  {
    public Form1()
    {
      InitializeComponent();
    }
    Thread kanal;

    TopluMail.frmAyar frmAyar;
    iniOku.iniOku iniOku = new iniOku.iniOku(Application.StartupPath+"\\Ayarlar.ini");
    private void mailListesiniYukle() {
      ds.Mailler.Rows.Clear();
      string tamDosyaAdi="";
      mailListesi.Filter = "Text Dosyalarý(*.txt) |*.txt";
      mailListesi.Title = "Mail Listesini Seçiniz!";

      if (mailListesi.ShowDialog() == DialogResult.OK)
      {
        tamDosyaAdi = mailListesi.FileName;
      }

      if (File.Exists(tamDosyaAdi))
      {
        StreamReader Sr = new StreamReader(tamDosyaAdi);
        while (Sr.EndOfStream==false)
        {
            ds.Mailler.Rows.Add(Sr.ReadLine(), 0);        
        }
      }
      else {
        MessageBox.Show("Mail Listesi Bulunamadý!");
      }
   
    }
    private void ekDosyaEkle() {
      string tamDosyaYolu = "";
      string dosyaAdi = "";
      FileInfo fi;

      ekDosya.Filter = "Tüm Dosyalarý(*.*) |*.*";
      ekDosya.Title = "Ek Dosya";

      if (ekDosya.ShowDialog() == DialogResult.OK)
      {
        tamDosyaYolu = ekDosya.FileName;

        if (File.Exists(ekDosya.FileName))
        {
          txtDosyaYolu.Text = tamDosyaYolu;
          fi = new FileInfo(tamDosyaYolu);
          txtBoyut.Text = fi.Length.ToString();
        }
        else
        {

          MessageBox.Show("Dosya Bulunamadý!");
        }
      }

      
    }
    private void Form1_Load(object sender, EventArgs e)
    {
      txtGonderen.Text = iniOku.IniReadValue("Ayarlar", "Kullanici");
    }
    
    public static bool mailTest(string email)
    {
     const string mailDeseni =
      @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
    + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
			[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
    + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
			[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
    + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

      if (email != null) return Regex.IsMatch(email, mailDeseni);
        else return false;
    }

    private void mailGonder() {
      if(ds.Mailler.Rows.Count < 1){
        MessageBox.Show("Mail Listesi Boþ Durumda!");
      }else if(string.IsNullOrEmpty(txtKonu.Text)){
        MessageBox.Show("Konuyu Boþ Býrakamassýnýz!");
      }else{
        string sunucu = iniOku.IniReadValue("Ayarlar", "Sunucu");
        int port = Convert.ToInt32( iniOku.IniReadValue("Ayarlar", "Port"));
        string kullanici = iniOku.IniReadValue("Ayarlar", "Kullanici");
        string sifre = Coz(iniOku.IniReadValue("Ayarlar", "Pw"));
        Boolean sll = Convert.ToBoolean(iniOku.IniReadValue("Ayarlar", "sll"));

        SmtpClient mailGonderici = new SmtpClient(sunucu);
        mailGonderici.Credentials = new NetworkCredential(kullanici,sifre);
        mailGonderici.Port = port;
        mailGonderici.EnableSsl =sll;

        MailMessage Mail = new MailMessage();
        Mail.Subject = txtKonu.Text;
        Mail.Body = richEditControl1.HtmlText.ToString();
        Mail.SubjectEncoding = System.Text.Encoding.UTF8;
        Mail.BodyEncoding = System.Text.Encoding.UTF8;
        Mail.IsBodyHtml = true;
        Mail.From = new MailAddress(kullanici);
        //mailGonderici.SendCompleted += new SendCompletedEventHandler(de);
        if(ds.Ektekiler.Rows.Count>0){
          foreach(DataRow dr in ds.Ektekiler.Rows){
            Mail.Attachments.Add(new Attachment(dr[1].ToString())); 
          }
        }
         
          int mailSayisi = ds.Mailler.Rows.Count-1;
          for(int x=0;x<=mailSayisi;x++){
           try
            {
               if (mailTest(ds.Mailler.Rows[x][0].ToString()))
              {
                Mail.To.Add(ds.Mailler.Rows[x][0].ToString()) ;
                ds.Mailler.Rows[x][1] = 1;
                mailGonderici.Send(Mail);
                Mail.To.Clear();
              }
              else
              {
                ds.Mailler.Rows[x][1] = 2;
              }
            }
            catch (SmtpException e )
            {
              ds.Mailler.Rows[x][1] = 2;
              MessageBox.Show(e.Message.ToString());
            }

         }
          Console.Beep(3767,500);
          MessageBox.Show("Mailler Gönderildi!");
      }
    }

    public static string Coz(string cozVeri)
    {
      byte[] cozByteDizi = System.Convert.FromBase64String(cozVeri);
      string orjinalVeri = System.Text.ASCIIEncoding.ASCII.GetString(cozByteDizi);
      return orjinalVeri;
    }
    private void buttonEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
    {
      if(!string.IsNullOrEmpty(buttonEdit1.Text)){
        ds.Mailler.Rows.Add(buttonEdit1.Text, 0);
        buttonEdit1.Text = "";
      } 
    }

    private void button1_Click(object sender, EventArgs e)
    {
      mailListesiniYukle();
    }

    private void btnDosyaSec_Click(object sender, EventArgs e)
    {
      ekDosyaEkle();
    }

    private void btnDosyaEkle_Click(object sender, EventArgs e)
    {
      string dosyaAdi = "";
      if(string.IsNullOrEmpty(txtDosyaYolu.Text)){
        MessageBox.Show("Dosya Bulunamadý");
      }else{
        dosyaAdi = Path.GetFileName(txtDosyaYolu.Text);
        ds.Ektekiler.Rows.Add(dosyaAdi,txtDosyaYolu.Text,txtBoyut.Text);
      }
      txtDosyaYolu.Clear();
      txtBoyut.Clear();
    }

    private void gridView2_RowCountChanged(object sender, EventArgs e)
    {
      this.xtraTabPage2.Text="Ekler {"+ds.Ektekiler.Rows.Count.ToString()+"}";
    }

    private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
      frmAyar = new TopluMail.frmAyar();
      frmAyar.Owner = this;
      frmAyar.ShowDialog();
    }

    private void btnGonder_Click(object sender, EventArgs e)
    {
      kanal = new Thread(new ThreadStart(mailGonder));
      kanal.Start();
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if (gridView1.DataRowCount > 0)
      {
        if (MessageBox.Show("Seçilen Mail Adresini Silmek Ýstiyor musunuz?", "Maili sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
          gridView1.DeleteSelectedRows();
        }
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
      if (gridView1.DataRowCount > 0)
      {
        if (MessageBox.Show("Mail Listesini Temizlemek Ýstiyor musunuz?", "Mail Listesini Temizle!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
          ds.Mailler.Rows.Clear();
        }
      }
    }

    private void btnSecileniSil_Click(object sender, EventArgs e)
    {
      if(gridView2.DataRowCount>0){
        if (MessageBox.Show("Seçilen Dosyayý Adresini Silmek Ýstiyor musunuz?", "Dosya sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
          gridView2.DeleteSelectedRows();
          gridView2_RowCountChanged(sender,e);
        }    
      }
    }

    private void simpleButton1_Click(object sender, EventArgs e)
    {
      if (gridView2.DataRowCount > 0)
      {
        if (MessageBox.Show("Tüm Dosyalarý Silmek Ýstiyor musunuz?", "Tüm Dosyalarý sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
          ds.Ektekiler.Rows.Clear();
          gridView2_RowCountChanged(sender, e);
        }
      }
    }

    private void mailListesiSeçToolStripMenuItem_Click(object sender, EventArgs e)
    {
      mailListesiniYukle();
    }

    private void mailiSilToolStripMenuItem_Click(object sender, EventArgs e)
    {
      button2_Click(sender,e);
    }

    private void listeyiTemizleToolStripMenuItem_Click(object sender, EventArgs e)
    {
      button3_Click(sender, e);
    }

    private void dosyaSeçToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ekDosyaEkle();
    }

    private void dosyaSilToolStripMenuItem_Click(object sender, EventArgs e)
    {
      btnSecileniSil_Click(sender,e);
    }

    private void dosyaListesiniTemizleToolStripMenuItem_Click(object sender, EventArgs e)
    {
      simpleButton1_Click(sender,e);
    }

  }
}