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
using Microsoft.WindowsAPICodePack.Dialogs;

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
            MessageBox.Show("Primero, selecciona los archivos que deseas comprimir.\nLuego, la ubicación deseada.");

            OpenFileDialog selectedFiles = new OpenFileDialog();
            CommonOpenFileDialog pathFinal = new CommonOpenFileDialog();

            selectedFiles.Multiselect = true;
            pathFinal.IsFolderPicker = true;

            if (selectedFiles.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("Hola");
            }

            if (pathFinal.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Console.WriteLine("Hola");
            }

            Directory.CreateDirectory(pathFinal.FileName + "/hgfcxcfd");

            foreach (String file in selectedFiles.FileNames)
            {
                string fileName = Path.GetFileName(file);
                File.Copy(file, pathFinal.FileName + "/hgfcxcfd/" + fileName);
            }

            if (zipName.Text == "")
            {
                ZipFile.CreateFromDirectory(pathFinal.FileName + "/hgfcxcfd", pathFinal.FileName + "/" + "archivoComprimido" + ".zip");
                Directory.Delete(pathFinal.FileName + "/hgfcxcfd", true);
                MessageBox.Show("¡Su carpeta fue comprimida con éxito!", "Operación completada");
            }
            else
            {
                ZipFile.CreateFromDirectory(pathFinal.FileName + "/hgfcxcfd", pathFinal.FileName + "/" + zipName.Text + ".zip");
                Directory.Delete(pathFinal.FileName + "/hgfcxcfd", true);
                MessageBox.Show("¡Su carpeta fue comprimida con éxito!", "Operación completada");
            }
        }

        private void DecompressButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Primero, selecciona el archivo que deseas descomprimir.\nLuego, la ubicación deseada.");

            OpenFileDialog file = new OpenFileDialog();
            CommonOpenFileDialog fbd = new CommonOpenFileDialog();

            fbd.IsFolderPicker = true;

            using (file)
            {
                file.Filter = "Archivos zip (*.zip)|*.zip|All files (*.*)|*.*";
                if (file.ShowDialog() == DialogResult.OK)
                {
                    Console.WriteLine("Hola");
                }
            }
            

            if (fbd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Console.WriteLine("Hola");
            }

            if (folderName.Text == "")
            {
                ZipFile.ExtractToDirectory(file.FileName, fbd.FileName + "/" + "Carpeta descomprimida");
                MessageBox.Show("¡Su archivo fue descomprimido con éxito!", "Operación completada");
            }
            else
            {
                ZipFile.ExtractToDirectory(file.FileName, fbd.FileName + "/" + folderName.Text);
                MessageBox.Show("¡Su archivo fue descomprimido con éxito!", "Operación completada");
            }
        }
    }
}
