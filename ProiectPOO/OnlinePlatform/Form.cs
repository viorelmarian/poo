using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
                                DateTime.Parse(attributes[5])
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
                                DateTime.Parse(attributes[5]),
                                Convert.ToInt16(attributes[6])
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
        }

        private void Form_Load(object sender, EventArgs e)
        {

        }
    }
}
