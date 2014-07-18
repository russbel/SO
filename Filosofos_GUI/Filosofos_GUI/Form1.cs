using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Filosofos_BE;
using Filosofos_DAC;
namespace Filosofos_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CEFilosofos oCE = new CEFilosofos();
        CLFilosofos oCL = new CLFilosofos();        

        bool bd = false;
        private void BtnSentar_Click(object sender, EventArgs e)
        {
            BtnSentar.Text = BtnSentar.Text.Equals("Sentar Filósofos") ? "Detener" : "Sentar Filósofos";

            if (bd == false)
            {
                oCE.TiempoC = int.Parse(numericUpDown1.Value.ToString());
                oCE.TiempoP = int.Parse(numericUpDown2.Value.ToString());
                bd = true;
            }
            else
            {
                Inicializar();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Inicializar();

        }

        private void ComprobarEstados()
        {
            string NameButton, NamePicture;

            for (int i = 0; i < 5; i++)
            {
                /*Buscar Boton*/
                NameButton = "Btn" + (i + 1).ToString();
                int ButtonIndex = panel1.Controls.IndexOfKey(NameButton);
                /*Buscar Picture*/
                NamePicture = "Pbx" + (i + 1).ToString();
                int PictureIndex = panel1.Controls.IndexOfKey(NamePicture);

                /*El filosofo i esta pensando*/
                if (oCL.Estados[i] == 0)
                {
                    if (ButtonIndex != -1)
                    {
                        Button Botoncito = (Button)panel1.Controls[ButtonIndex];
                        Botoncito.BackColor = Color.Green;
                    }
                    if (PictureIndex != -1)
                    {
                        PictureBox Picture = (PictureBox)panel1.Controls[PictureIndex];
                        Picture.Image = Filosofos_GUI.Properties.Resources.filosofo0;
                    }
                }

                /*El filosofo i esta comiendo*/
                if (oCL.Estados[i] == 1)
                {
                    if (ButtonIndex != -1)
                    {
                        Button Botoncito = (Button)panel1.Controls[ButtonIndex];
                        Botoncito.BackColor = Color.Blue;
                    }
                    if (PictureIndex != -1)
                    {
                        PictureBox Picture = (PictureBox)panel1.Controls[PictureIndex];
                        Picture.Image = Filosofos_GUI.Properties.Resources.filosofo1;
                    }
                }

                /*El filosofo i esta hambriento*/
                if (oCL.Estados[i] == 2)
                {
                    if (ButtonIndex != -1)
                    {
                        Button Botoncito = (Button)panel1.Controls[ButtonIndex];
                        Botoncito.BackColor = Color.Red;
                    }
                    if (PictureIndex != -1)
                    {
                        PictureBox Picture = (PictureBox)panel1.Controls[PictureIndex];
                        Picture.Image = Filosofos_GUI.Properties.Resources.filosofo2;
                    }
                }
            }
        }
         
        private void timer1_Tick(object sender, EventArgs e)
        { 
            if (bd == true)
            {
               oCL.Sincronizar();
                ComprobarEstados();
                lbl_tiempo.Text = oCE.Tiempo.ToString();
                oCE.Tiempo++;
            }
        }

        private void Inicializar()
        {
            oCE.Tiempo = 0;
            oCE.TiempoC = 0;
            oCE.TiempoP = 0;
            oCE.Comer = 0;
            oCE.Pensar = 0;
            oCE.Cont = 0;
            bd = false;
            lbl_tiempo.Text = oCE.Tiempo.ToString();
            this.Btn1.BackColor = SystemColors.Control;
            this.Btn2.BackColor = SystemColors.Control;
            this.Btn3.BackColor = SystemColors.Control;
            this.Btn4.BackColor = SystemColors.Control;
            this.Btn5.BackColor = SystemColors.Control;
            this.numericUpDown1.Value = 0;
            this.numericUpDown2.Value = 0;
            this.Pbx1.Image = Filosofos_GUI.Properties.Resources.silla;
            this.Pbx2.Image = Filosofos_GUI.Properties.Resources.silla;
            this.Pbx3.Image = Filosofos_GUI.Properties.Resources.silla;
            this.Pbx4.Image = Filosofos_GUI.Properties.Resources.silla;
            this.Pbx5.Image = Filosofos_GUI.Properties.Resources.silla;
        }    

    }
}
