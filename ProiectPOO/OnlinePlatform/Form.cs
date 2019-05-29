using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using ZXing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Drawing;
using iTextSharp.text.pdf.draw;

namespace OnlinePlatform
{
    public partial class Form : System.Windows.Forms.Form
    {
        public List<Perisabil> ProdusePerisabile = new List<Perisabil>();
        public List<Neperisabil> ProduseNeperisabile = new List<Neperisabil>();
        public List<Guest> Utilizatori = new List<Guest>();
        public List<Admin> Administratori = new List<Admin>();
        public List<string> Files = new List<string>();
        public Comanda comanda;
        public Guest currentUser;
        public Admin currentAdmin;
        public void ReadFromFile(int data)
        {
            Files.Clear();
            switch (data)
            {
                case 1:
                    Files.Add("Perisabile.txt");
                    ProdusePerisabile.Clear();
                    break;
                case 2:
                    Files.Add("Neperisabile.txt");
                    ProduseNeperisabile.Clear();
                    break;
                case 3:
                    Files.Add("Utilizatori.txt");
                    Utilizatori.Clear();
                    break;
                case 4:
                    Files.Add("Administratori.txt");
                    Administratori.Clear();
                    break;
                default: //Citim toate datele din toate fisierele
                    ReadFromFile(1); //Auto-apelare - Citire Perisabile
                    ReadFromFile(2); //Auto-apelare - Citire Neperisabile
                    ReadFromFile(3); //Auto-apelare - Citire Utilizatori
                    ReadFromFile(4); //Auto-apelare - Citire Administratori
                    break;
            }

            foreach (var file in Files)
            {
                string[] lines = System.IO.File.ReadAllLines(file);
                string[] attributes;
                foreach (string line in lines)
                {
                    switch (data)
                    {
                        case 1:
                            attributes = line.Split('|');
                            Perisabil produsPerisabil = new Perisabil(
                                Convert.ToInt16(attributes[0]),
                                attributes[1],
                                attributes[2],
                                attributes[3],
                                Convert.ToDouble(attributes[4]),
                                Convert.ToBoolean(attributes[5]),
                                DateTime.Parse(attributes[6])
                                );
                            ProdusePerisabile.Add(produsPerisabil);
                            produsPerisabil = null;
                            break;
                        case 2:
                            attributes = line.Split('|');
                            Neperisabil produsNeperisabil = new Neperisabil(
                                Convert.ToInt16(attributes[0]),
                                attributes[1],
                                attributes[2],
                                attributes[3],
                                Convert.ToDouble(attributes[4]),
                                Convert.ToBoolean(attributes[5]),
                                DateTime.Parse(attributes[6]),
                                Convert.ToInt16(attributes[7])
                                );
                            ProduseNeperisabile.Add(produsNeperisabil);
                            produsNeperisabil = null;
                            break;
                        case 3:
                            attributes = line.Split('|');
                            Guest guest = new Guest(Convert.ToInt16(attributes[0]),
                                attributes[1],
                                attributes[2],
                                attributes[3],
                                attributes[4],
                                attributes[5],
                                Convert.ToBoolean(attributes[6])
                                );
                            Utilizatori.Add(guest);
                            guest = null;
                            break;
                        case 4:
                            attributes = line.Split('|');
                            Admin admin = new Admin(Convert.ToInt16(attributes[0]),
                                attributes[1],
                                attributes[2],
                                attributes[3],
                                attributes[4],
                                attributes[5],
                                Convert.ToBoolean(attributes[6])
                                );
                            Administratori.Add(admin);
                            guest = null;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public Form()
        {
            InitializeComponent();
            ReadFromFile(0);// Citire Tot din Fisiere
            CommandPage.Hide();
            ProductPage.Hide();
            registerPanel.Hide();
            AdminPage.Hide();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            pInCategorie.Items.Add("Electronice");
            pInCategorie.Items.Add("Electrocasnice");
            pInCategorie.Items.Add("Ingrijire Personala");
            pInCategorie.Items.Add("Carti, Birotica");
            pInCategorie.Items.Add("Jucarii, Copii");
            pInCategorie.Items.Add("Supermarket");

            aCategorie.Items.Add("Electronice");
            aCategorie.Items.Add("Electrocasnice");
            aCategorie.Items.Add("Ingrijire Personala");
            aCategorie.Items.Add("Carti, Birotica");
            aCategorie.Items.Add("Jucarii, Copii");
            aCategorie.Items.Add("Supermarket");
        }

        private void pInCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvProduse.Items.Clear();
            foreach (var produs in ProdusePerisabile)
            {
                if (pInCategorie.Text == produs.Categorie)
                {
                    var Item = new ListViewItem(new[] {
                        produs.Denumire,
                        produs.Descriere,
                        produs.Pret.ToString(),
                        produs.Id.ToString(),
                        produs.Perisabil.ToString()
                    });
                    lvProduse.Items.Add(Item);
                }
            }
            foreach (var produs in ProduseNeperisabile)
            {
                if (pInCategorie.Text == produs.Categorie)
                {
                    var Item = new ListViewItem(new[] {
                        produs.Denumire,
                        produs.Descriere,
                        produs.Pret.ToString(),
                        produs.Id.ToString(),
                        produs.Perisabil.ToString()
                    });
                    lvProduse.Items.Add(Item);
                }
            }
        }

        private void lvProduse_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ean_8 = new BarcodeWriter();
            ean_8.Format = BarcodeFormat.EAN_8;

            var ean_13 = new BarcodeWriter();
            ean_13.Format = BarcodeFormat.EAN_13;

            var qr = new BarcodeWriter();
            qr.Format = BarcodeFormat.QR_CODE;

            pOutDenumire.Clear();
            pOutDescriere.Clear();
            pOutPret.Clear();
            pOutCategorie.Clear();
            pOutDataExp.Clear();
            pOutGarantie.Clear();

            if (lvProduse.SelectedIndices.Count != 0)
            {
                bool perisabil = Convert.ToBoolean(lvProduse.Items[lvProduse.SelectedIndices[0]].SubItems[4].Text);
                if (perisabil)
                {
                    foreach (var produs in ProdusePerisabile)
                    {
                        if (produs.Id == Convert.ToInt16(lvProduse.Items[lvProduse.SelectedIndices[0]].SubItems[3].Text))
                        {
                            string ean8 = "";
                            string ean13 = "";
                            for (int i = 12; i > produs.Id.ToString().Length; i--)
                            {
                                if (i <= 7)
                                {
                                    ean8 += "0";
                                }
                                ean13 += "0";
                            }

                            ean8 += produs.Id.ToString();
                            ean13 += produs.Id.ToString();

                            pictureBox1.Image = ean_8.Write(ean8);
                            pictureBox3.Image = ean_13.Write(ean13);
                            pictureBox2.Image = qr.Write(produs.Id.ToString());

                            pOutDenumire.Text = produs.Denumire;
                            pOutDescriere.Text = produs.Descriere;
                            pOutPret.Text = produs.Pret.ToString();
                            pOutCategorie.Text = produs.Categorie;
                            pOutDataExp.Text = produs.DataExpirare.ToString();
                        }
                    }
                }
                else
                {
                    foreach (var produs in ProduseNeperisabile)
                    {
                        if (produs.Id == Convert.ToInt16(lvProduse.Items[lvProduse.SelectedIndices[0]].SubItems[3].Text))
                        {
                            string ean8 = "";
                            string ean13 = "";
                            for (int i = 12; i > produs.Id.ToString().Length; i--)
                            {
                                if (i <= 7)
                                {
                                    ean8 += "0";
                                }
                                ean13 += "0";
                            }

                            ean8 += produs.Id.ToString();
                            ean13 += produs.Id.ToString();

                            pictureBox1.Image = ean_8.Write(ean8);
                            pictureBox3.Image = ean_13.Write(ean13);
                            pictureBox2.Image = qr.Write(produs.Id.ToString());

                            pOutDenumire.Text = produs.Denumire;
                            pOutDescriere.Text = produs.Descriere;
                            pOutPret.Text = produs.Pret.ToString();
                            pOutCategorie.Text = produs.Categorie;
                            pOutGarantie.Text = produs.Garantie.ToString();
                        }
                    }
                }
            }
        }

        private void pInAddCommand_Click(object sender, EventArgs e)
        {
            if (comanda == null)
            {
                comanda = new Comanda(currentUser.Id);
            }

            if (pInCantitate.Value != 0)
            {
                int productId = Convert.ToInt16(lvProduse.Items[lvProduse.SelectedIndices[0]].SubItems[3].Text);
                int quantity = Convert.ToInt32(pInCantitate.Value);
                bool perisabil = Convert.ToBoolean(lvProduse.Items[lvProduse.SelectedIndices[0]].SubItems[4].Text);
                Tuple<int, int, bool> newItem = Tuple.Create(productId, quantity, perisabil);

                comanda.Produse.Add(newItem);
                pInCantitate.Value = 0;
                MessageBox.Show("Produsele au fost adaugate in cos!", "Information");
            }
        }

        private void comandaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                CommandPage.Show();
                ProductPage.Hide();
                LoginPage.Hide();
            }
            else
            {
                LoginPage.Show();
                ProductPage.Hide();
                CommandPage.Hide();
            }
            lvComanda.Items.Clear();
            double total = 0;
            if (comanda != null)
            {
                foreach (var produs in comanda.Produse)
                {
                    if (produs.Item3 == true)
                    {
                        foreach (var item in ProdusePerisabile)
                        {
                            if (produs.Item1 == item.Id)
                            {
                                var Item = new ListViewItem(new[] {
                                    item.Denumire,
                                    produs.Item2.ToString(),
                                    item.Categorie,
                                    item.Pret.ToString(),
                                });
                                lvComanda.Items.Add(Item);
                                total += item.Pret * produs.Item2;
                            }
                        }
                    }
                    else
                    {
                        foreach (var item in ProduseNeperisabile)
                        {
                            if (produs.Item1 == item.Id)
                            {
                                var Item = new ListViewItem(new[] {
                                    item.Denumire,
                                    produs.Item2.ToString(),
                                    item.Categorie,
                                    item.Pret.ToString(),
                                });
                                lvComanda.Items.Add(Item);
                                total += item.Pret * produs.Item2;
                            }
                        }
                    }


                }
                cOutTotal.Text = total.ToString();
            }
        }

