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
        public void ReadFromFile(int data)
        {
            Files.Clear();
            switch (data)
            {
                case 1:
                    Files.Add("Perisabile.txt");
                    break;
                case 2:
                    Files.Add("Neperisabile.txt");
                    break;
                case 3:
                    Files.Add("Utilizatori.txt");
                    break;
                case 4:
                    Files.Add("Administratori.txt");
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
                                Guid.Parse(attributes[0]),
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
                                Guid.Parse(attributes[0]),
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
                            Guest guest = new Guest(Guid.Parse(attributes[0]),
                                attributes[1],
                                attributes[2],
                                attributes[3],
                                attributes[4],
                                attributes[5]
                                );
                            Utilizatori.Add(guest);
                            guest = null;
                            break;
                        case 4:
                            attributes = line.Split('|');
                            Admin admin = new Admin(Guid.Parse(attributes[0]),
                                attributes[1],
                                attributes[2],
                                attributes[3],
                                attributes[4],
                                attributes[5]
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
        }

        private void Form_Load(object sender, EventArgs e)
        {
            pInCategorie.Items.Add("Electronice");
            pInCategorie.Items.Add("Electrocasnice");
            pInCategorie.Items.Add("Ingrijire Personala");
            pInCategorie.Items.Add("Carti, Birotica");
            pInCategorie.Items.Add("Jucarii, Copii");
            pInCategorie.Items.Add("Supermarket");
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
                        if (produs.Id == Guid.Parse(lvProduse.Items[lvProduse.SelectedIndices[0]].SubItems[3].Text))
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
                        if (produs.Id == Guid.Parse(lvProduse.Items[lvProduse.SelectedIndices[0]].SubItems[3].Text))
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
                Guid productId = Guid.Parse(lvProduse.Items[lvProduse.SelectedIndices[0]].SubItems[3].Text);
                int quantity = Convert.ToInt32(pInCantitate.Value);

                Tuple<Guid, int> newItem = Tuple.Create(productId, quantity);

                comanda.Produse.Add(newItem);
                pInCantitate.Value = 0;
            }
        }

        private void comandaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductPage.Visible = false;
            CommandPage.Visible = true;
            if (currentUser != null)
            {
                LoginPage.Visible = false;
            }
            lvComanda.Items.Clear();
            double total = 0;
            if (comanda != null)
            {
                foreach (var produs in comanda.Produse)
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
                cOutTotal.Text = total.ToString();
            }
        }

        private void produseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductPage.Visible = true;
            CommandPage.Visible = false;
            if (currentUser != null)
            {
                LoginPage.Visible = false;
            }
        }

        private void cFinalizare_Click(object sender, EventArgs e)
        {
            comanda.TrimiteComanda();
            comanda = null;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string username = lUsername.Text;
            string password = lPassword.Text;

            foreach (var item in Utilizatori)
            {
                if (item.Username == username && item.Password == password)
                {
                    currentUser = new Guest(item.Id, item.Nume, item.Prenume, item.Username, item.Password, item.Email);
                }
            }
        }

        private void Register_Click(object sender, EventArgs e)
        {
            Guest newUser = new Guest(Guid.NewGuid(), rNume.Text, rPrenume.Text, rUsername.Text, rPassword.Text, rEmail.Text);
            newUser.WriteToFile();
        }
    }
}
