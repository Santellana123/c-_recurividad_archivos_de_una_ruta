namespace c__recurividad_archivos_de_una_ruta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usb = textBox.Text;

            if (Directory.Exists(usb))
            {
                listBox.Items.Clear();
                listBox.Items.Add("Contenido del almacenamiento:");

                try
                {
                    ContenidoRuta(usb);
                }
                catch (UnauthorizedAccessException)
                {
                    listBox.Items.Add("No tienes acceso a uno o más elementos en la memoria USB.");
                }
            }
            else
            {
                listBox.Items.Add("La ruta no es válida.");
            }
        }
        private void ContenidoRuta(string direccion)
        {
            listBox.Items.Add($"Contenido de {direccion}:");
            try
            {
                string[] directories = Directory.GetDirectories(direccion);
                foreach (string directory in directories)
                {
                    listBox.Items.Add($"[Directorio] {Path.GetFileName(directory)}");
                    ContenidoRuta(directory);
                }

                string[] archivos = Directory.GetFiles(direccion);
                foreach (string file in archivos)
                {
                    listBox.Items.Add($"[Archivo] {Path.GetFileName(file)}");
                }
            }
            catch (UnauthorizedAccessException)
            {
                listBox.Items.Add($"No tienes acceso a {direccion}.");
            }
        }
    }
}