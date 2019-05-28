using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;

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
            FacturaPage.Hide();
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
                FacturaPage.Hide();
            }
            else
            {
                LoginPage.Show();
                ProductPage.Hide();
                CommandPage.Hide();
                FacturaPage.Hide();
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
                FacturaPage.Hide();
            }
            else
            {
                LoginPage.Show();
                ProductPage.Hide();
                CommandPage.Hide();
                FacturaPage.Hide();
            }
        }

        private void cFinalizare_Click(object sender, EventArgs e)
        {
            comanda.TrimiteComanda();
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
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentUser != null)
            {
                ProductPage.Hide();
                CommandPage.Hide();
                LoginPage.Hide();
                FacturaPage.Show();
            }
            else
            {
                LoginPage.Show();
                ProductPage.Hide();
                CommandPage.Hide();
                FacturaPage.Hide();
            }
        }
    }
}
