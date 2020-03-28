using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace WeExtract
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CompressButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Primero, selecciona la carpeta que deseas comprimir.\nLuego, la ubicación deseada.");
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            FolderBrowserDialog file = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("Hola");
            }

            if (file.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("Hola");
            }

            if (zipName.Text == "")
            {
                ZipFile.CreateFromDirectory(fbd.SelectedPath, file.SelectedPath + "/" + "archivoComprimido" + ".zip");
                MessageBox.Show("¡Su carpeta fue comprimida con éxito!", "Operación completada");
            }
            else
            {
                ZipFile.CreateFromDirectory(fbd.SelectedPath, file.SelectedPath + "/" + zipName.Text + ".zip");
                MessageBox.Show("¡Su carpeta fue comprimida con éxito!", "Operación completada");
            }

        }

        private void DecompressButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Primero, selecciona el archivo que deseas descomprimir.\nLuego, la ubicación deseada.");
            OpenFileDialog file = new OpenFileDialog();
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            using (file)
            {
                file.Filter = "Archivos zip (*.zip)|*.zip|All files (*.*)|*.*";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine("Hola");
                }
            }
            

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("Hola");
            }

            if (folderName.Text == "")
            {
                ZipFile.ExtractToDirectory(file.FileName, fbd.SelectedPath + "/" + "carpetaDescomprimida");
                MessageBox.Show("¡Su archivo fue descomprimido con éxito!", "Operación completada");
            }
            else
            {
                ZipFile.ExtractToDirectory(file.FileName, fbd.SelectedPath + "/" + folderName.Text);
                MessageBox.Show("¡Su archivo fue descomprimido con éxito!", "Operación completada");
            }
        }
    }
}