        private void produseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                ProductPage.Show();
                CommandPage.Hide();
                LoginPage.Hide();
            }
            else
            {
                LoginPage.Show();
                ProductPage.Hide();
                CommandPage.Hide();
            }
        }

        private void cFinalizare_Click(object sender, EventArgs e)
        {
            comanda.TrimiteComanda();
            GenerateBill();
            comanda = null;
            MessageBox.Show("Comanda a fost plasata cu succes!", "Information");
        }

        private void Login_Click(object sender, EventArgs e)
        {
            ReadFromFile(3);
            ReadFromFile(4);
            string username = lUsername.Text;
            string password = lPassword.Text;

            foreach (var item in Utilizatori)
            {
                if (item.Username == username && item.Password == password)
                {
                    currentUser = new Guest(item.Id, item.Nume, item.Prenume, item.Username, item.Password, item.Email, false);
                    LoginPage.Hide();
                    CommandPage.Hide();
                    ProductPage.Show();
                    AdminPage.Hide();
                }
            }

            foreach (var item in Administratori)
            {
                if (item.Username == username && item.Password == password)
                {
                    currentAdmin = new Admin(item.Id, item.Nume, item.Prenume, item.Username, item.Password, item.Email, true);
                    LoginPage.Hide();
                    CommandPage.Hide();
                    ProductPage.Hide();
                    AdminPage.Show();
                }
            }
        }

        private void Register_Click(object sender, EventArgs e)
        {
            if (rbGuest.Checked)
            {
                ReadFromFile(3);
                int newUserId = Utilizatori.Count + 1;
                Guest newUser = new Guest(newUserId, rNume.Text, rPrenume.Text, rUsername.Text, rPassword.Text, rEmail.Text, false);
                newUser.WriteToFile();
            }
            else
            {
                ReadFromFile(4);
                int newUserId = Administratori.Count + 1;
                Admin newUser = new Admin(newUserId, rNume.Text, rPrenume.Text, rUsername.Text, rPassword.Text, rEmail.Text, true);
                newUser.WriteToFile();
            }

            registerPanel.Hide();
            MessageBox.Show("Inregistrare cu succes!", "Information");
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registerPanel.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentUser = null;
            currentAdmin = null;
            ProductPage.Hide();
            CommandPage.Hide();
            AdminPage.Hide();
            LoginPage.Show();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (rbPerisabil.Checked)
            {
                ReadFromFile(1);
                int newProductId = ProdusePerisabile.Count + 1;
                Perisabil produs = new Perisabil(
                                        newProductId,
                                        aDenumire.Text,
                                        aDescriere.Text,
                                        aCategorie.Text,
                                        Convert.ToDouble(aPret.Value),
                                        true,
                                        aDataExp.Value
                                    );
                produs.WriteToFile();
            }
            else
            {
                ReadFromFile(2);
                int newProductId = ProduseNeperisabile.Count + 1;
                Neperisabil produs = new Neperisabil(
                                        newProductId,
                                        aDenumire.Text,
                                        aDescriere.Text,
                                        aCategorie.Text,
                                        Convert.ToDouble(aPret.Value),
                                        false,
                                        DateTime.Now,
                                        Convert.ToInt16(aGarantie.Value)
                                    );
                produs.WriteToFile();
            }
            aDenumire.Clear();
            aDescriere.Clear();
            aPret.Value = 0;
            aDataExp.Value = DateTime.Now;
            aGarantie.Value = 0;
            MessageBox.Show("Produsul a fost adaugat", "Information");
            ReadFromFile(1);
            ReadFromFile(2);
        }

        private void GenerateBill()
        {
            FileStream fs = new FileStream("Factura.pdf", FileMode.Create, FileAccess.Write, FileShare.None);

            Document doc = new Document(PageSize.A4);

            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            doc.Open();
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("logo.png");
            logo.ScaleAbsolute(80f, 80f);
            doc.Add(logo);
            doc.Add(new Paragraph("\n"));
            Chunk glue1 = new Chunk(new VerticalPositionMark());
            iTextSharp.text.Font myFont = FontFactory.GetFont("Times New Roman", 14, iTextSharp.text.Font.BOLD, new iTextSharp.text.BaseColor(0, 0, 0));
            Paragraph p1 = new Paragraph("Furnizor", myFont);
            p1.Add(new Chunk(glue1));
            p1.Add("Client                                                         ");
            doc.Add(p1);
            Chunk glue2 = new Chunk(new VerticalPositionMark());
            Paragraph p2 = new Paragraph("Nume Furnizor: VS", myFont);
            p2.Add(new Chunk(glue2));
            if (currentUser != null) {
                p2.Add("Nume Client: " + currentUser.Nume+' '+currentUser.Prenume);
                if ((currentUser.Nume + currentUser.Prenume).Length < 31)
                    for (int i = 0; i < 31- (currentUser.Nume + currentUser.Prenume).Length; i++)
                        p2.Add(" ");
            }
            else
                p2.Add("Nume Client:                                    ");
            doc.Add(p2);

            PdfPTable table = new PdfPTable(2);
            table.TotalWidth = 250f;
            table.LockedWidth = true;
            float[] widths = new float[] { 75f, 175f};
            table.SetWidths(widths);

            //PdfPCell cell = new PdfPCell(new Phrase("This is table 1"));
            //cell.Colspan = 3;
            //cell.HorizontalAlignment = 1;
            //table.AddCell(cell);
            table.AddCell("Nr. Reg. Com.");
            if (comanda != null)
            {
                table.AddCell(comanda.Id.ToString());
            }
            else
            {
                table.AddCell("--");
            }
            table.AddCell("CIF");
            table.AddCell("RO2540803400012C");
            table.AddCell("Adresa");
            table.AddCell("Bulevardul Carol I, nr. 50");
            table.AddCell("Email");
            table.AddCell("vs@vs.com");
            table.AddCell("Telefon");
            table.AddCell("0236.811.001");
            table.AddCell("Banca");
            table.AddCell("Transilvania");
            table.AddCell("Cont");
            table.AddCell("	RO09BCYP0000001234567890");
            table.WriteSelectedRows(0, -1, doc.Left,doc.Top-150, writer.DirectContent);


            table = new PdfPTable(2);
            table.TotalWidth = 250f;
            table.LockedWidth = true;
            float[] widths1 = new float[] { 75f, 175f };
            table.SetWidths(widths1);
            //cell = new PdfPCell(new Phrase("This is table 2"));
            //cell.Colspan = 3;
            //cell.HorizontalAlignment = 1;
            //table.AddCell(cell);
            table.AddCell("Nr. Reg. Com.");
            if (comanda != null)
            {
                table.AddCell(comanda.Id.ToString());
            }
            else
            {
                table.AddCell("--");
            }
            table.AddCell("CIF");
            table.AddCell("RO2540803400012C");
            table.AddCell("Adresa");
            table.AddCell("Bulevardul Carol I, nr. 50");
            table.AddCell("Banca");
            table.AddCell("Transilvania");
            table.AddCell("Cont");
            table.AddCell("	RO09BCYP0000001234567890");
            table.WriteSelectedRows(0, -1, doc.Left + 260, doc.Top-165, writer.DirectContent);

            PdfPTable table2 = new PdfPTable(2);
            table2.TotalWidth = 510f;
            table2.LockedWidth = true;
            float[] widths2 = new float[] { 420f, 90f };
            table2.SetWidths(widths2);
            PdfPCell cell1t2 = new PdfPCell();
            if (comanda!=null)
            {

                cell1t2 = new PdfPCell(new Phrase("Factura seria: F nr.: " + comanda.Id.ToString() + " data: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year));
            }
            else
            {
                cell1t2 = new PdfPCell(new Phrase("Factura seria: F nr.: " + "--" + " data: " + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year));
            }
            cell1t2.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell1t2.BorderColor = BaseColor.GRAY;
            cell1t2.BorderWidth = 1f;
            table2.AddCell(cell1t2);
            PdfPCell cell2t2= new PdfPCell(new Phrase("Cota TVA: 19%"));
            cell2t2.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell2t2.BorderColor = BaseColor.GRAY;
            cell2t2.BorderWidth = 1f;
            table2.AddCell(cell2t2);
            table2.WriteSelectedRows(0, -1, doc.Left, doc.Top - 290, writer.DirectContent);

            PdfPTable table3 = new PdfPTable(6);
            table3.TotalWidth = 510f;
            table3.LockedWidth = true;
            float[] widths3 = new float[] { 255f, 51f,51f,51f,51f,51f };
            table3.SetWidths(widths3);
            PdfPCell cell1t3 = new PdfPCell(new Phrase("Denumire produse"));
            cell1t3.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell1t3.BorderColor = BaseColor.GRAY;
            cell1t3.BorderWidth = 1f;
            table3.AddCell(cell1t3);
            PdfPCell cell2t3 = new PdfPCell(new Phrase("U.M."));
            cell2t3.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell2t3.BorderColor = BaseColor.GRAY;
            cell2t3.BorderWidth = 1f;
            table3.AddCell(cell2t3);
            PdfPCell cell3t3 = new PdfPCell(new Phrase("Cant."));
            cell3t3.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell3t3.BorderColor = BaseColor.GRAY;
            cell3t3.BorderWidth = 1f;
            table3.AddCell(cell3t3);
            PdfPCell cell4t3 = new PdfPCell(new Phrase("Pret unitar"));
            cell4t3.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell4t3.BorderColor = BaseColor.GRAY;
            cell4t3.BorderWidth = 1f;
            table3.AddCell(cell4t3);
            PdfPCell cell5t3 = new PdfPCell(new Phrase("T.V.A."));
            cell5t3.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell5t3.BorderColor = BaseColor.GRAY;
            cell5t3.BorderWidth = 1f;
            table3.AddCell(cell5t3);
            PdfPCell cell6t3 = new PdfPCell(new Phrase("Total"));
            cell6t3.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell6t3.BorderColor = BaseColor.GRAY;
            cell6t3.BorderWidth = 1f;
            table3.AddCell(cell6t3);

            double total = 0;
            if (comanda != null)
            {
                foreach (var produs in comanda.Produse)
                {
                    if (produs.Item3 == true)
                    {
                        foreach (var perisabil in ProdusePerisabile)
                        {
                            if (perisabil.Id == produs.Item1)
                            {
                                table3.AddCell(perisabil.Denumire);
                                table3.AddCell("buc.");
                                table3.AddCell(produs.Item2.ToString());
                                table3.AddCell((perisabil.Pret - 0.19 * perisabil.Pret).ToString());
                                table3.AddCell(((0.19 * perisabil.Pret) * produs.Item2).ToString());
                                table3.AddCell(perisabil.Pret.ToString());
                                total += perisabil.Pret * produs.Item2;
                            }
                        }
                    }
                    else
                    {
                        foreach (var neperisabil in ProduseNeperisabile)
                        {
                            if (neperisabil.Id == produs.Item1)
                            {
                                table3.AddCell(neperisabil.Denumire);
                                table3.AddCell("buc.");
                                table3.AddCell(produs.Item2.ToString());
                                table3.AddCell((neperisabil.Pret - 0.19 * neperisabil.Pret).ToString());
                                table3.AddCell(((0.19 * neperisabil.Pret) * produs.Item2).ToString());
                                table3.AddCell(neperisabil.Pret.ToString());
                                total += neperisabil.Pret * produs.Item2;
                            }
                        }
                    }
                }
            }
            table3.WriteSelectedRows(0, -1, doc.Left, doc.Top - 330, writer.DirectContent);

            PdfPTable table4 = new PdfPTable(2);
            table4.TotalWidth = 210;
            table4.LockedWidth = true;
            float[] widths4 = new float[] { 70f, 30f };
            table4.SetWidths(widths4);
            PdfPCell cell1t4 = new PdfPCell(new Phrase("Pret fara T.V.A."));
            cell1t4.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell1t4.BorderColor = BaseColor.GRAY;
            cell1t4.BorderWidth = 1f;
            table4.AddCell(cell1t4);
            PdfPCell cell2t4 = new PdfPCell(new Phrase((total - 0.19 * total).ToString()));
            cell2t4.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell2t4.BorderColor = BaseColor.GRAY;
            cell2t4.BorderWidth = 1f;
            table4.AddCell(cell2t4);
            PdfPCell cell3t4 = new PdfPCell(new Phrase("Valoare T.V.A."));
            cell3t4.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell3t4.BorderColor = BaseColor.GRAY;
            cell3t4.BorderWidth = 1f;
            table4.AddCell(cell3t4);
            
            PdfPCell cell4t4 = new PdfPCell(new Phrase((0.19*total).ToString()));
            cell4t4.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell4t4.BorderColor = BaseColor.GRAY;
            cell4t4.BorderWidth = 1f;
            table4.AddCell(cell4t4);
            PdfPCell cell5t4 = new PdfPCell(new Phrase("Total de plata"));
            cell5t4.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell5t4.BorderColor = BaseColor.GRAY;
            cell5t4.BorderWidth = 1f;
            table4.AddCell(cell5t4);
            PdfPCell cell6t4 = new PdfPCell(new Phrase(total.ToString()));
            cell6t4.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell6t4.BorderColor = BaseColor.GRAY;
            cell6t4.BorderWidth = 1f;
            table4.AddCell(cell6t4);
            table4.WriteSelectedRows(0, -1, doc.Left+290, doc.Top-700, writer.DirectContent);
            doc.Close();
        }
    }
}
